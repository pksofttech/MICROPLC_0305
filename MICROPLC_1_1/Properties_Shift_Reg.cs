/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 6/2/2559
 * Time: 9:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of Properties_Shift_Reg.
	/// </summary>
	public partial class Properties_Shift_Reg : Form
	{
		Elements tag, temp_tag;
		//string tag_Name;
		public Properties_Shift_Reg(Elements element)
		{
			InitializeComponent();
			comboBox_valueType.DropDownStyle = ComboBoxStyle.DropDownList;
			tag = element;
			temp_tag = new Elements(tag.Type, tag.Name, tag.Parent);
			temp_tag.Properties	= tag.Properties;
			//tag_Name = tag.Name.Substring(1);
			Text = string.Format("Type : Edit Shift Regiter Elements : {0}", tag.Name);
			comboBox_Name.Text = tag.Name;
			
			switch (tag.Type) {
				case TypeTag.SHIFT_REGISTERS:
					radioButton1.Checked = true;
					//comboBox_valueType.Text = "Hex";
					textBox_SetValue.Text = tag.Properties;
					break;
				case TypeTag.SHIFT_REG_INBIT:
					radioButton2.Checked = true;
					break;
				case TypeTag.SHIFT_REG_RESET:
					radioButton3.Checked = true;
					break;
				case TypeTag.SHIFT_RIGHT:
					radioButton4.Checked = true;
					break;
				case TypeTag.SHIFT_LEFT:
					radioButton5.Checked = true;
					break;
			}
			
			Preview_Edit_Tag(null, null);
			CreateListnameelements();
			radioButton1.CheckedChanged += Preview_Edit_Tag;
			radioButton2.CheckedChanged += Preview_Edit_Tag;
			radioButton3.CheckedChanged += Preview_Edit_Tag;
			radioButton4.CheckedChanged += Preview_Edit_Tag;
			radioButton5.CheckedChanged += Preview_Edit_Tag;
			comboBox_Name.TextChanged += Preview_Edit_Tag;
			comboBox_Name.TextChanged += ComboBox_NameTextChanged;
			comboBox_Name.KeyUp += ComboBox_NameKeyUp;
		}
		void CreateListnameelements()
		{
			comboBox_Name.TextChanged -= ComboBox_NameTextChanged;
			comboBox_Name.Items.Clear();
			foreach (Elements element_Temp in Ladder.VariablePLCLib_element) {
				bool addItem = true;
				if (temp_tag.Name.Substring(0, 1) == element_Temp.Name.Substring(0, 1)) {
					foreach (string name in comboBox_Name.Items) {
						if (element_Temp.Name == name) {
							addItem = false;
							break;
						}							
					}
					if (addItem)
						comboBox_Name.Items.Add(element_Temp.Name);
				}
			}
			comboBox_Name.Text = temp_tag.Name;
			comboBox_Name.TextChanged += ComboBox_NameTextChanged;			
		}
		bool Return_Edit_Tag()
		{		
			foreach (Elements tempVar in Ladder.Element_tags) {
				if (tempVar.Name == temp_tag.Name)
					switch (tempVar.Type) {
						case TypeTag.SHIFT_LEFT:
						case TypeTag.SHIFT_RIGHT:
							if ((tempVar.Type == temp_tag.Type) & (tempVar != tag)) {
								
								MessageBox.Show("Define Control Shift in Ladder!", "Error Dupication Control Shift", MessageBoxButtons.OK, MessageBoxIcon.Error);
								return false;

							}
							break;						
					}			
			}
			foreach (Elements tempVar in Ladder.VariablePLCLib_element) {
				if ((tempVar.Name == comboBox_Name.Text) & (tempVar.Type == TypeTag.SHIFT_REGISTERS)) {
					temp_tag.Name = comboBox_Name.Text.Replace(" ", "_"); 
					tag.Name = temp_tag.Name;	
					tag.Properties = temp_tag.Properties;
					tag.Type = temp_tag.Type;
					Ladder.SaveStratus = true;
					return (true);
				}
			}
			if (MessageBox.Show("Create Shift Register !", string.Format("Can,n define Set Shift Register Name:{0} in Ladder Program", temp_tag.Name), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				return(false);
			temp_tag.Name = comboBox_Name.Text.Replace(" ", "_"); 
			tag.Name = temp_tag.Name;	
			tag.Properties = temp_tag.Properties;
			tag.Type = temp_tag.Type;
			Ladder.SaveStratus = true;
			return true;
		}
		void Preview_Edit_Tag(object sender, EventArgs e)
		{	
			textBox_SetValue.Enabled = false;
			comboBox_valueType.Enabled = false;
			if (radioButton1.Checked) {
				temp_tag.Type = TypeTag.SHIFT_REGISTERS;
				textBox_SetValue.Enabled = true;
				comboBox_valueType.Enabled = true;
			}				
			if (radioButton2.Checked)
				temp_tag.Type = TypeTag.SHIFT_REG_INBIT;
			if (radioButton3.Checked)
				temp_tag.Type = TypeTag.SHIFT_REG_RESET;
			if (radioButton4.Checked)
				temp_tag.Type = TypeTag.SHIFT_RIGHT;
			if (radioButton5.Checked)
				temp_tag.Type = TypeTag.SHIFT_LEFT;
		
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
		void Button1Click(object sender, EventArgs e)
		{
			if (Return_Edit_Tag())
				DialogResult = DialogResult.OK;
		}
		void Button2Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}
		void ComboBox_NameKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			if (Return_Edit_Tag())
				DialogResult = DialogResult.OK;
		}
		void ComboBox_NameTextChanged(object sender, EventArgs e)
		{
			if (comboBox_Name.Text == "")
				return;
			comboBox_Name.TextChanged -= ComboBox_NameTextChanged;
			
			if (comboBox_Name.Text.Substring(0, 1) != "S")
				comboBox_Name.Text = "S" + comboBox_Name.Text;
			comboBox_Name.Select(comboBox_Name.Text.Length, 0);
			
			comboBox_Name.TextChanged += ComboBox_NameTextChanged;
			
			temp_tag.Name = comboBox_Name.Text;
			Preview_Edit_Tag(sender, e);
			
		}
		void TextBox_SetValueTextChanged(object sender, EventArgs e)
		{
			if (textBox_SetValue.Text == "")
				return;
			textBox_SetValue.TextChanged -= TextBox_SetValueTextChanged;
			
			int i = 0;
			try {
				switch (comboBox_valueType.Text) {
					case "Binary":
						i = Convert.ToInt32(textBox_SetValue.Text, 2);
						textBox_SetValue.Text = Convert.ToString(i, 2).ToUpper();
						break;
					case "Decimal":
						i = Convert.ToInt32(textBox_SetValue.Text, 10);
						textBox_SetValue.Text = Convert.ToString(i, 10).ToUpper();
						break;
					case "Hex":
						i = Convert.ToInt32(textBox_SetValue.Text, 16);
						textBox_SetValue.Text = Convert.ToString(i, 16).ToUpper();
						break;					
				}
			} catch {
				MessageBox.Show("Error Number Format!", "Error Input Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
				textBox_SetValue.Text = textBox_SetValue.Text.Substring(0, textBox_SetValue.Text.Length - 1);
				textBox_SetValue.SelectionStart = textBox_SetValue.Text.Length;
			}
	
			temp_tag.Properties = Convert.ToString(i, 16).ToUpper();
			pictureBox1.Invalidate();
			textBox_SetValue.SelectionStart = textBox_SetValue.Text.Length;
			textBox_SetValue.TextChanged += TextBox_SetValueTextChanged;
		}
		void ComboBox_valueTypeTextChanged(object sender, EventArgs e)
		{
			int i = Convert.ToInt32(temp_tag.Properties, 16);
			try {
				switch (comboBox_valueType.Text) {
					case "Binary":
						textBox_SetValue.Text = Convert.ToString(i, 2);
						break;
					case "Decimal":
						textBox_SetValue.Text = Convert.ToString(i, 10);
						break;
					case "Hex":
						textBox_SetValue.Text = Convert.ToString(i, 16);
						break;					
				}
			} catch {
				MessageBox.Show("Error Number Format!", "Error Convent Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
