/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2/2/2559
 * Time: 16:42
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of Input_Analog.
	/// </summary>
	public partial class Input_Analog : Form
	{
		Elements temp_tag;
		public Input_Analog(Elements element)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			temp_tag = element;
			label_name.Text = element.Name;
			trackBar_value.Value = element.Properties_value;
			numericUpDown1.Value = element.Properties_value;
			trackBar_value.ValueChanged += tracBar_Value_chang;
			numericUpDown1.ValueChanged += numericUpDown1_Value_chang;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void tracBar_Value_chang(object sender, EventArgs e)
		{
			numericUpDown1.ValueChanged -= numericUpDown1_Value_chang;
			numericUpDown1.Value = trackBar_value.Value;
			numericUpDown1.ValueChanged += numericUpDown1_Value_chang;
		}
		void numericUpDown1_Value_chang(object sender, EventArgs e)
		{
			trackBar_value.ValueChanged -= tracBar_Value_chang;
			trackBar_value.Value = (int)numericUpDown1.Value;
			trackBar_value.ValueChanged += tracBar_Value_chang;
		}
		void Button1Click(object sender, EventArgs e)
		{
			temp_tag.Properties_value = trackBar_value.Value;
			Close();
		}
		void NumericUpDown1KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				Button1Click(null,null);
		}

	}
}
