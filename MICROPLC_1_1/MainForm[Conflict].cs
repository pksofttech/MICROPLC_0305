/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 4/10/2015
 * Time: 11:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of MainForm.
	/// DIY BY Pk softtech 2015 Co,Ltd.
	/// </summary>
	partial class MainForm : Form
	{
		public struct IconInfo
		{
			public bool fIcon;
			public int xHotspot;
			public int yHotspot;
			public IntPtr hbmMask;
			public IntPtr hbmColor;
		}
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

		[DllImport("user32.dll")]
		public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

		public static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
		{
			IntPtr ptr = bmp.GetHicon();
			var tmp = new IconInfo();
			GetIconInfo(ptr, ref tmp);
			tmp.xHotspot = xHotSpot;
			tmp.yHotspot = yHotSpot;
			tmp.fIcon = false;
			ptr = CreateIconIndirect(ref tmp);
			return new Cursor(ptr);
		}
		//readonly TagRung tagObj;
		public ProgramLadder program = Ladder.program;
		const int tag_size	= 75;
		string TitleStr;
		public string AssemblyTitle {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0) {
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "") {
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}
		public MainForm(string args)
		{
			TitleStr = AssemblyTitle;
			Loader_Form load_form = new Loader_Form();
			load_form.ShowDialog();
			InitializeComponent();	
			Text = TitleStr;
			panel_Ladder.BackColor = DrawingTags.color_draw_bg;
			listView_Map_I.ForeColor = Color.FromArgb(8, 174, 249);
			listView_Map_O.ForeColor = listView_Map_I.ForeColor;			
			listView_elements.ForeColor = Color.LightGray;
			//listView_elements.ForeColor = Color.FromArgb(0, 128, 0);
			
			listView_Map_I.BackColor = Color.FromArgb(30, 30, 30);				
			listView_Map_O.BackColor = listView_Map_I.BackColor;
			listView_elements.BackColor = listView_Map_O.BackColor;
			//this.BackColor = listView_elements.BackColor;
			
			richTextBox1.BackColor = Color.FromArgb(30, 30, 30);
			richTextBox1.ForeColor = Color.LightGray;
//			groupBox4.BackColor = groupBox3.BackColor;
			// SET DELEGETE
			Ladder.SetActiveProgram(program);
			this.Ladder_Draw.Paint += this.Ladder_panelPaint;
			this.btn_element_Contracs.Click += this.Btn_elements_Click;
			this.btn_element_MasterRelay.Click += this.Btn_elements_Click;
			this.btn_element_Coil.Click += this.Btn_elements_Click;
			this.btn_element_TOF.Click += this.Btn_elements_Click;
			this.btn_element_TON.Click += this.Btn_elements_Click;
			this.btn_element_TPC.Click += this.Btn_elements_Click;
			this.btn_element_CTU.Click += this.Btn_elements_Click;
			this.btn_element_CTD.Click += this.Btn_elements_Click;
			this.btn_element_CTC.Click += this.Btn_elements_Click;			
			this.btn_element_Compare.Click += this.Btn_elements_Click;				
			this.btn_element_Add.Click += this.Btn_elements_Click;
			this.btn_element_Sub.Click += this.Btn_elements_Click;
			this.btn_element_Mup.Click += this.Btn_elements_Click;
			this.btn_element_Div.Click += this.Btn_elements_Click;
			this.btn_element_Mod.Click += this.Btn_elements_Click;
			this.btn_element_Move.Click += this.Btn_elements_Click;
			this.btn_OSR.Click += this.Btn_elements_Click;
			this.btn_OSF.Click += this.Btn_elements_Click;
			this.btn_element_ADC.Click += this.Btn_elements_Click;
			this.btn_element_Shift_Contracs.Click += this.Btn_elements_Click;
			this.btn_element_Shift_Control.Click += this.Btn_elements_Click;
			this.btn_element_Shift_Reg.Click += this.Btn_elements_Click;
			this.btn_element_Comment.Click += this.Btn_elements_Click;
			this.btn_open.Click += this.Btn_elements_Click;
			this.btn_short.Click += this.Btn_elements_Click;
			this.btn_uart_recv.Click += this.Btn_elements_Click;
			this.btn_uart_send.Click += this.Btn_elements_Click;
			//this.btn_uart_sent_f.Click += this.Btn_elements_Click;
			//tsb_Insert_up.Click += this.Add_rung_UpClick;
			//tsb_Insert_down.Click += this.Add_rung_DownClick;
			tsb_Move_up.Click += this.Btn_Rung_Move_UpClick;			
			tsb_Move_down.Click += this.Btn_Rung_Move_DownClick;
			tsb_delete_rung.Click += this.Delete_RungClick;
			tsb_New_rung.Click += this.Add_new_rung;
			
			ts_arduinoUNO.Click += SelectHardware;
			ts_arduino_MEGA.Click += SelectHardware;
			ts_AUC01.Click += SelectHardware;
			ts_no_hw.Click += SelectHardware;
			ts_bnt_start.Enabled = false;
			ts_bnt_step.Enabled = false;
			ts_bnt_stop.Enabled = false;
			toolStripComboBox_Mup.Text = "1";
			toolStripComboBox_Mup.Enabled = false;
			
			NewToolStripMenuItemClick(null, null);
			Ladder.SaveStratus = false;
			_ReadSetting();
			Ladder_Draw.Invalidate();
		}

		Pen drawPen = new Pen(Color.Red, 1);
		void Ladder_panelPaint(object sender, PaintEventArgs e)
		{
			panel_Ladder.BackColor = DrawingTags.color_draw_bg;
			//panel_Ladder.BackColor = Color.Azure;
		
			Point ladder_point = program.DrawProgram(e.Graphics, panel_Ladder.Width, panel_Ladder.Height, tag_size);
			if (cursor_Mode == Cursor_Mode.draging) {
				e.Graphics.DrawRectangle(drawPen, rectangle_select);
			}
			
			Ladder_Draw.Height = ladder_point.Y;
			Ladder_Draw.Width = ladder_point.X + 20;
			int Ladder_Left = (panel_Ladder.Width - Ladder_Draw.Width) / 2;
			if (Ladder_Left > 0)
				Ladder_Draw.Left = Ladder_Left;
		}
		void SetCursorFunction(Cursor_Mode functionCode)
		{
			cursor_Mode	= functionCode;
			switch (cursor_Mode) {
				case Cursor_Mode.select_mode:	// SelectCursor
					Cursor = Cursors.Default;
					break;
				case Cursor_Mode.insert:	// InsertCursor
					//this.Cursor = Cursors.Hand;
					Bitmap b = new Bitmap(imageList1.Images[4]);
					Cursor = CreateCursor(b, 10, 10);
					toolTip_element.Hide(Ladder_Draw);
					//Cursor = Cursors.SizeAll;
					break;
				case Cursor_Mode.none:	// InsertCursor
					Cursor = Cursors.Cross;
					break;
				case Cursor_Mode.simulation:	// InsertCursor
					Cursor = Cursors.Hand;
					break;
			}
			//this.Text = cursor_Mode.ToString();
		}
		void Button1Click(object sender, EventArgs e)
		{			
			Ladder.Set_Tag_Insert(new Elements(TypeTag.CONTACTS, "Xnew", null));
        	
			SetCursorFunction(Cursor_Mode.insert);
	
		}
		
		void Button2Click(object sender, EventArgs e)
		{
         
			program.rungs.Add(new Rung());			
			Ladder_Draw.Invalidate();
		}

		
		enum Cursor_Mode
		{
			none,
			select_mode,
			insert,
			copy,
			move,
			delete,
			draging,
			simulation
		}
		Cursor_Mode cursor_Mode	= Cursor_Mode.select_mode;
		Point DragStart_Ladder_panel = Point.Empty;
		Rectangle rectangle_select = new Rectangle();
		activePositions Last_action_position	= activePositions.Null;
		void Ladder_panelMouseMove(object sender, MouseEventArgs e)
		{
			switch (cursor_Mode) {
				case Cursor_Mode.draging:					
					rectangle_select.X = DragStart_Ladder_panel.X;
					rectangle_select.Y = DragStart_Ladder_panel.Y;
					rectangle_select.Width	= Ladder_Draw.PointToClient(Cursor.Position).X - DragStart_Ladder_panel.X;
					rectangle_select.Height	= Ladder_Draw.PointToClient(Cursor.Position).Y - DragStart_Ladder_panel.Y;
					Ladder_Draw.Invalidate();
					break;
				case Cursor_Mode.insert:
					activePositions action_position	= program.InselectTag(Ladder_Draw.PointToClient(Cursor.Position).X, Ladder_Draw.PointToClient(Cursor.Position).Y);
					if (Last_action_position == action_position) {						
						break;
					}
					
					Last_action_position = action_position;	
					if (!Ladder.CheckParentCommon(program.Select_tags)) {
						Cursor = Cursors.No;
						break;
					}					   
					int retActiveCommand = Ladder.ActiveCommand(commands.INSERT_PREVIEW, action_position, program);
					if (retActiveCommand == -1 & action_position != activePositions.Null) {
						this.Cursor = Cursors.No;
					} else {
						SetCursorFunction(Cursor_Mode.insert);
					}
						
					Ladder_Draw.Invalidate();
					break;
			}
			
		}
		
		bool cursorOnSelect(Point cursor_mouse)
		{
			if (cursor_mouse.X > rectangle_select.X & cursor_mouse.X < rectangle_select.X + rectangle_select.Width)
			if (cursor_mouse.Y > rectangle_select.Y & cursor_mouse.Y < rectangle_select.Y + rectangle_select.Height)
				return true;
			return false;
		}
		void Ladder_panelMouseDown(object sender, MouseEventArgs e)
		{
			var me = (MouseEventArgs)e;
			Point cursor_mouse	= Ladder_Draw.PointToClient(Cursor.Position);	
			if (me.Button == MouseButtons.Left & cursor_Mode == Cursor_Mode.select_mode) {				
				SetCursorFunction(Cursor_Mode.draging);
				DragStart_Ladder_panel = cursor_mouse;
				rectangle_select = Rectangle.Empty;						
			}
			if (me.Button == MouseButtons.Left & cursor_Mode == Cursor_Mode.simulation) {				
				//SetCursorFunction(Cursor_Mode.draging);
				DragStart_Ladder_panel = cursor_mouse;
				rectangle_select = Rectangle.Empty;						
			}
		}
		void ElementCanInserted()
		{
			foreach (object elementObj in toolStrip_Element.Items) {
				//MessageBox.Show(elementObj.ToString());
			}
		}
		void Ladder_panelMouseUp(object sender, MouseEventArgs e)
		{
			var me = (MouseEventArgs)e;
			if (me.Button == MouseButtons.Left) {
				switch (cursor_Mode) {
					case Cursor_Mode.simulation:	
						if (rectangle_select.Width < 5) {
							int Tag_Size = 30;	
							rectangle_select.Y = Ladder_Draw.PointToClient(Cursor.Position).Y - Tag_Size;
							rectangle_select.X = Ladder_Draw.PointToClient(Cursor.Position).X - Tag_Size;
							rectangle_select.Height	= Tag_Size * 2;
							rectangle_select.Width	= Tag_Size * 2;	
						}
						program.SelectTags(rectangle_select, Ladder_Draw.PointToClient(Cursor.Position));   
						//toolTip_element.Hide(Ladder_Draw);
						
						if (program.Select_tags.Tags.Count == 1) {
							toolTip_element.ToolTipTitle = program.Select_tags.Tags[0].Name;
							toolTip_element.Show(program.Select_tags.Tags[0].getInfo(), Ladder_Draw, program.select_area.X + program.select_area.Width, program.select_area.Y);
						} else {
							toolTip_element.Hide(Ladder_Draw);
						}
						
						break;
					case Cursor_Mode.draging:
						if (rectangle_select.Width < 5) {
							int Tag_Size = 30;	
							rectangle_select.Y = Ladder_Draw.PointToClient(Cursor.Position).Y - Tag_Size;
							rectangle_select.X = Ladder_Draw.PointToClient(Cursor.Position).X - Tag_Size;
							rectangle_select.Height	= Tag_Size * 2;
							rectangle_select.Width	= Tag_Size * 2;	
						}
						program.SelectTags(rectangle_select, Ladder_Draw.PointToClient(Cursor.Position));    					
						SetCursorFunction(Cursor_Mode.select_mode);
						if (program.Rung_select == null) {
							btn_element_Contracs.Enabled = false;
							btn_element_Coil.Enabled = false;
							btn_element_CTD.Enabled = false;
							btn_element_CTU.Enabled = false;
							btn_element_Timers.Enabled = false;
							btn_element_CTC.Enabled = false;
							btn_element_Functions.Enabled = false;
							btn_element_Counters.Enabled = false;
							btn_element_Pluse.Enabled = false;
							btn_element_MasterRelay.Enabled = false;
							btn_element_Shift.Enabled = false;
							//tsb_Insert_up.Enabled = false;
							tsb_Copy_rung.Enabled = false;
							tsb_Move_down.Enabled = false;
							tsb_Move_up.Enabled = false;
							tsb_delete_rung.Enabled = false;
							btn_element_Comment.Enabled = false;
							
						} else {
							ActiveElementsButton();
						}
						if (program.Select_tags.Tags.Count == 1) {
							toolTip_element.ToolTipTitle = program.Select_tags.Tags[0].Name;
							toolTip_element.Show(program.Select_tags.Tags[0].getInfo(), Ladder_Draw, program.select_area.X + program.select_area.Width, program.select_area.Y);
						} else {
							toolTip_element.Hide(Ladder_Draw);
						}
						break;
					case Cursor_Mode.insert:
						activePositions action_position	= program.InselectTag(Ladder_Draw.PointToClient(Cursor.Position).X, Ladder_Draw.PointToClient(Cursor.Position).Y);
						Ladder.ActiveCommand(commands.INSERT_TAG, action_position, program);
						SetCursorFunction(Cursor_Mode.select_mode);
						CreateListElement();
						ActiveElementsButton();						
						break;
      				
				}
				Ladder_Draw.Invalidate();
      			
			}			
			int cursor_X	= Ladder_Draw.PointToClient(Cursor.Position).X;
			int cursor_Y	= Ladder_Draw.PointToClient(Cursor.Position).Y;
			if (me.Button == MouseButtons.Right) {
				switch (cursor_Mode) {
					case Cursor_Mode.select_mode:
						if (program.Select_tags.Tags.Count == 1) {
							if (program.On_selected_area(cursor_X, cursor_Y))
								contexMenu_Element.Show(Cursor.Position);
						}
						if (program.Select_tags.Tags.Count == 0 & program.Rung_select != null) {
							if (program.Rung_select.DrawPoint_Org.X < cursor_X & program.Rung_select.DrawPoint.X > cursor_X)
							if (program.Rung_select.DrawPoint_Org.Y < cursor_Y & program.Rung_select.DrawPoint.Y > cursor_Y)
								contextMenu_rung.Show(Cursor.Position);
						}							
						break;     						
				}
			}
			panel_Ladder.Focus();
		}

		Point DragStart = Point.Empty;
		
		RectangleF recpoint =	RectangleF.Empty;
		RectangleF rec_tag_preview =	RectangleF.Empty;
			
		int ActiveElementsButton()
		{	
			var temp_tag = new Elements();
			bool active_button;
			foreach (TypeTag type_element in Enum.GetValues(typeof(TypeTag))) {	
				active_button = false;
				temp_tag.Type = type_element;
				foreach (activePositions act in Enum.GetValues(typeof(activePositions))) {
					active_button |= Ladder.Can_Preview(temp_tag, act);
				}
				switch (type_element) {
					case TypeTag.CONTACTS:
					case TypeTag.OPEN:	
					case TypeTag.SHORT:
					case TypeTag.FCP:	
						btn_element_Compare.Enabled = active_button;
						btn_element_CTC.Enabled = active_button;
						btn_element_Contracs.Enabled = active_button;
						btn_other.Enabled = active_button;
						break;
					case TypeTag.COMMENT:
						btn_element_Comment.Enabled = active_button;
						break;
					case TypeTag.MOVE:	
					case TypeTag.ADD:	
					case TypeTag.SUB:	
					case TypeTag.MUL:	
					case TypeTag.DIV:	
					case TypeTag.MOD:	
					case TypeTag.ADC:
						btn_element_Functions.Enabled = active_button;
						break;
					case TypeTag.MASTER_RELAY:
						btn_element_MasterRelay.Enabled = active_button;
						break;
					case TypeTag.COIL:
						btn_element_Coil.Enabled = active_button;
						btn_element_CTD.Enabled = active_button;
						btn_element_CTU.Enabled = active_button;						
						break;
					case TypeTag.TOF:
					case TypeTag.TON:
					case TypeTag.TPC:
						btn_element_Timers.Enabled = active_button;
						break;
					case TypeTag.OSF:
					case TypeTag.OSR:
						btn_element_Pluse.Enabled = active_button;
						break;
					case TypeTag.UART_RECV:
					case TypeTag.UART_SEND:
						Btn_Communication.Enabled = active_button;
						break;
					case TypeTag.SHIFT_LEFT:
					case TypeTag.SHIFT_RIGHT:
					case TypeTag.SHIFT_REG_INBIT:
					case TypeTag.SHIFT_REG_RESET:
						btn_element_Shift.Enabled = active_button;
						btn_element_Shift_Contracs.Enabled = active_button;
						break;
				}
				
				btn_element_Counters.Enabled = btn_element_CTC.Enabled || btn_element_CTD.Enabled || btn_element_CTU.Enabled;
				
				//btn_element_Functions.Enabled = btn_element_Compare.Enabled;
			
			}
			//tsb_Insert_up.Enabled = true;
			tsb_Copy_rung.Enabled = true;
			tsb_Move_down.Enabled = true;
			tsb_Move_up.Enabled = true;
			tsb_delete_rung.Enabled = true;
			return 0;
		}
		string ldtoStrCode()
		{
			string strIO_List = "# LD FORMAT copy Form LDMICRO#\nHARDWARE\n"
			                    + Ladder.Hardware_name + "\nIO LIST\n";
			//int strIO_map;
			foreach (ListViewItem item in listView_Map_I.Items) {
				//if (int.TryParse(item.SubItems[1].Text.Substring(1), out strIO_map))
				
				strIO_List += item.SubItems[0].Text + " at " + item.SubItems[1].Text + "\n";
			}
			foreach (ListViewItem item in listView_Map_O.Items) {
				//if (int.TryParse(item.SubItems[1].Text.Substring(1), out strIO_map))
				strIO_List += item.SubItems[0].Text + " at " + item.SubItems[1].Text + "\n";
			}
			strIO_List += "END\n";
			string ladderstr = strIO_List + "PROGRAM\n";
			foreach (Rung rung in program.rungs) {
				ladderstr += Ladder.ExportRungLd(rung);
			}
			return ladderstr;
		}
		void SaveToFileLD(string strfilepath)
		{
			var ladderstr = ldtoStrCode();
			
			if (strfilepath.IndexOf(".ld.ld", StringComparison.Ordinal) > -1)
				strfilepath = strfilepath.Substring(0, strfilepath.Length - 3);
			try {
				File.WriteAllText(strfilepath, ladderstr);
				Ladder.SaveStratus = false;
				Text = string.Format("{0} - {1}", TitleStr, openFileDialogLadder.FileName);
				MessageBox.Show(ladderstr, "Save File", MessageBoxButtons.OK, MessageBoxIcon.Information);
		
			} catch (UnauthorizedAccessException e) {
				if (MessageBox.Show("Can'n save to file! \n Save as ?", "ERROR UnauthorizedAccessException", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK) {
					SaveAsToolStripMenuItemClick(null, null);
					openFileDialogLadder.FileName = saveFileDialogLadder.FileName;
					Text = string.Format("{0} - {1}", TitleStr, openFileDialogLadder.FileName);
				}
			}
			
		}
		void _SaveSetting()
		{
			var cvt = new FontConverter();        	
			//Font f = cvt.ConvertFromString(s) as Font;
			string path_Setting_File = Application.StartupPath + @"\setting";
			string setting_data = "Setting Data\n";
			string str_font = cvt.ConvertToString(DrawingTags.drawFont);
			setting_data += string.Format("_font_Tag_Name:{0}\n", str_font);

			str_font = cvt.ConvertToString(DrawingTags.drawFont_Symbol);
			setting_data += string.Format("_font_Tag_Symbol:{0}\n", str_font);
			
			str_font = ColorTranslator.ToHtml(DrawingTags.color_string_draw);
			setting_data += string.Format("_font_color_string_draw:{0}\n", str_font);
			
			str_font = ColorTranslator.ToHtml(DrawingTags.color_symbol_draw);
			setting_data += string.Format("_font_color_symbol_draw:{0}\n", str_font);
			
			str_font = ColorTranslator.ToHtml(DrawingTags.color_draw_bg);
			setting_data += string.Format("color_draw_bg:{0}\n", str_font);
			
			str_font = ColorTranslator.ToHtml(DrawingTags.color_draw);
			setting_data += string.Format("color_draw:{0}\n", str_font);
			
			File.WriteAllText(path_Setting_File, setting_data);
			
		}
		String HexConverter(Color c)
		{
			return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
		}
		void _ReadSetting()
		{
			var cvt = new FontConverter();
        	
			try {
				string path_Setting_File = Application.StartupPath + @"\setting";
				string str_Setting = File.ReadAllText(path_Setting_File);
				string[] _setting = str_Setting.Split(new string[] {
					"\n",
					"\r\n"
				}, StringSplitOptions.RemoveEmptyEntries);
				if (_setting.Length < 1)
					return;				
				foreach (string s in _setting) {
					string[] _s = s.Split(':');
					if (_s.Length < 2)
						continue;						
					
					switch (_s[0]) {
						case "_font_Tag_Name":
							DrawingTags.drawFont = cvt.ConvertFromString(_s[1]) as Font;
							break;

						case "_font_Tag_Symbol":
							DrawingTags.drawFont_Symbol = cvt.ConvertFromString(_s[1]) as Font;
							break;
						case "_font_color_string_draw":						
							DrawingTags.color_string_draw = ColorTranslator.FromHtml(_s[1]);
							break;
						case "_font_color_symbol_draw":						
							DrawingTags.color_symbol_draw = ColorTranslator.FromHtml(_s[1]);
							break;
						case "color_draw_bg":						
							//DrawingTags.color_draw_bg = Color.FromArgb(Int32.Parse(_s[1],NumberStyles.HexNumber));
							DrawingTags.color_draw_bg = ColorTranslator.FromHtml(_s[1]);
							break;
						case "color_draw":						
							DrawingTags.color_draw = ColorTranslator.FromHtml(_s[1]);
							break;
					}
				}
				
			} catch (IOException e) {
				MessageBox.Show(e.ToString());
			}
			
		}
		
		void NewToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (program.rungs.Count > 0) {
				DialogResult retSave = MessageBox.Show("ต้องการบันทึกงานที่ดำเนินการอยู่หรือไม่", "Save File?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
				switch (retSave) {
					case DialogResult.Cancel:					
						return;
					case DialogResult.Yes:	
						if (saveFileDialogLadder.ShowDialog(this) == DialogResult.OK) {
							SaveToFileLD(saveFileDialogLadder.FileName + ".ld");
						} else {
							return;
						}						
						break;			
				}			
			}
			Ladder.SaveStratus = true;
			program.rungs.Clear();
			program.ClearSelectTags();
			program.rungs.Add(new Rung());
			Ladder_Draw.Invalidate();
			Ladder.Index_Name = 1;
			Text = TitleStr + " - (New Ladder File)";
			openFileDialogLadder.FileName = "";
			Ladder.VariablePLCLib_element.Clear();
			listView_Map_I.Items.Clear();
			listView_Map_O.Items.Clear();
			listView_elements.Items.Clear();
		}
		void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (Ladder.saveStratus) {
				DialogResult retdialog = MessageBox.Show("ต้องการบันทึกงานที่ดำเนินการอยู่หรือไม่ ?", "SAVE LADDER FILE", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
				switch (retdialog) {
					case DialogResult.Yes:
						SaveToolStripMenuItemClick(sender, e);
						break;
					case DialogResult.Cancel:
						return;
				}
			}
			if (openFileDialogLadder.FileName == null)
				openFileDialogLadder.FileName = "";
			if (openFileDialogLadder.ShowDialog() == DialogResult.OK) {
				SelectHardware(ts_no_hw, null);
				ImportFormFile(openFileDialogLadder.FileName);
				Text = string.Format("{0} - {1}", TitleStr, openFileDialogLadder.FileName);
				Ladder.SaveStratus = false;
				Ladder_Draw.Invalidate();
				CreateListElement();	
				ts_Hardware_name.Text = Ladder.Hardware_name;
				foreach (ToolStripMenuItem tsm in tsmunu_hardware.DropDownItems) {
					if (Ladder.Hardware_name == tsm.Text) {
						SelectHardware(tsm, null);
						break;	
					}
				}
				//Ladder_panel.Invalidate();	
			}		
					
		}
		int no_rung	=	0;
		void ImportFormFile(string file)
		{
			try {
				string ladderstr = File.ReadAllText(file);
				string[] ladders = ladderstr.Split(new string[] {
					"\n",
					"\r\n"
				}, StringSplitOptions.RemoveEmptyEntries);
				ladderstr = "";
				string strIO_List = "";
				program.rungs.Clear();
				program.ClearSelectTags();
				int endrung = -1;
				bool DefineHW = false;
				bool endIO_List = true;	
				Ladder.Hardware_name = "Not setting";
				foreach (string s in ladders) {
					if (DefineHW) {
						Ladder.Hardware_name = s;
						DefineHW = false;
					}
					if (s == "HARDWARE") {
						DefineHW = true;
					}
					if (s == "IO LIST") {
						endIO_List = false;
						DefineHW = false;
					}
					if (!endIO_List) {
						strIO_List += s;
						strIO_List += "\n";
						if (s == "END") {
							endIO_List = true;
							Ladder.strIO_List_To_elements(strIO_List);
						}                			
					}
                	
					if (s == "PROGRAM") {
						no_rung	=	1;
						++endrung;
						program.rungs.Clear();
					} else if (s == "RUNG") {
						++endrung;                           
						ladderstr = "RUNG\n";
					} else if ((s == "END") & endrung > 0) {
						--endrung;
						ladderstr += s;
						ladderstr += '\n';
						if (endrung == 0) {
							program.rungs.Add(Ladder.strLadderToRung(ladderstr));
							program.rungs[program.rungs.Count - 1].Id_rung	= no_rung;
							++no_rung;
						}
                                    
					} else if (s == "SERIES") {
						++endrung;
						ladderstr += s;
						ladderstr += '\n';
					} else if (s == "PARALLEL") {
						--endrung;
						ladderstr += s;
						ladderstr += '\n';
					} else {
						if (endrung > 0) {
							ladderstr += s;
							ladderstr += '\n';
						}
					}
					//End_IO_List:
				}
				Ladder.VariablePLCLib_element.Clear();
				Ladder.GenVariablePLCLib();
				foreach (Elements iotag in Ladder.IOelement_tags) {	
					foreach (Elements tag in Ladder.VariablePLCLib_element) {
						if (iotag.Name == tag.Name)
						if (iotag.Type == tag.Type) {
							tag.IO_Port = iotag.IO_Port;
						}						
					}				
				}
			} catch (IOException e) {
				MessageBox.Show(e.ToString());
			}
		}

		void Ladder_panelDoubleClick(object sender, EventArgs e)
		{
			var me = (MouseEventArgs)e;
			DialogResult retPrtElement;
			if (me.Button == MouseButtons.Left) {
				if (program.Select_tags.Tags.Count == 1) {
					Elements selectTag = program.Select_tags.Tags[0];	
					if (cursor_Mode == Cursor_Mode.simulation) {
						if (selectTag.Type == TypeTag.CONTACTS & selectTag.Name.Substring(0, 1) == "X")
							foreach (Elements simulationTag in Ladder.Element_tags) {
								if (selectTag.Name == simulationTag.Name) {
									simulationTag.Startus = !simulationTag.Startus;
									program.Update_Common_Element(simulationTag);
									break;
								}
							}
						if (selectTag.Type == TypeTag.ADC & selectTag.Name.Substring(0, 1) == "A") {
							Input_Analog input_dialog = new Input_Analog(selectTag);
							input_dialog.ShowDialog();
						}
						return;
					}
					switch (selectTag.Type) {
						case TypeTag.CONTACTS:
						case TypeTag.COIL:								
							var propertiesElement = new PropertiesElement(selectTag);
							retPrtElement = propertiesElement.ShowDialog();	
							if (retPrtElement == DialogResult.OK) {
								bool removeVar = false;
								foreach (Elements tempVar in Ladder.VariablePLCLib_element) {
									if (selectTag != tempVar)
									if (selectTag.Name == tempVar.Name)
										removeVar = true;
								}
								if (removeVar)
									Ladder.VariablePLCLib_element.Remove(selectTag);
								CreateListElement();
								if (selectTag.Name.Substring(0, 1) == "C")
									program.Update_Common_Element(selectTag);
							}
								
							break;
						case TypeTag.COMMENT:
							var propertiesComment = new Properties_Comment(selectTag);
							retPrtElement = propertiesComment.ShowDialog();	
							break;
						case TypeTag.TOF:	
						case TypeTag.TON:
						case TypeTag.TPC:							
							var Properties_Timer = new Properties_Timer(selectTag);
							retPrtElement = Properties_Timer.ShowDialog();
							if (retPrtElement == DialogResult.OK) {
								CreateListElement();
								program.Update_Common_Element(selectTag);
							}								
							break;
						case TypeTag.FCP:							
							var Properties_FCP = new Properties_FCP(selectTag);
							retPrtElement = Properties_FCP.ShowDialog();
							if (retPrtElement == DialogResult.OK) {
								CreateListElement();
								//program.Update_Common_Element(selectTag);
							}								
							break;
						case TypeTag.MOVE:	
						case TypeTag.ADD:
						case TypeTag.SUB:	
						case TypeTag.MUL:
						case TypeTag.DIV:
						case TypeTag.MOD:
						case TypeTag.ADC:							
							var Properties_Var = new Properties_Variable(selectTag);
							retPrtElement = Properties_Var.ShowDialog();
							if (retPrtElement == DialogResult.OK) {
								CreateListElement();
//								if(selectTag.Type == TypeTag.ADC)
//									program.Update_Common_Element(selectTag);
							}								
							break;
						case TypeTag.SHIFT_LEFT:	
						case TypeTag.SHIFT_RIGHT:
						case TypeTag.SHIFT_REG_INBIT:	
						case TypeTag.SHIFT_REG_RESET:
						case TypeTag.SHIFT_REGISTERS:						
							var Properties_Shift_reg = new Properties_Shift_Reg(selectTag);
							retPrtElement = Properties_Shift_reg.ShowDialog();
							if (retPrtElement == DialogResult.OK) {
								CreateListElement();
//								if(selectTag.Type == TypeTag.ADC)
//									program.Update_Common_Element(selectTag);
							}								
							break;
						case TypeTag.SHIFT_VARIABLE:
							var Properties_Shift_variable = new Properties_Shift_Variable(selectTag);
							retPrtElement = Properties_Shift_variable.ShowDialog();
							if (retPrtElement == DialogResult.OK) {
								Ladder.buildVariablePLCLib();
								CreateListElement();
								Ladder.buildVariablePLCLib();
							}	
							break;
						default :
							MessageBox.Show(selectTag.Type.ToString(), "No Config Elements!");
							break;
					}
					
				}					
			}
			
		}
		void MainFormResize(object sender, EventArgs e)
		{
			Ladder_Draw.Invalidate();
		}
		
		void CreateListElement()
		{				
			program.CreateListElements();
			richTextBox1.Text = Gen_Code();
			listView_elements.Items.Clear();
			listView_Map_I.Items.Clear();
			listView_Map_O.Items.Clear();
//			int index_item = 0;
//			bool addIO = true;
			string strIO = "Null";
//			foreach (Elements tag in Ladder.Element_tags) {
//				if (tag.Type == TypeTag.FCP)
//					continue;
//				if (tag.Type == TypeTag.OSR)
//					continue;
//				if (tag.Type == TypeTag.OSF)
//					continue;
//				if (tag.Type == TypeTag.MASTER_RELAY)
//					continue;
//				if (tag.Type == TypeTag.SHIFT_VARIABLE)
//					continue;
//				var item = new ListViewItem(tag.Name);
//				if (tag.Type != TypeTag.MOVE) {
//					item.SubItems.Add(tag.Type.ToString());
//				} else {
//					item.SubItems.Add("int16");
//				}				
//				
//				switch (tag.Name.Substring(0, 1)) {
//					case "R":
//						item.SubItems.Add("Relay");
//						break;
//					case "T":
//						item.SubItems.Add("Timer");
//						break;
//					case "C":
//						item.SubItems.Add("Counter");
//						break;
//					case "A":						
//					case "X":
//						switch (tag.Name.Substring(0, 1)) {
//							case "A":	
//								item.SubItems.Add("Analog-In");	
//								break;
//							case "X":	
//								item.SubItems.Add("X-In");	
//								break;
//						}						
//						break;
//					case "Y":						
//						item.SubItems.Add("Y-Out");						
//						break;
//					default:
//						item.SubItems.Add("Variable");
//						break;
//				}
//				item.SubItems.Add(index_item.ToString());
//				addIO = true;
//				foreach (ListViewItem item_name in listView_elements.Items) {
//					if (item_name.Text == tag.Name)
//					if (item_name.SubItems[1].Text == item.SubItems[1].Text) {
//						addIO = false;
//						break;
//					}					
//				}
//				if (addIO)
//					//listView_elements.Items.Add(item);
//				index_item++;					
//			}			
//			//Ladder.buildVariablePLCLib();
			
			foreach (Elements temp_var in Ladder.VariablePLCLib_element) {
				//addIO = true;
				var item = new ListViewItem(temp_var.Name);
				switch (temp_var.Type) {
					case TypeTag.CONTACTS:
						var item_Input = new ListViewItem(temp_var.Name);	
						strIO = temp_var.IO_Port;						
						if (temp_var.IO_Port == "")
							strIO = "-";
						item_Input.SubItems.Add(strIO);
						item_Input.ToolTipText = item_Input.Name;	
						listView_Map_I.Items.Add(item_Input);	
						
//						item.SubItems.Add("Contrac");
//						item.SubItems.Add("X-Input");
//						listView_elements.Items.Add(item);							
						break;
					case TypeTag.ADC:
						item_Input = new ListViewItem(temp_var.Name);	
						strIO = temp_var.IO_Port;						
						if (temp_var.IO_Port == "")
							strIO = "-";
						item_Input.SubItems.Add(strIO);
						item_Input.ToolTipText = item_Input.Name;	
						listView_Map_I.Items.Add(item_Input);	
						
//						item.SubItems.Add("Analog");
//						item.SubItems.Add("A-Input");
//						listView_elements.Items.Add(item);							
						break;
						
					case TypeTag.COIL:
						if (temp_var.Name.Substring(0, 1) == "Y") {
							var item_Output = new ListViewItem(temp_var.Name);							
							strIO = temp_var.IO_Port;
							
							if (temp_var.IO_Port == "")
								strIO = "-";
							item_Output.SubItems.Add(strIO);
							item_Output.ToolTipText = item_Output.Name;								
							listView_Map_O.Items.Add(item_Output);	
							
//							item.SubItems.Add("Coil");
//							item.SubItems.Add("Y-Output");
//							listView_elements.Items.Add(item);							
						}
						if (temp_var.Name.Substring(0, 1) == "C") {
							
							item.SubItems.Add("Counter");
							item.SubItems.Add(temp_var._ct.ToString());
							listView_elements.Items.Add(item);	
						}
						if (temp_var.Name.Substring(0, 1) == "R") {
							
							item.SubItems.Add("Relay");
							item.SubItems.Add(temp_var.Startus.ToString());
							listView_elements.Items.Add(item);	
						}
						break;
					case TypeTag.OSF:
					case TypeTag.OSR:	
					
					//case TypeTag.TON:
					//case TypeTag.TPC:
					case TypeTag.SHIFT_VARIABLE:
						continue;
					case TypeTag.TOF:
						item.SubItems.Add("Delay Off");
						item.SubItems.Add(string.Format("{0} ms", temp_var.Properties_value));
						listView_elements.Items.Add(item);
						
						break;
					case TypeTag.TON:
						item.SubItems.Add("Delay On");
						item.SubItems.Add(string.Format("{0} ms", temp_var.Properties_value));
						listView_elements.Items.Add(item);
						break;
					case TypeTag.TPC:
						item.SubItems.Add("Pulse");
						item.SubItems.Add(string.Format("{0},{1}", temp_var.Properties_value, temp_var.Properties_value1));
						listView_elements.Items.Add(item);
						break;
					case TypeTag.MOVE:
						item.SubItems.Add("int16");
						item.SubItems.Add(temp_var.Properties_value.ToString());
						listView_elements.Items.Add(item);
						break;
					default:
						item.SubItems.Add(temp_var.Properties_value.ToString());
						item.SubItems.Add(temp_var.Type.ToString());
						listView_elements.Items.Add(item);
						break;
				}		
			}						
		}
		
		
		string GetArduino_UNOPin_Name(int port_io)
		{
			if (port_io < 14)
				return string.Format("D{0}", port_io);
			if (port_io >= 100)
				return string.Format("A{0}", port_io - 100);
			return "N/A";
		}
		int Find_Ref_Tag(Elements selecttag)
		{
			int ret = 0;
//			foreach (ListViewItem item in listView_elements.Items) {
//				if (item.Selected) {
//					int index_item = int.Parse(item.SubItems[3].Text);
//					if (index_item < 0)
//						break;
//					Elements temp_select = Ladder.Element_tags[index_item];
//					ret = program.SetSelectElement(temp_select);
//					break;
//				}
//			}
			if (selecttag == null) {
				if (listView_elements.SelectedItems.Count < 1)
					return 0;
				Elements temptag = new Elements(TypeTag.Null, listView_elements.SelectedItems[0].Text, null);
				switch (listView_elements.SelectedItems[0].SubItems[1].Text) {
					case "Contrac":
						temptag.Type = TypeTag.CONTACTS;
						break;
					case "Relay":
						temptag.Type = TypeTag.COIL;
						break;
					case "Delay Off":
						temptag.Type = TypeTag.TOF;
						break;
					case "Delay On":
						temptag.Type = TypeTag.TON;
						break;
					case "Pulse":
						temptag.Type = TypeTag.TPC;
						break;
					case "FCP":
						temptag.Type = TypeTag.FCP;
						break;
					case "int16":
						temptag.Type = TypeTag.MOVE;
						break;
					case "Analog":
						temptag.Type = TypeTag.ADC;
						break;
				}
				selecttag = temptag;
			}
			
			ret = program.SetSelectElement(selecttag);	
			
			Ladder_Draw.Invalidate();
			return ret;
		}
		void ToolStripMenuItem2Click(object sender, EventArgs e)
		{
			//MessageBox.Show(Find_Ref_Tag().ToString(),"Find Ref Tag");
			Find_Ref_Tag(null);
		}
		
	
		
		void Delete_RungClick(object sender, EventArgs e)
		{
			if (program.Rung_select != null) {
				DialogResult daiRes = MessageBox.Show("ยืนยันการลบ Rung ID " + program.Rung_select.Id_rung.ToString("00"), "Delete Rung!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
				if (daiRes == DialogResult.OK) {
					program.rungs.Remove(program.Rung_select);
					CreateListElement();
					//Find_Ref_Tag(null);
					Ladder_Draw.Invalidate();
				}
			}
		}
		
		void Btn_Rung_Move_UpClick(object sender, EventArgs e)
		{
			Rung temp_rung = program.Rung_select;
			int index_rung = program.rungs.IndexOf(program.Rung_select);
			if (index_rung == 0)
				return;
			if (index_rung != -1) {
				program.rungs.Remove(temp_rung);
				program.rungs.Insert(index_rung - 1, temp_rung);
				Ladder_Draw.Invalidate();
			}			
		}
		
		void Btn_Rung_Move_DownClick(object sender, EventArgs e)
		{
			Rung temp_rung = program.Rung_select;
			int index_rung = program.rungs.IndexOf(program.Rung_select);
			if (index_rung == program.rungs.Count - 1)
				return;
			if (index_rung != -1) {
				program.rungs.Remove(temp_rung);
				program.rungs.Insert(index_rung + 1, temp_rung);
				Ladder_Draw.Invalidate();
			}
		}
		
		
		void Delete_ElementClick(object sender, EventArgs e)
		{
			if (MessageBox.Show(program.Select_tags.Tags[0].Name, "Delete Tag", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK) {
				Ladder.ActiveCommand(commands.DELECT_TAG, activePositions.On_Tag, program);
				Ladder_Draw.Invalidate();
							
				program.CreateListElements();
				Ladder.buildVariablePLCLib();	
				CreateListElement();
			}
		}
		
		void Find_Ref_ElementsClick(object sender, EventArgs e)
		{
			Ladder.setfindRef = true;		
			Find_Ref_Tag(program.Select_tags.Tags[0]);
			Ladder.setfindRef = false;
		}
		// Element Click Code!
		void Btn_elements_Click(object sender, EventArgs e)
		{
			string strElement = "null";
			var btn	= sender as ToolStripButton;
			if (btn == null) {
				var mtn = sender as ToolStripMenuItem;
				if (mtn == null)
					return;	
				strElement = mtn.Text;
			} else {
				strElement = btn.Text;
			}
				
			var insert_Tag = new Elements(TypeTag.Null, "insert_Tag", null);
			switch (strElement) {
				case "Comment":
					insert_Tag.Type = TypeTag.COMMENT;
					insert_Tag.Name = "_COMMENT_";
					break;	
				case "Contracs":
					insert_Tag.Type = TypeTag.CONTACTS;
					insert_Tag.Name = "Xnew";
					break;				
				case "Coils":
					insert_Tag.Type = TypeTag.COIL;
					insert_Tag.Name = "Ynew";
					break;
				case "Shift Contrac":
					insert_Tag.Type = TypeTag.SHIFT_REGISTERS;
					insert_Tag.Name = "Snew";
					break;
				case "Shift Control":
					insert_Tag.Type = TypeTag.SHIFT_REGISTERS;
					insert_Tag.Name = "Snew";
					insert_Tag.Properties = "0";
					break;
				case "Shift Registers":
					insert_Tag.Type = TypeTag.SHIFT_VARIABLE;
					insert_Tag.Name = "reg";
					insert_Tag.Properties = "7";
					break;
				case "Master Relay":
					insert_Tag.Type = TypeTag.MASTER_RELAY;
					insert_Tag.Name = "Master_Relay";
					break;
				case "Timer On Delay":
					insert_Tag.Type = TypeTag.TON;
					insert_Tag.Name = "Tnew";
					break;
				case "Timer Off Delay":
					insert_Tag.Type = TypeTag.TOF;
					insert_Tag.Name = "Tnew";
					break;
				case "Timer Pluse Cycle":
					insert_Tag.Type = TypeTag.TPC;
					insert_Tag.Name = "Tnew";
					break;
				case "Counter Down":
					insert_Tag.Type = TypeTag.COIL;
					insert_Tag.Name = "Cnew";
					break;
				case "Counter Up":
					insert_Tag.Type = TypeTag.COIL;
					insert_Tag.Name = "Cnew";
					break;
				case "Counter Contrac":
					insert_Tag.Type = TypeTag.CONTACTS;
					insert_Tag.Name = "Cnew";
					insert_Tag.Properties_setOnly = true;
					break;
				case "Move":
					insert_Tag.Type = TypeTag.MOVE;
					insert_Tag.Name = "Vnew";
					insert_Tag.Properties = "0";
					break;
				case "Compare":
					insert_Tag.Type = TypeTag.FCP;
					insert_Tag.Name = "Vnew";
					insert_Tag.Properties = "== Var2";
					break;
					
				case "Add [+=]":
					insert_Tag.Type = TypeTag.ADD;
					insert_Tag.Name = "Vnew";
					insert_Tag.Properties = "Vnew 0";
					break;
				case "Sub [-=]":
					insert_Tag.Type = TypeTag.SUB;
					insert_Tag.Name = "Vnew";
					insert_Tag.Properties = "Vnew 0";
					break;
				case "Mup [*=]":
					insert_Tag.Type = TypeTag.MUL;
					insert_Tag.Name = "Vnew";
					insert_Tag.Properties = "Vnew 0";
					break;
				case "Div [/=]":
					insert_Tag.Type = TypeTag.DIV;
					insert_Tag.Name = "Vnew";
					insert_Tag.Properties = "Vnew 0";
					break;
				case "Mod [%=]":
					insert_Tag.Type = TypeTag.MOD;
					insert_Tag.Name = "Vnew";
					insert_Tag.Properties = "Vnew 0";
					break;
				case "A/D CONVERTER READ":
					insert_Tag.Type = TypeTag.ADC;
					insert_Tag.Name = "Anew";
					insert_Tag.Properties = "n/a";
					break;
					
				case "OSR (One Shot Rising)":
					insert_Tag.Type = TypeTag.OSR;
					insert_Tag.Name = "OSR";
					break;
				case "OSF (One Shot Falling)":
					insert_Tag.Type = TypeTag.OSF;
					insert_Tag.Name = "OSF";
					break;
				case "Open Circuit":
					insert_Tag.Type = TypeTag.OPEN;
					insert_Tag.Name = "Open";
					break;
				case "Short Circuit":
					insert_Tag.Type = TypeTag.SHORT;
					insert_Tag.Name = "Short";
					break;
				case "UART Send":
					insert_Tag.Type = TypeTag.UART_SEND;
					insert_Tag.Name = "u_send";
					break;
				case "UART Recv":
					insert_Tag.Type = TypeTag.UART_RECV;
					insert_Tag.Name = "u_recv";
					break;
				case "null":
					return;
			}
			
			Ladder.Set_Tag_Insert(insert_Tag);        	
			SetCursorFunction(Cursor_Mode.insert);
			
		}

		void SaveAsToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (program.rungs.Count == 0) {
				return;
			}
			if (saveFileDialogLadder.ShowDialog(this) == DialogResult.OK)
				SaveToFileLD(saveFileDialogLadder.FileName + ".ld");
		}
		
		void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (Ladder.SaveStratus & openFileDialogLadder.FileName == "") {
				SaveAsToolStripMenuItemClick(sender, e);
				return;
			}
			if (program.rungs.Count > 0)
				SaveToFileLD(openFileDialogLadder.FileName + ".ld");
		}
		void ListView_Map_IDoubleClick(object sender, EventArgs e)
		{			
			ListViewItem item = listView_Map_I.FocusedItem;
			if (item == null)
				return;
			Elements tagSelect = null;
			foreach (Elements tag in Ladder.VariablePLCLib_element) {
				if (item.Text == tag.Name & (tag.Type == TypeTag.CONTACTS || tag.Type == TypeTag.ADC)) {
					tagSelect = tag;
					break;
				}
			}
			if (DrawingTags.simulation_startus) {
				switch (tagSelect.Type) {
					case TypeTag.CONTACTS:
						tagSelect.Startus = !tagSelect.Startus;
						program.Update_Common_Element(tagSelect);						
						break;
					case TypeTag.ADC:
//						Input_Analog input_dialog = new Input_Analog(tagSelect);
//						input_dialog.ShowDialog();	
						//program.Update_Common_Element(tagSelect);						
						break;
				}
				return;
			}			
			DialogResult retMapIO;	
			if (tagSelect != null)
				switch (Ladder.Hardware_name) {
					case "ArUnitControl 32IO":
						MapIOPorts mapIoPorts = new MapIOPorts(tagSelect);
						retMapIO = mapIoPorts.ShowDialog();	
						if (retMapIO == DialogResult.Cancel)
							CreateListElement();
						break;	
					case "Arduino UNOR3":
						arduino_unoMapIO mapIoArduino = new arduino_unoMapIO(tagSelect);
						retMapIO = mapIoArduino.ShowDialog();
						if (retMapIO == DialogResult.Cancel)
							CreateListElement();
						break;
				}
		}
		void ListView_Map_OMouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (DrawingTags.simulation_startus)
				return;
			ListViewItem item = listView_Map_O.FocusedItem;
			if (item == null)
				return;
			Elements tagSelect = null;
			foreach (Elements tag in Ladder.Element_tags) {
				if (item.Text == tag.Name & tag.Type == TypeTag.COIL) {
					tagSelect = tag;
					break;
				}
			}
			DialogResult retMapIO;	
			if (tagSelect != null)
				switch (Ladder.Hardware_name) {
					case "ArUnitControl 32IO":
						MapIOPorts mapIoPorts = new MapIOPorts(tagSelect);
						retMapIO = mapIoPorts.ShowDialog();	
						if (retMapIO == DialogResult.Cancel)
							CreateListElement();
						break;	
					case "Arduino UNOR3":
						arduino_unoMapIO mapIoArduino = new arduino_unoMapIO(tagSelect);
						retMapIO = mapIoArduino.ShowDialog();	
						if (retMapIO == DialogResult.Cancel)
							CreateListElement();
						break;
				}
		}
		
		void Propertes_elementClick(object sender, EventArgs e)
		{
			if (program.Select_tags.Tags.Count == 1) {
				PropertiesElement propertiesElement = new PropertiesElement(program.Select_tags.Tags[0]);
				DialogResult retPrtElement = propertiesElement.ShowDialog();	
				if (retPrtElement == DialogResult.OK)
					CreateListElement();
			}
		}
		void Add_rung_UpClick(object sender, EventArgs e)
		{
			int index_rungActive = program.rungs.IndexOf(program.Rung_select);
			program.rungs.Insert(index_rungActive, new Rung());
			Ladder_Draw.Invalidate();
		}
		void Add_rung_DownClick(object sender, EventArgs e)
		{
			int index_rungActive = program.rungs.IndexOf(program.Rung_select);
			program.rungs.Insert(index_rungActive + 1, new Rung());
			Ladder_Draw.Invalidate();
		}
		void Add_new_rung(object sender, EventArgs e)
		{
			//int index_rungActive = program.rungs.IndexOf(program.Rung_select);
			program.rungs.Add(new Rung());
			Ladder_Draw.Invalidate();
		}
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			_SaveSetting();
			if (Ladder.SaveStratus) {
				if (program.rungs.Count > 0) {
					DialogResult retSave = MessageBox.Show("ต้องการบันทึกงานที่ดำเนินการอยู่หรือไม่", "Close Program?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
					switch (retSave) {
						case DialogResult.Cancel:
							e.Cancel = true;					
							return;
						case DialogResult.Yes:	
							SaveToolStripMenuItemClick(sender, e);
						
							break;			
					}			
				}

			}
		}
		internal void settoolStripProgressBar(int value)
		{
			toolStripProgressBar1.Value = value;
		}
		internal void settoolStripPortname(string value)
		{
			toolStripStatusLabel_PortInfo.Text = value;
		}
		internal void setComText_simulation(string value)
		{
			richTextBox1.AppendText(value);
			richTextBox1.SelectionStart = richTextBox1.Text.Length;
			richTextBox1.ScrollToCaret();
		}
		string Gen_Code()
		{
			string strCodeGen;
			string strGenIO = Ladder.GenVariablePLCLib();
			string strGenscanIO = "";
			string strGenMapio;
			string strConfigPin = "";
			string strInputMode = "";
			if (!Ladder.Input_Active_Mode)
				strInputMode = "Not";
			string str_Input = "";
			string str_Output = "";
			string str_configUART = "";
			foreach (Elements tempVar in Ladder.VariablePLCLib_element) {
				switch (tempVar.Type) {
					case TypeTag.CONTACTS:
						str_Input += string.Format("\t{0}\t= in{2}(_{1});\n", tempVar.Name, tempVar.IO_Port, strInputMode);
						strConfigPin += string.Format("\tpinMode(_{0},INPUT);\n", tempVar.IO_Port);							
						break;
					case TypeTag.ADC:
						//str_Input += string.Format("\t{0}\t= in{2}(_A{1});\n", tempVar.Name, (tempVar.IO_Port - 100).ToString("##"), strInputMode);
						strConfigPin += string.Format("\t//pinAnalog(_{0});\n", tempVar.IO_Port);	
						break;
					case TypeTag.COIL:
						if (tempVar.Name.Substring(0, 1) == "Y") {
							str_Output += string.Format("\tin({0});\n", tempVar.Name);
							str_Output += string.Format("\tout(_{0});\n", tempVar.IO_Port);
							strConfigPin += string.Format("\tpinMode(_{0},OUTPUT);\n", tempVar.IO_Port);	
						}
						break;						
				}
			}
			foreach (Elements tempUART in Ladder.Element_tags) {
				switch (tempUART.Type) {
					case TypeTag.UART_RECV:
					case TypeTag.UART_SEND:
						if (str_configUART == "")
							str_configUART = "\t//Initialize serial and wait for port to open:\n\tSerial.begin(9600);\n\twhile (!Serial); \n\t// wait for serial port to connect. Needed for native USB port only}\n";	
						break;
				}
			}
			strGenscanIO += str_Input;
			strGenscanIO += "\n//GEN CODE FOR Output\n";
			strGenscanIO += str_Output;
			strGenMapio = "\t// GenTest \n";
			string LoopPlc_Code = Ladder.GenPLCLib_Code(program);
			strCodeGen = "#include <Arduino.h>\n#include <plcLib.h>\n"
			+ strGenMapio
			+ "\tStack stack_series;\n"
			+ "\tStack stack_parallel;\n"
			+ "\textern int MasterscanValue;\n"
			+ "\textern int scanValue;\n"
			+ "\textern unsigned long scanTimeValue;\n"
			+ strGenIO + "void setup() {\n" + "	setupPLC();  // Setup inputs and outputs\n" + str_configUART + strConfigPin + "}\n" + "void scanIO() {\n" + strGenscanIO + "}\n" + Ladder.function_code + "\n" + "void loop() {\n" + LoopPlc_Code + "\n" + "}";			
			return strCodeGen;
		}
		void Export_CodeClick(object sender, EventArgs e)
		{
			var strCodeGen = Gen_Code();			
			//File.WriteAllText(openFileDialogLadder.FileName.Substring(0,openFileDialogLadder.FileName.Length-3) + "INO.ino", strCodeGen);
			var dir = new DirectoryInfo(@Ladder.tempDirectory);

			if (dir.Exists) {
				dir.Delete(true);
			}

			Directory.CreateDirectory(Ladder.tempDirectory);
			//string inofile = Environment.GetEnvironmentVariable("temp") + @"\arduinoplclibtemp.ino";
		
			string inofile = @Ladder.tempDirectory + @"\arduinoplclibtemp.ino";
			//inofile = @"G:\arduinoplclibtemp.ino";

			File.WriteAllText(inofile, strCodeGen);
			int compileCode = 0;
			switch (Ladder.Hardware_name) {
				case "Arduino UNOR3":
					compileCode = 1;
					break;
				case "ArUnitControl 32IO":
					compileCode = 13;
					break;
			}
			if (compileCode == 0) {
				MessageBox.Show("No Hardware Select!", "Hardware None?", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}
			
			
			//return;
			var progressForm = new ProgressForm(inofile, compileCode, 0);
			if (progressForm.ShowDialog() == DialogResult.OK) {
				tsLabel_comport.Text = Ladder.strCommunicationName;
				//CreateListElement();
			}
		}
		void Btn_simulationClick(object sender, EventArgs e)
		{
			DrawingTags.simulation_startus = !DrawingTags.simulation_startus;
			if (DrawingTags.simulation_startus) {
				Text += "    [Simulation Mode]";
				btn_simulation.Text = "            Edit Mode";
				SetCursorFunction(Cursor_Mode.simulation);
				btn_element_Contracs.Enabled = false;
				btn_element_Coil.Enabled = false;
				btn_element_CTD.Enabled = false;
				btn_element_CTU.Enabled = false;
				btn_element_Timers.Enabled = false;
				btn_element_CTC.Enabled = false;
				btn_element_Functions.Enabled = false;
				btn_element_Counters.Enabled = false;
				DrawingTags.simulationTime = 0;
				ts_bnt_start.Enabled = true;
				ts_bnt_step.Enabled = true;
				ts_bnt_stop.Enabled = true;
				setupSimulation();
				ts_bnt_start.Enabled = true;
				ts_bnt_stop.Enabled = false;
				mainMenu.Enabled = false;
				newToolStripButton.Enabled = false;
				openToolStripButton.Enabled = false;
				saveToolStripButton.Enabled = false;
				t_sBtn_simulation.BackColor = Color.Orange;
				listView_Map_I.Columns[1].Text = "Status";
				listView_Map_O.Columns[1].Text = "Status";
				
				listView_Map_I.ForeColor = Color.FromArgb(236, 165, 37);
				listView_Map_O.ForeColor = listView_Map_I.ForeColor;

				updateListView_IO();
				toolStripComboBox_Mup.Enabled = true;
			} else {
				if (Text.IndexOf("    [Simulation Mode]", StringComparison.Ordinal) > 0)
					Text = Text.Remove(Text.IndexOf("    [Simulation Mode]", StringComparison.Ordinal));
				btn_simulation.Text = "Simulation Mode";
				timer_simulation.Enabled = false;
				SetCursorFunction(Cursor_Mode.select_mode);
				rectangle_select = Rectangle.Empty;	
				program.SelectTags(rectangle_select, Ladder_Draw.PointToClient(Cursor.Position)); 
				ts_bnt_start.Enabled = false;
				ts_bnt_step.Enabled = false;
				ts_bnt_stop.Enabled = false;
				mainMenu.Enabled = true;
				newToolStripButton.Enabled = true;
				openToolStripButton.Enabled = true;
				saveToolStripButton.Enabled = true;
				t_sBtn_simulation.BackColor = Color.LightGray;
				listView_Map_I.Columns[1].Text = "Port";
				listView_Map_O.Columns[1].Text = "Port";
				
				listView_Map_I.ForeColor = Color.FromArgb(8, 174, 249);
				listView_Map_O.ForeColor = listView_Map_I.ForeColor;
				
				CreateListElement();
				toolStripComboBox_Mup.Enabled = false;
			}
			t_sBtn_simulation.Text = btn_simulation.Text;
			Ladder_Draw.Invalidate();
		}
		void T_sBtn_simulationClick(object sender, EventArgs e)
		{
			Btn_simulationClick(sender, e);
		}
		void Timer_simulationTick(object sender, EventArgs e)
		{
			step_Simulation();	
		}
		void startSimulate(object sender, EventArgs e)
		{
			timer_simulation.Enabled = true;
			ts_bnt_start.Enabled = false;
			ts_bnt_stop.Enabled = true;
			simulation_time = 0;
		}
		internal void stopSimulate(object sender, EventArgs e)
		{
			timer_simulation.Enabled = false;
			setupSimulation();
			DrawingTags.simulationTime = 0;
			ts_bnt_start.Enabled = true;
			ts_bnt_stop.Enabled = false;
			t_lable_Simulation_time.Text = string.Format("Run Time : {0:##0.00} s", (float)DrawingTags.simulationTime / 1000);		
		}
		void stepSimulate(object sender, EventArgs e)
		{
			timer_simulation.Enabled = false;	
			ts_bnt_start.Enabled = true;			
			step_Simulation();				
		}
		string GetstrBoolen(bool value)
		{
			if (value)
				return "ON";
			return "OFF";
		}
		void updateListView_IO()
		{
			foreach (Elements tag in Ladder.VariablePLCLib_element) {
				if (tag.Name.Substring(0, 1) == "X" || tag.Name.Substring(0, 1) == "Y" || tag.Name.Substring(0, 1) == "A") {
					foreach (ListViewItem item in listView_Map_I.Items) {
						switch (tag.Type) {
							case TypeTag.CONTACTS:
								if (tag.Name == item.Text & item.SubItems[1].Text != GetstrBoolen(tag.Startus)) {
									item.SubItems[1].Text = GetstrBoolen(tag.Startus);
								}
								break;
							case TypeTag.ADC:	
								if (tag.Name == item.Text & item.SubItems[1].Text != tag.Properties_value.ToString())
									item.SubItems[1].Text = tag.Properties_value.ToString();
								break;
						}						
					}
					foreach (ListViewItem item in listView_Map_O.Items) {
						if (tag.Name == item.Text & item.SubItems[1].Text != GetstrBoolen(tag.Startus)) {
							item.SubItems[1].Text = GetstrBoolen(tag.Startus);
						}
					}
				}
				foreach (ListViewItem item in listView_elements.Items) {
					if (tag.Name == item.Text) {
						switch (tag.Type) {
							case TypeTag.SHIFT_REGISTERS:
								// disable once RedundantCheckBeforeAssignment
								if (item.SubItems[2].Text != tag.Properties_value.ToString()) {
									item.SubItems[2].Text = tag.Properties_value.ToString();
								}
								break;
							case TypeTag.CONTACTS:
								// disable once RedundantCheckBeforeAssignment
								if (item.SubItems[2].Text != tag.Startus.ToString()) {
									item.SubItems[2].Text = tag.Startus.ToString();
								}
								break;
							case TypeTag.COIL:
								switch (tag.Name.Substring(0, 1)) {
									case "C":
										// disable once RedundantCheckBeforeAssignment
										if (item.SubItems[2].Text != tag._ct.ToString()) {
											item.SubItems[2].Text = tag._ct.ToString();
										}
										break;
									default:
									// disable once RedundantCheckBeforeAssignment
										if (item.SubItems[2].Text != tag.Startus.ToString()) {
											item.SubItems[2].Text = tag.Startus.ToString();
										}	
										break;
								}								
								break;
							case TypeTag.ADC:
							case TypeTag.MOVE:	
								// disable once RedundantCheckBeforeAssignment
								if (item.SubItems[2].Text != tag.Properties_value.ToString()) {
									item.SubItems[2].Text = tag.Properties_value.ToString();
								}
								break;
						}	
						
					}
				}
			}
		}
		ulong simulation_time;
		void step_Simulation()
		{
		/*	foreach (Elements tag in Ladder.VariablePLCLib_element) {
				if (tag.Type == TypeTag.ADC)
					continue;
				program.Update_Common_Element(tag);
			}
		*/
			float mup = 1;
			float.TryParse(toolStripComboBox_Mup.Text, out mup);
			//int timer_step = (int)(10 * mup);
			DrawingTags.simulationTime += (ulong)(timer_simulation.Interval * mup);
			t_lable_Simulation_time.Text = string.Format("Run Time : {0:##0.000} s", (float)DrawingTags.simulationTime * 0.001);
			
			if ((simulation_time + (ulong)Ladder.cycle_loop_value) > DrawingTags.simulationTime)
				return;
//			if ((simulation_time + (ulong)Ladder.cycle_loop_value) > DrawingTags.simulationTime)
//				return;
			
			updateListView_IO();
			Ladder_Draw.Invalidate();
			simulation_time = DrawingTags.simulationTime;			
		}
		void OpenToolStripButtonClick(object sender, EventArgs e)
		{
			OpenToolStripMenuItemClick(sender, e);
		}
		void setupSimulation()
		{
			richTextBox1.Text = "";
			simulation_time = 0;
			DrawingTags.simulationTime = 0;
			foreach (Elements tag in Ladder.VariablePLCLib_element) {
				tag.timerState = 0;
				tag.timerState_ = 0;
				tag.Startus = false;
				
//				if(tag.Type == TypeTag.FCP)
//					continue;
				program.Update_Common_Element(tag);
				switch (tag.Type) {
					case TypeTag.COIL:
						if (tag.Name.Substring(0, 1) == "C") {
							tag._ct = tag.Properties_value1;
							tag._lQ = true;
							tag._uQ = false;
						}
						break;
					case TypeTag.ADC:
					case TypeTag.MOVE:
						tag.Properties_value = 0;
						break;
				}
			}
		}
		void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
			var aboutform = new AboutForm();
			aboutform.ShowDialog();
		}
		void HelpToolStripButtonClick(object sender, EventArgs e)
		{
			AboutToolStripMenuItemClick(null, null);
		}
		void ListView_elementsItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
		{	
			Find_Ref_Tag(null);
		}
		void SelectHardware(object sender, EventArgs e)
		{
			var ts_select	= sender as ToolStripMenuItem;
			if (ts_no_hw == null)
				return;
			ts_select.Checked = true;
			Ladder.Hardware_name = ts_select.Text;
			ts_Hardware_name.Text = Ladder.Hardware_name;
			foreach (ToolStripMenuItem tsm in tsmunu_hardware.DropDownItems) {
				if (ts_select == tsm)
					continue;	
				tsm.CheckState = CheckState.Unchecked;
			}
		}
		
		void Ts_Hardware_nameTextChanged(object sender, EventArgs e)
		{
			//CreateListElement();
		}
		void SaveToolStripButtonClick(object sender, EventArgs e)
		{
			SaveToolStripMenuItemClick(sender, e);
		}
		Rung copy_rung;
		void Btn_copy_rungClick(object sender, EventArgs e)
		{
			int index_rungActive = program.rungs.IndexOf(program.Rung_select);
			Rung soure_rung = program.Rung_select;
			
			string strrung = Ladder.ExportRungLd(soure_rung);
			copy_rung = Ladder.strLadderToRung(strrung);
			tsb_Insert_up.Enabled = true;
			tsb_Insert_down.Enabled = true;
			//program.rungs.Insert(index_rungActive + 1, taget_rung);
			//Ladder_panel.Invalidate();
		}
		void OptionsToolStripMenuItemClick(object sender, EventArgs e)
		{
			Option_Config option_Config = new Option_Config();
			option_Config.ShowDialog();
			tsLabel_comport.Text = Ladder.strCommunicationName;
			CreateListElement();
		}
		
		void NewToolStripButtonClick(object sender, EventArgs e)
		{
			NewToolStripMenuItemClick(null, null);
		}
		void Tsb_Insert_upClick(object sender, EventArgs e)
		{
			int index_rungActive = program.rungs.IndexOf(program.Rung_select);			
			program.rungs.Insert(index_rungActive, copy_rung);
			Ladder_Draw.Invalidate();
			tsb_Insert_up.Enabled = false;
			tsb_Insert_down.Enabled = false;
		}
		void Tsb_Insert_downClick(object sender, EventArgs e)
		{
			int index_rungActive = program.rungs.IndexOf(program.Rung_select);			
			program.rungs.Insert(index_rungActive + 1, copy_rung);
			Ladder_Draw.Invalidate();
			tsb_Insert_up.Enabled = false;
			tsb_Insert_down.Enabled = false;
		}
		void Tsb_Copy_rungClick(object sender, EventArgs e)
		{
			Btn_copy_rungClick(sender, e);
		}
		void Tsb_configClick(object sender, EventArgs e)
		{
			OptionsToolStripMenuItemClick(sender, e);
		}
		void Expot_hexClick(object sender, EventArgs e)
		{
			var strCodeGen = Gen_Code();			
			//File.WriteAllText(openFileDialogLadder.FileName.Substring(0,openFileDialogLadder.FileName.Length-3) + "INO.ino", strCodeGen);
			var dir = new DirectoryInfo(@Ladder.tempDirectory);

			if (dir.Exists) {
				dir.Delete(true);
			}

			Directory.CreateDirectory(Ladder.tempDirectory);
			//string inofile = Environment.GetEnvironmentVariable("temp") + @"\arduinoplclibtemp.ino";
		
			string inofile = @Ladder.tempDirectory + @"\arduinoplclibtemp.ino";
			//inofile = @"G:\arduinoplclibtemp.ino";

			File.WriteAllText(inofile, strCodeGen);
			int compileCode = 0;
			switch (Ladder.Hardware_name) {
				case "Arduino UNOR3":
					compileCode = 1;
					break;
				case "ArUnitControl 32IO":
					compileCode = 13;
					break;
			}
			if (compileCode == 0) {
				MessageBox.Show("No Hardware Select!", "Hardware None?", MessageBoxButtons.OK, MessageBoxIcon.Stop);
				return;
			}

			var progressForm = new ProgressForm(inofile, compileCode, 1);
			if (progressForm.ShowDialog() == DialogResult.OK) {				
				tsLabel_comport.Text = Ladder.strCommunicationName;
				//CreateListElement();
				if (openFileDialogLadder.FileName == "")
					openFileDialogLadder.FileName = Directory.GetCurrentDirectory() + "//";
				string sourceFile = Ladder.tempDirectory + @"/tempcpp.hex";
				//string directoryPath = Path.GetDirectoryName(openFileDialogLadder.FileName);
				saveFileDialogLadder.Filter = "HEX files|*.hex";
				if (saveFileDialogLadder.ShowDialog(this) == DialogResult.OK) {
					try {
						string destinationFile = saveFileDialogLadder.FileName;
						if (destinationFile.Substring(destinationFile.Length - 4) != ".hex")
							destinationFile += ".hex";
						File.Copy(sourceFile, destinationFile, true);	
					} catch (Exception ex) {
						MessageBox.Show(ex.Message, "Error");
						return;
					}
				}	
				saveFileDialogLadder.Filter = "Ladder files|*.ld";				
			
			}
		}

		void ThemeLadderToolStripMenuItemClick(object sender, EventArgs e)
		{
			setting_Theme dialog_theme = new setting_Theme();
			dialog_theme.ShowDialog();
			Ladder_Draw.Invalidate();
		}
		
		void PrintToolStripMenuItemClick(object sender, EventArgs e)
		{
			
		}

		void printDocument_PrintPage(object sender, PrintPageEventArgs e)
		{
			//e.Graphics.DrawImage( Ladder_Draw.Image,0, 0,Ladder_Draw.Width,Ladder_Draw.Height);
			//e.Graphics.PageUnit = GraphicsUnit.Inch;  
			
			//printDocument_Ladder.OriginAtMargins = true;
			Color old_bg = DrawingTags.color_draw_bg;
			DrawingTags.color_draw_bg = Color.White;
			program.DrawProgram(e.Graphics, 0, Ladder_Draw.Height, tag_size);
			DrawingTags.color_draw_bg = old_bg;
		}
		void PrintPreviewToolStripMenuItemClick(object sender, EventArgs e)
		{
			//printPreviewDialog_Ladder.Document = printDocument_Ladder;
			printDocument_Ladder.DefaultPageSettings.Margins.Top = 0;
			printDocument_Ladder.DefaultPageSettings.Margins.Left = 40;
			printDocument_Ladder.DefaultPageSettings.Margins.Right = 0;
			printDocument_Ladder.DefaultPageSettings.Margins.Bottom = 0;
			printDocument_Ladder.OriginAtMargins = true;
			//printDocument_Ladder.DefaultPageSettings.PaperSize = new PaperSize("A4", 830, 1170);
			printDocument_Ladder.DefaultPageSettings.PaperSize = new PaperSize("A4", 830, Ladder_Draw.Height);

			printPreviewDialog_Ladder.ShowDialog();
		}
		void Ladder_DrawMouseLeave(object sender, EventArgs e)
		{
			switch (cursor_Mode) {
				case Cursor_Mode.insert:
					Cursor = Cursors.Default;
					break;
			}
		}
		void Ladder_DrawMouseHover(object sender, EventArgs e)
		{
			switch (cursor_Mode) {
				case Cursor_Mode.insert:
					Bitmap b = new Bitmap(imageList1.Images[4]);
					Cursor = CreateCursor(b, 10, 10);
					break;
			}
		}
	}
}
