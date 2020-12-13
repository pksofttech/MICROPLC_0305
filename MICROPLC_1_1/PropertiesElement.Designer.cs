/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 7/3/2015
 * Time: 6:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MICROPLC
{
	partial class PropertiesElement
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton rBnt_Output;
		private System.Windows.Forms.RadioButton rBnt_Input;
		private System.Windows.Forms.RadioButton rBnt_Internal_R;
		private System.Windows.Forms.ComboBox comboBox_Name;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rBnt_Reset;
		private System.Windows.Forms.RadioButton rBnt_Set;
		private System.Windows.Forms.RadioButton rBnt_Inverts;
		private System.Windows.Forms.RadioButton rBnt_Nornal;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.RadioButton rBnt_Counter_R;
		private System.Windows.Forms.Label label_Preset;
		private System.Windows.Forms.NumericUpDown numeric_Reset;
		private System.Windows.Forms.Label label_Reset;
		private System.Windows.Forms.NumericUpDown numeric_Preset;
		private System.Windows.Forms.CheckBox checkBox_auto_clear;
		private System.Windows.Forms.RadioButton rBnt_Shift_Bit;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown numericBitValue;
		private System.Windows.Forms.Button button_Convert;
		
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertiesElement));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_Convert = new System.Windows.Forms.Button();
            this.checkBox_auto_clear = new System.Windows.Forms.CheckBox();
            this.label_Preset = new System.Windows.Forms.Label();
            this.numeric_Reset = new System.Windows.Forms.NumericUpDown();
            this.label_Reset = new System.Windows.Forms.Label();
            this.numeric_Preset = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericBitValue = new System.Windows.Forms.NumericUpDown();
            this.rBnt_Reset = new System.Windows.Forms.RadioButton();
            this.rBnt_Set = new System.Windows.Forms.RadioButton();
            this.rBnt_Inverts = new System.Windows.Forms.RadioButton();
            this.rBnt_Nornal = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rBnt_Shift_Bit = new System.Windows.Forms.RadioButton();
            this.rBnt_Counter_R = new System.Windows.Forms.RadioButton();
            this.rBnt_Output = new System.Windows.Forms.RadioButton();
            this.rBnt_Input = new System.Windows.Forms.RadioButton();
            this.rBnt_Internal_R = new System.Windows.Forms.RadioButton();
            this.comboBox_Name = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Reset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Preset)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBitValue)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(168, 188);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 176);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1Paint);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button_Convert);
            this.panel2.Controls.Add(this.checkBox_auto_clear);
            this.panel2.Controls.Add(this.label_Preset);
            this.panel2.Controls.Add(this.numeric_Reset);
            this.panel2.Controls.Add(this.label_Reset);
            this.panel2.Controls.Add(this.numeric_Preset);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.comboBox_Name);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(168, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(433, 188);
            this.panel2.TabIndex = 1;
            // 
            // button_Convert
            // 
            this.button_Convert.Enabled = false;
            this.button_Convert.Location = new System.Drawing.Point(331, 8);
            this.button_Convert.Name = "button_Convert";
            this.button_Convert.Size = new System.Drawing.Size(89, 23);
            this.button_Convert.TabIndex = 11;
            this.button_Convert.Text = "Convert";
            this.button_Convert.UseVisualStyleBackColor = true;
            // 
            // checkBox_auto_clear
            // 
            this.checkBox_auto_clear.AutoSize = true;
            this.checkBox_auto_clear.Location = new System.Drawing.Point(343, 93);
            this.checkBox_auto_clear.Name = "checkBox_auto_clear";
            this.checkBox_auto_clear.Size = new System.Drawing.Size(64, 17);
            this.checkBox_auto_clear.TabIndex = 10;
            this.checkBox_auto_clear.Text = "Circular ";
            this.checkBox_auto_clear.UseVisualStyleBackColor = true;
            // 
            // label_Preset
            // 
            this.label_Preset.AutoSize = true;
            this.label_Preset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label_Preset.ForeColor = System.Drawing.Color.Red;
            this.label_Preset.Location = new System.Drawing.Point(290, 65);
            this.label_Preset.Name = "label_Preset";
            this.label_Preset.Size = new System.Drawing.Size(48, 15);
            this.label_Preset.TabIndex = 9;
            this.label_Preset.Text = "Preset";
            this.label_Preset.Visible = false;
            // 
            // numeric_Reset
            // 
            this.numeric_Reset.Location = new System.Drawing.Point(343, 39);
            this.numeric_Reset.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_Reset.Name = "numeric_Reset";
            this.numeric_Reset.Size = new System.Drawing.Size(77, 20);
            this.numeric_Reset.TabIndex = 8;
            this.numeric_Reset.Visible = false;
            // 
            // label_Reset
            // 
            this.label_Reset.AutoSize = true;
            this.label_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label_Reset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label_Reset.Location = new System.Drawing.Point(290, 39);
            this.label_Reset.Name = "label_Reset";
            this.label_Reset.Size = new System.Drawing.Size(44, 15);
            this.label_Reset.TabIndex = 7;
            this.label_Reset.Text = "Reset";
            this.label_Reset.Visible = false;
            // 
            // numeric_Preset
            // 
            this.numeric_Preset.Location = new System.Drawing.Point(343, 65);
            this.numeric_Preset.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_Preset.Name = "numeric_Preset";
            this.numeric_Preset.Size = new System.Drawing.Size(77, 20);
            this.numeric_Preset.TabIndex = 6;
            this.numeric_Preset.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(331, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 31);
            this.button2.TabIndex = 5;
            this.button2.Text = "&Close";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(331, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "&OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.numericBitValue);
            this.groupBox2.Controls.Add(this.rBnt_Reset);
            this.groupBox2.Controls.Add(this.rBnt_Set);
            this.groupBox2.Controls.Add(this.rBnt_Inverts);
            this.groupBox2.Controls.Add(this.rBnt_Nornal);
            this.groupBox2.Location = new System.Drawing.Point(152, 40);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(136, 135);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Element Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Register. Bit";
            // 
            // numericBitValue
            // 
            this.numericBitValue.Location = new System.Drawing.Point(48, 105);
            this.numericBitValue.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericBitValue.Name = "numericBitValue";
            this.numericBitValue.Size = new System.Drawing.Size(45, 20);
            this.numericBitValue.TabIndex = 4;
            this.numericBitValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericBitValue.ValueChanged += new System.EventHandler(this.NumericBitValueValueChanged);
            // 
            // rBnt_Reset
            // 
            this.rBnt_Reset.Location = new System.Drawing.Point(17, 94);
            this.rBnt_Reset.Name = "rBnt_Reset";
            this.rBnt_Reset.Size = new System.Drawing.Size(93, 24);
            this.rBnt_Reset.TabIndex = 3;
            this.rBnt_Reset.TabStop = true;
            this.rBnt_Reset.Text = "Reset Only";
            this.rBnt_Reset.UseVisualStyleBackColor = true;
            // 
            // rBnt_Set
            // 
            this.rBnt_Set.Location = new System.Drawing.Point(17, 70);
            this.rBnt_Set.Name = "rBnt_Set";
            this.rBnt_Set.Size = new System.Drawing.Size(93, 24);
            this.rBnt_Set.TabIndex = 2;
            this.rBnt_Set.TabStop = true;
            this.rBnt_Set.Text = "Set Only";
            this.rBnt_Set.UseVisualStyleBackColor = true;
            // 
            // rBnt_Inverts
            // 
            this.rBnt_Inverts.Location = new System.Drawing.Point(17, 46);
            this.rBnt_Inverts.Name = "rBnt_Inverts";
            this.rBnt_Inverts.Size = new System.Drawing.Size(104, 24);
            this.rBnt_Inverts.TabIndex = 1;
            this.rBnt_Inverts.TabStop = true;
            this.rBnt_Inverts.Text = "Inverts";
            this.rBnt_Inverts.UseVisualStyleBackColor = true;
            // 
            // rBnt_Nornal
            // 
            this.rBnt_Nornal.Location = new System.Drawing.Point(17, 22);
            this.rBnt_Nornal.Name = "rBnt_Nornal";
            this.rBnt_Nornal.Size = new System.Drawing.Size(104, 24);
            this.rBnt_Nornal.TabIndex = 0;
            this.rBnt_Nornal.TabStop = true;
            this.rBnt_Nornal.Text = "Nornal";
            this.rBnt_Nornal.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rBnt_Shift_Bit);
            this.groupBox1.Controls.Add(this.rBnt_Counter_R);
            this.groupBox1.Controls.Add(this.rBnt_Output);
            this.groupBox1.Controls.Add(this.rBnt_Input);
            this.groupBox1.Controls.Add(this.rBnt_Internal_R);
            this.groupBox1.Location = new System.Drawing.Point(8, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 135);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Source";
            // 
            // rBnt_Shift_Bit
            // 
            this.rBnt_Shift_Bit.Location = new System.Drawing.Point(16, 105);
            this.rBnt_Shift_Bit.Name = "rBnt_Shift_Bit";
            this.rBnt_Shift_Bit.Size = new System.Drawing.Size(104, 24);
            this.rBnt_Shift_Bit.TabIndex = 4;
            this.rBnt_Shift_Bit.TabStop = true;
            this.rBnt_Shift_Bit.Text = "Shift Register Bit";
            this.rBnt_Shift_Bit.UseVisualStyleBackColor = true;
            // 
            // rBnt_Counter_R
            // 
            this.rBnt_Counter_R.Location = new System.Drawing.Point(16, 83);
            this.rBnt_Counter_R.Name = "rBnt_Counter_R";
            this.rBnt_Counter_R.Size = new System.Drawing.Size(104, 24);
            this.rBnt_Counter_R.TabIndex = 3;
            this.rBnt_Counter_R.TabStop = true;
            this.rBnt_Counter_R.Text = "Counter Relay";
            this.rBnt_Counter_R.UseVisualStyleBackColor = true;
            // 
            // rBnt_Output
            // 
            this.rBnt_Output.Location = new System.Drawing.Point(16, 13);
            this.rBnt_Output.Name = "rBnt_Output";
            this.rBnt_Output.Size = new System.Drawing.Size(104, 24);
            this.rBnt_Output.TabIndex = 2;
            this.rBnt_Output.TabStop = true;
            this.rBnt_Output.Text = "Output (Y Port)";
            this.rBnt_Output.UseVisualStyleBackColor = true;
            // 
            // rBnt_Input
            // 
            this.rBnt_Input.Location = new System.Drawing.Point(16, 61);
            this.rBnt_Input.Name = "rBnt_Input";
            this.rBnt_Input.Size = new System.Drawing.Size(104, 24);
            this.rBnt_Input.TabIndex = 1;
            this.rBnt_Input.TabStop = true;
            this.rBnt_Input.Text = "Input   (X Port)";
            this.rBnt_Input.UseVisualStyleBackColor = true;
            // 
            // rBnt_Internal_R
            // 
            this.rBnt_Internal_R.Location = new System.Drawing.Point(16, 37);
            this.rBnt_Internal_R.Name = "rBnt_Internal_R";
            this.rBnt_Internal_R.Size = new System.Drawing.Size(104, 24);
            this.rBnt_Internal_R.TabIndex = 0;
            this.rBnt_Internal_R.TabStop = true;
            this.rBnt_Internal_R.Text = "Internal Relay";
            this.rBnt_Internal_R.UseVisualStyleBackColor = true;
            // 
            // comboBox_Name
            // 
            this.comboBox_Name.FormattingEnabled = true;
            this.comboBox_Name.Location = new System.Drawing.Point(136, 8);
            this.comboBox_Name.Name = "comboBox_Name";
            this.comboBox_Name.Size = new System.Drawing.Size(189, 21);
            this.comboBox_Name.TabIndex = 1;
            this.comboBox_Name.Text = "New";
            this.comboBox_Name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBox_NameKeyDown);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Element Name :";
            // 
            // PropertiesElement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 188);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PropertiesElement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PropertiesElement";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Reset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_Preset)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericBitValue)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
	}
}
