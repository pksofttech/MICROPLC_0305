/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 4/10/2015
 * Time: 11:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MICROPLC
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.contexMenu_Element = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.propertes_element = new System.Windows.Forms.ToolStripMenuItem();
			this.Delete_Element = new System.Windows.Forms.ToolStripMenuItem();
			this.Find_Ref_Elements = new System.Windows.Forms.ToolStripMenuItem();
			this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
			this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
			this.panel_Right = new System.Windows.Forms.Panel();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.listView_elements = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.listView_Map_I = new System.Windows.Forms.ListView();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.listView_Map_O = new System.Windows.Forms.ListView();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
			this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.splitContainer4 = new System.Windows.Forms.SplitContainer();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.toolStrip2 = new System.Windows.Forms.ToolStrip();
			this.tsb_Move_up = new System.Windows.Forms.ToolStripButton();
			this.tsb_Insert_up = new System.Windows.Forms.ToolStripButton();
			this.tsb_Copy_rung = new System.Windows.Forms.ToolStripButton();
			this.tsb_New_rung = new System.Windows.Forms.ToolStripButton();
			this.tsb_delete_rung = new System.Windows.Forms.ToolStripButton();
			this.tsb_Insert_down = new System.Windows.Forms.ToolStripButton();
			this.tsb_Move_down = new System.Windows.Forms.ToolStripButton();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.toolStrip_Element = new System.Windows.Forms.ToolStrip();
			this.btn_element_Comment = new System.Windows.Forms.ToolStripButton();
			this.btn_element_Contracs = new System.Windows.Forms.ToolStripButton();
			this.btn_element_Coil = new System.Windows.Forms.ToolStripButton();
			this.btn_element_MasterRelay = new System.Windows.Forms.ToolStripButton();
			this.btn_element_Timers = new System.Windows.Forms.ToolStripDropDownButton();
			this.btn_element_TON = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_TOF = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_TPC = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_Counters = new System.Windows.Forms.ToolStripDropDownButton();
			this.btn_element_CTU = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_CTD = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_CTC = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_Shift = new System.Windows.Forms.ToolStripDropDownButton();
			this.btn_element_Shift_Reg = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_Shift_Control = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_Shift_Contracs = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_Functions = new System.Windows.Forms.ToolStripDropDownButton();
			this.btn_element_Move = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_Compare = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_Add = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_Sub = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_Mup = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_Div = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_Mod = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_ADC = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_element_Pluse = new System.Windows.Forms.ToolStripDropDownButton();
			this.btn_OSR = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_OSF = new System.Windows.Forms.ToolStripMenuItem();
			this.Btn_Communication = new System.Windows.Forms.ToolStripDropDownButton();
			this.btn_uart_send = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_uart_recv = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_other = new System.Windows.Forms.ToolStripDropDownButton();
			this.btn_short = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_open = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainerLadder = new System.Windows.Forms.SplitContainer();
			this.panel_Ladder = new System.Windows.Forms.Panel();
			this.Ladder_Draw = new System.Windows.Forms.PictureBox();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
			this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.tsb_config = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
			this.t_sBtn_simulation = new System.Windows.Forms.ToolStripButton();
			this.t_lable_Simulation_time = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripComboBox_Mup = new System.Windows.Forms.ToolStripComboBox();
			this.ts_bnt_start = new System.Windows.Forms.ToolStripButton();
			this.ts_bnt_step = new System.Windows.Forms.ToolStripButton();
			this.ts_bnt_stop = new System.Windows.Forms.ToolStripButton();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.themeLadderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsmunu_hardware = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_arduino_Pro1685v = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_arduino_NANO = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_arduinoUNO = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_arduinoUNOR3 = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_arduino_MEGA = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_Micro_PLC_deca = new System.Windows.Forms.ToolStripMenuItem();
			this.ts_no_hw = new System.Windows.Forms.ToolStripMenuItem();
			this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.export_Code = new System.Windows.Forms.ToolStripMenuItem();
			this.expot_hex = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_simulation = new System.Windows.Forms.ToolStripMenuItem();
			this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialogLadder = new System.Windows.Forms.OpenFileDialog();
			this.contextMenu_rung = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
			this.add_Rung_Menu = new System.Windows.Forms.ToolStripMenuItem();
			this.add_rung_Up = new System.Windows.Forms.ToolStripMenuItem();
			this.add_rung_Down = new System.Windows.Forms.ToolStripMenuItem();
			this.Delete_Rung = new System.Windows.Forms.ToolStripMenuItem();
			this.Btn_copy_rung = new System.Windows.Forms.ToolStripMenuItem();
			this.Btn_Rung_Move_Up = new System.Windows.Forms.ToolStripMenuItem();
			this.Btn_Rung_Move_Down = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileDialogLadder = new System.Windows.Forms.SaveFileDialog();
			this.toolStripContainer3 = new System.Windows.Forms.ToolStripContainer();
			this.toolStripContainer4 = new System.Windows.Forms.ToolStripContainer();
			this.statusStripTool = new System.Windows.Forms.StatusStrip();
			this.ts_Hardware_name = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.tsLabel_comport = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripStatusLabel_PortInfo = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.fontDialog_Ladder = new System.Windows.Forms.FontDialog();
			this.colorDialog_Ladder = new System.Windows.Forms.ColorDialog();
			this.toolTip_element = new System.Windows.Forms.ToolTip(this.components);
			this.printPreviewDialog_Ladder = new System.Windows.Forms.PrintPreviewDialog();
			this.printDocument_Ladder = new System.Drawing.Printing.PrintDocument();
			this.contexMenu_Element.SuspendLayout();
			this.panel_Right.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.toolStripContainer2.ContentPanel.SuspendLayout();
			this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
			this.splitContainer_Main.Panel1.SuspendLayout();
			this.splitContainer_Main.Panel2.SuspendLayout();
			this.splitContainer_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
			this.splitContainer4.Panel1.SuspendLayout();
			this.splitContainer4.Panel2.SuspendLayout();
			this.splitContainer4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.toolStrip2.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.toolStrip_Element.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerLadder)).BeginInit();
			this.splitContainerLadder.Panel1.SuspendLayout();
			this.splitContainerLadder.Panel2.SuspendLayout();
			this.splitContainerLadder.SuspendLayout();
			this.panel_Ladder.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Ladder_Draw)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.contextMenu_rung.SuspendLayout();
			this.toolStripContainer3.ContentPanel.SuspendLayout();
			this.toolStripContainer3.SuspendLayout();
			this.toolStripContainer4.ContentPanel.SuspendLayout();
			this.toolStripContainer4.SuspendLayout();
			this.statusStripTool.SuspendLayout();
			this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// contexMenu_Element
			// 
			this.contexMenu_Element.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.contexMenu_Element.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripTextBox1,
			this.toolStripSeparator1,
			this.propertes_element,
			this.Delete_Element,
			this.Find_Ref_Elements});
			this.contexMenu_Element.Name = "contextMenu";
			this.contexMenu_Element.Size = new System.Drawing.Size(161, 94);
			// 
			// toolStripTextBox1
			// 
			this.toolStripTextBox1.BackColor = System.Drawing.Color.Silver;
			this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 8.830189F);
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.ReadOnly = true;
			this.toolStripTextBox1.Size = new System.Drawing.Size(100, 16);
			this.toolStripTextBox1.Text = "Element Menu";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(157, 6);
			// 
			// propertes_element
			// 
			this.propertes_element.Name = "propertes_element";
			this.propertes_element.Size = new System.Drawing.Size(160, 22);
			this.propertes_element.Text = "&Properties";
			this.propertes_element.Click += new System.EventHandler(this.Propertes_elementClick);
			// 
			// Delete_Element
			// 
			this.Delete_Element.Name = "Delete_Element";
			this.Delete_Element.Size = new System.Drawing.Size(160, 22);
			this.Delete_Element.Text = "&Delete";
			this.Delete_Element.Click += new System.EventHandler(this.Delete_ElementClick);
			// 
			// Find_Ref_Elements
			// 
			this.Find_Ref_Elements.Name = "Find_Ref_Elements";
			this.Find_Ref_Elements.Size = new System.Drawing.Size(160, 22);
			this.Find_Ref_Elements.Text = "&Find Ref@";
			this.Find_Ref_Elements.Click += new System.EventHandler(this.Find_Ref_ElementsClick);
			// 
			// BottomToolStripPanel
			// 
			this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.BottomToolStripPanel.Name = "BottomToolStripPanel";
			this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// TopToolStripPanel
			// 
			this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.TopToolStripPanel.Name = "TopToolStripPanel";
			this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// RightToolStripPanel
			// 
			this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.RightToolStripPanel.Name = "RightToolStripPanel";
			this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// LeftToolStripPanel
			// 
			this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
			this.LeftToolStripPanel.Name = "LeftToolStripPanel";
			this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
			// 
			// ContentPanel
			// 
			this.ContentPanel.AutoScroll = true;
			this.ContentPanel.Size = new System.Drawing.Size(956, 692);
			// 
			// panel_Right
			// 
			this.panel_Right.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel_Right.Controls.Add(this.splitContainer2);
			this.panel_Right.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Right.Location = new System.Drawing.Point(0, 0);
			this.panel_Right.Name = "panel_Right";
			this.panel_Right.Size = new System.Drawing.Size(275, 533);
			this.panel_Right.TabIndex = 2;
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.listView_elements);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.splitContainer1);
			this.splitContainer2.Size = new System.Drawing.Size(271, 529);
			this.splitContainer2.SplitterDistance = 238;
			this.splitContainer2.TabIndex = 5;
			// 
			// listView_elements
			// 
			this.listView_elements.BackColor = System.Drawing.Color.LightGray;
			this.listView_elements.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader1,
			this.columnHeader2,
			this.columnHeader3});
			this.listView_elements.Cursor = System.Windows.Forms.Cursors.Hand;
			this.listView_elements.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView_elements.FullRowSelect = true;
			this.listView_elements.HideSelection = false;
			this.listView_elements.Location = new System.Drawing.Point(0, 0);
			this.listView_elements.MultiSelect = false;
			this.listView_elements.Name = "listView_elements";
			this.listView_elements.Size = new System.Drawing.Size(271, 238);
			this.listView_elements.TabIndex = 0;
			this.listView_elements.UseCompatibleStateImageBehavior = false;
			this.listView_elements.View = System.Windows.Forms.View.Details;
			this.listView_elements.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ListView_elementsItemSelectionChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "NAME";
			this.columnHeader1.Width = 100;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "TYPE";
			this.columnHeader2.Width = 92;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Value";
			this.columnHeader3.Width = 80;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
			this.splitContainer1.Size = new System.Drawing.Size(271, 287);
			this.splitContainer1.SplitterDistance = 138;
			this.splitContainer1.TabIndex = 4;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.listView_Map_I);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.groupBox1.ForeColor = System.Drawing.Color.DarkGray;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(138, 287);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Input Ports";
			// 
			// listView_Map_I
			// 
			this.listView_Map_I.BackColor = System.Drawing.Color.Silver;
			this.listView_Map_I.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView_Map_I.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader4,
			this.columnHeader5});
			this.listView_Map_I.Cursor = System.Windows.Forms.Cursors.Hand;
			this.listView_Map_I.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView_Map_I.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.listView_Map_I.FullRowSelect = true;
			this.listView_Map_I.HideSelection = false;
			this.listView_Map_I.Location = new System.Drawing.Point(3, 18);
			this.listView_Map_I.MultiSelect = false;
			this.listView_Map_I.Name = "listView_Map_I";
			this.listView_Map_I.ShowItemToolTips = true;
			this.listView_Map_I.Size = new System.Drawing.Size(132, 266);
			this.listView_Map_I.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView_Map_I.TabIndex = 1;
			this.listView_Map_I.UseCompatibleStateImageBehavior = false;
			this.listView_Map_I.View = System.Windows.Forms.View.Details;
			this.listView_Map_I.DoubleClick += new System.EventHandler(this.ListView_Map_IDoubleClick);
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Name";
			this.columnHeader4.Width = 71;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "Port";
			this.columnHeader5.Width = 53;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.listView_Map_O);
			this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.groupBox2.ForeColor = System.Drawing.Color.DarkGray;
			this.groupBox2.Location = new System.Drawing.Point(0, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(129, 287);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Output Ports";
			// 
			// listView_Map_O
			// 
			this.listView_Map_O.BackColor = System.Drawing.Color.Silver;
			this.listView_Map_O.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView_Map_O.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.columnHeader6,
			this.columnHeader7});
			this.listView_Map_O.Cursor = System.Windows.Forms.Cursors.Hand;
			this.listView_Map_O.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView_Map_O.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
			this.listView_Map_O.FullRowSelect = true;
			this.listView_Map_O.HideSelection = false;
			this.listView_Map_O.Location = new System.Drawing.Point(3, 18);
			this.listView_Map_O.MultiSelect = false;
			this.listView_Map_O.Name = "listView_Map_O";
			this.listView_Map_O.ShowItemToolTips = true;
			this.listView_Map_O.Size = new System.Drawing.Size(123, 266);
			this.listView_Map_O.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView_Map_O.TabIndex = 2;
			this.listView_Map_O.UseCompatibleStateImageBehavior = false;
			this.listView_Map_O.View = System.Windows.Forms.View.Details;
			this.listView_Map_O.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListView_Map_OMouseDoubleClick);
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Name";
			this.columnHeader6.Width = 64;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Port";
			this.columnHeader7.Width = 49;
			// 
			// toolStripContainer2
			// 
			// 
			// toolStripContainer2.ContentPanel
			// 
			this.toolStripContainer2.ContentPanel.AutoScroll = true;
			this.toolStripContainer2.ContentPanel.Controls.Add(this.splitContainer_Main);
			this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(1240, 533);
			this.toolStripContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer2.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer2.Name = "toolStripContainer2";
			this.toolStripContainer2.Size = new System.Drawing.Size(1240, 582);
			this.toolStripContainer2.TabIndex = 6;
			this.toolStripContainer2.Text = "toolStripContainer2";
			// 
			// toolStripContainer2.TopToolStripPanel
			// 
			this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.mainMenu);
			this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.toolStrip1);
			this.toolStripContainer2.TopToolStripPanel.ForeColor = System.Drawing.SystemColors.HotTrack;
			// 
			// splitContainer_Main
			// 
			this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
			this.splitContainer_Main.Name = "splitContainer_Main";
			// 
			// splitContainer_Main.Panel1
			// 
			this.splitContainer_Main.Panel1.Controls.Add(this.splitContainer3);
			// 
			// splitContainer_Main.Panel2
			// 
			this.splitContainer_Main.Panel2.Controls.Add(this.panel_Right);
			this.splitContainer_Main.Size = new System.Drawing.Size(1240, 533);
			this.splitContainer_Main.SplitterDistance = 961;
			this.splitContainer_Main.TabIndex = 3;
			// 
			// splitContainer3
			// 
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.splitContainerLadder);
			this.splitContainer3.Size = new System.Drawing.Size(961, 533);
			this.splitContainer3.SplitterDistance = 161;
			this.splitContainer3.TabIndex = 0;
			// 
			// splitContainer4
			// 
			this.splitContainer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer4.Location = new System.Drawing.Point(0, 0);
			this.splitContainer4.Name = "splitContainer4";
			this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer4.Panel1
			// 
			this.splitContainer4.Panel1.Controls.Add(this.groupBox3);
			// 
			// splitContainer4.Panel2
			// 
			this.splitContainer4.Panel2.Controls.Add(this.groupBox4);
			this.splitContainer4.Size = new System.Drawing.Size(161, 533);
			this.splitContainer4.SplitterDistance = 195;
			this.splitContainer4.TabIndex = 3;
			// 
			// groupBox3
			// 
			this.groupBox3.BackColor = System.Drawing.Color.Transparent;
			this.groupBox3.Controls.Add(this.toolStrip2);
			this.groupBox3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox3.Font = new System.Drawing.Font("Courier New", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox3.ForeColor = System.Drawing.SystemColors.Highlight;
			this.groupBox3.Location = new System.Drawing.Point(0, 0);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(159, 193);
			this.groupBox3.TabIndex = 8;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Ladder Tools";
			// 
			// toolStrip2
			// 
			this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
			this.toolStrip2.CanOverflow = false;
			this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStrip2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStrip2.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.tsb_Move_up,
			this.tsb_Insert_up,
			this.tsb_Copy_rung,
			this.tsb_New_rung,
			this.tsb_delete_rung,
			this.tsb_Insert_down,
			this.tsb_Move_down});
			this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
			this.toolStrip2.Location = new System.Drawing.Point(3, 22);
			this.toolStrip2.Name = "toolStrip2";
			this.toolStrip2.Size = new System.Drawing.Size(153, 168);
			this.toolStrip2.TabIndex = 0;
			// 
			// tsb_Move_up
			// 
			this.tsb_Move_up.Enabled = false;
			this.tsb_Move_up.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsb_Move_up.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Move_up.Image")));
			this.tsb_Move_up.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsb_Move_up.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_Move_up.Name = "tsb_Move_up";
			this.tsb_Move_up.Size = new System.Drawing.Size(151, 22);
			this.tsb_Move_up.Text = "Move Up";
			// 
			// tsb_Insert_up
			// 
			this.tsb_Insert_up.Enabled = false;
			this.tsb_Insert_up.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsb_Insert_up.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Insert_up.Image")));
			this.tsb_Insert_up.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsb_Insert_up.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_Insert_up.Name = "tsb_Insert_up";
			this.tsb_Insert_up.Size = new System.Drawing.Size(151, 22);
			this.tsb_Insert_up.Text = "Insert Copy Up";
			this.tsb_Insert_up.Click += new System.EventHandler(this.Tsb_Insert_upClick);
			// 
			// tsb_Copy_rung
			// 
			this.tsb_Copy_rung.Enabled = false;
			this.tsb_Copy_rung.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsb_Copy_rung.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Copy_rung.Image")));
			this.tsb_Copy_rung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsb_Copy_rung.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_Copy_rung.Name = "tsb_Copy_rung";
			this.tsb_Copy_rung.Size = new System.Drawing.Size(151, 22);
			this.tsb_Copy_rung.Text = "Copy Rung";
			this.tsb_Copy_rung.Click += new System.EventHandler(this.Tsb_Copy_rungClick);
			// 
			// tsb_New_rung
			// 
			this.tsb_New_rung.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsb_New_rung.Image = ((System.Drawing.Image)(resources.GetObject("tsb_New_rung.Image")));
			this.tsb_New_rung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsb_New_rung.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_New_rung.Name = "tsb_New_rung";
			this.tsb_New_rung.Size = new System.Drawing.Size(151, 22);
			this.tsb_New_rung.Text = "New Rung";
			// 
			// tsb_delete_rung
			// 
			this.tsb_delete_rung.Enabled = false;
			this.tsb_delete_rung.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsb_delete_rung.Image = ((System.Drawing.Image)(resources.GetObject("tsb_delete_rung.Image")));
			this.tsb_delete_rung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsb_delete_rung.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_delete_rung.Name = "tsb_delete_rung";
			this.tsb_delete_rung.Size = new System.Drawing.Size(151, 22);
			this.tsb_delete_rung.Text = "Delete";
			// 
			// tsb_Insert_down
			// 
			this.tsb_Insert_down.Enabled = false;
			this.tsb_Insert_down.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsb_Insert_down.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Insert_down.Image")));
			this.tsb_Insert_down.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsb_Insert_down.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_Insert_down.Name = "tsb_Insert_down";
			this.tsb_Insert_down.Size = new System.Drawing.Size(151, 22);
			this.tsb_Insert_down.Text = "Insert Copy Down";
			this.tsb_Insert_down.Click += new System.EventHandler(this.Tsb_Insert_downClick);
			// 
			// tsb_Move_down
			// 
			this.tsb_Move_down.Enabled = false;
			this.tsb_Move_down.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tsb_Move_down.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Move_down.Image")));
			this.tsb_Move_down.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.tsb_Move_down.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_Move_down.Name = "tsb_Move_down";
			this.tsb_Move_down.Size = new System.Drawing.Size(151, 22);
			this.tsb_Move_down.Text = "Move Down";
			// 
			// groupBox4
			// 
			this.groupBox4.BackColor = System.Drawing.Color.LightBlue;
			this.groupBox4.Controls.Add(this.toolStrip_Element);
			this.groupBox4.Cursor = System.Windows.Forms.Cursors.Hand;
			this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox4.Font = new System.Drawing.Font("Courier New", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox4.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.groupBox4.Location = new System.Drawing.Point(0, 0);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(159, 332);
			this.groupBox4.TabIndex = 5;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Components";
			// 
			// toolStrip_Element
			// 
			this.toolStrip_Element.BackColor = System.Drawing.Color.Transparent;
			this.toolStrip_Element.CanOverflow = false;
			this.toolStrip_Element.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStrip_Element.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.toolStrip_Element.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.toolStrip_Element.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.btn_element_Comment,
			this.btn_element_Contracs,
			this.btn_element_Coil,
			this.btn_element_MasterRelay,
			this.btn_element_Timers,
			this.btn_element_Counters,
			this.btn_element_Shift,
			this.btn_element_Functions,
			this.btn_element_Pluse,
			this.Btn_Communication,
			this.btn_other});
			this.toolStrip_Element.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
			this.toolStrip_Element.Location = new System.Drawing.Point(3, 18);
			this.toolStrip_Element.Name = "toolStrip_Element";
			this.toolStrip_Element.Size = new System.Drawing.Size(153, 311);
			this.toolStrip_Element.TabIndex = 0;
			this.toolStrip_Element.Text = "Elements";
			// 
			// btn_element_Comment
			// 
			this.btn_element_Comment.Enabled = false;
			this.btn_element_Comment.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_element_Comment.ForeColor = System.Drawing.SystemColors.ActiveBorder;
			this.btn_element_Comment.Image = ((System.Drawing.Image)(resources.GetObject("btn_element_Comment.Image")));
			this.btn_element_Comment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_element_Comment.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_element_Comment.Name = "btn_element_Comment";
			this.btn_element_Comment.Size = new System.Drawing.Size(151, 22);
			this.btn_element_Comment.Text = "Comment";
			// 
			// btn_element_Contracs
			// 
			this.btn_element_Contracs.Enabled = false;
			this.btn_element_Contracs.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_element_Contracs.Image = ((System.Drawing.Image)(resources.GetObject("btn_element_Contracs.Image")));
			this.btn_element_Contracs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_element_Contracs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_element_Contracs.Name = "btn_element_Contracs";
			this.btn_element_Contracs.Size = new System.Drawing.Size(151, 22);
			this.btn_element_Contracs.Text = "Contracs";
			// 
			// btn_element_Coil
			// 
			this.btn_element_Coil.Enabled = false;
			this.btn_element_Coil.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_element_Coil.Image = ((System.Drawing.Image)(resources.GetObject("btn_element_Coil.Image")));
			this.btn_element_Coil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_element_Coil.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_element_Coil.Name = "btn_element_Coil";
			this.btn_element_Coil.Size = new System.Drawing.Size(151, 22);
			this.btn_element_Coil.Text = "Coils";
			// 
			// btn_element_MasterRelay
			// 
			this.btn_element_MasterRelay.Enabled = false;
			this.btn_element_MasterRelay.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_element_MasterRelay.Image = ((System.Drawing.Image)(resources.GetObject("btn_element_MasterRelay.Image")));
			this.btn_element_MasterRelay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_element_MasterRelay.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_element_MasterRelay.Name = "btn_element_MasterRelay";
			this.btn_element_MasterRelay.Size = new System.Drawing.Size(151, 22);
			this.btn_element_MasterRelay.Text = "Master Relay";
			// 
			// btn_element_Timers
			// 
			this.btn_element_Timers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.btn_element_TON,
			this.btn_element_TOF,
			this.btn_element_TPC});
			this.btn_element_Timers.Enabled = false;
			this.btn_element_Timers.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_element_Timers.Image = ((System.Drawing.Image)(resources.GetObject("btn_element_Timers.Image")));
			this.btn_element_Timers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_element_Timers.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_element_Timers.Name = "btn_element_Timers";
			this.btn_element_Timers.Size = new System.Drawing.Size(151, 22);
			this.btn_element_Timers.Text = "Timers";
			// 
			// btn_element_TON
			// 
			this.btn_element_TON.Name = "btn_element_TON";
			this.btn_element_TON.Size = new System.Drawing.Size(185, 22);
			this.btn_element_TON.Text = "Timer On Delay";
			// 
			// btn_element_TOF
			// 
			this.btn_element_TOF.Name = "btn_element_TOF";
			this.btn_element_TOF.Size = new System.Drawing.Size(185, 22);
			this.btn_element_TOF.Text = "Timer Off Delay";
			// 
			// btn_element_TPC
			// 
			this.btn_element_TPC.Name = "btn_element_TPC";
			this.btn_element_TPC.Size = new System.Drawing.Size(185, 22);
			this.btn_element_TPC.Text = "Timer Pluse Cycle";
			// 
			// btn_element_Counters
			// 
			this.btn_element_Counters.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.btn_element_CTU,
			this.btn_element_CTD,
			this.btn_element_CTC});
			this.btn_element_Counters.Enabled = false;
			this.btn_element_Counters.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_element_Counters.Image = ((System.Drawing.Image)(resources.GetObject("btn_element_Counters.Image")));
			this.btn_element_Counters.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_element_Counters.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_element_Counters.Name = "btn_element_Counters";
			this.btn_element_Counters.Size = new System.Drawing.Size(151, 22);
			this.btn_element_Counters.Text = "Counters";
			// 
			// btn_element_CTU
			// 
			this.btn_element_CTU.Name = "btn_element_CTU";
			this.btn_element_CTU.Size = new System.Drawing.Size(187, 22);
			this.btn_element_CTU.Text = "Counter Up";
			// 
			// btn_element_CTD
			// 
			this.btn_element_CTD.Name = "btn_element_CTD";
			this.btn_element_CTD.Size = new System.Drawing.Size(187, 22);
			this.btn_element_CTD.Text = "Counter Down";
			// 
			// btn_element_CTC
			// 
			this.btn_element_CTC.Name = "btn_element_CTC";
			this.btn_element_CTC.Size = new System.Drawing.Size(187, 22);
			this.btn_element_CTC.Text = "Counter Contrac";
			// 
			// btn_element_Shift
			// 
			this.btn_element_Shift.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.btn_element_Shift_Reg,
			this.btn_element_Shift_Control,
			this.btn_element_Shift_Contracs});
			this.btn_element_Shift.Enabled = false;
			this.btn_element_Shift.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_element_Shift.Image = ((System.Drawing.Image)(resources.GetObject("btn_element_Shift.Image")));
			this.btn_element_Shift.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_element_Shift.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_element_Shift.Name = "btn_element_Shift";
			this.btn_element_Shift.Size = new System.Drawing.Size(151, 22);
			this.btn_element_Shift.Text = "Shift Registers";
			// 
			// btn_element_Shift_Reg
			// 
			this.btn_element_Shift_Reg.Name = "btn_element_Shift_Reg";
			this.btn_element_Shift_Reg.Size = new System.Drawing.Size(165, 22);
			this.btn_element_Shift_Reg.Text = "Shift Registers";
			// 
			// btn_element_Shift_Control
			// 
			this.btn_element_Shift_Control.Name = "btn_element_Shift_Control";
			this.btn_element_Shift_Control.Size = new System.Drawing.Size(165, 22);
			this.btn_element_Shift_Control.Text = "Shift Control";
			// 
			// btn_element_Shift_Contracs
			// 
			this.btn_element_Shift_Contracs.Name = "btn_element_Shift_Contracs";
			this.btn_element_Shift_Contracs.Size = new System.Drawing.Size(165, 22);
			this.btn_element_Shift_Contracs.Text = "Shift Contracs";
			// 
			// btn_element_Functions
			// 
			this.btn_element_Functions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.btn_element_Move,
			this.btn_element_Compare,
			this.btn_element_Add,
			this.btn_element_Sub,
			this.btn_element_Mup,
			this.btn_element_Div,
			this.btn_element_Mod,
			this.btn_element_ADC});
			this.btn_element_Functions.Enabled = false;
			this.btn_element_Functions.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_element_Functions.Image = ((System.Drawing.Image)(resources.GetObject("btn_element_Functions.Image")));
			this.btn_element_Functions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_element_Functions.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_element_Functions.Name = "btn_element_Functions";
			this.btn_element_Functions.Size = new System.Drawing.Size(151, 22);
			this.btn_element_Functions.Text = "Functions";
			// 
			// btn_element_Move
			// 
			this.btn_element_Move.Name = "btn_element_Move";
			this.btn_element_Move.Size = new System.Drawing.Size(219, 22);
			this.btn_element_Move.Text = "Move";
			// 
			// btn_element_Compare
			// 
			this.btn_element_Compare.Name = "btn_element_Compare";
			this.btn_element_Compare.Size = new System.Drawing.Size(219, 22);
			this.btn_element_Compare.Text = "Compare";
			// 
			// btn_element_Add
			// 
			this.btn_element_Add.Name = "btn_element_Add";
			this.btn_element_Add.Size = new System.Drawing.Size(219, 22);
			this.btn_element_Add.Text = "Add [+=]";
			// 
			// btn_element_Sub
			// 
			this.btn_element_Sub.Name = "btn_element_Sub";
			this.btn_element_Sub.Size = new System.Drawing.Size(219, 22);
			this.btn_element_Sub.Text = "Sub [-=]";
			// 
			// btn_element_Mup
			// 
			this.btn_element_Mup.Name = "btn_element_Mup";
			this.btn_element_Mup.Size = new System.Drawing.Size(219, 22);
			this.btn_element_Mup.Text = "Mup [*=]";
			// 
			// btn_element_Div
			// 
			this.btn_element_Div.Name = "btn_element_Div";
			this.btn_element_Div.Size = new System.Drawing.Size(219, 22);
			this.btn_element_Div.Text = "Div [/=]";
			// 
			// btn_element_Mod
			// 
			this.btn_element_Mod.Name = "btn_element_Mod";
			this.btn_element_Mod.Size = new System.Drawing.Size(219, 22);
			this.btn_element_Mod.Text = "Mod [%=]";
			// 
			// btn_element_ADC
			// 
			this.btn_element_ADC.Name = "btn_element_ADC";
			this.btn_element_ADC.Size = new System.Drawing.Size(219, 22);
			this.btn_element_ADC.Text = "A/D CONVERTER READ";
			// 
			// btn_element_Pluse
			// 
			this.btn_element_Pluse.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.btn_OSR,
			this.btn_OSF});
			this.btn_element_Pluse.Enabled = false;
			this.btn_element_Pluse.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_element_Pluse.Image = ((System.Drawing.Image)(resources.GetObject("btn_element_Pluse.Image")));
			this.btn_element_Pluse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_element_Pluse.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_element_Pluse.Name = "btn_element_Pluse";
			this.btn_element_Pluse.Size = new System.Drawing.Size(151, 22);
			this.btn_element_Pluse.Text = "Pluses";
			// 
			// btn_OSR
			// 
			this.btn_OSR.Name = "btn_OSR";
			this.btn_OSR.Size = new System.Drawing.Size(216, 22);
			this.btn_OSR.Text = "OSR (One Shot Rising)";
			// 
			// btn_OSF
			// 
			this.btn_OSF.Name = "btn_OSF";
			this.btn_OSF.Size = new System.Drawing.Size(216, 22);
			this.btn_OSF.Text = "OSF (One Shot Falling)";
			// 
			// Btn_Communication
			// 
			this.Btn_Communication.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.btn_uart_send,
			this.btn_uart_recv});
			this.Btn_Communication.Enabled = false;
			this.Btn_Communication.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Btn_Communication.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Communication.Image")));
			this.Btn_Communication.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.Btn_Communication.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.Btn_Communication.Name = "Btn_Communication";
			this.Btn_Communication.Size = new System.Drawing.Size(151, 22);
			this.Btn_Communication.Text = "Communication";
			// 
			// btn_uart_send
			// 
			this.btn_uart_send.Name = "btn_uart_send";
			this.btn_uart_send.Size = new System.Drawing.Size(142, 22);
			this.btn_uart_send.Text = "UART Send";
			// 
			// btn_uart_recv
			// 
			this.btn_uart_recv.Name = "btn_uart_recv";
			this.btn_uart_recv.Size = new System.Drawing.Size(142, 22);
			this.btn_uart_recv.Text = "UART Recv";
			// 
			// btn_other
			// 
			this.btn_other.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.btn_short,
			this.btn_open});
			this.btn_other.Enabled = false;
			this.btn_other.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btn_other.Image = ((System.Drawing.Image)(resources.GetObject("btn_other.Image")));
			this.btn_other.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btn_other.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btn_other.Name = "btn_other";
			this.btn_other.Size = new System.Drawing.Size(151, 22);
			this.btn_other.Text = "Other...";
			// 
			// btn_short
			// 
			this.btn_short.Name = "btn_short";
			this.btn_short.Size = new System.Drawing.Size(158, 22);
			this.btn_short.Text = "Short Circuit";
			// 
			// btn_open
			// 
			this.btn_open.Name = "btn_open";
			this.btn_open.Size = new System.Drawing.Size(158, 22);
			this.btn_open.Text = "Open Circuit";
			// 
			// splitContainerLadder
			// 
			this.splitContainerLadder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.splitContainerLadder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerLadder.Location = new System.Drawing.Point(0, 0);
			this.splitContainerLadder.Name = "splitContainerLadder";
			this.splitContainerLadder.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainerLadder.Panel1
			// 
			this.splitContainerLadder.Panel1.Controls.Add(this.panel_Ladder);
			// 
			// splitContainerLadder.Panel2
			// 
			this.splitContainerLadder.Panel2.Controls.Add(this.richTextBox1);
			this.splitContainerLadder.Size = new System.Drawing.Size(796, 533);
			this.splitContainerLadder.SplitterDistance = 475;
			this.splitContainerLadder.TabIndex = 2;
			// 
			// panel_Ladder
			// 
			this.panel_Ladder.AutoScroll = true;
			this.panel_Ladder.BackColor = System.Drawing.SystemColors.ActiveBorder;
			this.panel_Ladder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel_Ladder.Controls.Add(this.Ladder_Draw);
			this.panel_Ladder.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Ladder.Location = new System.Drawing.Point(0, 0);
			this.panel_Ladder.Name = "panel_Ladder";
			this.panel_Ladder.Size = new System.Drawing.Size(794, 473);
			this.panel_Ladder.TabIndex = 0;
			// 
			// Ladder_Draw
			// 
			this.Ladder_Draw.BackColor = System.Drawing.Color.Black;
			this.Ladder_Draw.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Ladder_Draw.Location = new System.Drawing.Point(35, 20);
			this.Ladder_Draw.Name = "Ladder_Draw";
			this.Ladder_Draw.Size = new System.Drawing.Size(727, 303);
			this.Ladder_Draw.TabIndex = 1;
			this.Ladder_Draw.TabStop = false;
			this.Ladder_Draw.DoubleClick += new System.EventHandler(this.Ladder_panelDoubleClick);
			this.Ladder_Draw.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Ladder_panelMouseDown);
			this.Ladder_Draw.MouseLeave += new System.EventHandler(this.Ladder_DrawMouseLeave);
			this.Ladder_Draw.MouseHover += new System.EventHandler(this.Ladder_DrawMouseHover);
			this.Ladder_Draw.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Ladder_panelMouseMove);
			this.Ladder_Draw.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Ladder_panelMouseUp);
			// 
			// richTextBox1
			// 
			this.richTextBox1.BackColor = System.Drawing.Color.SteelBlue;
			this.richTextBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBox1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBox1.ForeColor = System.Drawing.Color.Black;
			this.richTextBox1.Location = new System.Drawing.Point(0, 0);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(794, 52);
			this.richTextBox1.TabIndex = 0;
			this.richTextBox1.Text = "PICLIB CODE:";
			this.richTextBox1.WordWrap = false;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.newToolStripButton,
			this.openToolStripButton,
			this.saveToolStripButton,
			this.toolStripSeparator8,
			this.toolStripSeparator9,
			this.helpToolStripButton,
			this.tsb_config,
			this.toolStripSeparator10,
			this.t_sBtn_simulation,
			this.t_lable_Simulation_time,
			this.toolStripSeparator11,
			this.toolStripLabel1,
			this.toolStripComboBox_Mup,
			this.ts_bnt_start,
			this.ts_bnt_step,
			this.ts_bnt_stop});
			this.toolStrip1.Location = new System.Drawing.Point(3, 24);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(722, 25);
			this.toolStrip1.TabIndex = 1;
			// 
			// newToolStripButton
			// 
			this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
			this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripButton.Name = "newToolStripButton";
			this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.newToolStripButton.Text = "&New";
			this.newToolStripButton.Click += new System.EventHandler(this.NewToolStripButtonClick);
			// 
			// openToolStripButton
			// 
			this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
			this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripButton.Name = "openToolStripButton";
			this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.openToolStripButton.Text = "&Open";
			this.openToolStripButton.Click += new System.EventHandler(this.OpenToolStripButtonClick);
			// 
			// saveToolStripButton
			// 
			this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
			this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripButton.Name = "saveToolStripButton";
			this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.saveToolStripButton.Text = "&Save";
			this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButtonClick);
			// 
			// toolStripSeparator8
			// 
			this.toolStripSeparator8.Name = "toolStripSeparator8";
			this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripSeparator9
			// 
			this.toolStripSeparator9.Name = "toolStripSeparator9";
			this.toolStripSeparator9.Size = new System.Drawing.Size(6, 25);
			// 
			// helpToolStripButton
			// 
			this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
			this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.helpToolStripButton.Name = "helpToolStripButton";
			this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.helpToolStripButton.Text = "He&lp";
			this.helpToolStripButton.Click += new System.EventHandler(this.HelpToolStripButtonClick);
			// 
			// tsb_config
			// 
			this.tsb_config.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.tsb_config.Image = ((System.Drawing.Image)(resources.GetObject("tsb_config.Image")));
			this.tsb_config.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsb_config.Name = "tsb_config";
			this.tsb_config.Size = new System.Drawing.Size(23, 22);
			this.tsb_config.Text = "Option Config";
			this.tsb_config.Click += new System.EventHandler(this.Tsb_configClick);
			// 
			// toolStripSeparator10
			// 
			this.toolStripSeparator10.Name = "toolStripSeparator10";
			this.toolStripSeparator10.Size = new System.Drawing.Size(6, 25);
			// 
			// t_sBtn_simulation
			// 
			this.t_sBtn_simulation.AutoSize = false;
			this.t_sBtn_simulation.Image = ((System.Drawing.Image)(resources.GetObject("t_sBtn_simulation.Image")));
			this.t_sBtn_simulation.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.t_sBtn_simulation.Name = "t_sBtn_simulation";
			this.t_sBtn_simulation.Size = new System.Drawing.Size(150, 22);
			this.t_sBtn_simulation.Text = "Simulation Mode";
			this.t_sBtn_simulation.Click += new System.EventHandler(this.T_sBtn_simulationClick);
			// 
			// t_lable_Simulation_time
			// 
			this.t_lable_Simulation_time.Enabled = false;
			this.t_lable_Simulation_time.Image = ((System.Drawing.Image)(resources.GetObject("t_lable_Simulation_time.Image")));
			this.t_lable_Simulation_time.Name = "t_lable_Simulation_time";
			this.t_lable_Simulation_time.Size = new System.Drawing.Size(109, 22);
			this.t_lable_Simulation_time.Text = "Run Time : 0 ms";
			this.t_lable_Simulation_time.ToolTipText = "Time To Run";
			// 
			// toolStripSeparator11
			// 
			this.toolStripSeparator11.Name = "toolStripSeparator11";
			this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Enabled = false;
			this.toolStripLabel1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel1.Image")));
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(66, 22);
			this.toolStripLabel1.Text = "Speed x";
			// 
			// toolStripComboBox_Mup
			// 
			this.toolStripComboBox_Mup.AutoSize = false;
			this.toolStripComboBox_Mup.BackColor = System.Drawing.SystemColors.Control;
			this.toolStripComboBox_Mup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.toolStripComboBox_Mup.Items.AddRange(new object[] {
			"0.1",
			"0.2",
			"0.5",
			"1",
			"2",
			"5",
			"10"});
			this.toolStripComboBox_Mup.Name = "toolStripComboBox_Mup";
			this.toolStripComboBox_Mup.Size = new System.Drawing.Size(50, 23);
			this.toolStripComboBox_Mup.ToolTipText = "Speed Control";
			// 
			// ts_bnt_start
			// 
			this.ts_bnt_start.Image = ((System.Drawing.Image)(resources.GetObject("ts_bnt_start.Image")));
			this.ts_bnt_start.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_bnt_start.Name = "ts_bnt_start";
			this.ts_bnt_start.Size = new System.Drawing.Size(53, 22);
			this.ts_bnt_start.Text = "Start";
			this.ts_bnt_start.Click += new System.EventHandler(this.StartSimulate);
			// 
			// ts_bnt_step
			// 
			this.ts_bnt_step.Image = ((System.Drawing.Image)(resources.GetObject("ts_bnt_step.Image")));
			this.ts_bnt_step.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_bnt_step.Name = "ts_bnt_step";
			this.ts_bnt_step.Size = new System.Drawing.Size(88, 22);
			this.ts_bnt_step.Text = "Step/Pause";
			this.ts_bnt_step.Click += new System.EventHandler(this.StepSimulate);
			// 
			// ts_bnt_stop
			// 
			this.ts_bnt_stop.Image = ((System.Drawing.Image)(resources.GetObject("ts_bnt_stop.Image")));
			this.ts_bnt_stop.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.ts_bnt_stop.Name = "ts_bnt_stop";
			this.ts_bnt_stop.Size = new System.Drawing.Size(53, 22);
			this.ts_bnt_stop.Text = "Stop";
			this.ts_bnt_stop.Click += new System.EventHandler(this.StopSimulate);
			// 
			// mainMenu
			// 
			this.mainMenu.BackColor = System.Drawing.Color.Transparent;
			this.mainMenu.Dock = System.Windows.Forms.DockStyle.None;
			this.mainMenu.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.fileToolStripMenuItem,
			this.editToolStripMenuItem,
			this.viewToolStripMenuItem,
			this.tsmunu_hardware,
			this.toolsToolStripMenuItem,
			this.helpToolStripMenuItem});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(1240, 24);
			this.mainMenu.TabIndex = 0;
			this.mainMenu.Text = "mainMenu";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.newToolStripMenuItem,
			this.openToolStripMenuItem,
			this.toolStripSeparator,
			this.saveToolStripMenuItem,
			this.saveAsToolStripMenuItem,
			this.toolStripSeparator2,
			this.printToolStripMenuItem,
			this.printPreviewToolStripMenuItem,
			this.toolStripSeparator3,
			this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "&File";
			// 
			// newToolStripMenuItem
			// 
			this.newToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripMenuItem.Image")));
			this.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.newToolStripMenuItem.Name = "newToolStripMenuItem";
			this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
			this.newToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.newToolStripMenuItem.Text = "&New";
			this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItemClick);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripMenuItem.Image")));
			this.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.openToolStripMenuItem.Text = "&Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
			// 
			// toolStripSeparator
			// 
			this.toolStripSeparator.Name = "toolStripSeparator";
			this.toolStripSeparator.Size = new System.Drawing.Size(143, 6);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripMenuItem.Image")));
			this.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.saveToolStripMenuItem.Text = "&Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// saveAsToolStripMenuItem
			// 
			this.saveAsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveAsToolStripMenuItem.Image")));
			this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
			this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.saveAsToolStripMenuItem.Text = "Save &As";
			this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveAsToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
			// 
			// printToolStripMenuItem
			// 
			this.printToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripMenuItem.Image")));
			this.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printToolStripMenuItem.Name = "printToolStripMenuItem";
			this.printToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
			this.printToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.printToolStripMenuItem.Text = "&Print";
			this.printToolStripMenuItem.Click += new System.EventHandler(this.PrintToolStripMenuItemClick);
			// 
			// printPreviewToolStripMenuItem
			// 
			this.printPreviewToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("printPreviewToolStripMenuItem.Image")));
			this.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
			this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.printPreviewToolStripMenuItem.Text = "Print Pre&view";
			this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.PrintPreviewToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(143, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
			this.exitToolStripMenuItem.Text = "E&xit";
			// 
			// editToolStripMenuItem
			// 
			this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.undoToolStripMenuItem,
			this.redoToolStripMenuItem,
			this.toolStripSeparator4,
			this.cutToolStripMenuItem,
			this.copyToolStripMenuItem,
			this.pasteToolStripMenuItem,
			this.toolStripSeparator5});
			this.editToolStripMenuItem.Name = "editToolStripMenuItem";
			this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
			this.editToolStripMenuItem.Text = "&Edit";
			// 
			// undoToolStripMenuItem
			// 
			this.undoToolStripMenuItem.Enabled = false;
			this.undoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("undoToolStripMenuItem.Image")));
			this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
			this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
			this.undoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.undoToolStripMenuItem.Text = "&Undo";
			// 
			// redoToolStripMenuItem
			// 
			this.redoToolStripMenuItem.Enabled = false;
			this.redoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("redoToolStripMenuItem.Image")));
			this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
			this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
			this.redoToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.redoToolStripMenuItem.Text = "&Redo";
			// 
			// toolStripSeparator4
			// 
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(141, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Enabled = false;
			this.cutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("cutToolStripMenuItem.Image")));
			this.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.cutToolStripMenuItem.Text = "Cu&t";
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Enabled = false;
			this.copyToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("copyToolStripMenuItem.Image")));
			this.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.copyToolStripMenuItem.Text = "&Copy";
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Enabled = false;
			this.pasteToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pasteToolStripMenuItem.Image")));
			this.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.pasteToolStripMenuItem.Text = "&Paste";
			// 
			// toolStripSeparator5
			// 
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(141, 6);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.themeLadderToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// themeLadderToolStripMenuItem
			// 
			this.themeLadderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("themeLadderToolStripMenuItem.Image")));
			this.themeLadderToolStripMenuItem.Name = "themeLadderToolStripMenuItem";
			this.themeLadderToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
			this.themeLadderToolStripMenuItem.Text = "Theme Ladder";
			this.themeLadderToolStripMenuItem.Click += new System.EventHandler(this.ThemeLadderToolStripMenuItemClick);
			// 
			// tsmunu_hardware
			// 
			this.tsmunu_hardware.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ts_arduino_Pro1685v,
			this.ts_arduino_NANO,
			this.ts_arduinoUNO,
			this.ts_arduinoUNOR3,
			this.ts_arduino_MEGA,
			this.ts_Micro_PLC_deca,
			this.ts_no_hw});
			this.tsmunu_hardware.Name = "tsmunu_hardware";
			this.tsmunu_hardware.Size = new System.Drawing.Size(70, 20);
			this.tsmunu_hardware.Text = "Hardware";
			// 
			// ts_arduino_Pro1685v
			// 
			this.ts_arduino_Pro1685v.Image = ((System.Drawing.Image)(resources.GetObject("ts_arduino_Pro1685v.Image")));
			this.ts_arduino_Pro1685v.Name = "ts_arduino_Pro1685v";
			this.ts_arduino_Pro1685v.Size = new System.Drawing.Size(212, 22);
			this.ts_arduino_Pro1685v.Text = "Arduino ProMini(168)5V";
			// 
			// ts_arduino_NANO
			// 
			this.ts_arduino_NANO.Image = ((System.Drawing.Image)(resources.GetObject("ts_arduino_NANO.Image")));
			this.ts_arduino_NANO.Name = "ts_arduino_NANO";
			this.ts_arduino_NANO.Size = new System.Drawing.Size(212, 22);
			this.ts_arduino_NANO.Text = "Arduino NANO(168)";
			// 
			// ts_arduinoUNO
			// 
			this.ts_arduinoUNO.Image = global::MICROPLC.Properties.Resources.Arduino_48;
			this.ts_arduinoUNO.Name = "ts_arduinoUNO";
			this.ts_arduinoUNO.Size = new System.Drawing.Size(212, 22);
			this.ts_arduinoUNO.Text = "Arduino/NANO UNO(328)";
			// 
			// ts_arduinoUNOR3
			// 
			this.ts_arduinoUNOR3.Image = global::MICROPLC.Properties.Resources.Arduino_48;
			this.ts_arduinoUNOR3.Name = "ts_arduinoUNOR3";
			this.ts_arduinoUNOR3.Size = new System.Drawing.Size(212, 22);
			this.ts_arduinoUNOR3.Text = "Arduino UNO R3";
			// 
			// ts_arduino_MEGA
			// 
			this.ts_arduino_MEGA.Image = global::MICROPLC.Properties.Resources.Arduino_48;
			this.ts_arduino_MEGA.Name = "ts_arduino_MEGA";
			this.ts_arduino_MEGA.Size = new System.Drawing.Size(212, 22);
			this.ts_arduino_MEGA.Text = "Arduino MEGA";
			// 
			// ts_Micro_PLC_deca
			// 
			this.ts_Micro_PLC_deca.Image = ((System.Drawing.Image)(resources.GetObject("ts_Micro_PLC_deca.Image")));
			this.ts_Micro_PLC_deca.Name = "ts_Micro_PLC_deca";
			this.ts_Micro_PLC_deca.Size = new System.Drawing.Size(212, 22);
			this.ts_Micro_PLC_deca.Text = "Micro PLC deca";
			// 
			// ts_no_hw
			// 
			this.ts_no_hw.Checked = true;
			this.ts_no_hw.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ts_no_hw.Name = "ts_no_hw";
			this.ts_no_hw.Size = new System.Drawing.Size(212, 22);
			this.ts_no_hw.Text = "No Hardware";
			// 
			// toolsToolStripMenuItem
			// 
			this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.export_Code,
			this.expot_hex,
			this.btn_simulation,
			this.optionsToolStripMenuItem});
			this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
			this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
			this.toolsToolStripMenuItem.Text = "&Tools";
			// 
			// export_Code
			// 
			this.export_Code.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.export_Code.Image = ((System.Drawing.Image)(resources.GetObject("export_Code.Image")));
			this.export_Code.Name = "export_Code";
			this.export_Code.Size = new System.Drawing.Size(198, 22);
			this.export_Code.Text = "Flash Program Ladder...";
			this.export_Code.Click += new System.EventHandler(this.Export_CodeClick);
			// 
			// expot_hex
			// 
			this.expot_hex.Image = ((System.Drawing.Image)(resources.GetObject("expot_hex.Image")));
			this.expot_hex.Name = "expot_hex";
			this.expot_hex.Size = new System.Drawing.Size(198, 22);
			this.expot_hex.Text = "Compile Ladder Hex...";
			this.expot_hex.Click += new System.EventHandler(this.Expot_hexClick);
			// 
			// btn_simulation
			// 
			this.btn_simulation.Image = ((System.Drawing.Image)(resources.GetObject("btn_simulation.Image")));
			this.btn_simulation.Name = "btn_simulation";
			this.btn_simulation.Size = new System.Drawing.Size(198, 22);
			this.btn_simulation.Text = "Simulation Mode";
			this.btn_simulation.Click += new System.EventHandler(this.Btn_simulationClick);
			// 
			// optionsToolStripMenuItem
			// 
			this.optionsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("optionsToolStripMenuItem.Image")));
			this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
			this.optionsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
			this.optionsToolStripMenuItem.Text = "&Options Config Ladder";
			this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItemClick);
			// 
			// helpToolStripMenuItem
			// 
			this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.contentsToolStripMenuItem,
			this.indexToolStripMenuItem,
			this.searchToolStripMenuItem,
			this.toolStripSeparator6,
			this.aboutToolStripMenuItem});
			this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
			this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.helpToolStripMenuItem.Text = "&Help";
			// 
			// contentsToolStripMenuItem
			// 
			this.contentsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("contentsToolStripMenuItem.Image")));
			this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
			this.contentsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.contentsToolStripMenuItem.Text = "&Contents";
			// 
			// indexToolStripMenuItem
			// 
			this.indexToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("indexToolStripMenuItem.Image")));
			this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
			this.indexToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.indexToolStripMenuItem.Text = "&Index";
			// 
			// searchToolStripMenuItem
			// 
			this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
			this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
			this.searchToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.searchToolStripMenuItem.Text = "&Search";
			// 
			// toolStripSeparator6
			// 
			this.toolStripSeparator6.Name = "toolStripSeparator6";
			this.toolStripSeparator6.Size = new System.Drawing.Size(119, 6);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutToolStripMenuItem.Image")));
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
			this.aboutToolStripMenuItem.Text = "&About...";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// openFileDialogLadder
			// 
			this.openFileDialogLadder.Filter = "Ladder files|*.ld";
			this.openFileDialogLadder.Title = "Open Ladder Program";
			// 
			// contextMenu_rung
			// 
			this.contextMenu_rung.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.contextMenu_rung.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripTextBox2,
			this.toolStripSeparator7,
			this.add_Rung_Menu,
			this.Delete_Rung,
			this.Btn_copy_rung,
			this.Btn_Rung_Move_Up,
			this.Btn_Rung_Move_Down});
			this.contextMenu_rung.Name = "contextMenu";
			this.contextMenu_rung.Size = new System.Drawing.Size(170, 138);
			// 
			// toolStripTextBox2
			// 
			this.toolStripTextBox2.BackColor = System.Drawing.Color.Silver;
			this.toolStripTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.toolStripTextBox2.Font = new System.Drawing.Font("Segoe UI", 8.830189F);
			this.toolStripTextBox2.Name = "toolStripTextBox2";
			this.toolStripTextBox2.ReadOnly = true;
			this.toolStripTextBox2.Size = new System.Drawing.Size(100, 16);
			this.toolStripTextBox2.Text = "Rung Menu";
			// 
			// toolStripSeparator7
			// 
			this.toolStripSeparator7.Name = "toolStripSeparator7";
			this.toolStripSeparator7.Size = new System.Drawing.Size(166, 6);
			// 
			// add_Rung_Menu
			// 
			this.add_Rung_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.add_rung_Up,
			this.add_rung_Down});
			this.add_Rung_Menu.Name = "add_Rung_Menu";
			this.add_Rung_Menu.Size = new System.Drawing.Size(169, 22);
			this.add_Rung_Menu.Text = "Add Rung";
			// 
			// add_rung_Up
			// 
			this.add_rung_Up.Name = "add_rung_Up";
			this.add_rung_Up.Size = new System.Drawing.Size(136, 22);
			this.add_rung_Up.Text = "Rung Up";
			this.add_rung_Up.Click += new System.EventHandler(this.Add_rung_UpClick);
			// 
			// add_rung_Down
			// 
			this.add_rung_Down.Name = "add_rung_Down";
			this.add_rung_Down.Size = new System.Drawing.Size(136, 22);
			this.add_rung_Down.Text = "Rung Down";
			this.add_rung_Down.Click += new System.EventHandler(this.Add_rung_DownClick);
			// 
			// Delete_Rung
			// 
			this.Delete_Rung.Name = "Delete_Rung";
			this.Delete_Rung.Size = new System.Drawing.Size(169, 22);
			this.Delete_Rung.Text = "&Delete Rung";
			this.Delete_Rung.Click += new System.EventHandler(this.Delete_RungClick);
			// 
			// Btn_copy_rung
			// 
			this.Btn_copy_rung.Name = "Btn_copy_rung";
			this.Btn_copy_rung.Size = new System.Drawing.Size(169, 22);
			this.Btn_copy_rung.Text = "&Copy Rung";
			this.Btn_copy_rung.Click += new System.EventHandler(this.Btn_copy_rungClick);
			// 
			// Btn_Rung_Move_Up
			// 
			this.Btn_Rung_Move_Up.Name = "Btn_Rung_Move_Up";
			this.Btn_Rung_Move_Up.Size = new System.Drawing.Size(169, 22);
			this.Btn_Rung_Move_Up.Text = "Rung Move Up";
			this.Btn_Rung_Move_Up.Click += new System.EventHandler(this.Btn_Rung_Move_UpClick);
			// 
			// Btn_Rung_Move_Down
			// 
			this.Btn_Rung_Move_Down.Name = "Btn_Rung_Move_Down";
			this.Btn_Rung_Move_Down.Size = new System.Drawing.Size(169, 22);
			this.Btn_Rung_Move_Down.Text = "Rung Move Down";
			this.Btn_Rung_Move_Down.Click += new System.EventHandler(this.Btn_Rung_Move_DownClick);
			// 
			// saveFileDialogLadder
			// 
			this.saveFileDialogLadder.AddExtension = false;
			this.saveFileDialogLadder.Filter = "Ladder files|*.ld";
			// 
			// toolStripContainer3
			// 
			this.toolStripContainer3.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer3.ContentPanel
			// 
			this.toolStripContainer3.ContentPanel.AutoScroll = true;
			this.toolStripContainer3.ContentPanel.Controls.Add(this.toolStripContainer2);
			this.toolStripContainer3.ContentPanel.Size = new System.Drawing.Size(1240, 582);
			this.toolStripContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer3.LeftToolStripPanelVisible = false;
			this.toolStripContainer3.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer3.Name = "toolStripContainer3";
			this.toolStripContainer3.RightToolStripPanelVisible = false;
			this.toolStripContainer3.Size = new System.Drawing.Size(1240, 582);
			this.toolStripContainer3.TabIndex = 8;
			this.toolStripContainer3.Text = "toolStripContainer3";
			this.toolStripContainer3.TopToolStripPanelVisible = false;
			// 
			// toolStripContainer4
			// 
			this.toolStripContainer4.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer4.ContentPanel
			// 
			this.toolStripContainer4.ContentPanel.AutoScroll = true;
			this.toolStripContainer4.ContentPanel.Controls.Add(this.toolStripContainer3);
			this.toolStripContainer4.ContentPanel.Size = new System.Drawing.Size(1240, 582);
			this.toolStripContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer4.LeftToolStripPanelVisible = false;
			this.toolStripContainer4.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer4.Name = "toolStripContainer4";
			this.toolStripContainer4.RightToolStripPanelVisible = false;
			this.toolStripContainer4.Size = new System.Drawing.Size(1240, 582);
			this.toolStripContainer4.TabIndex = 9;
			this.toolStripContainer4.Text = "toolStripContainer4";
			this.toolStripContainer4.TopToolStripPanelVisible = false;
			// 
			// statusStripTool
			// 
			this.statusStripTool.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStripTool.ImageScalingSize = new System.Drawing.Size(18, 18);
			this.statusStripTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.ts_Hardware_name,
			this.toolStripProgressBar1,
			this.tsLabel_comport,
			this.toolStripStatusLabel_PortInfo});
			this.statusStripTool.Location = new System.Drawing.Point(0, 0);
			this.statusStripTool.Name = "statusStripTool";
			this.statusStripTool.Size = new System.Drawing.Size(1240, 24);
			this.statusStripTool.TabIndex = 0;
			this.statusStripTool.Text = "statusStripTool";
			// 
			// ts_Hardware_name
			// 
			this.ts_Hardware_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ts_Hardware_name.Name = "ts_Hardware_name";
			this.ts_Hardware_name.Size = new System.Drawing.Size(77, 19);
			this.ts_Hardware_name.Text = "No Hardware";
			this.ts_Hardware_name.TextChanged += new System.EventHandler(this.Ts_Hardware_nameTextChanged);
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 18);
			// 
			// tsLabel_comport
			// 
			this.tsLabel_comport.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.tsLabel_comport.Name = "tsLabel_comport";
			this.tsLabel_comport.Size = new System.Drawing.Size(138, 19);
			this.tsLabel_comport.Text = "No Communication Port";
			// 
			// toolStripStatusLabel_PortInfo
			// 
			this.toolStripStatusLabel_PortInfo.Name = "toolStripStatusLabel_PortInfo";
			this.toolStripStatusLabel_PortInfo.Size = new System.Drawing.Size(12, 19);
			this.toolStripStatusLabel_PortInfo.Text = "-";
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.BottomToolStripPanel
			// 
			this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStripTool);
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.AutoScroll = true;
			this.toolStripContainer1.ContentPanel.Controls.Add(this.toolStripContainer4);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1240, 582);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(1240, 606);
			this.toolStripContainer1.TabIndex = 10;
			this.toolStripContainer1.Text = "toolStripContainer1";
			this.toolStripContainer1.TopToolStripPanelVisible = false;
			// 
			// imageList1
			// 
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList1.Images.SetKeyName(0, "Zerode-Plump-Help-Support.ico");
			this.imageList1.Images.SetKeyName(1, "64up.ico");
			this.imageList1.Images.SetKeyName(2, "del.jpg");
			this.imageList1.Images.SetKeyName(3, "del2.jpg");
			this.imageList1.Images.SetKeyName(4, "Plus 2 Math-40.png");
			// 
			// toolTip_element
			// 
			this.toolTip_element.AutomaticDelay = 100;
			this.toolTip_element.ToolTipTitle = "Info";
			// 
			// printPreviewDialog_Ladder
			// 
			this.printPreviewDialog_Ladder.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.printPreviewDialog_Ladder.AutoScrollMinSize = new System.Drawing.Size(0, 0);
			this.printPreviewDialog_Ladder.ClientSize = new System.Drawing.Size(400, 300);
			this.printPreviewDialog_Ladder.Document = this.printDocument_Ladder;
			this.printPreviewDialog_Ladder.Enabled = true;
			this.printPreviewDialog_Ladder.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog_Ladder.Icon")));
			this.printPreviewDialog_Ladder.MainMenuStrip = this.mainMenu;
			this.printPreviewDialog_Ladder.Name = "printPreviewDialog_Ladder";
			this.printPreviewDialog_Ladder.Visible = false;
			// 
			// printDocument_Ladder
			// 
			this.printDocument_Ladder.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument_PrintPage);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ButtonFace;
			this.ClientSize = new System.Drawing.Size(1240, 606);
			this.Controls.Add(this.toolStripContainer1);
			this.ForeColor = System.Drawing.Color.Green;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mainMenu;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LADDUINO MICRO-PLC";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.contexMenu_Element.ResumeLayout(false);
			this.contexMenu_Element.PerformLayout();
			this.panel_Right.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.toolStripContainer2.ContentPanel.ResumeLayout(false);
			this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer2.TopToolStripPanel.PerformLayout();
			this.toolStripContainer2.ResumeLayout(false);
			this.toolStripContainer2.PerformLayout();
			this.splitContainer_Main.Panel1.ResumeLayout(false);
			this.splitContainer_Main.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
			this.splitContainer_Main.ResumeLayout(false);
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
			this.splitContainer3.ResumeLayout(false);
			this.splitContainer4.Panel1.ResumeLayout(false);
			this.splitContainer4.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
			this.splitContainer4.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.toolStrip2.ResumeLayout(false);
			this.toolStrip2.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.toolStrip_Element.ResumeLayout(false);
			this.toolStrip_Element.PerformLayout();
			this.splitContainerLadder.Panel1.ResumeLayout(false);
			this.splitContainerLadder.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerLadder)).EndInit();
			this.splitContainerLadder.ResumeLayout(false);
			this.panel_Ladder.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.Ladder_Draw)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.contextMenu_rung.ResumeLayout(false);
			this.contextMenu_rung.PerformLayout();
			this.toolStripContainer3.ContentPanel.ResumeLayout(false);
			this.toolStripContainer3.ResumeLayout(false);
			this.toolStripContainer3.PerformLayout();
			this.toolStripContainer4.ContentPanel.ResumeLayout(false);
			this.toolStripContainer4.ResumeLayout(false);
			this.toolStripContainer4.PerformLayout();
			this.statusStripTool.ResumeLayout(false);
			this.statusStripTool.PerformLayout();
			this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.ResumeLayout(false);

		}
		
		private System.Windows.Forms.ToolStripStatusLabel tsLabel_comport;
		private System.Windows.Forms.ToolStripMenuItem Btn_copy_rung;
		private System.Windows.Forms.ToolStripStatusLabel ts_Hardware_name;
		private System.Windows.Forms.ToolStripMenuItem ts_no_hw;
		private System.Windows.Forms.ToolStripMenuItem ts_Micro_PLC_deca;
		private System.Windows.Forms.ToolStripMenuItem ts_arduino_MEGA;
		private System.Windows.Forms.ToolStripMenuItem ts_arduinoUNO;
		private System.Windows.Forms.ToolStripMenuItem tsmunu_hardware;
		private System.Windows.Forms.ToolStripMenuItem btn_element_TON;
		private System.Windows.Forms.ToolStripMenuItem btn_element_TOF;
		private System.Windows.Forms.ToolStripDropDownButton btn_element_Timers;
		private System.Windows.Forms.ToolStripMenuItem propertes_element;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.StatusStrip statusStripTool;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer4;
		private System.Windows.Forms.ToolStripContainer toolStripContainer3;
		private System.Windows.Forms.SplitContainer splitContainerLadder;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.SplitContainer splitContainer_Main;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListView listView_Map_I;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ListView listView_Map_O;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.SaveFileDialog saveFileDialogLadder;
		private System.Windows.Forms.ToolStripButton btn_element_Coil;
		private System.Windows.Forms.ToolStripButton btn_element_Contracs;
		private System.Windows.Forms.ToolStrip toolStrip_Element;
		private System.Windows.Forms.ToolStripMenuItem Find_Ref_Elements;
		private System.Windows.Forms.ToolStripMenuItem Delete_Element;
		private System.Windows.Forms.ContextMenuStrip contexMenu_Element;
		private System.Windows.Forms.ToolStripMenuItem Btn_Rung_Move_Down;
		private System.Windows.Forms.ToolStripMenuItem Btn_Rung_Move_Up;
		private System.Windows.Forms.ToolStripMenuItem Delete_Rung;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ContextMenuStrip contextMenu_rung;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
		private System.Windows.Forms.ListView listView_elements;
		private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
		private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
		private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
		private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
		private System.Windows.Forms.ToolStripContentPanel ContentPanel;
		private System.Windows.Forms.Panel panel_Right;
		private System.Windows.Forms.PictureBox Ladder_Draw;
		private System.Windows.Forms.ToolStripContainer toolStripContainer2;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
		private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem btn_simulation;
		private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialogLadder;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.ToolStripMenuItem add_Rung_Menu;
		private System.Windows.Forms.ToolStripMenuItem add_rung_Up;
		private System.Windows.Forms.ToolStripMenuItem add_rung_Down;
		private System.Windows.Forms.Panel panel_Ladder;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolStripMenuItem export_Code;
		private System.Windows.Forms.ToolStripMenuItem btn_element_TPC;
		private System.Windows.Forms.ToolStripDropDownButton btn_element_Counters;
		private System.Windows.Forms.ToolStripMenuItem btn_element_CTU;
		private System.Windows.Forms.ToolStripMenuItem btn_element_CTD;
		private System.Windows.Forms.ToolStripMenuItem btn_element_CTC;
		private System.Windows.Forms.ToolStripDropDownButton btn_element_Functions;
		private System.Windows.Forms.ToolStripMenuItem btn_element_Compare;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
		private System.Windows.Forms.ToolStripButton newToolStripButton;
		private System.Windows.Forms.ToolStripButton openToolStripButton;
		private System.Windows.Forms.ToolStripButton saveToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
		private System.Windows.Forms.ToolStripButton helpToolStripButton;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
		private System.Windows.Forms.ToolStripButton t_sBtn_simulation;
		private System.Windows.Forms.ToolStripLabel t_lable_Simulation_time;
		private System.Windows.Forms.ToolStripButton ts_bnt_start;
		private System.Windows.Forms.ToolStripButton ts_bnt_step;
		private System.Windows.Forms.ToolStripButton ts_bnt_stop;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_PortInfo;
		

        private System.Windows.Forms.ToolStripDropDownButton btn_element_Pluse;
        private System.Windows.Forms.ToolStripMenuItem btn_OSR;
        private System.Windows.Forms.ToolStripMenuItem btn_OSF;
        private System.Windows.Forms.ToolStripMenuItem expot_hex;
        private System.Windows.Forms.ToolStripButton btn_element_MasterRelay;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_Mup;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsb_Move_up;
        private System.Windows.Forms.ToolStripButton tsb_Insert_up;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.FontDialog fontDialog_Ladder;
        private System.Windows.Forms.ToolStripButton tsb_Insert_down;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripButton tsb_Move_down;
        private System.Windows.Forms.ToolStripButton tsb_delete_rung;
        private System.Windows.Forms.ToolStripButton tsb_New_rung;
        private System.Windows.Forms.ToolStripButton tsb_Copy_rung;
        private System.Windows.Forms.ToolStripButton tsb_config;
        private System.Windows.Forms.ToolStripMenuItem btn_element_Move;
        private System.Windows.Forms.ToolStripMenuItem btn_element_Add;
        private System.Windows.Forms.ToolStripMenuItem btn_element_Sub;
        private System.Windows.Forms.ToolStripMenuItem btn_element_Mup;
        private System.Windows.Forms.ToolStripMenuItem btn_element_Div;
        private System.Windows.Forms.ToolStripMenuItem btn_element_Mod;
        private System.Windows.Forms.ToolStripMenuItem btn_element_ADC;
        private System.Windows.Forms.ToolStripDropDownButton btn_element_Shift;
        private System.Windows.Forms.ToolStripMenuItem btn_element_Shift_Control;
        private System.Windows.Forms.ToolStripMenuItem btn_element_Shift_Contracs;
        private System.Windows.Forms.ColorDialog colorDialog_Ladder;
        private System.Windows.Forms.ToolStripMenuItem themeLadderToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip_element;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog_Ladder;
        private System.Drawing.Printing.PrintDocument printDocument_Ladder;
        private System.Windows.Forms.ToolStripButton btn_element_Comment;
        private System.Windows.Forms.ToolStripMenuItem btn_element_Shift_Reg;
        private System.Windows.Forms.ToolStripDropDownButton btn_other;
        private System.Windows.Forms.ToolStripMenuItem btn_short;
        private System.Windows.Forms.ToolStripMenuItem btn_open;
        private System.Windows.Forms.ToolStripDropDownButton Btn_Communication;
        private System.Windows.Forms.ToolStripMenuItem btn_uart_send;
        private System.Windows.Forms.ToolStripMenuItem btn_uart_recv;
        private System.Windows.Forms.ToolStripMenuItem ts_arduino_NANO;
        private System.Windows.Forms.ToolStripMenuItem ts_arduinoUNOR3;
        private System.Windows.Forms.ToolStripMenuItem ts_arduino_Pro1685v;
        

	}
}
