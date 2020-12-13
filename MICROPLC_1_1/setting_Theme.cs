/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 11/2/2559
 * Time: 20:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of setting_Ttheme.
	/// </summary>
	public partial class setting_Theme : Form
	{
		Elements test_view1 = new Elements(TypeTag.COIL, "Y_View", null);
		Elements test_view2 = new Elements(TypeTag.CONTACTS, "R_View", null);
		Elements test_view3 = new Elements(TypeTag.TPC, "T_View", null);
		Elements test_view4 = new Elements(TypeTag.SHIFT_REGISTERS, "S_View", null);
		public setting_Theme()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			pictureBox1.Paint += PictureBox_Paint;
			pictureBox2.Paint += PictureBox_Paint;
			pictureBox3.Paint += PictureBox_Paint;
			pictureBox4.Paint += PictureBox_Paint;
			View_Refresh();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		void View_Refresh()
		{
			pictureBox1.Invalidate();
			pictureBox2.Invalidate();
			pictureBox3.Invalidate();
			pictureBox4.Invalidate();
			btn_bg_set.BackColor = DrawingTags.color_draw_bg;
			btn_element_set.BackColor = DrawingTags.color_draw;
		}
		void PictureBox_Paint(object sender, PaintEventArgs e)
		{
			panel1.BackColor = DrawingTags.color_draw_bg;
			PictureBox _pic = sender as PictureBox;
			_pic.BackColor = DrawingTags.color_draw_bg;
			Point drawPoint = new Point();
			Elements _tag = test_view1;
			switch (_pic.Name) {
				case "pictureBox1":
					_tag = test_view1;
					break;
				case "pictureBox2":
					_tag = test_view2;
					break;
				case "pictureBox3":
					_tag = test_view3;
					break;
				case "pictureBox4":
					_tag = test_view4;
					break;
			}			
			
			DrawingTags.Drawtag(_tag, e.Graphics, drawPoint, _pic.Width);
			DrawingTags.DrawtagString(_tag, e.Graphics, drawPoint, _pic.Width, 0);
			
			simple_tag_symbol.Font = DrawingTags.drawFont_Symbol;
			simple_tag_symbol.ForeColor = DrawingTags.color_symbol_draw;
			simple_tag_symbol.BackColor = DrawingTags.color_draw_bg;
			
			simple_tag_font.Font = DrawingTags.drawFont;
			simple_tag_font.ForeColor = DrawingTags.color_string_draw;
			simple_tag_font.BackColor = DrawingTags.color_draw_bg;
			
		}
		void Btn_font_textClick(object sender, EventArgs e)
		{
			fontDialog_Ladder.Font = DrawingTags.drawFont;
			if (fontDialog_Ladder.ShowDialog() == DialogResult.OK) {
				DrawingTags.drawFont = fontDialog_Ladder.Font;
				View_Refresh();
			}
		}
		void Btn_font_symbolClick(object sender, EventArgs e)
		{
			fontDialog_Ladder.Font = DrawingTags.drawFont_Symbol;
			if (fontDialog_Ladder.ShowDialog() == DialogResult.OK) {
				DrawingTags.drawFont_Symbol = fontDialog_Ladder.Font;
				View_Refresh();
			}
		}
		void Btn_color_font_textClick(object sender, EventArgs e)
		{
			colorDialog_Ladder.Color = DrawingTags.color_string_draw;
			if (colorDialog_Ladder.ShowDialog() == DialogResult.OK) {
				DrawingTags.color_string_draw = colorDialog_Ladder.Color;
				View_Refresh();
			}
		}
		void Btn_color_font_symbolClick(object sender, EventArgs e)
		{
			colorDialog_Ladder.Color = DrawingTags.color_symbol_draw;
			if (colorDialog_Ladder.ShowDialog() == DialogResult.OK) {
				DrawingTags.color_symbol_draw = colorDialog_Ladder.Color;
				View_Refresh();
			}
		}
		void Btn_OKClick(object sender, EventArgs e)
		{
			Close();
		}
		void Btn_bg_setClick(object sender, EventArgs e)
		{
			colorDialog_Ladder.Color = DrawingTags.color_draw_bg;
			if (colorDialog_Ladder.ShowDialog() == DialogResult.OK) {
				DrawingTags.color_draw_bg = colorDialog_Ladder.Color;
				View_Refresh();
			}
		}
		void Btn_element_setClick(object sender, EventArgs e)
		{
			colorDialog_Ladder.Color = DrawingTags.color_draw;
			if (colorDialog_Ladder.ShowDialog() == DialogResult.OK) {
				DrawingTags.color_draw = colorDialog_Ladder.Color;
				View_Refresh();
			}
		}
		void Label1Click(object sender, EventArgs e)
		{
	
		}

	}
}
