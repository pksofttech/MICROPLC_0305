using System;
using System.Drawing;
using System.Management;
using System.Threading;
using System.Windows.Forms;
using System.IO;
namespace MICROPLC
{
	public class ProgressForm : Form
	{
		Button btnOk;
		Button btnCancel;
		// Note: richtext box can hold much longer text than a plain textbox.
		RichTextBox richTextBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System.ComponentModel.IContainer components;

        /// <summary>
        /// Default constructor
        /// </summary>
        /// 
        //string strcom;
        readonly int typeMcu;
        readonly int FormatType = 2;
        readonly int _mode = 0;
		// 0 == Arduino Format,1 == Arduino Building Format
		public ProgressForm(string inofiles, int typeMCU, int mode)
		{
			typeMcu = typeMCU;
			_mode = mode;
			InitializeComponent();
			SetProgressbar(0);
			//strcom = comport;            
			inofile = inofiles;
			try {
				var tempFile =
					new StreamReader(inofile);
				string strcompile = tempFile.ReadToEnd();
				tempFile.Close();
				btnOk.Enabled = false;
				//richTextBox1.Text = strcompile;
				
			} catch (IOException e) {
				btnOk.Enabled = false;
				richTextBox1.Text = "compile error\n" + e.Message;
				return;
			}            
            
			timer_ok.Start();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressForm));
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.timer_ok = new System.Windows.Forms.Timer(this.components);
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.Location = new System.Drawing.Point(345, 360);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "&Retry";
			this.btnOk.Click += new System.EventHandler(this.BtnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(12, 360);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "&About";
			this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// timer_ok
			// 
			this.timer_ok.Interval = 1000;
			this.timer_ok.Tick += new System.EventHandler(this.Timer_okTick);
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
			this.richTextBox1.HideSelection = false;
			this.richTextBox1.Location = new System.Drawing.Point(12, 38);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(408, 311);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.TabStop = false;
			this.richTextBox1.Text = "";
			this.richTextBox1.WordWrap = false;
			// 
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(408, 26);
			this.label1.TabIndex = 3;
			this.label1.Text = "Process Compile Upload To Hardware...";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ProgressForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(432, 395);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ProgressForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ProgressForm";
			this.ResumeLayout(false);

		}

        #endregion

        //string strArgs = @" -Cavrdude.conf -v -v -v -v -patmega328p -carduino -P\\.\COM3 -b115200 -D -Uflash:w:";

        readonly string inofile = Environment.GetEnvironmentVariable("temp") + @"\arduinoplclibtemp.ino";
		//string inofile = Path.GetTempPath() + "arduinoplclibtemp.ino";
		ProcessCaller processCaller;
		Label label1;
		System.Windows.Forms.Timer timer_ok;

		void BtnOk_Click(object sender, EventArgs e)
		{
			richTextBox1.Text = "";
			Startprocess();
		}
        
		// -compile -logger=machine -hardware "D:\arduino-1.6.6\hardware" -tools "D:\arduino-1.6.6\tools-builder" -tools "D:\arduino-1.6.6\hardware\tools\avr" -built-in-libraries "D:\arduino-1.6.6\libraries" -libraries "C:\Users\Administrator\Documents\Arduino\libraries" -fqbn=arduino:avr:uno -ide-version=10606 -build-path "%d\" -warnings=none -prefs=build.warn_data_percentage=75 -verbose "%d%f"
		string stratus_process = "compile";
		
