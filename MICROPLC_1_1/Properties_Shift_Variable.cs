/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 16/3/2559
 * Time: 17:51
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of Properties_Shift_Variable.
	/// </summary>
	/// 
	
	public partial class Properties_Shift_Variable : Form
	{
		Elements tag, temp_tag;
		public Properties_Shift_Variable(Elements element)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			//comboBox_valueType.DropDownStyle = ComboBoxStyle.DropDownList;
			tag = element;
			temp_tag = new Elements(tag.Type, tag.Name, tag.Parent);
			temp_tag.Properties	= tag.Properties;
			Text = string.Format("Type : Edit Shift Regiter Variable  : {0}", tag.Name);
			comboBox_Name.Text = tag.Name;
			numericUpDown1.Value = int.Parse(temp_tag.Properties) + 1;
			comboBox_Name.TextChanged += ComboBox_NameTextChanged;
			numericUpDown1.ValueChanged += NumericUpDown1ValueChanged;
		}
		void ComboBox_NameTextChanged(object sender, EventArgs e)
		{
//			if (comboBox_Name.Text == "")
//				return;
//			comboBox_Name.TextChanged -= ComboBox_NameTextChanged;
//			
//			if (comboBox_Name.Text.Substring(0, 1) != "S")
//				comboBox_Name.Text = "S" + comboBox_Name.Text;
//			comboBox_Name.Select(comboBox_Name.Text.Length, 0);
//			
//			comboBox_Name.TextChanged += ComboBox_NameTextChanged;
			
			temp_tag.Name = comboBox_Name.Text;
			Preview_Edit_Tag(sender, e);
			
		}
		void Preview_Edit_Tag(object sender, EventArgs e)
		{	
		
			pictureBox1.Invalidate();
			
			//CreateListnameelements();
		}
		void PictureBox1Paint(object sender, PaintEventArgs e)
		{
			pictureBox1.BackColor = DrawingTags.color_draw_bg;
			Point drawPoint = new Point();
			Pen drawPen	= new Pen(Color.White);
			DrawingTags.Drawtag(temp_tag, e.Graphics, drawPoint, pictureBox1.Width);
			DrawingTags.DrawtagString(temp_tag, e.Graphics, drawPoint, pictureBox1.Width, 1);
		}
		void NumericUpDown1ValueChanged(object sender, EventArgs e)
		{
			temp_tag.Properties = (numericUpDown1.Value - 1).ToString();
			Preview_Edit_Tag(sender, e);
		}
		void Button1Click(object sender, EventArgs e)
		{
			if (Return_Edit_Tag())
				DialogResult = DialogResult.OK;
		}
		void Button2Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
		bool Return_Edit_Tag()
		{		
//			foreach (Elements tempVar in Ladder.Element_tags) {
//				if (tempVar.Name == temp_tag.Name)
//					switch (tempVar.Type) {
//						case TypeTag.SHIFT_LEFT:
//						case TypeTag.SHIFT_RIGHT:
//							if ((tempVar.Type == temp_tag.Type) & (tempVar != tag)) {
//								
//								MessageBox.Show("Define Control Shift in Ladder!", "Error Dupication Control Shift", MessageBoxButtons.OK, MessageBoxIcon.Error);
//								return false;
//
//							}
//							break;						
//					}			
//			}
//			foreach (Elements tempVar in Ladder.VariablePLCLib_element) {
//				if ((tempVar.Name == comboBox_Name.Text) & (tempVar.Type == TypeTag.SHIFT_REGISTERS)) {
//					temp_tag.Name = comboBox_Name.Text.Replace(" ", "_"); 
//					tag.Name = temp_tag.Name;	
//					tag.Properties = temp_tag.Properties;
//					tag.Type = temp_tag.Type;
//					Ladder.SaveStratus = true;
//					return (true);
//				}
//			}
//			if (MessageBox.Show("Create Shift Register !", string.Format("Can,n define Set Shift Register Name:{0} in Ladder Program", temp_tag.Name), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
//				return(false);
			temp_tag.Name = comboBox_Name.Text.Replace(" ", "_").ToLower();
			tag.Name = temp_tag.Name;	
			tag.Properties = temp_tag.Properties;
			tag.Type = temp_tag.Type;
			Ladder.SaveStratus = true;
			return true;
		}
	}
}
