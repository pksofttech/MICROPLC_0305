/*
 * Created by SharpDevelop.
 * User: PK_SofttecH
 * Date: 8/5/2015
 * Time: 9:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of Properties_Counter.
	/// </summary>
	public partial class Properties_Variable : Form
	{
		Elements tag, temp_tag;
		string tag_Name;
		string str_variable;
		string str_operation;
		public Properties_Variable(Elements element)
		{	
			InitializeComponent();					
			tag = element;
			
			temp_tag = new Elements(tag.Type, tag.Name, tag.Parent);
			temp_tag.Properties	= tag.Properties;
			tag_Name = tag.Name;
			Text = string.Format("Type : {0} Edit Elements : {1}", tag.Type, tag.Name);
			comboBox_Name.Text = tag_Name;
			string[] strpara ;
			switch (tag.Type) {
				case TypeTag.MOVE:
					comboBox_Operation.Text = "";
					comboBox_variable_name.Visible = false;
					strpara = tag.Properties.Split(' ');
					str_variable = strpara[0];
					str_operation = strpara[0];
					if (strpara.Length > 1)
						str_operation = strpara[1];
					comboBox_Operation.Text = str_operation;
					comboBox_variable_name.Text = str_variable;
					CreateListnameelements();
					break;
				case TypeTag.SUB:	
				case TypeTag.MOD:	
				case TypeTag.MUL:	
				case TypeTag.DIV:
				case TypeTag.ADD:	
					strpara = tag.Properties.Split(' ');
					str_variable = strpara[0];
					str_operation = strpara[0];
					if (strpara.Length > 1)
						str_operation = strpara[1];
					comboBox_Operation.Text = str_operation;
					comboBox_variable_name.Text = str_variable;
					comboBox_variable_name.Visible = true;
					CreateListnameelements();
					break;
				case TypeTag.ADC:	
					label4.Visible = false;
					label3.Visible = false;
					comboBox_Type.Visible = false;
					comboBox_variable_name.Visible = false;
					break;
			}		
			
			int tempvalue = 0;
			if (int.TryParse(str_operation, out tempvalue)) {
				numericUpDown1.Value = tempvalue;
				radioButton1.Checked = true;
			} else {
				comboBox_Operation.Text = str_operation;
				radioButton2.Checked = true;
			}
			comboBox_Type.Text = temp_tag.Type.ToString();
			Preview_Edit_Tag(null, null);
			comboBox_Name.TextChanged += ComboBox_NameTextChanged;
			if (temp_tag.Type == TypeTag.ADC) {
				groupBox1.Visible = false;
				return;
			}
			comboBox_Operation.TextChanged += ComboBox_VariableTextChanged;
			comboBox_variable_name.TextChanged += ComboBox_variable_nameTextChanged;
			numericUpDown1.ValueChanged += Preview_Edit_Tag;
			radioButton1.CheckedChanged += Preview_Edit_Tag;
			radioButton2.CheckedChanged += Preview_Edit_Tag;
			comboBox_Type.TextChanged += Preview_Edit_Tag;
		}
		void CreateListnameelements()
		{
			foreach (Elements element_Temp in Ladder.VariablePLCLib_element) {
				bool addItem = true;
				//if ((temp_tag.Name.Substring(0, 1) == element_Temp.Name.Substring(0, 1)) || (true)) {
				switch (element_Temp.Type) {
					case TypeTag.MOVE:
					case TypeTag.ADC:	
					case TypeTag.SHIFT_REGISTERS:
						foreach (string name in comboBox_Name.Items) {
							if (element_Temp.Name == name) {
								addItem = false;
								break;
							}							
						}
						if (addItem) {
							if (element_Temp.Type != TypeTag.ADC)
								comboBox_Name.Items.Add(element_Temp.Name);								
							comboBox_Operation.Items.Add(element_Temp.Name);
							comboBox_variable_name.Items.Add(element_Temp.Name);
						}	
						break;							
				}
										
				//}
			}			
		}
		bool Return_Edit_Tag()
		{		
//			foreach (Elements temptag in Ladder.Element_tags) {
//				if (temptag.Name == temp_tag.Name)
//				if (temptag.Name != tag.Name){
//					MessageBox.Show("Can't Define Variable Element Name is Many Element In Ladder !","Error Many Element Ref.!!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
//					comboBox_Name.SelectionStart = 0;
//					comboBox_Name.SelectionLength = comboBox_Name.Text.Length;
//					comboBox_Name.Focus();
//					return false;
//				}
//			}
			tag_Name = comboBox_Name.Text.Replace(" ", "_"); 
			tag.Name = temp_tag.Name;	
			tag.Properties = temp_tag.Properties;
			tag.Type = temp_tag.Type;
			Ladder.SaveStratus = true;
			return true;
		}

		void Button2Click(object sender, EventArgs e)
		{	
			DialogResult = DialogResult.Cancel;
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			if (Return_Edit_Tag())
				DialogResult = DialogResult.OK;
			
		}
		void PictureBox1Paint(object sender, PaintEventArgs e)
		{
			pictureBox1.BackColor = DrawingTags.color_draw_bg;
			Point drawPoint = new Point();
			Pen drawPen	= new Pen(Color.White);
			DrawingTags.Drawtag(temp_tag, e.Graphics, drawPoint, pictureBox1.Width);
			DrawingTags.DrawtagString(temp_tag, e.Graphics, drawPoint, pictureBox1.Width, 1);
		}
		void Preview_Edit_Tag(object sender, EventArgs e)
		{
			
			if (radioButton1.Checked) {
				numericUpDown1.Enabled = true;
				comboBox_Operation.Enabled = false;
				str_operation = string.Format("{0}", numericUpDown1.Value);
			}				
			if (radioButton2.Checked) {
				numericUpDown1.Enabled = false;				
				comboBox_Operation.Enabled = true;
				str_operation = string.Format("{0}", comboBox_Operation.Text);
			}		
			switch (comboBox_Type.Text) {
				case "MOVE":
					temp_tag.Type = TypeTag.MOVE;
					comboBox_variable_name.Visible = false;
					temp_tag.Properties = string.Format("{0}", str_operation);
			
					break;
				case "ADD":
					temp_tag.Type = TypeTag.ADD;
					comboBox_variable_name.Visible = true;
					temp_tag.Properties = string.Format("{0} {1}", str_variable, str_operation);
			
					break;
				case "SUB":
					temp_tag.Type = TypeTag.SUB;
					comboBox_variable_name.Visible = true;
					temp_tag.Properties = string.Format("{0} {1}", str_variable, str_operation);
			
					break;
				case "MUP":
					temp_tag.Type = TypeTag.MUL;
					comboBox_variable_name.Visible = true;
					temp_tag.Properties = string.Format("{0} {1}", str_variable, str_operation);
			
					break;
				case "DIV":
					temp_tag.Type = TypeTag.DIV;
					comboBox_variable_name.Visible = true;
					temp_tag.Properties = string.Format("{0} {1}", str_variable, str_operation);
			
					break;
				case "MOD":
					temp_tag.Type = TypeTag.MOD;
					comboBox_variable_name.Visible = true;
					temp_tag.Properties = string.Format("{0} {1}", str_variable, str_operation);
			
					break;
			}
			pictureBox1.Invalidate();
			//CreateListnameelements();
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
//			switch (comboBox_Name.Text.Substring(0, 1)) {
//				case "V":
//				case "S":
//				case "A":
//					temp_tag.Name = comboBox_Name.Text; 
//					break;
//				default:
//					char chType = 'V';
//					switch (temp_tag.Type) {
//						case TypeTag.MOVE:
//							chType = 'V';
//							break;
//						case TypeTag.ADC:
//							chType = 'A';
//							break;
//					}
//					temp_tag.Name = chType + comboBox_Name.Text; 
//					break;
//			}
			if(temp_tag.Type == TypeTag.ADC)
            {
				temp_tag.Name = "A" + comboBox_Name.Text.ToLower();
			}
            else
            {
				temp_tag.Name = comboBox_Name.Text.ToLower();
			}
			
			
			Preview_Edit_Tag(sender, e);
		}
		void ComboBox_VariableTextChanged(object sender, EventArgs e)
		{
			str_operation = comboBox_Operation.Text; 
			
			Preview_Edit_Tag(sender, e);
		}
		void Label1Click(object sender, EventArgs e)
		{
	
		}
		void ComboBox_variable_nameTextChanged(object sender, EventArgs e)
		{
			str_variable = comboBox_variable_name.Text; 
			
			Preview_Edit_Tag(sender, e);
		}
	}
}
