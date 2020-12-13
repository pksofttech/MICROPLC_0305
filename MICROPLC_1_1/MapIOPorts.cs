/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 7/7/2015
 * Time: 1:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of MapIOPorts.
	/// </summary>
	public partial class MapIOPorts : Form
	{
		Elements element;
		string io_old;
		public MapIOPorts(Elements element)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			Text = Ladder.Hardware_name + " Map IO";
			this.element = element;
			io_old = element.IO_Port;
			label_Name.Text = element.Name;
			label_Type.Text = element.Type.ToString();
			Creaet_List_Port_IO();
			pictureBox1.BackColor = DrawingTags.color_draw_bg;
			//
		}
		void Gen_List_Port_IO()
		{
			foreach (Elements tag in Ladder.VariablePLCLib_element) {
				int index_of_item = -1;
				for (int i = 0; i < listView_IO.Items.Count; i++) {
					if (listView_IO.Items[i].SubItems[0].Text == tag.IO_Port) {
						index_of_item = i;
						break;
					}
				}
				if (index_of_item > -1) {
			
					listView_IO.Items[index_of_item].SubItems[1].Text = tag.Name;
					listView_IO.Items[index_of_item].SubItems[2].Text = tag.Type.ToString();
					if(tag == element){
						listView_IO.Items[index_of_item].ForeColor = Color.Blue;
				
//						listView_IO.Items[index_of_item].Selected  =true;
//						listView_IO.Items[index_of_item].Focused  =true;
											}
				}
							
			}
		}
		void Creaet_List_Port_IO()
		{
			listView_IO.Items.Clear();
			
			string pin_name;
			switch (Ladder.Hardware_name) {
				case "Arduino ProMini(168)5V":
				case "Arduino NANO(168)":
				case "Arduino/NANO UNO(328)":
					
					for (int i = 0; i <= 13; i++) {						
						pin_name =	string.Format("D{0}", i);
						var item_pin = new ListViewItem(pin_name, 0);	
						item_pin.SubItems.Add("");
						item_pin.SubItems.Add("");
						listView_IO.Items.Add(item_pin);
					}
					for (int i = 0; i <= 5; i++) {						
						pin_name =	string.Format("A{0}", i);
						var item_pin = new ListViewItem(pin_name, 1);	
						item_pin.SubItems.Add("");
						item_pin.SubItems.Add("");
						listView_IO.Items.Add(item_pin);
					}
					Gen_List_Port_IO();
					break;
				case "Arduino MEGA":
					for (int i = 0; i <= 52; i++) {						
						pin_name =	string.Format("D{0}", i);
						var item_pin = new ListViewItem(pin_name, 0);	
						item_pin.SubItems.Add("");
						item_pin.SubItems.Add("");
						listView_IO.Items.Add(item_pin);
					}
					for (int i = 0; i <= 12; i++) {						
						pin_name =	string.Format("A{0}", i);
						var item_pin = new ListViewItem(pin_name, 1);	
						item_pin.SubItems.Add("");
						item_pin.SubItems.Add("");
						listView_IO.Items.Add(item_pin);
					}
					Gen_List_Port_IO();
					break;
				case "Micro PLC deca":
					string strIO = "Null";
					TypeTag typeIO = TypeTag.Null;
					if (element.Type == TypeTag.CONTACTS) {
						strIO = "X";
						typeIO	= TypeTag.CONTACTS;
					}
					if (element.Type == TypeTag.ADC) {
						strIO = "A";
						typeIO	= TypeTag.ADC;
					}	
					if (element.Type == TypeTag.COIL) {
						strIO = "Y";
						typeIO	= TypeTag.COIL;
					}
					for (int i = 0; i < 16; i++) {
						ListViewItem item = new ListViewItem(strIO + i.ToString("00"), 0);
						item.SubItems.Add("");
						item.SubItems.Add("");
						foreach (Elements tag in Ladder.VariablePLCLib_element) {
							switch (element.Type) {
								case TypeTag.COIL:
									if (tag.IO_Port == string.Format("Y{0}", i.ToString("00")) & tag.Type == typeIO) {
										item.SubItems[1].Text = tag.Name;
									}
									break;
								case TypeTag.CONTACTS:
									if (tag.IO_Port == string.Format("X{0}", i.ToString("00")) & tag.Type == typeIO) {
										item.SubItems[1].Text = tag.Name;
									}
									break;
								case TypeTag.ADC:
									if (tag.IO_Port == string.Format("A{0}", i.ToString("00")) & tag.Type == typeIO) {
										item.SubItems[1].Text = tag.Name;
									}
									break;
							}
							
						}			
						listView_IO.Items.Add(item);
					}
					
					break;
			}
		}
		
		void ListView_IODoubleClick(object sender, EventArgs e)
		{
			ListViewItem item = listView_IO.FocusedItem;
			if (item == null)
				return;
			if (item.SubItems[1].Text != element.Name)
			if (item.SubItems[1].Text != "") {
				if (MessageBox.Show("Element is Usr Port to not Map IO ?", "Port Is User By Other!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel) {
					return;
				}			
			}
			foreach (Elements tag in Ladder.VariablePLCLib_element) {
				if (tag.Name == item.SubItems[1].Text) {
					tag.IO_Port = "";
					break;
				}							
			}
			element.IO_Port = item.Text;
			for (int i = 0; i < listView_IO.Items.Count; i++) {
				if (listView_IO.Items[i].SubItems[1].Text == element.Name) {
					listView_IO.Items[i].SubItems[1].Text = "";
					listView_IO.Items[i].SubItems[2].Text = "";
					break;
				}
			}
			listView_IO.FocusedItem.SubItems[1].Text = element.Name;
			listView_IO.FocusedItem.SubItems[2].Text = element.Type.ToString();
//			switch (element.Type) {
//				case TypeTag.CONTACTS:
//					element.IO_Port = "X" + item.Index.ToString("00");
//					break;
//				case TypeTag.COIL:
//					element.IO_Port = "Y" + item.Index.ToString("00");
//					break;
//				case TypeTag.ADC:
//					element.IO_Port = "A" + item.Index.ToString("00");
//					break;
//			}	
			//Creaet_List_Port_IO();
		}
		
		void MapIOPortsFormClosed(object sender, FormClosedEventArgs e)
		{
			
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
		void PictureBox1Paint(object sender, PaintEventArgs e)
		{
			Point drawPoint = new Point();
			//Pen drawPen	= new Pen(Color.White);
			DrawingTags.Drawtag(element, e.Graphics, drawPoint, pictureBox1.Width);
			DrawingTags.DrawtagString(element, e.Graphics, drawPoint, pictureBox1.Width, 1);
		}
		void ListView_IOSelectedIndexChanged(object sender, EventArgs e)
		{
	
		}
	}
}
