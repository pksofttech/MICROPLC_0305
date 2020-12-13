/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 7/12/2559
 * Time: 11:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of Arduino_MapIO.
	/// </summary>
	public partial class Arduino_MapIO : Form
	{
		Elements element;
		string io_old;
		//Elements element_refactor;
		//string io_refactor = "";
		public Arduino_MapIO(Elements element)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			this.element = element;
			io_old = element.IO_Port;
			label_Name.Text = element.Name;
			label_Type.Text = element.Type.ToString();
			//Creaet_List_Port_IO();
			pictureBox1.BackColor = DrawingTags.color_draw_bg;
			
			string pin_name;
			switch (Ladder.Hardware_name) {
				case "Arduino NANO":
				case "Arduino/Genuino UNO":
					
					for (int i = 0; i <= 13; i++) {						
						pin_name =	string.Format("D{0}", i);
						var item_pin = new ListViewItem(pin_name, 0);	
						item_pin.SubItems.Add("-");
						item_pin.SubItems.Add("-");
						listView1.Items.Add(item_pin);
					}
					for (int i = 0; i <= 5; i++) {						
						pin_name =	string.Format("A{0}", i);
						var item_pin = new ListViewItem(pin_name, 1);	
						item_pin.SubItems.Add("-");
						item_pin.SubItems.Add("-");
						listView1.Items.Add(item_pin);
					}
					break;
				case "Arduino MEGA":
					for (int i = 0; i <= 52; i++) {						
						pin_name =	string.Format("D{0}", i);
						var item_pin = new ListViewItem(pin_name, 0);	
						item_pin.SubItems.Add("-");
						item_pin.SubItems.Add("-");
						listView1.Items.Add(item_pin);
					}
					for (int i = 0; i <= 12; i++) {						
						pin_name =	string.Format("A{0}", i);
						var item_pin = new ListViewItem(pin_name, 1);	
						item_pin.SubItems.Add("-");
						item_pin.SubItems.Add("-");
						listView1.Items.Add(item_pin);
					}
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