		void Startprocess()
		{
			btnOk.Enabled = false;
			richTextBox1.Text = "";
			string curFile = "";
			string path_tool;
			string command;
			string hardware;
			string tools;
			string libraries;
			string fqbn;
			string build_path;
			string build_file;
			string Arguments = "";
			switch (FormatType) {
				case 0:
					curFile = Application.StartupPath + @"\bin\arduino-builder.exe";
					path_tool = Application.StartupPath + @"\bin\";
					command = "-compile -logger=machine";
					hardware = @"-hardware """ + path_tool + @"hardware"""; 
					tools = @"-tools """ + path_tool + @"tools-builder""" +
					@" -tools """ + path_tool + @"hardware\tools\avr""";
					libraries = @"-built-in-libraries """ + path_tool + @"libraries""";
					fqbn = @"-fqbn=arduino:avr:uno";
					switch (typeMcu) {
						case 1:
							fqbn = @"-fqbn=arduino:avr:uno";
							break;
						case 13:
							fqbn = @"-fqbn=arduino:avr:mega:cpu=atmega2560";
							break;
					}
			
					build_path = string.Format(@"-ide-version=10606 " +
					@" -build-path {0}\" +
					@" -warnings=none -prefs=build.warn_data_percentage=75", Ladder.tempDirectory);
					build_file = string.Format(@" -verbose ""{0}""", inofile);
					Arguments = string.Format("{0} {1} {2} {3} {4} {5} {6}", command, hardware, tools, libraries, fqbn, build_path, build_file);
					break;
				case 1:
					curFile = Application.StartupPath + @"\system\ArduinoUploader.exe";
					path_tool = Application.StartupPath + @"\system\";
					build_file = string.Format(@"{0}", inofile);
					Arguments = string.Format(@"{0} {1}", inofile, typeMcu);
					break;
				case 2:
					curFile = Application.StartupPath + @"\system\bin\avr-g++.exe";		
					string appStr = Application.StartupPath;
					path_tool = appStr + @"\system\";
					string tempdir = @Ladder.tempDirectory;
					string filecpp = tempdir + @"\tempcpp";
					string inocode = File.ReadAllText(inofile);
					//inocode += File.ReadAllText(path_tool + @"arduino\hardware\arduino\cores\arduino\main.cpp"); 
					File.WriteAllText(filecpp + ".cpp", inocode);
					//string plclib = Path.Combine(path_tool, @"\arduino\libraries\plcLib\plcLib");
					string mcu = "";
					string DARDUINO = "";
					string variants = "";
					filecpp = "\"" + filecpp + "\"";
					switch (typeMcu) {
						case 1:
							mcu = @"atmega328p";
							DARDUINO = "-DARDUINO_AVR_MEGA382P";
							variants = "uno";
							break;
						case 2:
							mcu = @"atmega168";
							DARDUINO = "-DARDUINO_AVR_MEGA168";
							variants = "uno";
							break;
						case 13:
							mcu = @"atmega2560";
							DARDUINO = "-DARDUINO_AVR_MEGA2560";
							variants = "mega";
							break;
						case 23:
							mcu = @"atmega2560";
							DARDUINO = "-DARDUINO_AVR_MEGA2560 -DARDUINO_AVR_PLC_DECA";
							variants = "mega";
							break;
					}					
					Arguments = string.Format(@"-c -Os -s -pipe -fno-exceptions -ffunction-sections -fdata-sections -MMD -DARDUINO=10604 -DF_CPU=16000000L -mmcu={0} -DARDUINO_ARCH_AVR {1} -I""{2}arduino\hardware\arduino\cores/arduino"" -I""{2}arduino/hardware/arduino/variants/{3}"" -I""{2}arduino/libraries/plcLib"" {4}.cpp -o {4}.o", mcu, DARDUINO, path_tool, variants, filecpp);
					//Arguments.Replace('\\', Path.DirectorySeparatorChar);
					break;
				default:
					return;
			}
			
			
			if (!(File.Exists(curFile))) {
				MessageBox.Show(string.Format("No Module PlcLibArduinoComplie !\n{0}", curFile), "LDPLCUNO Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}


            processCaller = new ProcessCaller(this)
            {
                FileName = curFile,
                Arguments = string.Format("{0}", Arguments)
            };

            processCaller.StdErrReceived += WriteStreamError;
			processCaller.StdOutReceived += WriteStreamInfo;
			processCaller.Completed += ProcessCompletedOrCanceled;

			richTextBox1.Text = "Started function.  Please stand by..\n" + curFile + " " + processCaller.Arguments + Environment.NewLine;

			stratus_process = "compile";
			
			processCaller.Start();
              
		}
		
		void Startprocess_compile_TimerScan()
		{
			string Arguments = "";
			string curFile = Application.StartupPath + @"\system\bin\avr-g++.exe";					
			string path_tool = Application.StartupPath + @"\system\";
			string tempdir = @Ladder.tempDirectory;
			
//			string inocode = File.ReadAllText(inofile);
//			File.WriteAllText(filecpp + ".cpp", inocode);
			string plclib = path_tool + @"arduino\libraries\plcLib\TimerOne";
			//string filecpp = plclib + @"\tempcpp";
			string mcu = "";
			string DARDUINO = "";
			string variants = "";
			switch (typeMcu) {
				case 1:
					mcu = @"atmega328p";
					DARDUINO = "-DARDUINO_AVR_MEGA382P";
					variants = "uno";
					break;
				case 2:
					mcu = @"atmega168";
					DARDUINO = "-DARDUINO_AVR_MEGA168";
					variants = "uno";
					break;
				case 13:
					mcu = @"atmega2560";
					DARDUINO = "-DARDUINO_AVR_MEGA2560";
					variants = "mega";
					break;
				case 23:
					mcu = @"atmega2560";
					DARDUINO = "-DARDUINO_AVR_MEGA2560 -DARDUINO_AVR_PLC_DECA";
					variants = "mega";
					break;
			}					
			Arguments = string.Format(@"-c -Os -s -pipe -fno-exceptions -ffunction-sections -fdata-sections -MMD -DARDUINO=10604 -DF_CPU=16000000L -mmcu={0} -DARDUINO_ARCH_AVR {1} -I""{2}arduino/hardware/arduino/cores/arduino"" -I""{2}arduino/hardware/arduino/variants/{3}"" -I""{2}arduino/libraries/plcLib"" ""{4}.cpp"" -o {5}/TimerOne.o", mcu, DARDUINO, path_tool, variants, plclib, tempdir);
							
			
			if (!(File.Exists(curFile))) {
				MessageBox.Show(string.Format("No Module compile_TimerScanComplie !\n{0}", curFile), "LDPLCUNO Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

            processCaller = new ProcessCaller(this)
            {
                FileName = curFile,
                Arguments = Arguments
            };

            processCaller.StdErrReceived += WriteStreamError;
			processCaller.StdOutReceived += WriteStreamInfo;
			processCaller.Completed += ProcessCompletedOrCanceled;
			//processCaller.Cancelled += processCompletedOrCanceled;
			// processCaller.Failed += no event handler for this one, yet.

			richTextBox1.Text += "\nStarted compile_TimerScan...\n" + curFile + " " + processCaller.Arguments + Environment.NewLine;

			// the following function starts a process and returns immediately,
			// thus allowing the form to stay responsive.
			stratus_process = "compile_TimerScan";
			
			processCaller.Start();
              
		}
		void Startprocess_compile_plcLib()
		{
			string Arguments = "";
			string curFile = Application.StartupPath + @"\system\bin\avr-g++.exe";					
			string path_tool = Application.StartupPath + @"\system\";
			string tempdir = @Ladder.tempDirectory;
			
//			string inocode = File.ReadAllText(inofile);
//			File.WriteAllText(filecpp + ".cpp", inocode);
			string plclib = path_tool + @"arduino\libraries\plcLib\";
			//string filecpp = plclib + @"\tempcpp";
			string mcu = "";
			string DARDUINO = "";
			string variants = "";
			switch (typeMcu) {
				case 1:
					mcu = @"atmega328p";
					DARDUINO = "-DARDUINO_AVR_MEGA382P";
					variants = "uno";
					break;
				case 2:
					mcu = @"atmega168";
					DARDUINO = "-DARDUINO_AVR_MEGA168";
					variants = "uno";
					break;
				case 13:
					mcu = @"atmega2560";
					DARDUINO = "-DARDUINO_AVR_MEGA2560";
					variants = "mega";
					break;
				case 23:
					mcu = @"atmega2560";
					DARDUINO = "-DARDUINO_AVR_MEGA2560 -DARDUINO_AVR_PLC_DECA";
					variants = "mega";
					break;
			}					
			Arguments = string.Format(@"-c -Os -s -pipe -fno-exceptions -ffunction-sections -fdata-sections -MMD -DARDUINO=10604 -DF_CPU=16000000L -mmcu={0} -DARDUINO_ARCH_AVR {1} -I""{2}arduino/hardware/arduino/cores/arduino"" -I""{2}arduino/hardware/arduino/variants/{3}"" -I""{2}arduino/libraries/plcLib"" ""{4}plcLib.cpp"" -o {5}/plcLib.o", mcu, DARDUINO, path_tool, variants, plclib, tempdir);
							
			
			if (!(File.Exists(curFile))) {
				MessageBox.Show(string.Format("No Module PlcLibArduinoComplie !\n{0}", curFile), "LDPLCUNO Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

            processCaller = new ProcessCaller(this)
            {
                FileName = curFile,
                Arguments = Arguments
            };

            processCaller.StdErrReceived += WriteStreamError;
			processCaller.StdOutReceived += WriteStreamInfo;
			processCaller.Completed += ProcessCompletedOrCanceled;
			//processCaller.Cancelled += processCompletedOrCanceled;
			// processCaller.Failed += no event handler for this one, yet.

			richTextBox1.Text += "\nStarted compile_plcLib...\n" + curFile + " " + processCaller.Arguments + Environment.NewLine;

			// the following function starts a process and returns immediately,
			// thus allowing the form to stay responsive.
			stratus_process = "compile_plcLib";
			
			processCaller.Start();
              
		}
        int index_librariesName = 0;
        string[] libs;
        void Startprocess_compile_Libraries(int index)
        {
            string Arguments = "";
            string curFile = Application.StartupPath + @"\system\bin\avr-g++.exe";
            string path_tool = Application.StartupPath + @"\system\";
            string tempdir = @Ladder.tempDirectory;

            string plclib = path_tool + @"arduino\libraries\plcLib\";

            string mcu = "";
            string DARDUINO = "";
            string variants = "";
            if(index == 0)
            {
             libs = Directory.GetFiles(plclib, "*.cpp");
            for (int i = 0; i < libs.Length; i++)
                libs[i] = Path.GetFileName(libs[i]);

			}
            

            //string[] lib = librariesName.Split(' ');
            if(index >= libs.Length)
            {
                stratus_process = "compile_Libraries successful completed!";
                //SetProgressbar(40);
                richTextBox1.AppendText("Compile_Libraries successful completed!\n\n");
                Startprocess_link();
                return;
            }
           
            switch (typeMcu)
            {
                case 1:
                    mcu = @"atmega328p";
                    DARDUINO = "-DARDUINO_AVR_MEGA382P";
                    variants = "uno";
                    break;
                case 2:
                    mcu = @"atmega168";
                    DARDUINO = "-DARDUINO_AVR_MEGA168";
                    variants = "uno";
                    break;
                case 13:
                    mcu = @"atmega2560";
                    DARDUINO = "-DARDUINO_AVR_MEGA2560";
                    variants = "mega";
                    break;
                case 23:
                    mcu = @"atmega2560";
                    DARDUINO = "-DARDUINO_AVR_MEGA2560 -DARDUINO_AVR_PLC_DECA";
                    variants = "mega";
                    break;
            }
            Arguments = string.Format(@"-c -Os -s -pipe -fno-exceptions -ffunction-sections -fdata-sections -MMD -DARDUINO=10604 -DF_CPU=16000000L -mmcu={0} -DARDUINO_ARCH_AVR {1} -I""{2}arduino/hardware/arduino/cores/arduino"" -I""{2}arduino/hardware/arduino/variants/{3}"" -I""{2}arduino/libraries/plcLib"" ""{4}{6}"" -o ""{5}/{6}.o""", mcu, DARDUINO, path_tool, variants, plclib, tempdir, libs[index_librariesName]);


            if (!(File.Exists(curFile)))
            {
                MessageBox.Show(string.Format("No Module compile_Libraries !\n{0}", curFile), "LDPLCUNO Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            processCaller = new ProcessCaller(this)
            {
                FileName = curFile,
                Arguments = Arguments
            };

            processCaller.StdErrReceived += WriteStreamError;
            processCaller.StdOutReceived += WriteStreamInfo;
            processCaller.Completed += ProcessCompletedOrCanceled;

            richTextBox1.Text += "\nStarted compile_Libraries...\n" + libs[index_librariesName] + " =>>" + processCaller.Arguments + Environment.NewLine;
            
            stratus_process = "compile_Libraries";

            processCaller.Start();

        }
        void Startprocess_link()
		{
			string curFile = "";
			string path_tool;
			string Arguments = "";
			string mcu = "";
			//string DARDUINO = "";
			//string variants = "";
			
			curFile = Application.StartupPath + @"\system\bin\avr-gcc.exe";					
			path_tool = Application.StartupPath + @"\system\";
			string tempdir = @Ladder.tempDirectory;
			string elffile = tempdir + @"\tempcpp.elf";
			string objfile = tempdir + @"\tempcpp.o";
			string obj_plcLib_file = tempdir + @"\plcLib.o";
			string obj_TimerOne_file = tempdir + @"\TimerOne.o";

            string[] libs = Directory.GetFiles(tempdir, "*.o");
   //         for (int i = 0; i < libs.Length; i++)
   //             libs[i] = Path.GetFileName(libs[i]);

            string obj_Libraries_file = "";
            //string[] libs = librariesName.Split(' ');
            string libslist = "";
            foreach (string  lib in libs)
            {
                obj_Libraries_file += string.Format(@"""{0}"" ",lib, tempdir);
                libslist += string.Format("\n{0}" , lib);

			}
			string a_file = "";
			switch (typeMcu) {
				case 1:
					mcu = @"atmega328p";
					a_file = path_tool + @"arduino\hardware\arduino\variants\uno\core\core.a";
			
					break;
				case 2:
					mcu = @"atmega168";
					a_file = path_tool + @"arduino\hardware\arduino\variants\uno\core\core.a";
			
					break;
				case 13:
				case 23:
					mcu = @"atmega2560";
					a_file = path_tool + @"arduino\hardware\arduino\variants\mega\core\core.a";
			
					break;
			}
			
			
			Arguments = string.Format(@"-w -Os -Wl,--gc-sections -mmcu={0} -o ""{1}"" {6} ""{5}""", mcu, elffile, objfile, obj_plcLib_file, obj_TimerOne_file, a_file, obj_Libraries_file);
			
			if (!(File.Exists(curFile))) {
				MessageBox.Show(string.Format("No Module PlcLibArduinoComplie !\n{0}", curFile), "LDPLCUNO Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

            processCaller = new ProcessCaller(this)
            {
                FileName = curFile,
                Arguments = Arguments
            };

            processCaller.StdErrReceived += WriteStreamError;
			processCaller.StdOutReceived += WriteStreamInfo;
			processCaller.Completed += ProcessCompletedOrCanceled;
            //processCaller.Cancelled += processCompletedOrCanceled;
            // processCaller.Failed += no event handler for this one, yet.

            richTextBox1.Text += "\nStarted Link Obj...\n" + curFile + " " + processCaller.Arguments + Environment.NewLine + libslist;


			// the following function starts a process and returns immediately,
			// thus allowing the form to stay responsive.
			stratus_process = "link";
			
			processCaller.Start();
              
		}
		void Startprocess_objcopy()
		{
			string curFile = "";
			string path_tool;
			string Arguments = "";
			switch (typeMcu) {
				case 1:
                    break;
				case 2:
                    break;
				case 13:
				case 23:
                    break;
			}
			switch (FormatType) {
				case 2:
					curFile = Application.StartupPath + @"\system\bin\avr-objcopy.exe";
					
					path_tool = Application.StartupPath + @"\system\";
					string tempdir = @Ladder.tempDirectory;
					string filecpp = tempdir + @"\tempcpp";
					Arguments = string.Format(@"-j .text -j .data -O ihex ""{0}.elf"" ""{0}.hex""", filecpp);
					break;
				default:
					return;
			}
			
			
			if (!(File.Exists(curFile))) {
				MessageBox.Show(string.Format("No Module PlcLibArduinoComplie !\n{0}", curFile), "LDPLCUNO Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

            processCaller = new ProcessCaller(this)
            {
                FileName = curFile,
                Arguments = Arguments
            };

            processCaller.StdErrReceived += WriteStreamError;
			processCaller.StdOutReceived += WriteStreamInfo;
			processCaller.Completed += ProcessCompletedOrCanceled;

			richTextBox1.Text += "\nStarted Generating Intel Hex Files...\n" + curFile + " " + processCaller.Arguments + Environment.NewLine;

			// the following function starts a process and returns immediately,
			// thus allowing the form to stay responsive.
			stratus_process = "check_memory";
			
			processCaller.Start();
              
		}
		void BtnCancel_Click(object sender, System.EventArgs e)
		{
			if (processCaller != null) {
				processCaller.Cancel();
			}
		}
		int error_index = 0;
		void WriteStreamError(object sender, DataReceivedEventArgs e)
		{
			switch (stratus_process) {
				case "compile":
					error_index = richTextBox1.Text.Length;
				//richTextBox1.ForeColor = Color.Red;
					richTextBox1.AppendText(e.Text + Environment.NewLine);
				//richTextBox1.ForeColor = Color.White;
					richTextBox1.SelectionStart = error_index;
					richTextBox1.SelectionLength = e.Text.Length;
					richTextBox1.SelectionColor = Color.Red;	
			
					break;
				case "link":
				case "compile_Libraries":
				case "objcopy":	
				case "Error":
					error_index = richTextBox1.Text.Length;
				//richTextBox1.ForeColor = Color.Red;
					richTextBox1.AppendText(e.Text + Environment.NewLine);
				//richTextBox1.ForeColor = Color.White;
					richTextBox1.SelectionStart = error_index;
					richTextBox1.SelectionLength = e.Text.Length;
					richTextBox1.SelectionColor = Color.Red;
					stratus_process = "Error";
					break;
				case "upload":
					error_index = richTextBox1.Text.Length;
				//richTextBox1.ForeColor = Color.Red;
					richTextBox1.AppendText(e.Text + Environment.NewLine);
				//richTextBox1.ForeColor = Color.White;
					richTextBox1.SelectionStart = error_index;
					richTextBox1.SelectionLength = e.Text.Length;
					richTextBox1.SelectionColor = Color.OrangeRed;
				
					string compiliation = "avrdude.exe: stk500v2_ReceiveMessage(): timeout";
					if (richTextBox1.Find(compiliation) > -1) {
						processCaller.Cancel();
						MessageBox.Show(" timeout ", "Program Upload Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					
						processCaller.Cancel();
						DialogResult = DialogResult.OK;
						Close();						
					
					}
					break;
			}
		}
		string report_memory = "";
		void WriteStreamInfo(object sender, DataReceivedEventArgs e)
		{
			//richTextBox1.ForeColor = Color.White;
			string buffer_Stream = e.Text;
			switch (stratus_process) {
				case "compile":
					int retFind = buffer_Stream.IndexOf("===Progress {0} ||| [", StringComparison.Ordinal);
					if (retFind > -1) {
						string buffer_stratus = buffer_Stream.Substring(retFind + 21, 3);
						float buffer_mvalue;
                        float.TryParse(buffer_stratus, out buffer_mvalue);
                        SetProgressbar((int)buffer_mvalue);
						richTextBox1.AppendText(buffer_Stream + Environment.NewLine);
					} 
					richTextBox1.AppendText(buffer_Stream + Environment.NewLine);
					break;
				case "check_memory":
				case "objcopy":
					richTextBox1.AppendText(buffer_Stream + Environment.NewLine);
					report_memory += buffer_Stream + Environment.NewLine;
					break;
				default:
					//richTextBox1.AppendText(buffer_Stream + Environment.NewLine);
					break;
			}
		}
		
		void StartprocessProgram_size()
		{
			//richTextBox1.Text = "";
			string curFile = Application.StartupPath + @"/system/bin/avr-size.exe";		
			//string path_tool = Application.StartupPath + @"\bin\hardware\tools\avr\";
			string para1 = string.Format(@"-C ");
			
			string para2 = "";
			
			switch (typeMcu) {
				case 1:
					para2 = string.Format(@"--mcu=atmega328p ");
					break;
				case 2:
					para2 = string.Format(@"--mcu=atmega168 ");
					break;
				case 13:
				case 23:
					para2 = string.Format(@"--mcu=atmega2560 ");
					break;
			}
			string elffile = Ladder.tempDirectory + @"\tempcpp.elf";
		
			string para3 = string.Format(@"{0}", elffile);
			
			if (!(File.Exists(elffile))) {
				MessageBox.Show(string.Format("No Elf File !\n{0}", curFile), "Laduino Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

            processCaller = new ProcessCaller(this)
            {
                FileName = curFile,
                Arguments = string.Format(@"{0} {1} ""{2}""", para1, para2, para3)
            };

            processCaller.StdErrReceived += new DataReceivedHandler(WriteStreamError);
			processCaller.StdOutReceived += new DataReceivedHandler(WriteStreamInfo);
			processCaller.Completed += new EventHandler(ProcessCompletedOrCanceled);
			processCaller.Cancelled += new EventHandler(ProcessCompletedOrCanceled);
			// processCaller.Failed += no event handler for this one, yet.

			richTextBox1.Text += "Started Check Memory User...\n" + curFile + " " + processCaller.Arguments + Environment.NewLine;

			// the following function starts a process and returns immediately,
			// thus allowing the form to stay responsive.
			stratus_process = "check_memory";
			if (FormatType == 2)
				stratus_process = "objcopy";
			processCaller.Start();
         
		}

		void StartprocessUpload()
		{
			btnOk.Enabled = false;
			
			string curFile = Application.StartupPath + @"/system/bin/avrdude.exe";
		
			if (!(File.Exists(curFile))) {
				MessageBox.Show(string.Format("No Module AVR Upload !\n{0}", curFile), "LDPLCUNO Error",
					MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			string strComName = "";
			if (Ladder.strCommunicationName.IndexOf("COM", StringComparison.Ordinal) > -1) {
				strComName = Ladder.strCommunicationName;
			}
			if (strComName == "") {
				strComName = Ladder.AutodetectArduinoPort();
				if (strComName == "") {					
				
					DialogResult result = MessageBox.Show("No Com-Port Seeting to HW!", "Can'n Upload!", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
					if (result == DialogResult.OK) {
						Option_Config option_Config = new Option_Config();
						option_Config.ShowDialog();
						strComName = Ladder.strCommunicationName;
					
					}
				} else {
					Ladder.strCommunicationName = strComName;
				}
			}
			
			string path_tool = Application.StartupPath + @"/system/bin/";
			string para1 = string.Format(@"""-C{0}avrdude.conf """, path_tool);
			
			string para2 = "";
			string baud_rate = Ladder.strCommunication_baud_rate;
			switch (typeMcu) {
				case 1:
					para2 = string.Format(@"-v -patmega328p -carduino -P{0} -b{1} -D", strComName,baud_rate);
					break;
				case 2:
					para2 = string.Format(@"-v -patmega168 -carduino -P{0} -b{1} -D", strComName,baud_rate);
					break;
				case 13:
				case 23:
					para2 = string.Format(@"-v -patmega2560 -cwiring -P{0} -b{1} -D", strComName,baud_rate);
					break;
			}
			string para3 = string.Format(@"-Uflash:w:""{0}.hex"":i", Ladder.tempDirectory + @"/tempcpp");

            //E:\arduino_tool\hardware\tools\avr/bin/avrdude -CE:\arduino_tool\hardware\tools\avr/etc/avrdude.conf -v -patmega328p -carduino -PCOM5 -b115200 -D -Uflash:w:C:\Users\ADMINI~1\AppData\Local\Temp\build95cf39be4ecd73ad3d3a8e624857745f.tmp/Blink.ino.hex:i

            processCaller = new ProcessCaller(this)
            {
                FileName = curFile,
                Arguments = string.Format(@"{0} {1} {2}", para1, para2, para3)
            };

            processCaller.StdErrReceived += new DataReceivedHandler(WriteStreamError);
			processCaller.StdOutReceived += new DataReceivedHandler(WriteStreamInfo);
			processCaller.Completed += new EventHandler(ProcessCompletedOrCanceled);
			processCaller.Cancelled += new EventHandler(ProcessCompletedOrCanceled);
			// processCaller.Failed += no event handler for this one, yet.

			richTextBox1.Text = "Started function.  Please stand by..\n" + curFile + " " + processCaller.Arguments + Environment.NewLine;

			// the following function starts a process and returns immediately,
			// thus allowing the form to stay responsive.
			stratus_process = "upload";
			processCaller.Start();
         
		}
		void ProcessCompletedOrCanceled(object sender, EventArgs e)
		{
			Cursor = Cursors.Default;
			btnOk.Enabled = true;	
			string compiliation = "";
			switch (stratus_process) {
				case "compile":			
					if (richTextBox1.Find("error") > 0) {					
						MessageBox.Show("Error Compile", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return;
					}
					switch (FormatType) {
						case 0:
							compiliation = "===Progress {0} ||| [100.00]";
							if (richTextBox1.Find(compiliation) > -1) {
								SetProgressbar(100);
								StartprocessProgram_size();											
							}
							break;
						case 1:
							compiliation = "Compiliation successful completed!";
							if (richTextBox1.Find(compiliation) > -1) {
								SetProgressbar(100);
								StartprocessProgram_size();											
							}
							break;
						case 2:
							compiliation = "Avr Compile successful completed!\n\n";
							SetProgressbar(25);
							richTextBox1.AppendText(compiliation);
                            //startprocess_compile_TimerScan();		
                            Startprocess_compile_Libraries(0);
							break;
					}				
					break;

                case "compile_Libraries":
                    compiliation = "Compile_compile_Libraries "+ index_librariesName + " successful completed!\n";
                    //SetProgressbar(40);
                    richTextBox1.AppendText(compiliation);
                    Startprocess_compile_Libraries(++index_librariesName);
                    break;

                case "link":
					compiliation = "Link successful completed!\n\n";
					SetProgressbar(60);
					richTextBox1.AppendText(compiliation);						
					StartprocessProgram_size();
					break;
				case "objcopy":		
					compiliation = "Genalator ELF File successful completed!\n\n";
					SetProgressbar(80);
					richTextBox1.AppendText(compiliation);	
					Startprocess_objcopy();

					break;
				case "check_memory":		
					compiliation = "(.data + .bss + .noinit)";
					if (richTextBox1.Find(compiliation) > -1) {
						if (_mode == 1) {
							SetProgressbar(100);
							MessageBox.Show(report_memory, "Program Compile Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
							DialogResult = DialogResult.OK;
							Close();
							return;
						}						
						StartprocessUpload();							
					}
					break;
				case "upload":		
					//compiliation = "avrdude.exe done.  Thank you.";
					compiliation = "avrdude.exe: verifying ...";
					if (richTextBox1.Find(compiliation) > -1) {
						SetProgressbar(100);
						report_memory =
						"###################################\n" +
						Ladder.Hardware_name + "\n" +
						"###################################\n" +
						report_memory;
						MessageBox.Show(report_memory, "Program Upload Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
						DialogResult = DialogResult.OK;
						Close();						
					}
					break;
			}
//			if (-1 != richTextBox1.Find("read from file '" + inofile + "' failed")) {
//				MessageBox.Show("read from file '" + inofile + "' failed", "LDPLCUNO", 
//					MessageBoxButtons.OK, MessageBoxIcon.Error);
//				return;
//			
//			}
			
		}
  
		void BtnCloseClick(object sender, EventArgs e)
		{
			Close();
		}
		void Timer_okTick(object sender, EventArgs e)
		{
			Text += "\t Start Progress";
			timer_ok.Stop();
			Startprocess();
		}
		
		void SetProgressbar(int value)
		{
			this.Text = "UPLOAD PROCESS " + value.ToString() + "%";	
			(Application.OpenForms["MainForm"] as MainForm).SettoolStripProgressBar(value);           
		}

	}
    
}
