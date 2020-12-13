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
	public partial class Properties_Counter : Form
	{
		Elements tag, temp_tag;
		string tag_Name;
		public Properties_Counter(Elements element)
		{	
			InitializeComponent();					
			tag = element;
			temp_tag = new Elements(tag.Type, tag.Name, tag.Parent);
			temp_tag.Properties_negated = tag.Properties_negated;
			temp_tag.Properties_value	= tag.Properties_value;
			temp_tag.Properties_value1	= tag.Properties_value1;
			tag_Name = tag.Name.Substring(1);
			Text = string.Format("Type : {0}     Edit Counter Elements : {1}", tag.Type, tag.Name);
			comboBox_Name.Text = tag_Name;
			CreateListnameelements();
			if (temp_tag.Properties_negated) {
				rBnt_lowerQ.Checked = true;
			} else {
				rBnt_upperQ.Checked = true;
			}
			numericUpDown1.Value = temp_tag.Properties_value1;
			numericUpDown2.Value = temp_tag.Properties_value;
			
			comboBox_Name.TextChanged += ComboBox_NameTextChanged;
			numericUpDown1.ValueChanged += Preview_Edit_Tag;
			numericUpDown2.ValueChanged += Preview_Edit_Tag;
			rBnt_lowerQ.CheckedChanged += Preview_Edit_Tag;
			rBnt_upperQ.CheckedChanged += Preview_Edit_Tag;
		}
		void CreateListnameelements()
		{
			foreach (Elements element_Temp in Ladder.Element_tags) {
				bool addItem = true;
				if (temp_tag.Name.Substring(0, 1) == element_Temp.Name.Substring(0, 1)) {
					foreach (string name in comboBox_Name.Items) {
						if (element_Temp.Name.Substring(1) == name) {
							addItem = false;
							break;
						}							
					}
					if (addItem)
						comboBox_Name.Items.Add(element_Temp.Name.Substring(1));
				}
			}			
		}
		bool Return_Edit_Tag()
		{					
			tag_Name = comboBox_Name.Text.Replace(" ", "_"); 
			tag.Name = temp_tag.Name;	
			tag.Properties_negated = temp_tag.Properties_negated;
			tag.Properties_value = temp_tag.Properties_value;
			tag.Properties_value1 = temp_tag.Properties_value1;
		
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
			if (numericUpDown1.Value >= numericUpDown2.Value)
				numericUpDown1.Value = numericUpDown2.Value;
			temp_tag.Properties_negated = rBnt_lowerQ.Checked;
			temp_tag.Properties_value = (int)numericUpDown2.Value;
			temp_tag.Properties_value1 = (int)numericUpDown1.Value;

			pictureBox1.Invalidate();
			CreateListnameelements();
		}
		void ComboBox_NameKeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			if (Return_Edit_Tag())
				DialogResult = DialogResult.OK;
		}
		void ComboBox_NameTextChanged(object sender, EventArgs e)
		{
			temp_tag.Name = "C" + comboBox_Name.Text; 
			foreach (Elements temptag in Ladder.Element_tags) {
				if (temptag.Name == temp_tag.Name)
				if (temptag.Type == temp_tag.Type) {
					numericUpDown1.Value = temptag.Properties_value1;					
					numericUpDown2.Value = temptag.Properties_value;
					break;
				}
			}			
			Preview_Edit_Tag(sender, e);
		}

	}
}
