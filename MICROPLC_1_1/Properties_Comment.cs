/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 14/2/2559
 * Time: 18:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of Properties_Comment.
	/// </summary>
	public partial class Properties_Comment : Form
	{
		Elements tag;
		public Properties_Comment(Elements element)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			tag = element;
			textBox1.Text = element.Properties;
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void Properties_CommentFormClosed(object sender, FormClosedEventArgs e)
		{
			tag.Properties = textBox1.Text;
		}
	}
}
