/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 4/10/2015
 * Time: 11:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace MICROPLC
{
    /// <summary>
    /// Class with program entry point.
    /// </summary>
    internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
             string argsstr = "null";
             if (args.Length >=1)
                 argsstr = args[0];
             MainForm mainForm = new MainForm(argsstr); //this takes ages            
            Application.Run(mainForm);	
            
		}
		
	}
}
