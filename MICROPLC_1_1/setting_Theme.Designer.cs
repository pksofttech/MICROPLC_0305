/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 11/2/2559
 * Time: 20:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MICROPLC
{
	partial class setting_Theme
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Button btn_OK;
		private System.Windows.Forms.Button btn_Cancle;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Button btn_font_text;
		private System.Windows.Forms.Button btn_color_font_text;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label simple_tag_font;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Button btn_font_symbol;
		private System.Windows.Forms.Button btn_color_font_symbol;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Label simple_tag_symbol;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.FontDialog fontDialog_Ladder;
		private System.Windows.Forms.ColorDialog colorDialog_Ladder;
		private System.Windows.Forms.Button btn_element_set;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btn_bg_set;
		private System.Windows.Forms.Label label1;
		
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btn_element_set = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.btn_bg_set = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel6 = new System.Windows.Forms.Panel();
			this.btn_font_symbol = new System.Windows.Forms.Button();
			this.btn_color_font_symbol = new System.Windows.Forms.Button();
			this.panel7 = new System.Windows.Forms.Panel();
			this.simple_tag_symbol = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel5 = new System.Windows.Forms.Panel();
			this.btn_font_text = new System.Windows.Forms.Button();
			this.btn_color_font_text = new System.Windows.Forms.Button();
			this.panel4 = new System.Windows.Forms.Panel();
			this.simple_tag_font = new System.Windows.Forms.Label();
			this.panel3 = new System.Windows.Forms.Panel();
			this.btn_OK = new System.Windows.Forms.Button();
			this.btn_Cancle = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.fontDialog_Ladder = new System.Windows.Forms.FontDialog();
			this.colorDialog_Ladder = new System.Windows.Forms.ColorDialog();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.panel2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel6.SuspendLayout();
			this.panel7.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.Location = new System.Drawing.Point(7, 1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(75, 75);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.btn_element_set);
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.btn_bg_set);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.groupBox2);
			this.panel2.Controls.Add(this.groupBox1);
			this.panel2.Controls.Add(this.panel3);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(168, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(399, 157);
			this.panel2.TabIndex = 7;
			// 
			// btn_element_set
			// 
			this.btn_element_set.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_element_set.Location = new System.Drawing.Point(86, 104);
			this.btn_element_set.Name = "btn_element_set";
			this.btn_element_set.Size = new System.Drawing.Size(52, 23);
			this.btn_element_set.TabIndex = 16;
			this.btn_element_set.UseVisualStyleBackColor = true;
			this.btn_element_set.Click += new System.EventHandler(this.Btn_element_setClick);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 109);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "ElementColor";
			// 
			// btn_bg_set
			// 
			this.btn_bg_set.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btn_bg_set.Location = new System.Drawing.Point(86, 128);
			this.btn_bg_set.Name = "btn_bg_set";
			this.btn_bg_set.Size = new System.Drawing.Size(52, 24);
			this.btn_bg_set.TabIndex = 14;
			this.btn_bg_set.UseVisualStyleBackColor = true;
			this.btn_bg_set.Click += new System.EventHandler(this.Btn_bg_setClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 134);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 13;
			this.label1.Text = "BackColor";
			this.label1.Click += new System.EventHandler(this.Label1Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.panel6);
			this.groupBox2.Controls.Add(this.panel7);
			this.groupBox2.Location = new System.Drawing.Point(166, 11);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(119, 80);
			this.groupBox2.TabIndex = 12;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tag Symbol";
			// 
			// panel6
			// 
			this.panel6.Controls.Add(this.btn_font_symbol);
			this.panel6.Controls.Add(this.btn_color_font_symbol);
			this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel6.Location = new System.Drawing.Point(3, 54);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(113, 23);
			this.panel6.TabIndex = 11;
			// 
			// btn_font_symbol
			// 
			this.btn_font_symbol.Dock = System.Windows.Forms.DockStyle.Left;
			this.btn_font_symbol.Location = new System.Drawing.Point(0, 0);
			this.btn_font_symbol.Name = "btn_font_symbol";
			this.btn_font_symbol.Size = new System.Drawing.Size(53, 23);
			this.btn_font_symbol.TabIndex = 8;
			this.btn_font_symbol.Text = "Font";
			this.btn_font_symbol.UseVisualStyleBackColor = true;
			this.btn_font_symbol.Click += new System.EventHandler(this.Btn_font_symbolClick);
			// 
			// btn_color_font_symbol
			// 
			this.btn_color_font_symbol.Dock = System.Windows.Forms.DockStyle.Right;
			this.btn_color_font_symbol.Location = new System.Drawing.Point(60, 0);
			this.btn_color_font_symbol.Name = "btn_color_font_symbol";
			this.btn_color_font_symbol.Size = new System.Drawing.Size(53, 23);
			this.btn_color_font_symbol.TabIndex = 9;
			this.btn_color_font_symbol.Text = "Color";
			this.btn_color_font_symbol.UseVisualStyleBackColor = true;
			this.btn_color_font_symbol.Click += new System.EventHandler(this.Btn_color_font_symbolClick);
			// 
			// panel7
			// 
			this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel7.Controls.Add(this.simple_tag_symbol);
			this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel7.Location = new System.Drawing.Point(3, 16);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(113, 33);
			this.panel7.TabIndex = 10;
			// 
			// simple_tag_symbol
			// 
			this.simple_tag_symbol.Dock = System.Windows.Forms.DockStyle.Fill;
			this.simple_tag_symbol.Location = new System.Drawing.Point(0, 0);
			this.simple_tag_symbol.Name = "simple_tag_symbol";
			this.simple_tag_symbol.Size = new System.Drawing.Size(111, 31);
			this.simple_tag_symbol.TabIndex = 7;
			this.simple_tag_symbol.Text = "Simple";
			this.simple_tag_symbol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.panel5);
			this.groupBox1.Controls.Add(this.panel4);
			this.groupBox1.Location = new System.Drawing.Point(5, 11);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(119, 80);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tag Text";
			// 
			// panel5
			// 
			this.panel5.Controls.Add(this.btn_font_text);
			this.panel5.Controls.Add(this.btn_color_font_text);
			this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel5.Location = new System.Drawing.Point(3, 54);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(113, 23);
			this.panel5.TabIndex = 11;
			// 
			// btn_font_text
			// 
			this.btn_font_text.Dock = System.Windows.Forms.DockStyle.Left;
			this.btn_font_text.Location = new System.Drawing.Point(0, 0);
			this.btn_font_text.Name = "btn_font_text";
			this.btn_font_text.Size = new System.Drawing.Size(53, 23);
			this.btn_font_text.TabIndex = 8;
			this.btn_font_text.Text = "Font";
			this.btn_font_text.UseVisualStyleBackColor = true;
			this.btn_font_text.Click += new System.EventHandler(this.Btn_font_textClick);
			// 
			// btn_color_font_text
			// 
			this.btn_color_font_text.Dock = System.Windows.Forms.DockStyle.Right;
			this.btn_color_font_text.Location = new System.Drawing.Point(60, 0);
			this.btn_color_font_text.Name = "btn_color_font_text";
			this.btn_color_font_text.Size = new System.Drawing.Size(53, 23);
			this.btn_color_font_text.TabIndex = 9;
			this.btn_color_font_text.Text = "Color";
			this.btn_color_font_text.UseVisualStyleBackColor = true;
			this.btn_color_font_text.Click += new System.EventHandler(this.Btn_color_font_textClick);
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.simple_tag_font);
			this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel4.Location = new System.Drawing.Point(3, 16);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(113, 33);
			this.panel4.TabIndex = 10;
			// 
			// simple_tag_font
			// 
			this.simple_tag_font.Dock = System.Windows.Forms.DockStyle.Fill;
			this.simple_tag_font.Location = new System.Drawing.Point(0, 0);
			this.simple_tag_font.Name = "simple_tag_font";
			this.simple_tag_font.Size = new System.Drawing.Size(111, 31);
			this.simple_tag_font.TabIndex = 7;
			this.simple_tag_font.Text = "Simple";
			this.simple_tag_font.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.btn_OK);
			this.panel3.Controls.Add(this.btn_Cancle);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel3.Location = new System.Drawing.Point(291, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(106, 155);
			this.panel3.TabIndex = 6;
			// 
			// btn_OK
			// 
			this.btn_OK.Location = new System.Drawing.Point(20, 11);
			this.btn_OK.Name = "btn_OK";
			this.btn_OK.Size = new System.Drawing.Size(75, 32);
			this.btn_OK.TabIndex = 4;
			this.btn_OK.Text = "&OK";
			this.btn_OK.UseVisualStyleBackColor = true;
			this.btn_OK.Click += new System.EventHandler(this.Btn_OKClick);
			// 
			// btn_Cancle
			// 
			this.btn_Cancle.Location = new System.Drawing.Point(20, 49);
			this.btn_Cancle.Name = "btn_Cancle";
			this.btn_Cancle.Size = new System.Drawing.Size(75, 31);
			this.btn_Cancle.TabIndex = 5;
			this.btn_Cancle.Text = "&Cancle";
			this.btn_Cancle.UseVisualStyleBackColor = true;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.pictureBox3);
			this.panel1.Controls.Add(this.pictureBox4);
			this.panel1.Controls.Add(this.pictureBox2);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Padding = new System.Windows.Forms.Padding(5);
			this.panel1.Size = new System.Drawing.Size(168, 157);
			this.panel1.TabIndex = 6;
			// 
			// pictureBox3
			// 
			this.pictureBox3.BackColor = System.Drawing.Color.Black;
			this.pictureBox3.Location = new System.Drawing.Point(85, 78);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(75, 75);
			this.pictureBox3.TabIndex = 3;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox4
			// 
			this.pictureBox4.BackColor = System.Drawing.Color.Black;
			this.pictureBox4.Location = new System.Drawing.Point(85, 1);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(75, 75);
			this.pictureBox4.TabIndex = 2;
			this.pictureBox4.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.BackColor = System.Drawing.Color.Black;
			this.pictureBox2.Location = new System.Drawing.Point(7, 78);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(75, 75);
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// setting_Theme
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(567, 157);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "setting_Theme";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Theme Ladder Style Setting";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.panel7.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
