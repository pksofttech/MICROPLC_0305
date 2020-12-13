/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 7/7/2015
 * Time: 1:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MICROPLC
{
	partial class MapIOPorts
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapIOPorts));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.label_Type = new System.Windows.Forms.Label();
			this.label_Name = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listView_IO = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.pictureBox1.Location = new System.Drawing.Point(12, 19);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(100, 100);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1Paint);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btn_cancel);
			this.groupBox1.Controls.Add(this.btn_ok);
			this.groupBox1.Controls.Add(this.label_Type);
			this.groupBox1.Controls.Add(this.label_Name);
			this.groupBox1.Controls.Add(this.pictureBox1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(496, 525);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Element Data";
			// 
			// btn_cancel
			// 
			this.btn_cancel.Location = new System.Drawing.Point(6, 494);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(123, 23);
			this.btn_cancel.TabIndex = 5;
			this.btn_cancel.Text = "&Abrout";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.Btn_cancelClick);
			// 
			// btn_ok
			// 
			this.btn_ok.Location = new System.Drawing.Point(6, 465);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(123, 23);
			this.btn_ok.TabIndex = 4;
			this.btn_ok.Text = "&Close";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.Btn_okClick);
			// 
			// label_Type
			// 
			this.label_Type.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Type.Location = new System.Drawing.Point(12, 168);
			this.label_Type.Name = "label_Type";
			this.label_Type.Size = new System.Drawing.Size(100, 23);
			this.label_Type.TabIndex = 3;
			this.label_Type.Text = "label1";
			// 
			// label_Name
			// 
			this.label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label_Name.Location = new System.Drawing.Point(12, 131);
			this.label_Name.Name = "label_Name";
			this.label_Name.Size = new System.Drawing.Size(100, 23);
			this.label_Name.TabIndex = 2;
			this.label_Name.Text = "label1";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.listView_IO);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
			this.groupBox2.Location = new System.Drawing.Point(132, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(364, 525);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "I/O";
			// 
			// listView_IO
			// 
			this.listView_IO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader1,
			this.columnHeader2,
			this.columnHeader3});
			this.listView_IO.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView_IO.FullRowSelect = true;
			this.listView_IO.GridLines = true;
			this.listView_IO.Location = new System.Drawing.Point(3, 16);
			this.listView_IO.MultiSelect = false;
			this.listView_IO.Name = "listView_IO";
			this.listView_IO.Size = new System.Drawing.Size(358, 506);
			this.listView_IO.SmallImageList = this.imageList1;
			this.listView_IO.TabIndex = 0;
			this.listView_IO.UseCompatibleStateImageBehavior = false;
			this.listView_IO.View = System.Windows.Forms.View.Details;
			this.listView_IO.SelectedIndexChanged += new System.EventHandler(this.ListView_IOSelectedIndexChanged);
			this.listView_IO.DoubleClick += new System.EventHandler(this.ListView_IODoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "PIN";
			this.columnHeader1.Width = 107;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Map Element";
			this.columnHeader2.Width = 128;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Type";
			this.columnHeader3.Width = 111;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "MOUSE03.ICO");
			this.imageList1.Images.SetKeyName(1, "SINEWAVE.ICO");
			this.imageList1.Images.SetKeyName(2, "Arrow Back.ico");
			this.imageList1.Images.SetKeyName(3, "Arrow Forward.ico");
			// 
			// MapIOPorts
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(496, 525);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MapIOPorts";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "MapIOPorts";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MapIOPortsFormClosed);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.ListView listView_IO;
		private System.Windows.Forms.Label label_Name;
		private System.Windows.Forms.Label label_Type;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
	}
}
