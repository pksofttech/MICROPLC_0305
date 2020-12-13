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
	public partial class Properties_FCP : Form
	{
		Elements tag, temp_tag;
		string tag_Variable, strCordition, strValue;
		
		public Properties_FCP(Elements element)
		{	
			InitializeComponent();	
			
			tag = element;
			temp_tag = new Elements(tag.Type, tag.Name, tag.Parent);
			temp_tag.Properties	= tag.Properties;			
			tag_Variable = tag.Name;
			
			Text = string.Format("Type : {0} Edit Function Compare Elements", tag.Type);

			comboBox1.Text = tag_Variable;
			strCordition = "==";
			strValue = "0";
			string[] strtemp = temp_tag.Properties.Split(' ');
			if (strtemp.Length > 1) {
				strCordition = strtemp[0];
				strValue = strtemp[1];
			}
			comboBox2.Text = strValue;
			switch (strCordition) {
				case "==":
					rBnt_EQ.Checked = true;
					break;
				case ">":
					rBnt_GT.Checked = true;
					break;
				case ">=":
					rBnt_GTE.Checked = true;
					break;
				case "<":
					rBnt_LT.Checked = true;
					break;
				case "<=":
					rBnt_LTE.Checked = true;
					break;
				case "!=":
					r_BntUEQ.Checked = true;
					break;
			}
			CreateListnameelements();
			r_BntUEQ.CheckedChanged += Preview_Edit_Tag;
			rBnt_EQ.CheckedChanged += Preview_Edit_Tag;
			rBnt_GT.CheckedChanged += Preview_Edit_Tag;
			rBnt_LT.CheckedChanged += Preview_Edit_Tag;
			comboBox1.TextChanged += Preview_Edit_Tag;
			comboBox2.TextChanged += Preview_Edit_Tag;
		}
		void CreateListnameelements()
		{
			foreach (Elements element_Temp in Ladder.VariablePLCLib_element) {
				bool addItem = true;
				switch (element_Temp.Name.Substring(0, 1)) {
				//case "T":
					case "Y":
					case "R":
					case "X":
					
						break;
					default:
						foreach (string name in comboBox1.Items) {
							if (element_Temp.Name == name) {
								addItem = false;
								break;
							}							
						}
						if (addItem) {
							comboBox1.Items.Add(element_Temp.Name);
							comboBox2.Items.Add(element_Temp.Name);
						}
							
						break;
				}
			}			
		}
		bool Return_Edit_Tag()
		{	
			Update_Temptag();
			bool checkVariable = false;
			foreach (string name in comboBox1.Items) {
				if (comboBox1.Text == name) {
					checkVariable = true;
					break;
				}							
			}
			if (!checkVariable) {
				MessageBox.Show("Can't Defent Element In Ladder !", "Error  Variable Name is Defent Element Ref.!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				comboBox1.SelectionStart = 0;
				comboBox1.SelectionLength = comboBox1.Text.Length;
				comboBox1.Focus();
				return false;
			}
			
			tag.Name = temp_tag.Name;	

			tag.Properties = temp_tag.Properties;
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

		void Update_Temptag()
		{
			if (r_BntUEQ.Checked)
				strCordition = "!=";
			if (rBnt_EQ.Checked)
				strCordition = "==";
			if (rBnt_GT.Checked)
				strCordition = ">";
			if (rBnt_GTE.Checked)
				strCordition = ">=";
			if (rBnt_LT.Checked)
				strCordition = "<";
			if (rBnt_LTE.Checked)
				strCordition = "<=";
			temp_tag.Name = comboBox1.Text;
			strValue = comboBox2.Text;
			temp_tag.Properties = string.Format("{0} {1}", strCordition, strValue);
		}

		void Preview_Edit_Tag(object sender, EventArgs e)
		{
			Update_Temptag();
			pictureBox1.Invalidate();
			//CreateListnameelements();
		}

	}
}
