/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 9/13/2015
 * Time: 12:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO.Ports;
using System.Management;
//using System.Management;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of Option_Config.
	/// </summary>
	public partial class Option_Config : Form
	{
		public Option_Config()
		{
			InitializeComponent();
			GetSerialPort();
			foreach (string captiontext in cb_com_select.Items) {
				if (Ladder.strCommunicationName == captiontext) {
					cb_com_select.Text = captiontext;
					break;
				}
			}	
			if (cb_com_select.Text == "") {
				foreach (string captiontext in cb_com_select.Items) {
					if (GetSerialPortInfo(captiontext).IndexOf("USB Serial Device (", StringComparison.Ordinal) == 0) {
						cb_com_select.Text = captiontext;
						break;
					}
				}
			}
			tb_baud_rate.Text = Ladder.strCommunication_baud_rate;
			// 
			//cb_com_select.Text = "Not Upload";
			rbnt_Input_Active_Low.Checked = !Ladder.Input_Active_Mode;
			rbnt_Input_Active_Hight.Checked = Ladder.Input_Active_Mode;
			rbnt_output_Active_Low.Checked = !Ladder.Output_Active_Mode;
			rbnt_output_Active_Hight.Checked = Ladder.Output_Active_Mode;
			numericUpDown_loop_time.Value = Ladder.cycle_loop_value;
		}
		string GetSerialPortInfo(string portname)
		{
			string result = "";
			using (var searcher = new ManagementObjectSearcher("SELECT * FROM WIN32_SerialPort")) {
				ManagementObjectCollection ports = searcher.Get();
				foreach (ManagementObject  queryObj in searcher.Get()) {
					if (queryObj["Caption"].ToString().Contains(portname)) {
						result = string.Format("{0}", queryObj["Caption"]);  
						//result += queryObj["Device"]
					}
				}
			}
			return result;
		}
		
		void GetSerialPort()
		{
			cb_com_select.Items.Clear();
			cb_com_select.Items.Add("Not Upload");
			foreach (string item in SerialPort.GetPortNames()) {
				//store the each retrieved available prot names into the Listbox...
				cb_com_select.Items.Add(item);
			}
		}
		
		void Cb_com_selectSelectedIndexChanged(object sender, EventArgs e)
		{
			Ladder.strCommunicationName = cb_com_select.Text;
			textBox1.Text = GetSerialPortInfo(Ladder.strCommunicationName);
			(Application.OpenForms["MainForm"] as MainForm).SettoolStripPortname(textBox1.Text);   
		}
		
		void Rbnt_Input_Active_LowCheckedChanged(object sender, EventArgs e)
		{
			Ladder.Input_Active_Mode = !rbnt_Input_Active_Low.Checked;
		}
		
		void Rbnt_Input_Active_HightCheckedChanged(object sender, EventArgs e)
		{
			Ladder.Input_Active_Mode = rbnt_Input_Active_Hight.Checked;
		}

		private void rbnt_output_Active_Low_CheckedChanged(object sender, EventArgs e)
		{
			Ladder.Output_Active_Mode = !rbnt_output_Active_Low.Checked;
		}

		private void rbnt_output_Active_Hight_CheckedChanged(object sender, EventArgs e)
		{
			Ladder.Output_Active_Mode = !rbnt_output_Active_Hight.Checked;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			rbnt_output_Active_Hight.Checked = true;
			rbnt_Input_Active_Hight.Checked = true;
			numericUpDown_loop_time.Value = 10;
		}

		private void numericUpDown_loop_time_ValueChanged(object sender, EventArgs e)
		{
			Ladder.cycle_loop_value = (int)numericUpDown_loop_time.Value;
		}
		void Button2Click(object sender, EventArgs e)
		{
			Close();
		}
		void Tb_baud_rateTextChanged(object sender, EventArgs e)
		{
			Ladder.strCommunication_baud_rate = tb_baud_rate.Text;
		}
	}
}
