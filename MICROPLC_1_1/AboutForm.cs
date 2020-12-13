/*
 * Created by SharpDevelop.
 * User: PKsofttech
 * Date: 12/7/2014
 * Time: 6:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of AboutForm.
	/// </summary>
	public partial class AboutForm : Form
	{
		public string AssemblyTitle {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0) {
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "") {
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}
		internal AboutForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            richTextBox1.AppendText("Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString());
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText(@" https://www.facebook.com/pksofttech/");
            richTextBox1.AppendText(Environment.NewLine);
            richTextBox1.AppendText("pksofttech@gmail.com");
            label1.Text = String.Format("** {0} **", AssemblyTitle);
            

            //
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo sInfo = new ProcessStartInfo(@"http://www.laduinocontrol.16mb.com");
            Process.Start(sInfo);
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }


	}
}
