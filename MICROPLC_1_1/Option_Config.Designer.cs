/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 9/13/2015
 * Time: 12:01 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MICROPLC
{
	partial class Option_Config
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tb_baud_rate = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cb_com_select = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rbnt_Input_Active_Hight = new System.Windows.Forms.RadioButton();
			this.rbnt_Input_Active_Low = new System.Windows.Forms.RadioButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.rbnt_output_Active_Hight = new System.Windows.Forms.RadioButton();
			this.rbnt_output_Active_Low = new System.Windows.Forms.RadioButton();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox6 = new System.Windows.Forms.GroupBox();
			this.numericUpDown_loop_time = new System.Windows.Forms.NumericUpDown();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_loop_time)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tb_baud_rate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cb_com_select);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(338, 81);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Model Haed ware Configulation";
			// 
			// tb_baud_rate
			// 
			this.tb_baud_rate.Location = new System.Drawing.Point(238, 44);
			this.tb_baud_rate.Name = "tb_baud_rate";
			this.tb_baud_rate.Size = new System.Drawing.Size(88, 20);
			this.tb_baud_rate.TabIndex = 4;
			this.tb_baud_rate.Text = "115200";
			this.tb_baud_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.tb_baud_rate.TextChanged += new System.EventHandler(this.Tb_baud_rateTextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(149, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Communication baud rate";
			// 
			// cb_com_select
			// 
			this.cb_com_select.FormattingEnabled = true;
			this.cb_com_select.Location = new System.Drawing.Point(138, 17);
			this.cb_com_select.Name = "cb_com_select";
			this.cb_com_select.Size = new System.Drawing.Size(188, 21);
			this.cb_com_select.TabIndex = 2;
			this.cb_com_select.SelectedIndexChanged += new System.EventHandler(this.Cb_com_selectSelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(119, 15);
			this.label1.TabIndex = 1;
			this.label1.Text = "Communication Port";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Location = new System.Drawing.Point(12, 99);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(326, 78);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Information";
			// 
			// textBox1
			// 
			this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBox1.Location = new System.Drawing.Point(3, 16);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(320, 59);
			this.textBox1.TabIndex = 0;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rbnt_Input_Active_Hight);
			this.groupBox3.Controls.Add(this.rbnt_Input_Active_Low);
			this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
			this.groupBox3.Location = new System.Drawing.Point(9, 19);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(155, 70);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Input Active Mode";
			// 
			// rbnt_Input_Active_Hight
			// 
			this.rbnt_Input_Active_Hight.AutoSize = true;
			this.rbnt_Input_Active_Hight.Location = new System.Drawing.Point(13, 42);
			this.rbnt_Input_Active_Hight.Name = "rbnt_Input_Active_Hight";
			this.rbnt_Input_Active_Hight.Size = new System.Drawing.Size(121, 19);
			this.rbnt_Input_Active_Hight.TabIndex = 1;
			this.rbnt_Input_Active_Hight.Text = "Active Hight Logic";
			this.rbnt_Input_Active_Hight.UseVisualStyleBackColor = true;
			this.rbnt_Input_Active_Hight.CheckedChanged += new System.EventHandler(this.Rbnt_Input_Active_HightCheckedChanged);
			// 
			// rbnt_Input_Active_Low
			// 
			this.rbnt_Input_Active_Low.AutoSize = true;
			this.rbnt_Input_Active_Low.Checked = true;
			this.rbnt_Input_Active_Low.ForeColor = System.Drawing.Color.Red;
			this.rbnt_Input_Active_Low.Location = new System.Drawing.Point(13, 19);
			this.rbnt_Input_Active_Low.Name = "rbnt_Input_Active_Low";
			this.rbnt_Input_Active_Low.Size = new System.Drawing.Size(115, 19);
			this.rbnt_Input_Active_Low.TabIndex = 0;
			this.rbnt_Input_Active_Low.TabStop = true;
			this.rbnt_Input_Active_Low.Text = "Active Low Logic";
			this.rbnt_Input_Active_Low.UseVisualStyleBackColor = true;
			this.rbnt_Input_Active_Low.CheckedChanged += new System.EventHandler(this.Rbnt_Input_Active_LowCheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.rbnt_output_Active_Hight);
			this.groupBox4.Controls.Add(this.rbnt_output_Active_Low);
			this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox4.ForeColor = System.Drawing.Color.Black;
			this.groupBox4.Location = new System.Drawing.Point(168, 19);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(166, 70);
			this.groupBox4.TabIndex = 2;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Output Active Mode";
			// 
			// rbnt_output_Active_Hight
			// 
			this.rbnt_output_Active_Hight.AutoSize = true;
			this.rbnt_output_Active_Hight.Location = new System.Drawing.Point(13, 42);
			this.rbnt_output_Active_Hight.Name = "rbnt_output_Active_Hight";
			this.rbnt_output_Active_Hight.Size = new System.Drawing.Size(138, 19);
			this.rbnt_output_Active_Hight.TabIndex = 1;
			this.rbnt_output_Active_Hight.Text = "Source (Active Hight)";
			this.rbnt_output_Active_Hight.UseVisualStyleBackColor = true;
			this.rbnt_output_Active_Hight.CheckedChanged += new System.EventHandler(this.rbnt_output_Active_Hight_CheckedChanged);
			// 
			// rbnt_output_Active_Low
			// 
			this.rbnt_output_Active_Low.AutoSize = true;
			this.rbnt_output_Active_Low.Checked = true;
			this.rbnt_output_Active_Low.ForeColor = System.Drawing.Color.Red;
			this.rbnt_output_Active_Low.Location = new System.Drawing.Point(13, 19);
			this.rbnt_output_Active_Low.Name = "rbnt_output_Active_Low";
			this.rbnt_output_Active_Low.Size = new System.Drawing.Size(117, 19);
			this.rbnt_output_Active_Low.TabIndex = 0;
			this.rbnt_output_Active_Low.TabStop = true;
			this.rbnt_output_Active_Low.Text = "Sink (Active Low)";
			this.rbnt_output_Active_Low.UseVisualStyleBackColor = true;
			this.rbnt_output_Active_Low.CheckedChanged += new System.EventHandler(this.rbnt_output_Active_Low_CheckedChanged);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.button2);
			this.groupBox5.Controls.Add(this.button1);
			this.groupBox5.Controls.Add(this.groupBox6);
			this.groupBox5.Controls.Add(this.groupBox3);
			this.groupBox5.Controls.Add(this.groupBox4);
			this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox5.ForeColor = System.Drawing.Color.Red;
			this.groupBox5.Location = new System.Drawing.Point(12, 183);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(340, 159);
			this.groupBox5.TabIndex = 3;
			this.groupBox5.TabStop = false;
			this.groupBox5.Text = "Setting MCU";
			// 
			// button2
			// 
			this.button2.ForeColor = System.Drawing.Color.Black;
			this.button2.Location = new System.Drawing.Point(259, 113);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 5;
			this.button2.Text = "Close";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button1
			// 
			this.button1.ForeColor = System.Drawing.Color.Black;
			this.button1.Location = new System.Drawing.Point(168, 113);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 4;
			this.button1.Text = "Default";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox6
			// 
			this.groupBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.groupBox6.Controls.Add(this.numericUpDown_loop_time);
			this.groupBox6.Location = new System.Drawing.Point(9, 95);
			this.groupBox6.Name = "groupBox6";
			this.groupBox6.Size = new System.Drawing.Size(155, 53);
			this.groupBox6.TabIndex = 3;
			this.groupBox6.TabStop = false;
			this.groupBox6.Text = "Cycle Loop Time (ms)";
			// 
			// numericUpDown_loop_time
			// 
			this.numericUpDown_loop_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.numericUpDown_loop_time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.numericUpDown_loop_time.Location = new System.Drawing.Point(24, 20);
			this.numericUpDown_loop_time.Maximum = new decimal(new int[] {
			100000,
			0,
			0,
			0});
			this.numericUpDown_loop_time.Minimum = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.numericUpDown_loop_time.Name = "numericUpDown_loop_time";
			this.numericUpDown_loop_time.Size = new System.Drawing.Size(101, 24);
			this.numericUpDown_loop_time.TabIndex = 0;
			this.numericUpDown_loop_time.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.numericUpDown_loop_time.Value = new decimal(new int[] {
			10,
			0,
			0,
			0});
			this.numericUpDown_loop_time.ValueChanged += new System.EventHandler(this.numericUpDown_loop_time_ValueChanged);
			// 
			// Option_Config
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(363, 354);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox5);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Option_Config";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Option_Config";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox5.ResumeLayout(false);
			this.groupBox6.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown_loop_time)).EndInit();
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.RadioButton rbnt_Input_Active_Hight;
		private System.Windows.Forms.RadioButton rbnt_Input_Active_Low;
		private System.Windows.Forms.RadioButton rbnt_output_Active_Low;
		private System.Windows.Forms.RadioButton rbnt_output_Active_Hight;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.ComboBox cb_com_select;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown numericUpDown_loop_time;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_baud_rate;
    }
}
