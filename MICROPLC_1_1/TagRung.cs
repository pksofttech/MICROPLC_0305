/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 4/22/2015
 * Time: 2:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of TagRung.
	/// </summary>
	/// 

	public enum TypeTag
{
	Null,
	Rung,
    	PARALLEL,
    	SERIES,
    	CONTACTS,
    	COIL
}		

	public class ProgramLadder 
	{
		public List<Rung> rungs	=	new List<Rung>{};
//		string strladder = "PROGRAM\n";		
		string msgDebug	 = "Debug";
		TagRung select_tags		= new TagRung();
		Rectangle	select_area	= new Rectangle();
		int tag_size	=	0;
		public TagRung Select_tags {
			get { return select_tags; }
		}
		public string MsgDebug {
			get { return msgDebug; }
			set { msgDebug = value; }
		}
		Rung rung_select;
		
		public Rung Rung_select {
			get { return rung_select; }
			set { rung_select = value; }
		}

//		public string ExportToLadder()
//		{
//			foreach (Rung rung in rungs)
//			{
//				strladder	+= "RUNG\n";
//				rung.ExportToLadder(ref strladder);
//				strladder	+= "END\n";
//			}				
//			return strladder;
//		}
//		
		private Pen drawPen = new System.Drawing.Pen(Color.Gray, 2);
		private Font drawFont = new Font("Arial", 10);
    	private SolidBrush drawBrush = new SolidBrush(Color.LightBlue);
    	
		int tag_cells		= 10;
		int margin_left;
		int margin_right;
		int margin_top		= 80;
		int margin_button	= 40;

		public int InselectTag(int p_x,int p_y)
		{
			if(p_x > select_area.X & p_x < select_area.X+select_area.Width)
				if(p_y > select_area.Y & p_y < select_area.Y+select_area.Height)
			{
				if(p_x > select_area.X & p_x < select_area.X+select_area.Width*0.2)
				if(p_y > select_area.Y+select_area.Height*0.2 & p_y < select_area.Y+select_area.Height*0.8)
					return 1;
				if(p_x > select_area.X+select_area.Width*0.2 & p_x < select_area.X+select_area.Width*0.8)
				if(p_y > select_area.Y & p_y < select_area.Y+select_area.Height*0.2)
					return 2;
				if(p_x > select_area.X+select_area.Width*0.8 & p_x < select_area.X+select_area.Width)
				if(p_y > select_area.Y+select_area.Height*0.2 & p_y < select_area.Y+select_area.Height*0.8)
					return 3;
				if(p_x > select_area.X+select_area.Width*0.2 & p_x < select_area.X+select_area.Width*0.8)
				if(p_y > select_area.Y+select_area.Height*0.8 & p_y < select_area.Y+select_area.Height)
					return 4;
			}
			return 0;
		}
		public Rung GetRung(RectangleF select_rectangle)
		{
			//MessageBox.Show(select_rectangle.X + " " + select_rectangle.Y , "Debug DrowPoint Rung");
			foreach (Rung rung in rungs)
    			{   		
				if (rung.GetRung(select_rectangle)  == rung_select )
					return rung.GetRung(select_rectangle);
    			}
			return null;
		}
		public bool SelectTags(Rectangle rectangle_select)
		{
			
			foreach (Rung rung in rungs)
			{
				rung.SelectTag(new Rectangle(0,0,0,0),ref select_tags);
			}
			select_tags.Tags.Clear();
			foreach (Rung rung in rungs)
			{
				if(rung.GetRung(new Rectangle(rectangle_select.X,rectangle_select.Y+50,rectangle_select.Width,rectangle_select.Height)) != null)
				{
					rung.SelectTag(rectangle_select,ref select_tags);
					rung_select	=	rung;
				}
					
			}
			BuildSelectFrame();
			return false;
		}
	//*********************Program Draw Ladder***************************//
	void BuildSelectFrame()
	{
		int max_x=0,max_y=0;

			select_area.X	= 9999;
			select_area.Y	= 9999;
			foreach (TagRung tag in select_tags.Tags)
			{
				max_x	=	Math.Max(max_x,tag.DrawPoint_size.X);
				max_y	=	Math.Max(max_y,tag.DrawPoint_size.Y);
				select_area.X	= Math.Min(select_area.X,tag.drawPoint_org.X);
				select_area.Y	= Math.Min(select_area.Y,tag.drawPoint_org.Y);
			}
			select_area.Width	= max_x - select_area.X;
			select_area.Height	= max_y - select_area.Y;
	}
	
		public Point DrawProgram(System.Drawing.Graphics g,int width,int height,int tag_size)
		{			
//			tag_size	=	width/tag_cells;
//			if(tag_size%2 == 1)
//				tag_size	-=	1;
			this.tag_size	=	tag_size;
			margin_left		=	width/2 - (tag_size * tag_cells/2);
			margin_right	=	width/2 + (tag_size * tag_cells/2);
			drawPen.Color	=	Color.Gray;
			Rectangle	recdraw		=	new Rectangle(margin_left,margin_top,tag_size * tag_cells ,height-margin_button-margin_top);
			g.Clear(Color.Black);
			g.DrawLine(drawPen,margin_left,margin_top,margin_left,height - margin_button);
			g.DrawLine(drawPen,margin_right,margin_top,margin_right,height - margin_button);

			
			String drawString = "Ladder Program By PLCMICROLADDER [PksofttecH]";
    
			// Measure string.
    		SizeF stringSize = new SizeF();
   			stringSize = g.MeasureString(drawString, drawFont);	
			
   			Point drawPointProgram = new Point( (int)( (width - stringSize.Width) *0.5) , margin_top/2);
    		g.DrawString(drawString, drawFont, drawBrush, drawPointProgram);
    		
    		drawPointProgram.Y	-=	drawFont.Height;
    		
    		g.DrawString(msgDebug, drawFont, drawBrush, drawPointProgram);

    		//*****************Rungs Draw Ladder*************************************	
    		Point drawPoint = new Point(margin_left, margin_top);	
    		int rung_No	= 0;
    		foreach (Rung rung in rungs)
    		{
    			drawPoint.X	=	margin_left;   
    			g.DrawString("- Rung " + ++rung_No,drawFont,drawBrush,drawPoint.X+5,drawPoint.Y);			
				drawPoint	=	rung.DrawRung(drawPoint,tag_size,g,tag_cells,recdraw);
    		}    	
    		drawPen.Color	=	Color.Blue;
    		//g.DrawRectangle(drawPen,select_area);
    		
    		g.DrawString("Select Tags = "+select_tags.Tags.Count.ToString(),drawFont,drawBrush,select_area.X,select_area.Y-30);
    		return drawPoint;
		}	
	}
	
	// ##########################################################################################//
	// ##########################################################################################//
