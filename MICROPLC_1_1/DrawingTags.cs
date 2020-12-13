/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 4/30/2015
 * Time: 9:48 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.000
 */
using System;
using System.Drawing;
using System.Windows.Forms;
namespace MICROPLC
{
	/// <summary>
	/// Description of DrawingTags.
	/// </summary>
	public static class DrawingTags
	{
		public static  Color color_simulat = Color.Red;
		public static  Color color_draw = Color.Gray;
		public static  Color color_draw_select = Color.Orange;
		public static  Color color_symbol_draw = Color.Green;
		public static  Color color_string_draw = Color.Green;
		public static  Color color_draw_bg = Color.FromArgb(16, 16, 16);
		
		public static string font_name = "";
		public static Font drawFont = new Font(font_name, 8);
		public static Font drawFont_Type = new Font(font_name, 9);
		//========================
		public static Font drawFont_Symbol = new Font(font_name, 12);
		
		static SolidBrush drawBrush = new SolidBrush(color_symbol_draw);
		static Pen drawPen = new Pen(color_draw, 2);
		static readonly Pen drawPen_select = new Pen(color_draw_select, 2);
		
		public static int tag_draw_size = 75;
		public static bool simulation_startus;
		public static bool sync_startus;
		public static int scanValue;
		public static int Master_scanValue;
		public static ulong simulationTime;
		
		static void DrawBaseContrac(Graphics g, int type, bool Nc_contrac, Point drawPoint, int size, Pen drawpen, bool startus)
		{
			var _drawpen = new Pen(color_draw, drawpen.Width) {
				Color = drawpen.Color
			};
			if (scanValue > 0)
				_drawpen.Color = color_simulat;
			g.DrawLine(_drawpen, drawPoint.X, drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 0.25)), drawPoint.Y + size / 2);
			
