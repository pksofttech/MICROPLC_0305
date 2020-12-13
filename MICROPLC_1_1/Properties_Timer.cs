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
	public partial class Properties_Timer : Form
	{
		Elements tag, temp_tag;
		string tag_Name;
		public Properties_Timer(Elements element)
		{	
			InitializeComponent();					
			tag = element;
			temp_tag = new Elements(tag.Type, tag.Name, tag.Parent);
			temp_tag.Properties_value	= tag.Properties_value;
			temp_tag.Properties_value1	= tag.Properties_value1;
			tag_Name = tag.Name.Substring(1);
			Text = string.Format("Type : {0} Edit Timers Elements : {1}", tag.Type, tag.Name);
			comboBox_Name.Text = tag_Name;
			//CreateListnameelements();
			switch (temp_tag.Type) {
				case TypeTag.TOF:
					rBnt_Tof.Checked = true;
					numericUpDown2.Enabled = false;
					break;
				case TypeTag.TON:
					rBnt_Ton.Checked = true;
					numericUpDown2.Enabled = false;
					break;
				case TypeTag.TPC:
					rBnt_Tpc.Checked = true;
					break;
			}
			numericUpDown1.Value = temp_tag.Properties_value;
			numericUpDown2.Value = temp_tag.Properties_value1;
			
			comboBox_Name.TextChanged += ComboBox_NameTextChanged;
			numericUpDown1.ValueChanged += Preview_Edit_Tag;
			numericUpDown2.ValueChanged += Preview_Edit_Tag;
			rBnt_Ton.CheckedChanged += Preview_Edit_Tag;
			rBnt_Tof.CheckedChanged += Preview_Edit_Tag;
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
			foreach (Elements temptag in Ladder.Element_tags) {
				if (temptag.Name == temp_tag.Name)
				if (temptag.Name != tag.Name){
					MessageBox.Show("Can't Define Timer Element Name is Many Element In Ladder !","Error Many Element Ref.!!!",MessageBoxButtons.OK,MessageBoxIcon.Error);
					comboBox_Name.SelectionStart = 0;
					comboBox_Name.SelectionLength = comboBox_Name.Text.Length;
					comboBox_Name.Focus();
					return false;
				}
			}
			tag_Name = comboBox_Name.Text.Replace(" ", "_"); 
			tag.Name = temp_tag.Name;	
			tag.Properties_value = temp_tag.Properties_value;
			tag.Properties_value1 = temp_tag.Properties_value1;
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
			temp_tag.Properties_value = (int)numericUpDown1.Value;
			temp_tag.Properties_value1 = (int)numericUpDown2.Value;
			if (rBnt_Tof.Checked) {
				temp_tag.Type = TypeTag.TOF;
				numericUpDown2.Enabled = false;
			}				
			if (rBnt_Ton.Checked) {
				temp_tag.Type = TypeTag.TON;
				numericUpDown2.Enabled = false;
			}				
			if (rBnt_Tpc.Checked) {
				temp_tag.Type = TypeTag.TPC;
				numericUpDown2.Enabled = true;
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
			temp_tag.Name = "T" + comboBox_Name.Text; 
			
			Preview_Edit_Tag(sender, e);
		}

	}
}
