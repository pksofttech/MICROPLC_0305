/*
 * Created by SharpDevelop.
 * User: PksofttecH
 * Date: 19/8/2558
 * Time: 15:36
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of Set_stratus_from.
	/// </summary>
	public partial class Set_stratus_from : Form
	{
		Elements tempElement;
		public Set_stratus_from(Elements element)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();			
			Text = string.Format("Set Stratus For : {0}",element.Name);
			if(element.Type == TypeTag.CONTACTS){
				button1.Text = element.Startus ? "Deactivate" : "Activate";
			}
			tempElement = element;
		}
		void Button1Click(object sender, EventArgs e)
		{
			tempElement.Startus = !tempElement.Startus;
			if(tempElement.Type == TypeTag.CONTACTS){
				button1.Text = tempElement.Startus ? "Deactivate" : "Activate";
			}
		}

	}
}