//			public class Rung
	// ##########################################################################################//
		
	public class Rung
	{	
		public List<TagRung> tags	=	new List<TagRung>{};
		int	id_rung;
		
		public int Id_rung {
			get { return id_rung; }
			set { id_rung = value; }
		}

		public bool SelectTag(RectangleF select_rectangle,ref TagRung select_tags)
		{
			bool return_select	= false;
			foreach (TagRung tag in tags)
    			{   		
					return_select = tag.SetSelectTag(select_rectangle,ref select_tags);
    			}
			return return_select;
		}
		public TagRung GetTag(RectangleF select_rectangle)
		{
			foreach (TagRung tag in tags)
    			{   		
				if (tag.GetTag(select_rectangle) != null)
					return  tag.GetTag(select_rectangle);
    			}
			return null;
		}	
		public Rung GetRung(RectangleF select_rectangle)
		{
			if ((select_rectangle.X > this.drawPoint_Org.X) & (select_rectangle.X < this.drawPoint.X) &
			    (select_rectangle.Y > this.drawPoint_Org.Y) & (select_rectangle.Y < this.drawPoint.Y))
				return this;
				//MessageBox.Show(this.drawPoint.X.ToString() );
			return null;
		}		
		private Pen drawPen = new Pen(Color.Gray,2);
		private Pen drawPen_R = new Pen(Color.Red,2);
		private Font drawFont = new Font("Arial", 8);
    	private SolidBrush drawBrush = new SolidBrush(Color.White);
		Point drawPoint = new Point(0, 0);
		
		public Point DrawPoint {
			get { return drawPoint; }
		}
		Point drawPoint_Org	=	new Point(0,0);
		
		public Point DrawPoint_Org {
			get { return drawPoint_Org; }
		}
		public Point DrawRung(Point drawPoint,int size,System.Drawing.Graphics g,int tagcells,Rectangle recdraw)
		{
			this.drawPoint = drawPoint;	
			drawPoint_Org	=	drawPoint;
			//
			//g.DrawRectangle(drawPen_R,drawPoint.X,drawPoint.Y,size,size);
			g.DrawLine(drawPen,drawPoint.X,drawPoint.Y+size/2,drawPoint.X+size,drawPoint.Y+size/2);
			this.drawPoint.X  += size;
			
			
			//*****************Tasg Draw Ladder*************************************
			if( tags.Count == 0)
			{
				this.drawPoint.Y+= size;
				return this.drawPoint;
			}
				
			int max_y = 0;
			int max_x = 0;
    		foreach (TagRung tag in tags)
    		{   		
    			this.drawPoint.Y	=	 drawPoint.Y;
				this.drawPoint		=	 tag.DrawTag(this.drawPoint,size,g,tagcells,recdraw);
				if(max_y < this.drawPoint.Y)
					max_y	=	this.drawPoint.Y;
				if(max_x < this.drawPoint.X)
					max_x	=	this.drawPoint.X;
    		}
    		
    		this.drawPoint.Y	=	max_y;
    		this.drawPoint.X	=	max_x;
    		//MessageBox.Show(this.drawPoint.X.ToString() + "   " + this.drawPoint.Y.ToString(),"Debug DrowPoint Rung of ");
				
    		return this.drawPoint;
		}
		 
	}
	//#################################################################################################//
	//
	//		public class TagRung
	//
	//#################################################################################################//
	
	public class TagRung
	{
		private List<TagRung> tags = new List<TagRung>{};		
		
		public List<TagRung> Tags {
			get { return tags; }
		}
		TypeTag type 	= 	TypeTag.Null;
		
		public TypeTag Type {
			get { return type; }
			set { type = value; }
		}
		string	name,properties;

		public string Properties {
			get {
				return properties;
			}
			set {
				properties = value;
			}
		}
		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
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
		object parent;
		
		public object Parent {
			get { return parent; }
		}
		private Pen drawPen = new Pen(Color.Gray, 2);
		private Pen drawPen_R = new Pen(Color.Red, 2);
		private Font drawFont = new Font("Arial", 8);
    	private SolidBrush drawBrush = new SolidBrush(Color.LawnGreen);
		private Point drawPoint = new Point(0, 0);		
		private Point drawPoint_size	=	new Point(0,0);
		public Point DrawPoint_size {
			get { return drawPoint_size; }
			set { drawPoint_size = value; }
		}		

		public TagRung()
		{
			this.type	= 	TypeTag.Null;
		}

		public TagRung(TypeTag typetag,string name,object parent)
		{
			this.type	= 	typetag;
			this.name	=	name;
			this.parent	=	parent;
		}
		public TagRung(TypeTag typetag,string name,string properties,object parent)
		{			
			this.type		= 	typetag;
			this.name		=	name;
			this.properties	=	properties;
			this.parent		=	parent;					
		}		
		
		public bool SetSelectTag(RectangleF select_rectangle,ref TagRung select_tags)
		{
			select_tag	=	false;
			select_all	=	true;
			if( (type == TypeTag.PARALLEL )|| (type == TypeTag.SERIES))
			{
				foreach (TagRung tag in tags)
    			{   	
					if (tag.SetSelectTag(select_rectangle,ref select_tags))
					{
						Select_tag = true;
					}else{
						select_all	=	false;
					}
						
    			}
				if(select_all)
				{
					foreach (TagRung tag in tags)
						select_tags.tags.Remove(tag);
					select_tags.tags.Add(this);
				}
					
				return select_all;
			}else{
				int fx_select	= 25;
				if (select_rectangle.X < drawPoint_size.X - fx_select*2 & drawPoint_size.X -fx_select< (select_rectangle.X + select_rectangle.Width)&
				    select_rectangle.Y < drawPoint_size.Y - fx_select*2	 & drawPoint_size.Y -fx_select< (select_rectangle.Y + select_rectangle.Height))
				{
					select_tag 	= true;
					select_all	=	select_tag;
					select_tags.tags.Add(this);
					return true;
				}			
			}	
			select_all	=	false;
			return select_all;
		}
		public bool InTag(int p_x,int p_y)
		{
			if(drawPoint_org.X < p_x & p_x < drawPoint_size.X)
				if(drawPoint_org.Y > p_y & p_y < drawPoint_size.Y)
					return true;
			return false;
		}
		
		public TagRung GetTag(RectangleF select_rectangle)
		{
			if( (type == TypeTag.PARALLEL ) || (type == TypeTag.SERIES))
			{
				foreach (TagRung tag in tags)
    				{   		
					if( tag.GetTag(select_rectangle) != null)
						return  tag.GetTag(select_rectangle);
    				}
				return null;
			}	
			if ((select_rectangle.X > this.drawPoint.X) & (select_rectangle.X < this.drawPoint_size.X) &
			   (select_rectangle.Y > this.drawPoint.Y) & (select_rectangle.Y < this.drawPoint_size.Y))				
			return this;
			return null;
		}
		public void AddTag(TagRung tag)
		{
			tags.Add(tag);
		}
			
		public Point drawPoint_org;
		
		
		public Point DrawTag(Point drawPoint,int size,System.Drawing.Graphics g,int tagcells,Rectangle recdraw)
		{
			this.drawPoint	=	drawPoint;
			drawPoint_org	=	drawPoint;
			int tag_x	= 0;
			int tag_y	= 0;
			drawPen.Color	= Color.Gray;
    		drawBrush.Color	= Color.GreenYellow;
    		if(Select_tag)
    		{
    			drawPen.Color	= Color.Red;
    			drawBrush.Color	= Color.Red;
    		}
    				
    		if (type == TypeTag.SERIES || type == TypeTag.PARALLEL)
			{		
				this.drawPoint = drawPoint;
//				if(Select_all)
//					g.DrawString("Select",drawFont, drawBrush, drawPoint);
				if (type == TypeTag.SERIES )
				{
					foreach (TagRung tag in tags)
					{
						this.drawPoint.Y	=	 drawPoint.Y;
						this.drawPoint		=	 tag.DrawTag(this.drawPoint,size,g,tagcells,recdraw);						
						if(tag_x < this.drawPoint.X)
							tag_x	=	this.drawPoint.X;
						if(tag_y < this.drawPoint.Y)
							tag_y	=	this.drawPoint.Y;
					}
				}
					
				if (type == TypeTag.PARALLEL )
				{	
					TagRung befor_tag	=	null;
					foreach (TagRung tag in tags)
					{
						this.drawPoint.X	=	 drawPoint.X;
						this.drawPoint		=	 tag.DrawTag(this.drawPoint,size,g,tagcells,recdraw);
						
						if(tag_x < this.drawPoint.X)
							tag_x	=	this.drawPoint.X;
						if(tag_y < this.drawPoint.Y)
							tag_y	=	this.drawPoint.Y;
						
						if(befor_tag != null)
						{
							drawPen.Color	 = Color.Gray;
							if(tag.Select_tag & befor_tag.Select_tag)								
								drawPen.Color	 = Color.Red;

							g.DrawLine(drawPen,befor_tag.drawPoint_org.X,befor_tag.drawPoint_size.Y - size/2,befor_tag.drawPoint_org.X,tag.drawPoint_size.Y - size/2);
					
						}
						befor_tag	=	tag;
					}
					
					drawPen.Color	 = Color.Gray;
					if(this.Select_all)								
						drawPen.Color	 = Color.Red;
					g.DrawLine(drawPen,tag_x,this.drawPoint.Y - size/2,tag_x,drawPoint.Y + size/2);
										
					foreach (TagRung tag in tags)
					{							
						if( tag.DrawPoint_size.X < tag_x)
						{
							drawPen.Color	 = Color.Gray;
							if(tag.Select_all)								
								drawPen.Color	 = Color.Red;
							g.DrawLine(drawPen,tag.DrawPoint_size.X,tag.DrawPoint_size.Y-size/2,tag_x ,tag.DrawPoint_size.Y-size/2);
						}			
					}				
				}
				drawPoint_size.X	= tag_x;
				drawPoint_size.Y	= tag_y;
				//MessageBox.Show(DrowPoint_size.X.ToString() + "   " + DrowPoint_size.Y.ToString(),"Debug DrowPoint Rung of " + type);				
				return DrawPoint_size;			
			}else{		
			
				switch(type)
				{						
					case TypeTag.COIL :
						int old_drawpoint_x	=	drawPoint.X;
						drawPoint.X		=	 recdraw.X + recdraw.Width - size;						
						g.DrawLine(drawPen,old_drawpoint_x,drawPoint.Y+size/2, (float)(drawPoint.X + (size * 0.25)),drawPoint.Y+size/2);	
					break;					
				}
				
				TagRung parent_tag	=	parent as TagRung;
				string parent_name	= "Rung";
				if(parent_tag != null)
					parent_name	=	parent_tag.name;
				DrawingTags.drawtag(type,g,drawPen,drawPoint,size);
                SizeF stringSize = new SizeF();
                stringSize = g.MeasureString(name, drawFont);
                Point strPoint = new Point( (int) (drawPoint.X + (size - stringSize.Width )/2) ,drawPoint.Y );
                
                g.DrawString(name, drawFont, drawBrush, strPoint);
                strPoint.Y -= drawFont.Height;
				//g.DrawString(parent_name, drawFont, drawBrush, strPoint);
				
                drawPoint_size.Y	=	drawPoint.Y + size;
				drawPoint_size.X	=	drawPoint.X  + size;					
				return DrawPoint_size;
			}    		
    		
		}
		
	}
}
