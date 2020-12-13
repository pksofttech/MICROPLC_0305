/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 4/22/2015
 * Time: 2:55 PM
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MICROPLC
{
	public enum TypeTag
	{
		Null,
		Rung,
		PARALLEL,
		SERIES,
		CONTACTS,
		COIL,
		TOF,
		TON,
		TPC,
		FCP,
		MOVE,
		OSR,
		OSF,
		ADD,
		SUB,
		MUL,
		DIV,
		MOD,
		ADC,
		MASTER_RELAY,
		SHIFT_REGISTERS,
		SHIFT_RIGHT,
		SHIFT_LEFT,
		SHIFT_REG_RESET,
		SHIFT_REG_INBIT,
		COMMENT,
		SHIFT_VARIABLE,
		UART_RECV,
		UART_SEND,
		SHORT,
		OPEN
	}
	
	public class ProgramLadder
	{
		public List<Rung> rungs	=	new List<Rung>();
		string msgDebug = "Ladder Program By MICROPLC-LITE [PksofttecH]";
		Elements select_tags	= new Elements();

		public Elements Select_tags {
			get {
				return select_tags;
			}
			set {
				select_tags = value;
			}
		}
		Elements select_element	= new Elements();
		public Rectangle	select_area;
		int tag_size	=	0;

		public string MsgDebug {
			get { return msgDebug; }
			set { msgDebug = value; }
		}
		public Rung Rung_select {
			get;
			set;
		}
		//Pen drawPen = new Pen(Color.Gray, 4);
		//Font drawFont = new Font("Arial", 10);
		int tag_cells = 10;
		int margin_left;
		int margin_right;
		int margin_top = 80;
		int margin_button	= 20;

		public ActivePositions InselectTag(int p_x, int p_y)
		{
			if (Rung_select != null) {
				if (select_tags.Tags.Count > 0) {				
				
					if (p_x > select_area.X & p_x < select_area.X + select_area.Width)
					if (p_y > select_area.Y & p_y < select_area.Y + select_area.Height) {
					
						if (p_x > select_area.X & p_x < select_area.X + select_area.Width * 0.2)
						if (p_y > select_area.Y + select_area.Height * 0.2 & p_y < select_area.Y + select_area.Height * 0.8)
							return ActivePositions.Left;
						if (p_x > select_area.X + select_area.Width * 0.2 & p_x < select_area.X + select_area.Width * 0.8)
						if (p_y > select_area.Y & p_y < select_area.Y + select_area.Height * 0.2)
							return ActivePositions.Top;
						if (p_x > select_area.X + select_area.Width * 0.8 & p_x < select_area.X + select_area.Width)
						if (p_y > select_area.Y + select_area.Height * 0.2 & p_y < select_area.Y + select_area.Height * 0.8)
							return ActivePositions.Right;
						if (p_x > select_area.X + select_area.Width * 0.2 & p_x < select_area.X + select_area.Width * 0.8)
						if (p_y > select_area.Y + select_area.Height * 0.8 & p_y < select_area.Y + select_area.Height)
							return ActivePositions.Buttom;				
					}
				}
				if (p_x > Rung_select.DrawPoint_Org.X & p_x < Rung_select.DrawPoint_Org.X + 70 & Select_tags.Tags.Count == 0)
				if (p_y > Rung_select.DrawPoint_Org.Y & p_y < Rung_select.DrawPoint_Org.Y + 70)
					return ActivePositions.InRung;
			}	
			return ActivePositions.Null;
		}
		public Rung GetRung(RectangleF select_rectangle)
		{
			//MessageBox.Show(select_rectangle.X + " " + select_rectangle.Y , "Debug DrowPoint Rung");
			foreach (Rung rung in rungs) {   		
				if (rung.GetRung(select_rectangle) == Rung_select)
					return rung.GetRung(select_rectangle);
			}
			return null;
		}
		public void ClearSelectTags()
		{
			
			select_tags.Tags.Clear();
			select_area = Rectangle.Empty;
			foreach (Rung rung in rungs) {
				rung.SelectTag(select_area, ref select_tags);
			}			
		}
		public bool On_selected_area(int x, int y)
		{
			if (x > select_area.X & x < select_area.X + select_area.Width)
			if (y > select_area.Y & y < select_area.Y + select_area.Height)
				return true;
			return false;
		}
		public bool SelectTags(Rectangle rectangle_select)
		{		
			foreach (Rung rung in rungs) {
				//rung.SelectTag(new Rectangle(0, 0, 0, 0), ref select_tags);
				rung.clearSelectTag();
			}
			select_tags.Tags.Clear();
			Rung_select = null;
			foreach (Rung rung in rungs) {
				if (rung.GetRung(rectangle_select) != null) {
					rung.SelectTag(rectangle_select, ref select_tags);
					Rung_select	=	rung;
					break;
				}				
			}
			BuildSelectFrame();
			return false;
		}
		//*********************Program Draw Ladder***************************//
		public void BuildSelectFrame()
		{
			int max_x = 0, max_y = 0;
			select_area.X	= 9999;
			select_area.Y	= 9999;
			foreach (Elements tag in select_tags.Tags) {
				max_x = Math.Max(max_x, tag.DrawPoint_size.X);
				max_y = Math.Max(max_y, tag.DrawPoint_size.Y);
				select_area.X	= Math.Min(select_area.X, tag.drawPoint_org.X);
				select_area.Y	= Math.Min(select_area.Y, tag.drawPoint_org.Y);
			}
			select_area.Width	= max_x - select_area.X + 10;
			select_area.Height	= max_y - select_area.Y + 10;
			select_area.X -= 5;
			select_area.Y -= 5;		
		}
		public Point DrawProgram(Graphics g, int width, int height, int tag_size)
		{		
			SolidBrush drawBrush = new SolidBrush(DrawingTags.color_string_draw);
			Pen drawPen = new Pen(DrawingTags.color_draw, 4);	
			Font drawFont = DrawingTags.drawFont_Symbol;
			
			this.tag_size	=	tag_size;
			margin_left =	0;
			margin_right	=	(int)(tag_size * tag_cells);
			
			//drawPen.Color	=	DrawingTags.color_draw;
			var	recdraw =	new Rectangle(margin_left, margin_top, tag_size * tag_cells, height - margin_button - margin_top);
			g.Clear(DrawingTags.color_draw_bg);
			
			int rungID = 0;
			if (Rung_select != null)
				rungID = Rung_select.Id_rung;
			String drawString = " Rung # " + rungID;
    
			// Measure string.
			var stringSize = new SizeF();
			stringSize = g.MeasureString(drawString, drawFont);	
			var drawPointProgram = new Point((int)((margin_right - stringSize.Width) * 0.5), margin_top / 2);
			g.DrawString(drawString, drawFont, drawBrush, drawPointProgram);
    		
			stringSize = g.MeasureString(msgDebug, drawFont);	
			drawPointProgram = new Point((int)((margin_right - stringSize.Width) * 0.5), margin_top / 2);
			
			drawPointProgram.Y	-=	drawFont.Height;
    		
			g.DrawString(msgDebug, drawFont, drawBrush, drawPointProgram);

			//*****************Rungs Draw Ladder*************************************	
			var drawPoint = new Point(margin_left, margin_top);	
			int rung_No	= 0;
			DrawingTags.Master_scanValue = 1;
			for (int i = 0; i < rungs.Count; i++) {
				Rung rung = rungs[i];
				rung.Id_rung	= i + 1;
				drawPoint.X = margin_left;
				
				drawPen.Color = DrawingTags.color_draw;
				if (rung == Rung_select) {
					drawPen.Width = 1;
					drawPen.Color = Color.Red;
					//g.DrawRectangle(drawPen, new Rectangle(Rung_select.DrawPoint_Org.X + 3, Rung_select.DrawPoint_Org.Y, tag_size, tag_size / 3));
					Icon icon = SystemIcons.Information;
					//Image img = icon.ToBitmap();
					g.DrawIcon(icon, Rung_select.DrawPoint_Org.X + icon.Size.Width / 2, Rung_select.DrawPoint_Org.Y + tag_size / 2 + 5);
				}
				g.DrawString(string.Format("Rung\n :{0:00}", ++rung_No), drawFont, drawPen.Brush, drawPoint.X + 5, drawPoint.Y);
				
				drawPoint = rung.DrawRung(drawPoint, tag_size, g, tag_cells, recdraw);
				
				drawPoint.Y += 15;
			}    	
			if (select_tags.Tags.Count > 0)
			if (select_tags.Tags[0].Type != TypeTag.COMMENT) {
				drawPen.Color	=	Color.Blue;
				g.DrawRectangle(drawPen, select_area);	// Draw RecSelect
    		
				g.DrawString("Select Tags = " + select_tags.Tags.Count, drawFont, drawBrush, select_area.X, select_area.Y - 20);
			
			}
			
			drawPen.Color = Color.Orange;
			g.DrawLine(drawPen, margin_left + 2, margin_top, margin_left + 2, drawPoint.Y - margin_button);
			drawPen.Color = Color.Blue;
			g.DrawLine(drawPen, margin_right, margin_top, margin_right, drawPoint.Y - margin_button);
			//drawPen.Color = Color.Gray;
			drawPoint.X = margin_right;
			return drawPoint;
		}
	
		public int CreateListElements()
		{
			Ladder.Element_tags.Clear();
			int i = 0;
			foreach (Rung rung in rungs) {
				i += rung.CreateElements();
			}
			return i;
		}
	
		public int SetSelectElement(Elements element)
		{
			ClearSelectTags();
			int i = 0;
			foreach (Rung rung in rungs) {
				i += rung.SetSelectElement(element);
			}
			return i;
		}
		public int Update_Common_Element(Elements element)
		{
			int i = 0;
			foreach (Rung rung in rungs) {
				i += rung.Update_Common_Element(element);
			}
			return i;
		}
	}
	
	// ##########################################################################################//
	// ##########################################################################################//
	//			public class Rung
	// ##########################################################################################//
		
	public class Rung
	{
		Elements rung_elements	= new Elements();
		public Rung()
		{
			rung_elements.Type	= TypeTag.Rung;
			rung_elements.Parent	= null;
			rung_elements.Name	= "Rung";
		}
		public Elements Rung_elements {
			get {
				return rung_elements;
			}
			set {
				rung_elements = value;
			}
		}
		int	id_rung;
		public int Id_rung {
			get { return id_rung; }
			set { id_rung = value; }
		}

		public int Update_Common_Element(Elements element)
		{
			int i = 0;
			foreach (Elements tag in Rung_elements.Tags) {
				i += tag.Update_Common_Element(element);
			}
			return i;
		}
		public void clearSelectTag()
		{
			rung_elements.clear_selectTag();
		}
		public bool SelectTag(RectangleF select_rectangle, ref Elements select_tags)
		{
			return rung_elements.SetSelectTag(select_rectangle, ref select_tags);
		}
		
		public int CreateElements()
		{			
			return rung_elements.CreateElement();
		}
		public int SetSelectElement(Elements element)
		{
			
			return rung_elements.SetSelectElement(element);
		}
	
		private Pen drawPen = new Pen(Color.Gray, 2);
		private Pen drawPen_R = new Pen(Color.Red, 2);
		private Font drawFont = new Font("Arial", 8);
		private SolidBrush drawBrush = new SolidBrush(Color.White);
		Point drawPoint = new Point(0, 0);
		
		public Point DrawPoint {
			get { return drawPoint; }
			set { drawPoint = value; }
		}

		Point drawPoint_Org	=	new Point(0, 0);
		
		public Point DrawPoint_Org {
			get { return drawPoint_Org; }
			set { drawPoint_Org = value; }
		}

		
		public Rung GetRung(RectangleF select_rectangle)
		{
			int mid_reg_x = (int)(select_rectangle.X + select_rectangle.Width / 2);
			int mid_reg_y = (int)(select_rectangle.Y + select_rectangle.Height / 2);
			if ((mid_reg_x > drawPoint_Org.X) & (mid_reg_x < drawPoint.X) &
			    (mid_reg_y > drawPoint_Org.Y) & (mid_reg_y < drawPoint.Y))
				return this;
			return null;
		}
		public Point DrawRung(Point drawPoint, int size, Graphics g, int tagcells, Rectangle recdraw)
		{
			DrawPoint = drawPoint;	
			DrawPoint_Org	= drawPoint;
			drawPen.Color = DrawingTags.color_draw;
			DrawingTags.scanValue = DrawingTags.simulation_startus ? 1 : 0;
			
			if (Ladder.Find_Master_Relay(rung_elements))
				DrawingTags.Master_scanValue = 1;
			DrawingTags.scanValue &= DrawingTags.Master_scanValue;	
			
			if (DrawingTags.simulation_startus & (DrawingTags.Master_scanValue == 1)) {
				drawPen.Color = DrawingTags.color_simulat;
			}
			
			g.DrawLine(drawPen, drawPoint.X, drawPoint.Y + size / 2, drawPoint.X + size, drawPoint.Y + size / 2);
			this.drawPoint.X += size;					
			//*****************Tasg Draw Ladder*************************************
			if (Rung_elements.Tags.Count == 0) {
				this.drawPoint.Y	+= size;
				return DrawPoint;
			}	
			
			DrawPoint	= rung_elements.DrawTag(this.drawPoint, size, g, tagcells, recdraw);			
			return DrawPoint;
		}
		 
	}
	//#################################################################################################//
	//
	//		public class Elements
	//
	//#################################################################################################//
	
	public class Elements
	{
		List<Elements> tags = new List<Elements>();
		public List<Elements> Tags {
			get { return tags; }
		}
		public TypeTag Type {
			get;
			set;
		}
		public string Properties {
			get;
			set;
		}
		//#########################################################
		// Properties Detail
		public bool Properties_negated {
			get;
			set;
		}
		public bool Properties_setOnly {
			get;
			set;
		}
		public bool Properties_resetOnly {
			get;
			set;
		}
		public bool Properties_delay {
			get;
			set;
		}
		public bool Startus {
			get;
			set;
		}
		public bool Properties_auto_clear {
			get;
			set;
		}
		public int Properties_value {
			get;
			set;
		}
		public int Properties_value1 {
			get;
			set;
		}
		//################ SIMULATION VALUE #####################//
		//
		//
		//#######################################################//
		public ulong timerState {
			get;
			set;
		}
		public ulong timerState_ {
			get;
			set;
		}
		public int _ct {
			get;
			set;
		}
		public bool _ctUpEdge {
			get;
			set;
		}
		public bool _ctDownEdge {
			get;
			set;
		}
		public bool _uQ {
			get;
			set;
		}
		public bool _lQ {
			get;
			set;
		}
		public int _srLeftEdge {
			get;
			set;
		}
		public int _srRightEdge {
			get;
			set;
		}
		public int _inbit {
			get;
			set;
		}

		int SetBit(int value, int index)
		{
			if (index < 0 || index >= sizeof(int) * 8) {
				throw new ArgumentOutOfRangeException();
			}
 
			return value | (1 << index);
		}
		
		public void shiftLeft()				// Shift left method
		{
			if (DrawingTags.scanValue == 0) {			// clock = 0 so clear shift left edge detect
				_srLeftEdge = 0;
			} else {							// Clock = 1
				if (_srLeftEdge == 0) {		// Rising edge detected so shift left
					_srLeftEdge = 1;		// Set shift left edge detect
					Properties_value = Properties_value << 1;		// Shift to the left
					//if (Properties_value > 0xFFFF)
					Properties_value &= 0xFFFF;
					if (_inbit == 1) {		// Shift-in new input bit at RHS
						Properties_value = SetBit(Properties_value, 0);
					}
				}
			}
		}
		public void shiftRight()			// Shift right method
		{
			if (DrawingTags.scanValue == 0) {			// clock = 0 so clear shift right edge detect
				_srRightEdge = 0;
			} else {							// Clock = 1
				if (_srRightEdge == 0) {	// Rising edge detected so shift right
					_srRightEdge = 1;		// Set shift right edge detect
					Properties_value = Properties_value >> 1;		// Shift to the right
					if (_inbit == 1) {		// Shift-in new input bit at LHS
						Properties_value = SetBit(Properties_value, 15);
					}
				}
			}
		}
		public void shift_reset()					// Reset the shift register if scanValue = 0
		{
			if (DrawingTags.scanValue == 1) {
				Properties_value = 0;					// Set  the shift register to zero
				_srLeftEdge = 0;			// Prepare rising edge detect for left shift
				_srRightEdge = 0;			// Prepare rising edge detect for right shift
			}
		}
		public void shiftinputBit()				// Set the input bit of the shift register
		{
			if (DrawingTags.scanValue == 0) {			// If scanValue = 0, clear input bit
				_inbit = 0;
			} else {							// Otherwise set the input bit
				_inbit = 1;
			}
		}
		
		public void countUp_loop()				// Count up method
		{
			if (_ct <= Properties_value) {      		// Not yet finished counting so continue
				if (DrawingTags.scanValue == 0) {// clock = 0 so clear counter edge detect
					_ctUpEdge = false;
				} else {					// Clock = 1
					if (!_ctUpEdge) {	// Rising edge detected so increment count
						_ctUpEdge = true;		// Set counter edge		
						_ct++;				// Increment count
						if (_ct == Properties_value) {	// Counter has reached final value
							_uQ = true;		// Counter upper Q output = 1
							_lQ = false;		// Counter lower Q output = 0
						} else {			// Counter is not yet finished
							_uQ = false;		// Counter upper Q output = 0
							_lQ = false;		// Counter lower Q output = 0
						}
						if (_ct > Properties_value)
							_ct = Properties_value1;
					}
				}
			}
		}
		public void countUp()				// Count up method
		{
			if (_ct < Properties_value) {      		// Not yet finished counting so continue
				if (DrawingTags.scanValue == 0) {// clock = 0 so clear counter edge detect
					_ctUpEdge = false;
				} else {					// Clock = 1
					if (!_ctUpEdge) {	// Rising edge detected so increment count
						_ctUpEdge = true;		// Set counter edge		
						_ct++;				// Increment count
						if (_ct >= Properties_value) {	// Counter has reached final value
							_uQ = true;		// Counter upper Q output = 1
							_lQ = false;		// Counter lower Q output = 0
						} else {			// Counter is not yet finished
							_uQ = false;		// Counter upper Q output = 0
							_lQ = false;		// Counter lower Q output = 0
						}
					}
				}
			}
		}
		public bool shift_reg()				// Count up method
		{
			if (DrawingTags.scanValue == 0) {// clock = 0 so clear counter edge detect
				_ctUpEdge = false;
			} else {					
				if (!_ctUpEdge) {	
					_ctUpEdge = true;
					return true;
				}
			}
			return false;
		}
		public void countDown_loop()				// Count up method
		{
			if (_ct >= Properties_value1) {      		// Not yet finished counting so continue
				if (DrawingTags.scanValue == 0) {// clock = 0 so clear counter edge detect
					_ctDownEdge = false;
				} else {					// Clock = 1
					if (!_ctDownEdge) {	// Rising edge detected so increment count
						_ctDownEdge = true;		// Set counter edge		
						_ct--;				// Increment count
						if (_ct == Properties_value1) {	// Counter has reached final value
							_uQ = false;		// Counter upper Q output = 1
							_lQ = true;		// Counter lower Q output = 0
						} else {			// Counter is not yet finished
							_uQ = false;		// Counter upper Q output = 0
							_lQ = false;		// Counter lower Q output = 0
						}
						if (_ct < Properties_value1)
							_ct = Properties_value;
					}
				}
			}
		}
		public void countDown()			// Count down method
		{
			if (_ct > Properties_value1) {					// Not yet finished so continue
				if (DrawingTags.scanValue == 0) {		// clock = 0 so clear counter edge detect
					_ctDownEdge = false;
				} else {						// Clock = 1
					if (!_ctDownEdge) {	// Rising edge detected so decrement count
						_ctDownEdge = true;	// Set counter edge
						if (_ct > 0)
							_ct--; 				// Decrement count
						if (_ct <= Properties_value1) {		// Counter has reached final value
							_uQ = false;		// Counter QUp output = 0
							_lQ = true;		// Counter QDown output = 1
						} else {		// Counter is not yet finished
							_uQ = false;		// Counter upper Q output = 0
							_lQ = false;		// Counter lower Q output = 0
						}
					}
				}
			}	
		}
		//########################################################
		public string Name {
			get;
			set;
		}
		public string IO_Port {
			get;
			set;
		}
		bool	select_tag	=	false;
		public bool Select_tag {
			get { return select_tag; }
			set { select_tag = value; }
		}
		bool	select_all	=	false;
		public bool Select_all {
			get { return select_all; }
			set { select_all = value; }
		}
		public Elements Parent {
			get;
			set;
		}
		Pen drawPen = new Pen(Color.Gray, 2);
		Pen drawPen_R = new Pen(Color.Red, 2);
		Font drawFont = new Font("Arial", 8);
		SolidBrush drawBrush = new SolidBrush(Color.LawnGreen);
		Point drawPoint = new Point(0, 0);
		Point drawPoint_size	=	new Point(0, 0);
		public Point DrawPoint_size {
			get { return drawPoint_size; }
			set { drawPoint_size = value; }
		}

		public Elements()
		{
			this.Type	= TypeTag.Null;
			this.IO_Port	=	"";
			this.Properties_value = 1;
			this.Properties_value1 = 1;
		}

		public Elements(TypeTag typetag, string name, Elements parent)
		{
			this.Type	= typetag;
			this.Name	=	name;
			this.Parent	=	parent;
			this.IO_Port	=	"";
			this.Properties_value = 1;
			this.Properties_value1 = 1;
		}
		public Elements(TypeTag typetag, string name, string properties, Elements parent)
		{			
			this.Type = typetag;
			this.Name =	name;
			this.Properties	=	properties;
			this.Parent =	parent;	
			this.IO_Port	=	"";		
			this.Properties_value = 0;
			this.Properties_value1 = 1;
		}
		public int Update_Common_Element(Elements element)
		{
			int i = 0;
			if (this == element)
				return 0;
			switch (Type) {
				case TypeTag.PARALLEL:
				case TypeTag.SERIES:
				//case TypeTag.Rung:
					foreach (Elements tag in Tags) {
						i += tag.Update_Common_Element(element);
					}
					break;
				case TypeTag.MOVE:
				case TypeTag.ADD:
				case TypeTag.SUB:
				case TypeTag.MUL:
				case TypeTag.DIV:
				case TypeTag.MOD:				
					break;
				case TypeTag.ADC:	
					//Properties_value = element.Properties_value;					
					//Properties_value1 = element.Properties_value1;
					if (element.Type == TypeTag.ADC) {
						Properties = element.Properties;	
					}
					return 1;
				case TypeTag.COIL:
					if (element.Name == Name) {
						Properties_value = element.Properties_value;					
						Properties_value1 = element.Properties_value1;
						
						if (Name.Substring(0, 1) == "C" & element.Type == TypeTag.COIL) {
//							_lQ = element._lQ;					
//							_uQ = element._uQ;
							_ct = element._ct;
//							if (Properties_resetOnly)
//								element.Startus = _lQ;
//							if (Properties_setOnly)
//								element.Startus = _uQ;							
						}
						
						Startus = element.Startus;
					}
					return 1;
				case TypeTag.CONTACTS:
					if (element.Name == Name) {
						Properties_value = element.Properties_value;					
						//Properties_value1 = element.Properties_value1;
						
						if (Name.Substring(0, 1) == "C" & element.Type == TypeTag.COIL) {
							_lQ = element._lQ;					
							_uQ = element._uQ;
							if (Properties_resetOnly)
								element.Startus = _lQ;
							if (Properties_setOnly)
								element.Startus = _uQ;	
							Startus = element.Startus;							
						}
						Startus = element.Startus;
						if (Name.Substring(0, 1) == "S" & Type == TypeTag.CONTACTS) {
							Startus = (Properties_value & (1 << Properties_value1)) != 0;
						}
						
					}
					return 1;
			}
			
			return i;
		}
		public void clear_selectTag()
		{
			if (Type == TypeTag.PARALLEL || Type == TypeTag.SERIES || Type == TypeTag.Rung) {
				foreach (Elements tag in tags) {   	
					tag.clear_selectTag();
				}
			}
			select_tag	=	false;
			select_all	=	false;
		}
		public bool SetSelectTag(RectangleF select_rectangle, ref Elements select_tags)
		{
			select_tag	=	false;
			select_all	=	true;
			if (Type == TypeTag.PARALLEL || Type == TypeTag.SERIES || Type == TypeTag.Rung) {
				foreach (Elements tag in tags) {   	
					if (tag.SetSelectTag(select_rectangle, ref select_tags)) {
						Select_tag = true;
					} else {
						select_all	= false;
					}					
				}
				if (select_all & Type != TypeTag.Rung) {
					foreach (Elements tag in tags) {
						select_tags.tags.Remove(tag);
					}			
					select_tags.tags.Add(this);
				}				
				return select_all;
			} else {
				int pos_org_tag_x = drawPoint_org.X;
				int pos_org_tag_y = drawPoint_org.Y;
				int pos_tag_x = drawPoint_size.X;
				int pos_tag_y = drawPoint_size.Y;
				int reg_org_x = (int)select_rectangle.X;
				int reg_org_y = (int)select_rectangle.Y;
				int reg_x = (int)(select_rectangle.X + select_rectangle.Width);
				int reg_y = (int)(select_rectangle.Y + select_rectangle.Height);
				
				if (select_rectangle.Width <= 0) {
					if (reg_org_x > pos_org_tag_x & reg_org_x < pos_tag_x)
					if (reg_org_y > pos_org_tag_y & reg_org_y < pos_tag_y) {
						select_tag = true;
						select_all	=	select_tag;
						select_tags.tags.Add(this);
						return true;
					}
				} else {
					if (reg_org_x <= pos_org_tag_x & pos_tag_x <= reg_x)
					if (reg_org_y <= pos_org_tag_y & pos_tag_y <= reg_y) {
						select_tag = true;
						select_all	=	select_tag;
						select_tags.tags.Add(this);
						return true;
					}
				}
			
//				const int fx_select = 20;
//				if (select_rectangle.X < drawPoint_size.X - fx_select * 2 & drawPoint_size.X - fx_select < (select_rectangle.X + select_rectangle.Width) &
//				    select_rectangle.Y < drawPoint_size.Y - fx_select * 2 & drawPoint_size.Y - fx_select < (select_rectangle.Y + select_rectangle.Height)) {
//					select_tag = true;
//					select_all	=	select_tag;
//					select_tags.tags.Add(this);
//					return true;
//				}			
			}	
			select_all	=	false;
			return select_all;
		}
		public bool InTag(int p_x, int p_y)
		{
			if (drawPoint_org.X < p_x & p_x < drawPoint_size.X)
			if (drawPoint_org.Y > p_y & p_y < drawPoint_size.Y)
				return true;
			return false;
		}
		
		public Elements GetTag(RectangleF select_rectangle)
		{
			if ((Type == TypeTag.PARALLEL) || (Type == TypeTag.SERIES)) {
				foreach (Elements tag in tags) {   		
					if (tag.GetTag(select_rectangle) != null)
						return  tag.GetTag(select_rectangle);
				}
				return null;
			}	
			if ((select_rectangle.X > this.drawPoint.X) & (select_rectangle.X < this.drawPoint_size.X) &
			    (select_rectangle.Y > this.drawPoint.Y) & (select_rectangle.Y < this.drawPoint_size.Y))
				return this;
			return null;
		}
		public void AddTag(Elements tag)
		{
			tag.Parent = this;
			tags.Add(tag);
			if (!(tag.Type == TypeTag.PARALLEL || tag.Type == TypeTag.SERIES))
				Ladder.Element_Tags_Add(tag);
		}
		
		public bool InsertTag(int index_tag, Elements tag)
		{
			if (index_tag == -1)
				return false;
			tag.Parent = this;
			tags.Insert(index_tag, tag);
			return true;
		}
		public bool RemoveTag(Elements tag)
		{
			if (tags.IndexOf(tag) == -1)
				return false;
			tags.Remove(tag);
			return true;
		}
		public int CreateElement()
		{
			int i = 0;
			foreach (Elements tag in tags) {
				switch (tag.Type) {
					case TypeTag.Rung:
					case TypeTag.SERIES:
					case TypeTag.PARALLEL:
						i += tag.CreateElement();
						break;
					case TypeTag.CONTACTS:
					case TypeTag.COIL:
					case TypeTag.MOVE:
					case TypeTag.ADC:
					case TypeTag.TOF:
					case TypeTag.TON:
					case TypeTag.TPC:
					case TypeTag.FCP:
					case TypeTag.OSF:
					case TypeTag.OSR:
					case TypeTag.SHIFT_REGISTERS:
					case TypeTag.SHIFT_VARIABLE:
					case TypeTag.SHIFT_LEFT:
					case TypeTag.SHIFT_REG_RESET:
					case TypeTag.SHIFT_RIGHT:
					case TypeTag.SHIFT_REG_INBIT:
					case TypeTag.UART_RECV:
					case TypeTag.UART_SEND:
						i += Ladder.Element_Tags_Add(tag);
						break;
				}
			}
			return i;
		}
		public int SetSelectElement(Elements element)
		{
			int i = 0;
			foreach (Elements tag in tags) {
				switch (tag.Type) {
					case TypeTag.Rung:
					case TypeTag.SERIES:
					case TypeTag.PARALLEL:
						i += tag.SetSelectElement(element);
						break;
//					case TypeTag.CONTACTS:
//						
//					case TypeTag.COIL:
					default:
						//Ladder.setfindRef = true;
						if (Ladder.setfindRef) {
							if (element.Name == tag.Name) {
								tag.Select_tag = true;
								i++;
							}
						} else {
							if (element.Name == tag.Name & element.Type == tag.Type) {
								tag.Select_tag = true;
								i++;
							}	
						}												
						break;
				}
			}
			return i;
		}
		public Point drawPoint_org;
		
		public Point DrawTag(Point drawPoint, int size, Graphics g, int tagcells, Rectangle recdraw)
		{
			Startus &= DrawingTags.simulation_startus;
			this.drawPoint	=	drawPoint;
			drawPoint_org	=	drawPoint;
			int tag_x	= 0;
			int tag_y	= 0;
			drawPen.Color	= DrawingTags.color_draw;
			//drawBrush.Color	= Color.GreenYellow;
			if (Select_tag) {
				drawPen.Color	= Color.Orange;
				drawBrush.Color	= Color.Red;
			}				
			switch (Type) {
				case TypeTag.Rung:	
				case TypeTag.SERIES:										
					this.drawPoint = drawPoint;
					foreach (Elements tag in tags) {
						this.drawPoint.Y	= drawPoint.Y;
						this.drawPoint = tag.DrawTag(this.drawPoint, size, g, tagcells, recdraw);						
						if (tag_x < this.drawPoint.X)
							tag_x	=	this.drawPoint.X;
						if (tag_y < this.drawPoint.Y)
							tag_y	=	this.drawPoint.Y;
					}
					drawPoint_size.X	= tag_x;
					drawPoint_size.Y	= tag_y;
					
					break;
				case TypeTag.PARALLEL:
					this.drawPoint = drawPoint;
					int tempRes = 0;
					Elements befor_tag	=	null;
					int tempScanValue = DrawingTags.scanValue;
					
					for (int i = 0; i < Tags.Count; i++) {
						Elements tag = tags[i];
						this.drawPoint.X = drawPoint.X;
						DrawingTags.scanValue = tempScanValue;
						this.drawPoint = tag.DrawTag(this.drawPoint, size, g, tagcells, recdraw);
						if (tag_x < this.drawPoint.X)
							tag_x = this.drawPoint.X;
						if (tag_y < this.drawPoint.Y)
							tag_y = this.drawPoint.Y;
						if (tempScanValue > 0) {
							drawPen.Color = DrawingTags.color_simulat;
						}
						if (befor_tag != null) {
							//drawPen.Color = Color.Gray;
							if (i != Tags.Count - 1) {
								g.DrawLine(drawPen, befor_tag.drawPoint_org.X, drawPoint_org.Y + size / 2, befor_tag.drawPoint_org.X, tag.drawPoint_size.Y - size / 2);					
							} else {			
								g.DrawLine(drawPen, befor_tag.drawPoint_org.X, befor_tag.drawPoint_size.Y - size / 2, befor_tag.drawPoint_org.X, tag.drawPoint_org.Y + size / 2);
							}
						} else {
							//drawPen.Color = Color.Gray;
							g.DrawLine(drawPen, drawPoint_org.X, drawPoint_org.Y + size / 2, drawPoint_org.X, tag.drawPoint_size.Y - size / 2);								
						}
						befor_tag = tag;
						if (DrawingTags.scanValue > 0) {
							tempRes = DrawingTags.scanValue;
						}
					}	
					//drawPen.Color = Color.Gray;
					if (Select_all)
						drawPen.Color = Color.Red;
					for (int i = 0; i < tags.Count; i++) {
						Elements tag = tags[i];
						
						if (tag.DrawPoint_size.X <= tag_x) {
							drawPen.Color = DrawingTags.color_draw;
							if (tempRes > 0) {
								drawPen.Color = DrawingTags.color_simulat;
							}
							g.DrawLine(drawPen, tag.DrawPoint_size.X, tag.drawPoint_org.Y + size / 2, tag_x, tag.drawPoint_org.Y + size / 2);
							if (i > 0) {
								g.DrawLine(drawPen, tag_x, tags[i - 1].drawPoint_org.Y + size / 2, tag_x, tag.drawPoint_org.Y - size / 2);	
							}
						}
						if (i > 0) {						
							g.DrawLine(drawPen, tag_x, tags[i - 1].DrawPoint_size.Y - size / 2, tag_x, tag.drawPoint_org.Y + size / 2);						
						}
					}
					DrawingTags.scanValue = tempRes;
					drawPoint_size.X	= tag_x;
					drawPoint_size.Y	= tag_y;
					break;
					
				case TypeTag.COIL:
				case TypeTag.MOVE:
				case TypeTag.ADD:
				case TypeTag.SUB:
				case TypeTag.MUL:
				case TypeTag.DIV:
				case TypeTag.MOD:
				case TypeTag.ADC:
				case TypeTag.MASTER_RELAY:
				case TypeTag.SHIFT_REGISTERS:
				case TypeTag.SHIFT_VARIABLE:	
				case TypeTag.SHIFT_LEFT:
				case TypeTag.SHIFT_RIGHT:
				case TypeTag.SHIFT_REG_INBIT:
				case TypeTag.SHIFT_REG_RESET:
					drawPen.Color = DrawingTags.color_draw;
					if ((DrawingTags.scanValue > 0) & DrawingTags.simulation_startus)
						drawPen.Color = DrawingTags.color_simulat;
					int old_drawpoint_x	=	drawPoint.X;
					drawPoint.X = recdraw.X + recdraw.Width - size;						
					g.DrawLine(drawPen, old_drawpoint_x, drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 0.25)), drawPoint.Y + size / 2);	
					
					goto default;
					
				default :	// All Elements In Case
					var parent_tag	=	Parent as Elements;
					string parent_name	= "Rung";
					if (parent_tag != null)
						parent_name	=	parent_tag.Name;
					switch (Type) {
						case TypeTag.CONTACTS:
							int endElementX = recdraw.X + recdraw.Width;
							if (drawPoint.X >= (endElementX - size)) {
								MessageBox.Show("Error!", "Over Point Element");
								return drawPoint_size;
							}
							break;
					}
					DrawingTags.Drawtag(this, g, drawPoint, size);
					if (Type != TypeTag.COMMENT)
						DrawingTags.DrawtagString(this, g, drawPoint, size, 0);
					
					drawPoint_size.Y	=	drawPoint.Y + size;
					drawPoint_size.X	=	drawPoint.X + size;	
					
					break;
			}
			
			return drawPoint_size;
		}
		public string getInfo()
		{
			string retInfo = string.Format("Type: {0}", Type);
			switch (Type) {
				case TypeTag.CONTACTS:
					retInfo += Properties_negated ? string.Format("_Normal Close") : string.Format("_Normal Open");
					
					break;
				case TypeTag.COIL:
					switch (Name.Substring(0, 1)) {
						case "Y":
						case "R":
							retInfo += Properties_negated ? string.Format("_Normal Inactive") : string.Format("_Normal Active");	
							break;
					}
					
					
					break;
			}
		
			return retInfo;
		}
	}

	//#################################################################################################//
	//
	//		public class Elements
	//
	//#################################################################################################//
	


}