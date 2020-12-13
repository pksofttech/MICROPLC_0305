/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 9/7/2015
 * Time: 12:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MICROPLC
{
	public partial class arduino_unoMapIO : Form
	{
		Elements element;
		string  io_old;
		Elements element_refactor;
		string io_refactor = "";
		public arduino_unoMapIO(Elements element)
		{
			InitializeComponent();
			this.element = element;
			io_old = element.IO_Port;
			label_Name.Text = element.Name;
			label_Type.Text = element.Type.ToString();
			Creaet_List_Port_IO();
			pictureBox1.BackColor = DrawingTags.color_draw_bg;
			foreach (var rb in groupBox1.Controls) {
				if (rb is RadioButton) {
					RadioButton tempobj = rb as RadioButton;
					if(element.Name == tempobj.Text){
						tempobj.Checked = true;
						tempobj.ForeColor = Color.Red;
					}
					tempobj.Click += new EventHandler(rb_evntHandler);
				}					
			}			
		}
		void rb_evntHandler(object sender, EventArgs e)
		{
			RadioButton rb = sender as RadioButton;
			if (rb == null)
				return;
			if (rb.Text == element.Name)
				return;
			if (rb.Text != "Not'use") {
				DialogResult dialogResult = MessageBox.Show("User Pin Sure?", "IO Pin In use!!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (dialogResult == DialogResult.Yes) {
					string ioint = setMapIO(rb);
					foreach (Elements tag in Ladder.Element_tags) {
						if (tag.IO_Port == ioint) {	
							if (io_refactor != "") {
								element_refactor.IO_Port = io_refactor;
								io_refactor = "";
							}	
							io_refactor = tag.IO_Port;
							element_refactor = tag;
							tag.IO_Port = "";
							break;				 		
						}
					}
					element.IO_Port = ioint;
				}else{
					rb.Checked = false;
				}
				//return;
			} else { 
				element.IO_Port = setMapIO(rb);	
				if (io_refactor != "") {
					element_refactor.IO_Port = io_refactor;
					io_refactor = "";
				}	
			}			
			Creaet_List_Port_IO();			
		}
		void Creaet_List_Port_IO()
		{
			foreach (var rb in groupBox1.Controls) {
				if (rb is RadioButton) {
					RadioButton tempobj = rb as RadioButton;
					if(tempobj.Name != "rbnt_no_setting")
						tempobj.Text = "Not'use";
				}		
			}
			foreach (Elements tag in Ladder.Element_tags) {
				switch (tag.Type) {
					case TypeTag.COIL:
					case TypeTag.CONTACTS:
						if (tag.IO_Port != "") {
							setIOmap(tag);
						}
						break;
				}
			}
		}
		string setMapIO(RadioButton rb)
		{
			rb.ForeColor = Color.Red;
			switch (rb.Name) {
			// Analog IO
				case "radioButton1":
					return "A0";
				case "radioButton2":
					return "A1";
				case "radioButton3":
					return "A2";
				case "radioButton4":
					return "A3";
				case "radioButton5":
					return "A4";
				case "radioButton6":
					return "A5";
			// Digital IO	
				case "radioButton7":
					return "D0";
				case "radioButton8":
					return "D1";
				case "radioButton9":
					return "D2";
				case "radioButton10":
					return "D3";
				case "radioButton11":
					return "D4";
				case "radioButton12":
					return "D5";
				case "radioButton13":
					return "D6";
				case "radioButton14":
					return "D7";
				case "radioButton15":
					return "D8";
				case "radioButton16":
					return "D9";
				case "radioButton17":
					return "D10";
				case "radioButton18":
					return "D11";
				case "radioButton19":
					return "D12";
				case "radioButton20":
					return "D13";
				case "rbnt_no_setting":
					return "";
			}
			return "";
		}
		void setIOmap(Elements iotag)
		{
			switch (iotag.IO_Port) {
			// Analog IO
				case "A0":
					radioButton1.Text = iotag.Name;
					break;
				case "A1":
					radioButton2.Text = iotag.Name;
					break;
				case "A2":
					radioButton3.Text = iotag.Name;
					break;
				case "A3":
					radioButton4.Text = iotag.Name;
					break;
				case "A4":
					radioButton5.Text = iotag.Name;
					break;
				case "A5":
					radioButton6.Text = iotag.Name;
					break;
			// Digital IO	
				case "D0":
					radioButton7.Text = iotag.Name;
					break;
				case "D1":
					radioButton8.Text = iotag.Name;
					break;
				case "D2":
					radioButton9.Text = iotag.Name;
					break;
				case "D3":
					radioButton10.Text = iotag.Name;
					break;
				case "D4":
					radioButton11.Text = iotag.Name;
					break;
				case "D5":
					radioButton12.Text = iotag.Name;
					break;
				case "D6":
					radioButton13.Text = iotag.Name;
					break;
				case "D7":
					radioButton14.Text = iotag.Name;
					break;	
				case "D8":
					radioButton15.Text = iotag.Name;
					break;
				case "D9":
					radioButton16.Text = iotag.Name;
					break;
				case "D10":
					radioButton17.Text = iotag.Name;
					break;
				case "D11":
					radioButton18.Text = iotag.Name;
					break;
				case "D12":
					radioButton19.Text = iotag.Name;
					break;
				case "D13":
					radioButton20.Text = iotag.Name;
					break;
			}
		}
		void PictureBox1Paint(object sender, PaintEventArgs e)
		{
			Point drawPoint = new Point();
			//Pen drawPen	= new Pen(Color.White);
			DrawingTags.Drawtag(element, e.Graphics, drawPoint, pictureBox1.Width);
			DrawingTags.DrawtagString(element, e.Graphics, drawPoint, pictureBox1.Width, 1);
		
		}
		void Btn_cancelClick(object sender, EventArgs e)
		{
			element.IO_Port = io_old;
			this.DialogResult = DialogResult.Abort;
		}
		
		void Btn_okClick(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
		}
	}
}