			int tempcenterX = (int)(drawPoint.X + (size * 0.25));
			int tempcenterY = (int)(drawPoint.Y + (size * 0.5));
			if (!Nc_contrac) {
				
				if (startus) {
					g.DrawLine(_drawpen, (float)(drawPoint.X + (size * 0.25)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 0.75)), (float)(drawPoint.Y + (size * 0.4)));
				} else {
					g.DrawLine(_drawpen, (float)(drawPoint.X + (size * 0.25)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 0.75)), (float)(drawPoint.Y + (size * 0.3)));
				}
				_drawpen.Color = color_draw;
				if (startus & (scanValue > 0)) {
					_drawpen.Color = color_simulat;
					scanValue = 1;
				} else {
					scanValue = 0;
				}
				
				g.DrawLine(_drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 0.75)), (float)(drawPoint.Y + size * 0.4));
				g.DrawLine(_drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, drawPoint.X + size, drawPoint.Y + size / 2);

			} else {
				if (startus) {
					g.DrawLine(_drawpen, (float)(drawPoint.X + (size * 0.25)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 0.75)), (float)(drawPoint.Y + (size * 0.75)));
				} else {
					g.DrawLine(_drawpen, (float)(drawPoint.X + (size * 0.25)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 0.75)), (float)(drawPoint.Y + (size * 0.6)));
				}

				if (startus) {
					_drawpen.Color = color_draw;
					scanValue = 0;
				}
				g.DrawLine(_drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 0.75)), (float)(drawPoint.Y + size * 0.6));
				g.DrawLine(_drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, drawPoint.X + size, drawPoint.Y + size / 2);
				
			}
			var temprec = new Rectangle(tempcenterX - 4, tempcenterY - 4, 8, 8);
			g.FillEllipse(drawBrush, temprec);
		}
		
		public static void Drawtag(Elements tag, Graphics g, Point drawPoint, int size)
		{
			Point strPoint;
			RectangleF recf;
			SizeF stringSize;
			Pen drawpen = new Pen(color_draw, drawPen.Width);
			if (tag.Select_tag) {
				drawpen.Color = color_draw_select;
				drawBrush.Color = color_draw_select;
			} else {
				drawpen.Color = color_draw;
				drawBrush.Color = color_symbol_draw;
			}
			string strVar = "";
			switch (tag.Type) {
				case TypeTag.COMMENT:
					
					string strComment = tag.Properties;
					
					//stringSize = g.MeasureString(strSymbole, drawFont_Symbol);
					DrawIcon(size, g, SystemIcons.Question, drawPoint);
					strPoint = new Point((int)(drawPoint.X + (size)), (int)(drawPoint.Y + 20));
					g.DrawString(strComment, drawFont_Symbol, drawBrush, strPoint.X, strPoint.Y);
					
					break;
				case  TypeTag.SHORT:
				case  TypeTag.OPEN:
					
					if (simulation_startus) {
						tag.Startus = false;
						drawpen.Color = color_draw;
						if (scanValue > 0) {
							
							//tag.Startus = true;
							if (tag.Type == TypeTag.SHORT) {
								drawpen.Color = color_simulat;
							}
							if (tag.Type == TypeTag.OPEN) {
								scanValue = 0;
							}
						}
					}
					if (tag.Type == TypeTag.SHORT) {
						Point[] points = {
							new Point((int)(drawPoint.X), (int)(drawPoint.Y + size * 0.5)),
							//new Point((int)(drawPoint.X + (size * 0.5)), (int)(drawPoint.Y + size * 0.25)),
							//new Point((int)(drawPoint.X + (size * 0.75)), (int)(drawPoint.Y + size * 0.25)),
							new Point((int)(drawPoint.X + (size)), (int)(drawPoint.Y + size * 0.5))
						};
						g.DrawLines(drawpen, points);
					}
					if (tag.Type == TypeTag.OPEN) {
						Point[] points = {
							new Point((int)(drawPoint.X), (int)(drawPoint.Y + size * 0.5)),
							new Point((int)(drawPoint.X + (size * 0.25)), (int)(drawPoint.Y + size * 0.5)),
							//new Point((int)(drawPoint.X + (size * 0.75)), (int)(drawPoint.Y + size * 0.75)),
							//new Point((int)(drawPoint.X + (size * 0.75)), (int)(drawPoint.Y + size * 0.5))
						};
						g.DrawLines(drawpen, points);
						Point[] points0 = {
							//new Point((int)(drawPoint.X ), (int)(drawPoint.Y + size * 0.5)),
							//new Point((int)(drawPoint.X + (size * 0.25)), (int)(drawPoint.Y + size * 0.5)),
							new Point((int)(drawPoint.X + (size * 0.75)), (int)(drawPoint.Y + size * 0.5)),
							new Point((int)(drawPoint.X + (size * 1)), (int)(drawPoint.Y + size * 0.5))
						};
						g.DrawLines(drawpen, points0);
					}
					int tempcenterX = (int)(drawPoint.X + (size * 0.25));
					int tempcenterY = (int)(drawPoint.Y + (size * 0.5));
					var temprec = new Rectangle(tempcenterX - 4, tempcenterY - 4, 8, 8);
					g.FillEllipse(drawBrush, temprec);
					
					tempcenterX = (int)(drawPoint.X + (size * 0.75));
					tempcenterY = (int)(drawPoint.Y + (size * 0.5));
					temprec = new Rectangle(tempcenterX - 4, tempcenterY - 4, 8, 8);
					g.FillEllipse(drawBrush, temprec);
					break;
				case TypeTag.CONTACTS:
					
					DrawBaseContrac(g, 0, tag.Properties_negated, drawPoint, size, drawpen, tag.Startus);
					string strSymbole = "";
					switch (tag.Name.Substring(0, 1)) {
						case "C":
							if (tag.Properties_setOnly)
								strSymbole = @"Upper";
							if (tag.Properties_resetOnly)
								strSymbole = @"lower";
							stringSize = g.MeasureString(strSymbole, drawFont);
							strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + (size - stringSize.Height) * 0.75));
							g.DrawString(strSymbole, drawFont, drawBrush, strPoint.X, strPoint.Y);
							
							strSymbole = "C";
							break;
						case "R":
							strSymbole = "R";
							break;
						case "X":
							strSymbole = "X";
							break;
						case "Y":
							strSymbole = "Y";
							break;
						case "S":
							strSymbole = string.Format("{0}", tag.Properties_value1.ToString("00"));
							break;
					}
					stringSize = g.MeasureString(strSymbole, drawFont_Symbol);
					strPoint = new Point((int)(drawPoint.X + (size) / 2), (int)(drawPoint.Y + (size - stringSize.Height) / 2));
					g.DrawString(strSymbole, drawFont_Symbol, drawBrush, strPoint.X, strPoint.Y);
					
					break;
				case TypeTag.MASTER_RELAY:
					if (tag.Select_tag)
						drawpen.Color = color_draw_select;
					if (simulation_startus) {
						tag.Startus = false;
						drawpen.Color = color_draw;
						if (scanValue > 0) {
							drawpen.Color = color_simulat;
							tag.Startus = true;
							Master_scanValue = 1;
						} else {
							Master_scanValue = 0;
						}
					}
					stringSize = g.MeasureString("MR", drawFont_Symbol);
					strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + (size - stringSize.Height) / 2));
					
					recf = new RectangleF((float)(drawPoint.X + (size * 0.25)), (float)(drawPoint.Y + (size * 0.25)), (float)(size * 0.5), (float)(size * 0.5));
					g.DrawRectangle(drawpen, recf.X, recf.Y, recf.Width, recf.Height);
					g.DrawString("MR", drawFont_Symbol, drawBrush, strPoint.X, strPoint.Y);
					
					//g.DrawLine(drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 1)), drawPoint.Y + size / 2);
					
					break;
				case TypeTag.MOVE:
					if (tag.Select_tag)
						drawpen.Color = color_draw_select;
					strVar = "Move";
					if (simulation_startus) {
						drawpen.Color = color_draw;
						drawpen.Color = color_simulat;
						int value_data;
						foreach (Elements vartemp in Ladder.VariablePLCLib_element) {
							if (vartemp.Name == tag.Name) {
								if (scanValue > 0) {
									tag.Startus = true;
									if (!int.TryParse(tag.Properties, out value_data)) {
										if (tag.Properties.Substring(0, 1) == "'") {
											char[] ch = tag.Properties.ToCharArray();
											value_data = ch[1];
										} else {
											foreach (Elements varMove in Ladder.VariablePLCLib_element) {
												if (varMove.Name == tag.Properties) {
													value_data = varMove.Properties_value;
													break;
												}
											}
										}
									}
									switch (vartemp.Name.Substring(0, 1)) {
										case "C":
											vartemp._ct = value_data;
											break;
//										case "T":
//											vartemp._ct = value_data;
//											break;
										default:
											vartemp.Properties_value = value_data;
											break;
									}
								} else {
									tag.Startus = false;
								}
								strVar = string.Format("{0}", vartemp.Properties_value);
								break;
							}
						}
					}

					if (tag.Startus & simulation_startus || tag.Select_tag) {
						drawpen.Color = color_simulat;
					} else {
						drawpen.Color = color_draw;
					}
					
					stringSize = g.MeasureString(strVar, drawFont_Symbol);
					strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + (size - stringSize.Height) / 2));
					recf = new RectangleF((float)(drawPoint.X + (size * 0.25)), (float)(drawPoint.Y + (size * 0.25)), (float)(size * 0.5), (float)(size * 0.5));
					g.DrawRectangle(drawpen, recf.X, recf.Y, recf.Width, recf.Height);
					g.DrawLine(drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 1)), drawPoint.Y + size / 2);
					
					g.DrawString(strVar, drawFont_Symbol, drawBrush, strPoint.X, strPoint.Y);
					strVar = string.Format(":= {0}", tag.Properties);
					stringSize = g.MeasureString(strVar, drawFont);
					strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + size * 0.8));
					g.DrawString(strVar, drawFont, drawBrush, strPoint.X, strPoint.Y);
					
					break;
				case TypeTag.ADD:
				case TypeTag.SUB:
				case TypeTag.MUL:
				case TypeTag.DIV:
				case TypeTag.MOD:
				case TypeTag.ADC:
					if (tag.Select_tag)
						drawpen.Color = color_draw_select;
					
					switch (tag.Type) {
						case TypeTag.ADD:
							strVar = "Add";
							break;
						case TypeTag.SUB:
							strVar = "Sub";
							break;
						case TypeTag.MUL:
							strVar = "Mul";
							break;
						case TypeTag.DIV:
							strVar = "Div";
							break;
						case TypeTag.MOD:
							strVar = "Mod";
							break;
						case TypeTag.ADC:
							strVar = "ADC";
							break;
					}
					
					if (simulation_startus) {
						drawpen.Color = color_draw;
						drawpen.Color = color_simulat;
						foreach (Elements vartemp in Ladder.VariablePLCLib_element) {
							if (vartemp.Name == tag.Name) {
								if (scanValue > 0) {
									tag.Startus = true;
									int value_data = 0;
									int value_operation = 0;
									if (tag.Type != TypeTag.ADC) {
										string[] operation_para = tag.Properties.Split(' ');
										
										foreach (Elements varElement in Ladder.VariablePLCLib_element) {
											if (varElement.Name == operation_para[0]) {
												value_operation = varElement.Properties_value;
												break;
											}
										}
										if (!int.TryParse(operation_para[1], out value_data)) {
											foreach (Elements varElement in Ladder.VariablePLCLib_element) {
												if (varElement.Name == operation_para[1]) {
													value_data = varElement.Properties_value;
													break;
												}
											}
										}
									}
									
									switch (tag.Type) {
										case TypeTag.ADD:
											vartemp.Properties_value = value_operation + value_data;
											break;
										case TypeTag.SUB:
											vartemp.Properties_value = value_operation - value_data;
											break;
										case TypeTag.MUL:
											vartemp.Properties_value = value_operation * value_data;
											break;
										case TypeTag.DIV:
											if (value_data == 0) {
												(Application.OpenForms["MainForm"] as MainForm).StopSimulate(null, null);
												DialogResult retSave = MessageBox.Show(string.Format("Variable Div by Zero!! *** {2}\n \t{0}/{1}", vartemp.Properties_value, value_data, vartemp.Name), "Error?", MessageBoxButtons.OK, MessageBoxIcon.Error);
												break;
											}
											vartemp.Properties_value = value_operation / value_data;
											break;
										case TypeTag.MOD:
											if (value_data == 0) {
												(Application.OpenForms["MainForm"] as MainForm).StopSimulate(null, null);
												DialogResult retSave = MessageBox.Show(string.Format("Variable Div by Zero!! *** {2}\n \t{0}/{1}", vartemp.Properties_value, value_data, vartemp.Name), "Error?", MessageBoxButtons.OK, MessageBoxIcon.Error);
												break;
											}
											vartemp.Properties_value = value_operation % value_data;
											break;
										case TypeTag.ADC:
											vartemp.Properties_value = tag.Properties_value;
											break;
									}
									if (vartemp.Properties_value > 32000 || vartemp.Properties_value < -32000) {
										
										(Application.OpenForms["MainForm"] as MainForm).StopSimulate(null, null);
										DialogResult retSave = MessageBox.Show(string.Format("Value Over Flow in Variable \n \t{0} = {1}", vartemp.Name, vartemp.Properties_value), "Error?", MessageBoxButtons.OK, MessageBoxIcon.Error);
										vartemp.Properties_value = 0;
										return;
									}
									
								} else {
									tag.Startus = false;
								}
								//strVar = string.Format("{0}", vartemp.Properties_value);
								break;
							}
						}
						
						foreach (Elements vartemp in Ladder.VariablePLCLib_element) {
							if (vartemp.Name == tag.Name) {
								strVar = string.Format("{0}", vartemp.Properties_value);
								break;
							}
						}
						
					}

					if (tag.Startus & simulation_startus || tag.Select_tag) {
						drawpen.Color = color_simulat;
					} else {
						drawpen.Color = color_draw;
					}
					
					stringSize = g.MeasureString(strVar, drawFont_Symbol);
					strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + (size - stringSize.Height) / 2));
					recf = new RectangleF((float)(drawPoint.X + (size * 0.25)), (float)(drawPoint.Y + (size * 0.25)), (float)(size * 0.5), (float)(size * 0.5));
					g.DrawRectangle(drawpen, recf.X, recf.Y, recf.Width, recf.Height);
					g.DrawLine(drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 1)), drawPoint.Y + size / 2);
					
					g.DrawString(strVar, drawFont_Symbol, drawBrush, strPoint.X, strPoint.Y);
					
					string[] operation_;
					switch (tag.Type) {
						case TypeTag.ADD:
							operation_ = tag.Properties.Split(' ');
							strVar = string.Format("{0}+{1}", operation_[0], operation_[1]);
							break;
						case TypeTag.SUB:
							operation_ = tag.Properties.Split(' ');
							strVar = string.Format("{0}-{1}", operation_[0], operation_[1]);
							break;
						case TypeTag.MUL:
							operation_ = tag.Properties.Split(' ');
							strVar = string.Format("{0}*{1}", operation_[0], operation_[1]);
							break;
						case TypeTag.DIV:
							operation_ = tag.Properties.Split(' ');
							strVar = string.Format("{0}/{1}", operation_[0], operation_[1]);
							break;
						case TypeTag.MOD:
							operation_ = tag.Properties.Split(' ');
							strVar = string.Format("{0}%{1}", operation_[0], operation_[1]);
							break;
						case TypeTag.ADC:
							strVar = "read analog";
							if (simulation_startus)
								strVar = string.Format("{0}", tag.Properties_value);
							break;
					}
					
					stringSize = g.MeasureString(strVar, drawFont);
					strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + size * 0.8));
					g.DrawString(strVar, drawFont, drawBrush, strPoint.X, strPoint.Y);
					
					break;
				case TypeTag.COIL:
					if (tag.Select_tag)
						drawpen.Color = color_draw_select;
					if (simulation_startus) {
						
						switch (tag.Name.Substring(0, 1)) {
							case "Y":
							case "R":
								if (sync_startus)
									break;
								if (tag.Properties_setOnly & scanValue == 0) {
									break;
								}
								if (tag.Properties_resetOnly & scanValue == 0) {
									break;
								}
								tag.Startus = false;
								drawpen.Color = color_draw;
								if (tag.Properties_negated ^ (scanValue > 0)) {
									drawpen.Color = color_simulat;
									tag.Startus = true;
								}
								if (tag.Properties_resetOnly & (scanValue > 0)) {
									tag.Startus = false;
									foreach (Elements vartem in Ladder.VariablePLCLib_element) {
										if (vartem.Name == tag.Name)
											vartem.Startus = tag.Startus;
									}
								}
								if (tag.Properties_setOnly & (scanValue > 0)) {
									tag.Startus = true;
									foreach (Elements vartem in Ladder.VariablePLCLib_element) {
										if (vartem.Name == tag.Name)
											vartem.Startus = tag.Startus;
									}
								}
								break;
							case "C":
								Elements varElement = tag;
								foreach (Elements vartem in Ladder.VariablePLCLib_element) {
									if (vartem.Name == tag.Name) {
										varElement = vartem;
									}
								}
								if (scanValue > 0) {
									drawpen.Color = color_simulat;
									
									if (tag.Properties_resetOnly) {
										if (!sync_startus)
											varElement._ct = varElement.Properties_value1;
										varElement._uQ = false;
										varElement._lQ = true;
										
									}
									if (tag.Properties_setOnly) {
										if (!sync_startus)
											varElement._ct = varElement.Properties_value;
										varElement._lQ = false;
										varElement._uQ = true;
										
									}
								}
								if (!tag.Properties_setOnly & !tag.Properties_resetOnly) {
									if (!sync_startus)
									if (tag.Properties_negated) {
										if (tag.Properties_auto_clear) {
											varElement.countDown_loop();
										} else {
											varElement.countDown();
										}
									} else {
										if (tag.Properties_auto_clear) {
											varElement.countUp_loop();
										} else {
											varElement.countUp();
										}
									}
									stringSize = g.MeasureString(tag._ct.ToString(), drawFont);
									strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + size * 0.8));
									g.DrawString(varElement._ct.ToString(), drawFont, drawBrush, strPoint.X, strPoint.Y);
								}
								break;
						}
					}
					g.DrawLine(drawpen, drawPoint.X, drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 0.25)), drawPoint.Y + size / 2);
					g.DrawLine(drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 1)), drawPoint.Y + size / 2);
					if (tag.Name.Substring(0, 1) == "R" || tag.Name.Substring(0, 1) == "Y")
					if (tag.Startus & simulation_startus || tag.Select_tag) {
						drawpen.Color = color_simulat;
					} else {
						drawpen.Color = color_draw;
					}
					recf = new RectangleF((float)(drawPoint.X + (size * 0.25)), (float)(drawPoint.Y + (size * 0.25)), (float)(size * 0.5), (float)(size * 0.5));
					if (tag.Name.Substring(0, 1) == "Y")
						g.DrawEllipse(drawpen, recf);
					if (tag.Name.Substring(0, 1) == "R" || tag.Name.Substring(0, 1) == "C")
						g.DrawRectangle(drawpen, recf.X, recf.Y, recf.Width, recf.Height);
					
					if (tag.Properties_negated & tag.Name.Substring(0, 1) != "C")
						g.DrawLine(drawpen, (float)(drawPoint.X + (size * 0.4)), (float)(drawPoint.Y + size * 0.7), (float)(drawPoint.X + (size * 0.6)), (float)(drawPoint.Y + size * 0.3));
					
					stringSize = g.MeasureString("_", drawFont_Symbol);
					strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + (size - stringSize.Height) / 2));
					
					if (tag.Properties_setOnly)
						g.DrawString("S", drawFont_Symbol, drawBrush, strPoint.X, strPoint.Y);
					if (tag.Properties_resetOnly)
						g.DrawString("R", drawFont_Symbol, drawBrush, strPoint.X, strPoint.Y);
					if (tag.Name.Substring(0, 1) == "C" & !tag.Properties_setOnly & !tag.Properties_resetOnly) {
						string temp_Count_type = "CTU";
						if (tag.Properties_negated)
							temp_Count_type = "CTD";
						if (tag.Properties_auto_clear)
							temp_Count_type += "a";
						stringSize = g.MeasureString(temp_Count_type, drawFont);
						strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + (size - stringSize.Height) * 0.35));
						g.DrawString(temp_Count_type, drawFont, drawBrush, strPoint.X, strPoint.Y);
						
						temp_Count_type = string.Format("{0}:{1}", tag.Properties_value, tag.Properties_value1);
						stringSize = g.MeasureString(temp_Count_type, drawFont);
						strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + size * 0.5));
						g.DrawString(temp_Count_type, drawFont, drawBrush, strPoint.X, strPoint.Y);
						
					}
					break;
				case TypeTag.SHIFT_REGISTERS:
				case TypeTag.SHIFT_VARIABLE:
				case TypeTag.SHIFT_REG_RESET:
				case TypeTag.SHIFT_REG_INBIT:
				case TypeTag.SHIFT_LEFT:
				case TypeTag.SHIFT_RIGHT:
					if (tag.Select_tag)
						drawpen.Color = color_draw_select;
					Elements vartemp_SHIFT_REGISTERS = null;
					if (simulation_startus) {
						foreach (Elements _vartemp in Ladder.VariablePLCLib_element) {
							if (_vartemp.Name == tag.Name) {
								vartemp_SHIFT_REGISTERS = _vartemp;
								break;
							}
						}
						if (vartemp_SHIFT_REGISTERS == null) {
//							recf = new RectangleF((float)(drawPoint.X + (size * 0.25)), (float)(drawPoint.Y + (size * 0.25)), (float)(size * 0.5), (float)(size * 0.5));
//							g.DrawRectangle(drawpen, recf.X, recf.Y, recf.Width, recf.Height);
//							g.DrawLine(drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 1)), drawPoint.Y + size / 2);
							drawBrush.Color = Color.Red;
							strVar = "Error! No Define?";
							stringSize = g.MeasureString(strVar, drawFont_Symbol);
							strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + (size - stringSize.Height) * 0.35));
							g.DrawString(strVar, drawFont_Symbol, drawBrush, strPoint.X, strPoint.Y);
							
							
							strPoint = new Point((int)(drawPoint.X), (int)(drawPoint.Y));
							DrawIcon(size, g, SystemIcons.Warning, strPoint);
							
							return;
							
						}
						switch (tag.Type) {
							case TypeTag.SHIFT_REGISTERS:
								if (scanValue > 0)
									vartemp_SHIFT_REGISTERS.Properties_value = Convert.ToInt32(tag.Properties, 16);
								break;
							case TypeTag.SHIFT_REG_RESET:
								vartemp_SHIFT_REGISTERS.shift_reset();
								break;
							case TypeTag.SHIFT_REG_INBIT:
								vartemp_SHIFT_REGISTERS.shiftinputBit();
								break;
							case TypeTag.SHIFT_RIGHT:
								vartemp_SHIFT_REGISTERS.shiftRight();
								break;
							case TypeTag.SHIFT_LEFT:
								vartemp_SHIFT_REGISTERS.shiftLeft();
								break;
							case TypeTag.SHIFT_VARIABLE:
								if (vartemp_SHIFT_REGISTERS.shift_reg()) {
									for (int i = int.Parse(tag.Properties); i > 0; --i) {
										string reg1_name = string.Format("{0}{1}", tag.Name, i);
										string reg0_name = string.Format("{0}{1}", tag.Name, i - 1);
										Elements reg1 = Ladder.GetVariablePLCLib_element(reg1_name);
										Elements reg0 = Ladder.GetVariablePLCLib_element(reg0_name);
										reg1.Properties_value = reg0.Properties_value;
									}
									
								}
								break;
						}
					}
					string strProperties = "";
