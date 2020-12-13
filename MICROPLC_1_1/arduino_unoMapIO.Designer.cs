/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 9/7/2015
 * Time: 12:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MICROPLC
{
	partial class arduino_unoMapIO
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(arduino_unoMapIO));
			this.picture_hw = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rbnt_no_setting = new System.Windows.Forms.RadioButton();
			this.label_Type = new System.Windows.Forms.Label();
			this.label_Name = new System.Windows.Forms.Label();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.radioButton20 = new System.Windows.Forms.RadioButton();
			this.radioButton19 = new System.Windows.Forms.RadioButton();
			this.radioButton18 = new System.Windows.Forms.RadioButton();
			this.radioButton17 = new System.Windows.Forms.RadioButton();
			this.radioButton16 = new System.Windows.Forms.RadioButton();
			this.radioButton15 = new System.Windows.Forms.RadioButton();
			this.radioButton14 = new System.Windows.Forms.RadioButton();
			this.radioButton13 = new System.Windows.Forms.RadioButton();
			this.radioButton12 = new System.Windows.Forms.RadioButton();
			this.radioButton11 = new System.Windows.Forms.RadioButton();
			this.radioButton10 = new System.Windows.Forms.RadioButton();
			this.radioButton9 = new System.Windows.Forms.RadioButton();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.picture_hw)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// picture_hw
			// 
			this.picture_hw.Image = ((System.Drawing.Image)(resources.GetObject("picture_hw.Image")));
			this.picture_hw.InitialImage = null;
			this.picture_hw.Location = new System.Drawing.Point(149, 19);
			this.picture_hw.Name = "picture_hw";
			this.picture_hw.Size = new System.Drawing.Size(422, 552);
			this.picture_hw.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picture_hw.TabIndex = 0;
			this.picture_hw.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Location = new System.Drawing.Point(12, 19);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(131, 122);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1Paint);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rbnt_no_setting);
			this.groupBox1.Controls.Add(this.label_Type);
			this.groupBox1.Controls.Add(this.label_Name);
			this.groupBox1.Controls.Add(this.btn_cancel);
			this.groupBox1.Controls.Add(this.btn_ok);
			this.groupBox1.Controls.Add(this.radioButton20);
			this.groupBox1.Controls.Add(this.radioButton19);
			this.groupBox1.Controls.Add(this.radioButton18);
			this.groupBox1.Controls.Add(this.radioButton17);
			this.groupBox1.Controls.Add(this.radioButton16);
			this.groupBox1.Controls.Add(this.radioButton15);
			this.groupBox1.Controls.Add(this.radioButton14);
			this.groupBox1.Controls.Add(this.radioButton13);
			this.groupBox1.Controls.Add(this.radioButton12);
			this.groupBox1.Controls.Add(this.radioButton11);
			this.groupBox1.Controls.Add(this.radioButton10);
			this.groupBox1.Controls.Add(this.radioButton9);
			this.groupBox1.Controls.Add(this.radioButton8);
			this.groupBox1.Controls.Add(this.radioButton7);
			this.groupBox1.Controls.Add(this.radioButton6);
			this.groupBox1.Controls.Add(this.radioButton5);
			this.groupBox1.Controls.Add(this.radioButton4);
			this.groupBox1.Controls.Add(this.radioButton3);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Controls.Add(this.picture_hw);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(730, 602);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// rbnt_no_setting
			// 
			this.rbnt_no_setting.Checked = true;
			this.rbnt_no_setting.Location = new System.Drawing.Point(320, 572);
			this.rbnt_no_setting.Name = "rbnt_no_setting";
			this.rbnt_no_setting.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.rbnt_no_setting.Size = new System.Drawing.Size(131, 24);
			this.rbnt_no_setting.TabIndex = 26;
			this.rbnt_no_setting.TabStop = true;
			this.rbnt_no_setting.Text = "No Setting";
			this.rbnt_no_setting.UseVisualStyleBackColor = true;
			// 
			// label_Type
			// 
			this.label_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Type.Location = new System.Drawing.Point(12, 194);
			this.label_Type.Name = "label_Type";
			this.label_Type.Size = new System.Drawing.Size(100, 23);
			this.label_Type.TabIndex = 25;
			this.label_Type.Text = "label1";
			// 
			// label_Name
			// 
			this.label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Name.Location = new System.Drawing.Point(12, 157);
			this.label_Name.Name = "label_Name";
			this.label_Name.Size = new System.Drawing.Size(100, 23);
			this.label_Name.TabIndex = 24;
			this.label_Name.Text = "label1";
			// 
			// btn_cancel
			// 
			this.btn_cancel.Location = new System.Drawing.Point(619, 61);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 23;
			this.btn_cancel.Text = "&Abrout";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(619, 19);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(75, 23);
			this.btn_ok.TabIndex = 22;
			this.btn_ok.Text = "&Close";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.Btn_okClick);
			// 
			// radioButton20
			// 
			this.radioButton20.Location = new System.Drawing.Point(577, 219);
			this.radioButton20.Name = "radioButton20";
			this.radioButton20.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton20.Size = new System.Drawing.Size(131, 24);
			this.radioButton20.TabIndex = 21;
			this.radioButton20.Text = "Not use";
			this.radioButton20.UseVisualStyleBackColor = true;
			// 
			// radioButton19
			// 
			this.radioButton19.Location = new System.Drawing.Point(577, 240);
			this.radioButton19.Name = "radioButton19";
			this.radioButton19.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton19.Size = new System.Drawing.Size(131, 24);
			this.radioButton19.TabIndex = 20;
			this.radioButton19.Text = "Not use";
			this.radioButton19.UseVisualStyleBackColor = true;
			// 
			// radioButton18
			// 
			this.radioButton18.Location = new System.Drawing.Point(577, 261);
			this.radioButton18.Name = "radioButton18";
			this.radioButton18.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton18.Size = new System.Drawing.Size(131, 24);
			this.radioButton18.TabIndex = 19;
			this.radioButton18.Text = "Not use";
			this.radioButton18.UseVisualStyleBackColor = true;
			// 
			// radioButton17
			// 
			this.radioButton17.Location = new System.Drawing.Point(577, 282);
			this.radioButton17.Name = "radioButton17";
			this.radioButton17.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton17.Size = new System.Drawing.Size(131, 24);
			this.radioButton17.TabIndex = 18;
			this.radioButton17.Text = "Not use";
			this.radioButton17.UseVisualStyleBackColor = true;
			// 
			// radioButton16
			// 
			this.radioButton16.Location = new System.Drawing.Point(577, 303);
			this.radioButton16.Name = "radioButton16";
			this.radioButton16.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton16.Size = new System.Drawing.Size(131, 24);
			this.radioButton16.TabIndex = 17;
			this.radioButton16.Text = "Not use";
			this.radioButton16.UseVisualStyleBackColor = true;
			// 
			// radioButton15
			// 
			this.radioButton15.Location = new System.Drawing.Point(577, 323);
			this.radioButton15.Name = "radioButton15";
			this.radioButton15.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton15.Size = new System.Drawing.Size(131, 24);
			this.radioButton15.TabIndex = 16;
			this.radioButton15.Text = "Not use";
			this.radioButton15.UseVisualStyleBackColor = true;
			// 
			// radioButton14
			// 
			this.radioButton14.Location = new System.Drawing.Point(577, 369);
			this.radioButton14.Name = "radioButton14";
			this.radioButton14.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton14.Size = new System.Drawing.Size(131, 24);
			this.radioButton14.TabIndex = 15;
			this.radioButton14.Text = "Not use";
			this.radioButton14.UseVisualStyleBackColor = true;
			// 
			// radioButton13
			// 
			this.radioButton13.Location = new System.Drawing.Point(577, 389);
			this.radioButton13.Name = "radioButton13";
			this.radioButton13.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton13.Size = new System.Drawing.Size(131, 24);
			this.radioButton13.TabIndex = 14;
			this.radioButton13.Text = "Not use";
			this.radioButton13.UseVisualStyleBackColor = true;
			// 
			// radioButton12
			// 
			this.radioButton12.Location = new System.Drawing.Point(577, 410);
			this.radioButton12.Name = "radioButton12";
			this.radioButton12.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton12.Size = new System.Drawing.Size(131, 24);
			this.radioButton12.TabIndex = 13;
			this.radioButton12.Text = "Not use";
			this.radioButton12.UseVisualStyleBackColor = true;
			// 
			// radioButton11
			// 
			this.radioButton11.Location = new System.Drawing.Point(577, 430);
			this.radioButton11.Name = "radioButton11";
			this.radioButton11.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton11.Size = new System.Drawing.Size(131, 24);
			this.radioButton11.TabIndex = 12;
			this.radioButton11.Text = "Not use";
			this.radioButton11.UseVisualStyleBackColor = true;
			// 
			// radioButton10
			// 
			this.radioButton10.Location = new System.Drawing.Point(577, 451);
			this.radioButton10.Name = "radioButton10";
			this.radioButton10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton10.Size = new System.Drawing.Size(131, 24);
			this.radioButton10.TabIndex = 11;
			this.radioButton10.Text = "Not use";
			this.radioButton10.UseVisualStyleBackColor = true;
			// 
			// radioButton9
			// 
			this.radioButton9.Location = new System.Drawing.Point(577, 472);
			this.radioButton9.Name = "radioButton9";
			this.radioButton9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton9.Size = new System.Drawing.Size(131, 24);
			this.radioButton9.TabIndex = 10;
			this.radioButton9.Text = "Not use";
			this.radioButton9.UseVisualStyleBackColor = true;
			// 
			// radioButton8
			// 
			this.radioButton8.Location = new System.Drawing.Point(577, 493);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton8.Size = new System.Drawing.Size(131, 24);
			this.radioButton8.TabIndex = 9;
			this.radioButton8.Text = "Not use";
			this.radioButton8.UseVisualStyleBackColor = true;
			// 
			// radioButton7
			// 
			this.radioButton7.Location = new System.Drawing.Point(577, 514);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.radioButton7.Size = new System.Drawing.Size(131, 24);
			this.radioButton7.TabIndex = 8;
			this.radioButton7.Text = "Not use";
			this.radioButton7.UseVisualStyleBackColor = true;
			// 
			// radioButton6
			// 
			this.radioButton6.Location = new System.Drawing.Point(12, 502);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioButton6.Size = new System.Drawing.Size(131, 24);
			this.radioButton6.TabIndex = 7;
			this.radioButton6.Text = "Not use";
			this.radioButton6.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.Location = new System.Drawing.Point(12, 481);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioButton5.Size = new System.Drawing.Size(131, 24);
			this.radioButton5.TabIndex = 6;
			this.radioButton5.Text = "Not use";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.Location = new System.Drawing.Point(12, 460);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioButton4.Size = new System.Drawing.Size(131, 24);
			this.radioButton4.TabIndex = 5;
			this.radioButton4.Text = "Not use";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.Location = new System.Drawing.Point(12, 439);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioButton3.Size = new System.Drawing.Size(131, 24);
			this.radioButton3.TabIndex = 4;
			this.radioButton3.Text = "Not use";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(12, 419);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioButton2.Size = new System.Drawing.Size(131, 24);
			this.radioButton2.TabIndex = 3;
			this.radioButton2.Text = "Not use";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.Location = new System.Drawing.Point(12, 398);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.radioButton1.Size = new System.Drawing.Size(131, 24);
			this.radioButton1.TabIndex = 2;
			this.radioButton1.Text = "Not use";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// arduino_unoMapIO
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(730, 602);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "arduino_unoMapIO";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "arduino_unoMapIO";
			((System.ComponentModel.ISupportInitialize)(this.picture_hw)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.RadioButton rbnt_no_setting;
		private System.Windows.Forms.Label label_Name;
		private System.Windows.Forms.Label label_Type;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.RadioButton radioButton15;
		private System.Windows.Forms.RadioButton radioButton16;
		private System.Windows.Forms.RadioButton radioButton17;
		private System.Windows.Forms.RadioButton radioButton18;
		private System.Windows.Forms.RadioButton radioButton19;
		private System.Windows.Forms.RadioButton radioButton20;
		private System.Windows.Forms.RadioButton radioButton8;
		private System.Windows.Forms.RadioButton radioButton9;
		private System.Windows.Forms.RadioButton radioButton10;
		private System.Windows.Forms.RadioButton radioButton11;
		private System.Windows.Forms.RadioButton radioButton12;
		private System.Windows.Forms.RadioButton radioButton13;
		private System.Windows.Forms.RadioButton radioButton14;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.RadioButton radioButton5;
		private System.Windows.Forms.RadioButton radioButton6;
		private System.Windows.Forms.RadioButton radioButton7;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox picture_hw;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