//					if (simulation_startus)
//						strProperties = Convert.ToString(vartemp_SHIFT_REGISTERS.Properties_value, 16).ToUpper();
//
					if (scanValue > 0) {
						tag.Startus = true;
					} else {
						tag.Startus = false;
					}
					switch (tag.Type) {
						case TypeTag.SHIFT_VARIABLE:
							strVar = "reg[ ]";
							strProperties = string.Format("[0..{0}]", tag.Properties);
							
							break;
						case TypeTag.SHIFT_REGISTERS:
							strVar = "SET";
							strProperties = string.Format("#{0}", tag.Properties);
							
							break;
						case TypeTag.SHIFT_LEFT:
							strVar = "<==";
							
							break;
						case TypeTag.SHIFT_RIGHT:
							strVar = "==>";
							break;
						case TypeTag.SHIFT_REG_RESET:
							strVar = "R";
							break;
						case TypeTag.SHIFT_REG_INBIT:
							strVar = "IN";
							break;
						default:
							
							break;
					}
					
					if (tag.Startus & simulation_startus || tag.Select_tag) {
						drawpen.Color = color_simulat;
					} else {
						drawpen.Color = color_draw;
					}
					
					g.DrawLine(drawpen, drawPoint.X, drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 0.25)), drawPoint.Y + size / 2);
					g.DrawLine(drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 1)), drawPoint.Y + size / 2);
					
					recf = new RectangleF((float)(drawPoint.X + (size * 0.25)), (float)(drawPoint.Y + (size * 0.25)), (float)(size * 0.5), (float)(size * 0.5));
					g.DrawRectangle(drawpen, recf.X, recf.Y, recf.Width, recf.Height);
					g.DrawLine(drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 1)), drawPoint.Y + size / 2);
					
					
					stringSize = g.MeasureString(strVar, drawFont_Symbol);
					strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + (size - stringSize.Height) * 0.35));
					g.DrawString(strVar, drawFont_Symbol, drawBrush, strPoint.X, strPoint.Y);
					
					stringSize = g.MeasureString(strProperties, drawFont);
					strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + size * 0.8));
					g.DrawString(strProperties, drawFont, drawBrush, strPoint.X, strPoint.Y);
					
					if (vartemp_SHIFT_REGISTERS == null)
						return;
					
					strVar = Convert.ToString(vartemp_SHIFT_REGISTERS.Properties_value, 16).ToUpper();
					stringSize = g.MeasureString(strVar, drawFont);
					strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + size * 0.5));
					g.DrawString(strVar, drawFont, drawBrush, strPoint.X, strPoint.Y);
					
					
					break;
				case TypeTag.TON:
				case TypeTag.TOF:
				case TypeTag.TPC:
					if (simulation_startus & !sync_startus) {
						if (tag.Type == TypeTag.TON) {
							if (scanValue == 0) {
								tag.timerState = 0;
								tag.Startus = false;
							} else {
								if (tag.timerState == 0) {
									tag.timerState = simulationTime;
									scanValue = 0;
								} else {
									if (simulationTime > (tag.timerState + (ulong)tag.Properties_value)) {	// Timer has finished
										//scanValue = 1;								// Result = 'finished' (1)
										tag.Startus = true;
									} else {											// Timer has not finished
										scanValue = 0;								// Result = 'not finished' (0)
										tag.Startus = false;
									}
								}
							}
						}
						if (tag.Type == TypeTag.TOF) {
							if (scanValue == 0) {
								if (tag.timerState == 0) {
									tag.timerState = simulationTime;
									scanValue = 1;
								} else {
									if (simulationTime > (tag.timerState + (ulong)tag.Properties_value)) {	// Timer has finished
										//scanValue = 0;								// Result = 'finished' (1)
										tag.Startus = false;
									} else {											// Timer has not finished
										scanValue = 1;								// Result = 'not finished' (0)
										tag.Startus = true;
									}
								}
							} else {
								tag.timerState = 0;
								tag.Startus = true;
							}
						}
						if (tag.Type == TypeTag.TPC) {
							if (scanValue == 0) {									// Enable input is off (scanValue = 0)
								tag.timerState_ = 0;									// Ready to start LOW pulse period when enabled
								tag.timerState = 1;
								tag.Startus = false;
							} else {													// Enabled
								if (tag.timerState_ == 0) {								// Low pulse Active
									if (tag.timerState == 1) {							// LOW pulse period starting
										tag.timerState = simulationTime;						// Set timerState to current time in milliseconds
									} else if (simulationTime > (tag.timerState + (ulong)tag.Properties_value)) {	// Low pulse period has finished
										tag.timerState = 0;
										tag.timerState_ = 1;							// Ready to start HIGH pulse period
									}								// Result = 'Pulse LOW' (0)
									tag.Startus = false;
								}
								if (tag.timerState == 0) {								// High pulse Active
									if (tag.timerState_ == 1) {							// HIGH pulse period starting
										tag.timerState_ = simulationTime;						// Set timerState to current time in milliseconds
									} else if (simulationTime > (tag.timerState_ + (ulong)tag.Properties_value1)) {	// High pulse has finished
										tag.timerState_ = 0;
										tag.timerState = 1;							// Ready to start LOW pulse period
									}
									scanValue = 1;									// Result = 'Pulse HIGH' (1)
									tag.Startus = true;
								}
							}
						}
					}
					g.DrawLine(drawpen, drawPoint.X, drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 0.25)), drawPoint.Y + size / 2);
					g.DrawLine(drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 1)), drawPoint.Y + size / 2);
					if (tag.Select_tag)
						drawpen = drawPen_select;
					DrawBaseContrac(g, 0, tag.Properties_negated, drawPoint, size, drawpen, tag.Startus);
					strSymbole = "T";
					if (tag.Type == TypeTag.TOF)
						strSymbole = @"T";
					if (tag.Type == TypeTag.TON)
						strSymbole = @"T";
					if (tag.Type == TypeTag.TPC)
						strSymbole = @"T";
					stringSize = g.MeasureString(strSymbole, drawFont_Symbol);
					strPoint = new Point((int)(drawPoint.X + (size) / 2), (int)(drawPoint.Y + (size - stringSize.Height) / 2));
					g.DrawString(strSymbole, drawFont_Symbol, drawBrush, strPoint.X, strPoint.Y);
					if (tag.Type == TypeTag.TOF)
						strSymbole = @"Delay Off";
					if (tag.Type == TypeTag.TON)
						strSymbole = @"Delay On";
					if (tag.Type == TypeTag.TPC)
						strSymbole = @"Pluse";
					stringSize = g.MeasureString(strSymbole, drawFont);
					strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + (size - stringSize.Height) * 0.75));
					g.DrawString(strSymbole, drawFont, drawBrush, strPoint.X, strPoint.Y);
					
					string strValue = "";
					double floatDelay;
					if (tag.Type != TypeTag.TPC) {
						if (tag.Type == TypeTag.TON) {
							if (tag.Properties_value >= 1000) {
								if (simulation_startus & tag.timerState > 0 & !tag.Startus) {
									floatDelay = (double)(tag.timerState + (ulong)tag.Properties_value - simulationTime) / 1000;
								} else {
									floatDelay = (double)tag.Properties_value / 1000;
								}
								
								strValue = floatDelay.ToString("0.00") + " s";
							} else {
								if (simulation_startus & tag.timerState > 0 & !tag.Startus) {
									floatDelay = (double)(tag.timerState + (ulong)tag.Properties_value - simulationTime);
								} else {
									floatDelay = tag.Properties_value;
								}
								strValue = floatDelay + " ms";
							}
						}
						if (tag.Type == TypeTag.TOF) {
							if (tag.Properties_value >= 1000) {
								if (simulation_startus & tag.timerState > 0 & tag.Startus) {
									floatDelay = (double)(tag.timerState + (ulong)tag.Properties_value - simulationTime) / 1000;
								} else {
									floatDelay = (double)tag.Properties_value / 1000;
								}
								
								strValue = floatDelay.ToString("0.00") + " s";
							} else {
								if (simulation_startus & tag.timerState > 0 & tag.Startus) {
									floatDelay = (double)(tag.timerState + (ulong)tag.Properties_value - simulationTime);
								} else {
									floatDelay = tag.Properties_value;
								}
								strValue = floatDelay + " ms";
							}
						}
						stringSize = g.MeasureString(strValue, drawFont);
						strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + size * 0.8));
						g.DrawString(strValue, drawFont, drawBrush, strPoint.X, strPoint.Y);
					} else {
						if (tag.Properties_value >= 1000) {
							floatDelay = (double)tag.Properties_value / 1000;
							strValue = floatDelay.ToString("0.000") + " s,";
						} else {
							floatDelay = tag.Properties_value;
							strValue = floatDelay + " ms,";
						}
						if (tag.Properties_value1 >= 1000) {
							floatDelay = (double)tag.Properties_value1 / 1000;
							strValue += floatDelay.ToString("0.000") + " s";
						} else {
							floatDelay = tag.Properties_value1;
							strValue += floatDelay + " ms";
						}
						stringSize = g.MeasureString(strValue, drawFont);
						strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + size * 0.8));
						g.DrawString(strValue, drawFont, drawBrush, strPoint.X, strPoint.Y);
					}
					
					break;
				case TypeTag.FCP:
					g.DrawLine(drawpen, drawPoint.X, drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 0.25)), drawPoint.Y + size / 2);
					g.DrawLine(drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 1)), drawPoint.Y + size / 2);
					if (tag.Select_tag)
						drawpen = drawPen_select;
					if (simulation_startus) {
						string[] strPara = tag.Properties.Split(' ');
						int compareValue;
						if (strPara.Length > 1) {
							if (int.TryParse(strPara[1], out compareValue)) {
								compareValue = int.Parse(strPara[1]);
							} else {
								if (strPara[1].Substring(0, 1) == "'") {
									char[] ch = strPara[1].ToCharArray();
									compareValue = ch[1];
								} else {
									foreach (Elements temptag in Ladder.VariablePLCLib_element) {
										if (temptag.Name == strPara[1]) {
											compareValue = temptag.Properties_value;
											break;
										}
									}
								}
							}
							Elements tempPara1;
							tempPara1 = null;
							foreach (Elements temptag in Ladder.VariablePLCLib_element) {
								if (temptag.Name == tag.Name) {
									tempPara1 = temptag;
								}
							}
							if (tempPara1 == null)
								tempPara1 = new Elements(TypeTag.MOVE, "No ref!", null);
							int tempPara1_value = 0;
							switch (tempPara1.Name.Substring(0, 1)) {
								case "C":
									tempPara1_value = tempPara1._ct;
									break;
								default:
									tempPara1_value = tempPara1.Properties_value;
									break;
							}
							
							switch (strPara[0]) {
								case "==":
									tag.Startus = tempPara1_value == compareValue;
									break;
								case "!=":
									tag.Startus = tempPara1_value != compareValue;
									break;
								case ">":
									tag.Startus = tempPara1_value > compareValue;
									break;
								case ">=":
									tag.Startus = tempPara1_value >= compareValue;
									break;
								case "<":
									tag.Startus = tempPara1_value < compareValue;
									break;
								case "<=":
									tag.Startus = tempPara1_value <= compareValue;
									break;
							}
						}
					}
					DrawBaseContrac(g, 0, tag.Properties_negated, drawPoint, size, drawpen, tag.Startus);
					string strTemp = tag.Properties;
					stringSize = g.MeasureString(strTemp, drawFont);
					strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + (size - stringSize.Height) * 0.7));
					g.DrawString(strTemp, drawFont, drawBrush, strPoint.X, strPoint.Y);
					
					break;
				case TypeTag.OSR:
				case TypeTag.OSF:
				case TypeTag.UART_RECV:
				case TypeTag.UART_SEND:
					if (simulation_startus) {
						if (tag.Type == TypeTag.OSR) {
							if (scanValue != StratusInt(tag.Startus)) {	// Rising or falling edge detected
								if (scanValue == 1) {		// Rising edge detected
									tag.Startus = true;				// Pulse input tracker = 1
								} else {						// Falling edge detectede
									tag.Startus = false;				// Pulse input tracker = 0
								}
							} else {							// No change detected
								scanValue = 0;					// Set scanValue detect values to zero
							}
						}
						if (tag.Type == TypeTag.OSF) {
							if (scanValue != StratusInt(tag.Startus)) {	// Rising or falling edge detected
								if (scanValue == 1) {		// Rising edge detected
									tag.Startus = true;				// Pulse input tracker = 1
									scanValue = 0;
								} else {						// Falling edge detectede
									tag.Startus = false;				// Pulse input tracker = 0
									scanValue = 1;
								}
							} else {							// No change detected
								scanValue = 0;					// Set scanValue detect values to zero
							}
							
						}
						if (tag.Type == TypeTag.UART_RECV) {
							scanValue = tag.Startus ? 1 : 0;
							
						}
						if (tag.Type == TypeTag.UART_SEND) {
							if (scanValue != StratusInt(tag.Startus)) {	// Rising or falling edge detected
								if (scanValue == 1) {					// Rising edge detected
									tag.Startus = true;					// Pulse input tracker = 1
								} else {								// Falling edge detectede
									tag.Startus = false;				// Pulse input tracker = 0
								}
							} else {									// No change detected
								scanValue = 0;							// Set scanValue detect values to zero
							}
							if (scanValue == 1) {
								//tag.Startus = true;
								//string value_Char = "";
								
								foreach (Elements varElement in Ladder.VariablePLCLib_element) {
									if (varElement.Name == tag.Name) {
										//value_Char =  varElement.Properties_value.ToString();
										
										(Application.OpenForms["MainForm"] as MainForm).SetComText_simulation(Convert.ToChar(varElement.Properties_value).ToString());
										
										break;
									}
								}
							} else {
								//tag.Startus = false;
							}
						}
						
						if (tag.Startus) {
							drawpen.Color = Color.Red;
						}
					}
					if (tag.Type == TypeTag.OSR) {
						Point[] points = {
							new Point((int)(drawPoint.X + (size * 0.25)), (int)(drawPoint.Y + size * 0.5)),
							new Point((int)(drawPoint.X + (size * 0.5)), (int)(drawPoint.Y + size * 0.25)),
							new Point((int)(drawPoint.X + (size * 0.75)), (int)(drawPoint.Y + size * 0.25)),
							new Point((int)(drawPoint.X + (size * 0.75)), (int)(drawPoint.Y + size * 0.5))
						};
						g.DrawLines(drawpen, points);
					}
					if (tag.Type == TypeTag.OSF) {
						Point[] points = {
							new Point((int)(drawPoint.X + (size * 0.25)), (int)(drawPoint.Y + size * 0.5)),
							new Point((int)(drawPoint.X + (size * 0.5)), (int)(drawPoint.Y + size * 0.75)),
							new Point((int)(drawPoint.X + (size * 0.75)), (int)(drawPoint.Y + size * 0.75)),
							new Point((int)(drawPoint.X + (size * 0.75)), (int)(drawPoint.Y + size * 0.5))
						};
						g.DrawLines(drawpen, points);
					}
					if (tag.Type == TypeTag.UART_RECV) {
						Point[] points = {
							new Point((int)(drawPoint.X + (size * 0.35)), (int)(drawPoint.Y + size * 0.5)),
							new Point((int)(drawPoint.X + (size * 0.65)), (int)(drawPoint.Y + size * 0.3)),
							new Point((int)(drawPoint.X + (size * 0.65)), (int)(drawPoint.Y + size * 0.7)),
							new Point((int)(drawPoint.X + (size * 0.35)), (int)(drawPoint.Y + size * 0.5))
						};
						g.DrawLines(drawpen, points);
						strSymbole = @"UART_RECV";
						stringSize = g.MeasureString(strSymbole, drawFont);
						strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + (size - stringSize.Height) * 0.95));
						g.DrawString(strSymbole, drawFont, drawBrush, strPoint.X, strPoint.Y);
						
					}
					if (tag.Type == TypeTag.UART_SEND) {
						Point[] points = {
							new Point((int)(drawPoint.X + (size * 0.65)), (int)(drawPoint.Y + size * 0.5)),
							new Point((int)(drawPoint.X + (size * 0.35)), (int)(drawPoint.Y + size * 0.7)),
							new Point((int)(drawPoint.X + (size * 0.35)), (int)(drawPoint.Y + size * 0.3)),
							new Point((int)(drawPoint.X + (size * 0.65)), (int)(drawPoint.Y + size * 0.5))
						};
						g.DrawLines(drawpen, points);
						strSymbole = @"UART_SEND";
						stringSize = g.MeasureString(strSymbole, drawFont);
						strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + (size - stringSize.Height) * 0.95));
						g.DrawString(strSymbole, drawFont, drawBrush, strPoint.X, strPoint.Y);
						
					}
					g.DrawLine(drawpen, drawPoint.X, drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 0.25)), drawPoint.Y + size / 2);
					g.DrawLine(drawpen, (float)(drawPoint.X + (size * 0.75)), drawPoint.Y + size / 2, (float)(drawPoint.X + (size * 1)), drawPoint.Y + size / 2);
					
					break;
			}
			if (simulation_startus) {
				foreach (Elements sim_tag in Ladder.VariablePLCLib_element) {
					if (sim_tag.Type == TypeTag.ADC)
						continue;
					Ladder.program.Update_Common_Element(sim_tag);
				}
			}
		}
		static int StratusInt(bool value)
		{
			return value ? 1 : 0;
		}
		public static void DrawtagString(Elements tag, Graphics g, Point drawPoint, int size, int inPreview)
		{
			//SizeF stringSize = new SizeF();
			
			Font strFont;
			if (inPreview > 0) {
				strFont = drawFont_Symbol;
			} else {
				strFont = drawFont;
			}
			drawBrush.Color = color_string_draw;
			SizeF stringSize = g.MeasureString(tag.Name, strFont);
			var strPoint = new Point((int)(drawPoint.X + (size - stringSize.Width) / 2), (int)(drawPoint.Y + size * 0.25 - stringSize.Height));
			g.DrawString(tag.Name, strFont, drawBrush, strPoint);
			
		}
		
		public static void DrawIcon(int size, Graphics g, Icon _icon, Point drawPoint)
		{
			//Icon icon = _icon;
			g.DrawIcon(_icon, drawPoint.X + (size - _icon.Width) / 2, drawPoint.Y + size / 2);
			
		}
		
	}
	
	
	//########################################################################//
	
}
