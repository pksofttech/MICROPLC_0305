/*
 * Created by SharpDevelop.
 * User: PK_SofttecH
 * Date: 5/7/2015
 * Time: 4:17 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of Ladder.
	/// </summary>
	/// 
	public enum commands
	{
		NULL,
		INSERT_PREVIEW,
		INSERT_TAG,
		DELECT_TAG}

	;
	public enum activePositions
	{
		Null,
		Left,
		Top,
		Buttom,
		Right,
		InRung,
		On_Tag}
	;

	static public class Ladder
	{
		static readonly List<Elements> element_tags = new List<Elements>();
		public static List<Elements> IOelement_tags = new List<Elements>();
		public static List<Elements> VariablePLCLib_element = new List<Elements>();
		public static string tempDirectory = Path.Combine(Environment.GetEnvironmentVariable("temp"), "plclib");
		static public int element_Tags_Add(Elements tag)
		{
			element_tags.Add(tag);
			return 1;
		}

		public static bool saveStratus;
		public static ProgramLadder program = new ProgramLadder();
		// disable once ConvertToAutoProperty
		public static bool SaveStratus {
			get {
				return saveStratus;
			}
			set {
				saveStratus = value;
			}
		}

		public static List<Elements> Element_tags {
			get {
				return element_tags;
			}
		}
		public static string strCommunicationName = "";
		public static bool Input_Active_Mode = true;
		public static bool Output_Active_Mode = true;
		public static int cycle_loop_value = 10;
		static public int element_Tags_Remove(Elements tag)
		{
			if (element_tags.IndexOf(tag) == -1)
				return -1;
			element_tags.Remove(tag);
			return element_tags.Count;
		}
		static int? GetIndex(string text, string substr)
		{
			int index = text.IndexOf(substr, StringComparison.Ordinal);
			return index >= 0 ? (int?)index : null;
		}
		static string GetFirstLine(string text)
		{
			int? newlinePos = GetIndex(text, "\r") ?? GetIndex(text, "\n");

			if (newlinePos.HasValue) {
				return text.Substring(0, newlinePos.Value);
			}
			return text;
		}
		
		static string GetCutFirstLine(string text)
		{
			int? newlinePos = GetIndex(text, "\r") ?? GetIndex(text, "\n");

			if (newlinePos.HasValue) {
				return text.Substring(newlinePos.Value + 1);
			}
			return text;
		}
		
		public static int strIO_List_To_elements(string strIO_List)
		{
			string strTemps	= GetFirstLine(strIO_List).Trim();
			strIO_List = GetCutFirstLine(strIO_List);
			string[] io_lists = strIO_List.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
			if (strTemps != "IO LIST")
				return -1;
			element_tags.Clear();
			foreach (string s in io_lists) {
				string temp_io_lists = s.Trim();
				if (temp_io_lists == "END")
					break;
				string[] strIo_List = temp_io_lists.Split(' ');
				if (strIo_List.Length == 3) {
					Elements Io_tag = new Elements(TypeTag.Null, strIo_List[0], null);
					//string number = "";
					string value = strIo_List[2].Trim();
					Io_tag.IO_Port = "";
					
					//	bool result = Int32.TryParse(value.Substring(1), out number);
					//	if (result) {
					switch (value.Substring(0, 1)) {
						case "X":
						case "Y":
						case "D":
							Io_tag.IO_Port = value;
							break;
						case "A":
							Io_tag.IO_Port = value;
							Io_tag.Properties = string.Format("A{0}", value);
							break;
					}
						       
					//}
					switch (strIo_List[0].Substring(0, 1)) {
						case "Y":
							Io_tag.Type = TypeTag.COIL;
							break;
						case "X":
							Io_tag.Type = TypeTag.CONTACTS;
							break;	
						case "A":
							Io_tag.Type = TypeTag.ADC;
							break;	
					}
					IOelement_tags.Add(Io_tag);
				}				
			}
			return 0;
		}
		
		public static bool setfindRef;
		public static string Hardware_name;
		public static Rung strLadderToRung(string strladder)
		{
			string strTemps	= GetFirstLine(strladder).Trim();
			strladder	=	GetCutFirstLine(strladder);
			if (strTemps == "RUNG") {				
				var tempRung = new Rung();	
				while (strladder != "") {
					Elements temp_element	= strLadderToTag(ref strladder, tempRung.Rung_elements);
					if (temp_element != null)
						tempRung.Rung_elements.AddTag(temp_element);
					if (strladder.Length < 1)
						return tempRung;
					if (strladder.Substring(0, 3) == "END")
						return tempRung;
				}
			}					
			return null;
		}
		static public Elements getVariablePLCLib_element(string name)
		{
			foreach (Elements shift_tag in VariablePLCLib_element) {
				if (shift_tag.Name == name)
					return shift_tag;
			}						
			return null;
		}
			
		static  Elements strLadderToTag(ref string strladder, Elements parent)
		{
			string strTemps	= GetFirstLine(strladder).Trim();
			strladder	=	GetCutFirstLine(strladder).Trim();
			string[] strTemp = strTemps.Split(' ');
			string strPopertry = "";
			for (int i = 2; i < strTemp.Length; i++) {
				strPopertry += (strTemp[i] + ' ');
			}                   
			TypeTag tempType	=	TypeTag.Null;
			
			if (strTemp[0] == "SERIES") {
				tempType	=	TypeTag.SERIES;
				var tempSeries = new Elements(tempType, "SERIES", parent);
				while (true) {
					var tempSeries_tag = strLadderToTag(ref strladder, tempSeries);
					if (tempSeries_tag != null)
						tempSeries.AddTag(tempSeries_tag);
					if (strladder.Substring(0, 3) == "END") {
						strladder = GetCutFirstLine(strladder).Trim();
						return tempSeries;
					}
					
				}				
			}			
			if (strTemp[0] == "PARALLEL") {
				tempType	=	TypeTag.PARALLEL;	
				var tempParallel = new Elements(tempType, "PARALLEL", parent);
				while (true) {
					var tempParallel_tag = strLadderToTag(ref strladder, tempParallel);
					if (tempParallel_tag != null)
						tempParallel.AddTag(tempParallel_tag);
					//tempParallel.AddTag(strLadderToTag(ref strladder, tempParallel));
					if (strladder.Substring(0, 3) == "END") {
						strladder = GetCutFirstLine(strladder).Trim();
						return tempParallel;
					}
				}			
			}				
			
			switch (strTemp[0]) {
				case "CONTACTS":
					Elements tag_Contrac	= new Elements(TypeTag.CONTACTS, strTemp[1], strPopertry, parent);
					if (strTemp.Length > 2)
						tag_Contrac.Properties_negated |= strTemp[2] == "1";
					if (strTemp.Length > 3)
						tag_Contrac.Properties_setOnly |= strTemp[3] == "1";
					if (strTemp.Length > 4)
						tag_Contrac.Properties_resetOnly |= strTemp[4] == "1";					
					if (strTemp.Length > 5)
						tag_Contrac.Properties_value = int.Parse(strTemp[5]);
					if (strTemp.Length > 6)
						tag_Contrac.Properties_value1 = int.Parse(strTemp[6]);
		
					foreach (Elements tag in element_tags) {
						if (tag.Name == tag_Contrac.Name)
						if (tag.Name.Substring(0, 1) == "X")
							tag_Contrac.IO_Port = tag.IO_Port;
					}
					return tag_Contrac;
				case "COMMENT":									
					string commant_text = strTemps.Substring(strTemp[0].Length + 1).Replace("\\r\\n", Environment.NewLine);
					//Elements tag_Comment	= new Elements(TypeTag.COMMENT, strTemp[1], strPopertry.Replace("/cnc/", Environment.NewLine).Replace('^', ' '), parent);
					var tag_Comment	= new Elements(TypeTag.COMMENT, "COMMENT", commant_text, parent);		
					return tag_Comment;
				case "TOF":
					Elements tag_Tof	= new Elements(TypeTag.TOF, strTemp[1], strPopertry, parent);
					if (strTemp.Length > 2)
						tag_Tof.Properties_value = int.Parse(strTemp[2]) / 1000;	
					return tag_Tof;
				case "TON":
					Elements tag_Ton	= new Elements(TypeTag.TON, strTemp[1], strPopertry, parent);
					if (strTemp.Length > 2)
						tag_Ton.Properties_value = int.Parse(strTemp[2]) / 1000;	
					return tag_Ton;	
				case "TPC":
					Elements tag_Tpc	= new Elements(TypeTag.TPC, strTemp[1], strPopertry, parent);
					if (strTemp.Length > 2) {
						tag_Tpc.Properties_value = int.Parse(strTemp[2]);	
						tag_Tpc.Properties_value1 = int.Parse(strTemp[3]);	
					}						
					return tag_Tpc;	
				case "FCP":
					Elements tag_Fcp	= new Elements(TypeTag.FCP, strTemp[1], strPopertry, parent);
					return tag_Fcp;
					
				case "EQU":
					var tag_EQU	= new Elements(TypeTag.FCP, strTemp[1], string.Format("== {0}", strTemp[2]), parent);
					return tag_EQU;
				case "NEQ":
					var tag_NEQ	= new Elements(TypeTag.FCP, strTemp[1], string.Format("!= {0}", strTemp[2]), parent);
					return tag_NEQ;	
				case "GRT":	
					var tag_GRT	= new Elements(TypeTag.FCP, strTemp[1], string.Format("> {0}", strTemp[2]), parent);
					return tag_GRT;
				case "GEQ":	
					var tag_GEQ	= new Elements(TypeTag.FCP, strTemp[1], string.Format(">= {0}", strTemp[2]), parent);
					return tag_GEQ;
				case "LES":	
					var tag_LES	= new Elements(TypeTag.FCP, strTemp[1], string.Format("< {0}", strTemp[2]), parent);
					return tag_LES;
				case "LEQ":	
					var tag_LEQ	= new Elements(TypeTag.FCP, strTemp[1], string.Format("<= {0}", strTemp[2]), parent);
					return tag_LEQ;
					
				case "OSR":
					var tag_Osr	= new Elements(TypeTag.OSR, "OSR", strPopertry, parent);
					return tag_Osr;
				
				case "OSF":
					Elements tag_Osf	= new Elements(TypeTag.OSF, "OSF", strPopertry, parent);
					return tag_Osf;
				case "MASTER_RELAY":
					Elements tag_Mc = new Elements(TypeTag.MASTER_RELAY, strTemp[1], strPopertry, parent);
					return tag_Mc;	
					
				case "MOVE":
					Elements tag_Fmv	= new Elements(TypeTag.MOVE, strTemp[1], strPopertry, parent);
					if (strTemp.Length > 2)
						tag_Fmv.Properties = strTemp[2];
					return tag_Fmv;
				case "ADD":
					Elements tag_Add	= new Elements(TypeTag.ADD, strTemp[1], strPopertry, parent);
					tag_Add.Properties = strPopertry;
					return tag_Add;
				case "SUB":
					Elements tag_Sub	= new Elements(TypeTag.SUB, strTemp[1], strPopertry, parent);
					tag_Sub.Properties = strPopertry;
					return tag_Sub;
				case "MUL":
					Elements tag_Mup	= new Elements(TypeTag.MUL, strTemp[1], strPopertry, parent);
					tag_Mup.Properties = strPopertry;
					return tag_Mup;
				case "DIV":
					Elements tag_Div	= new Elements(TypeTag.DIV, strTemp[1], strPopertry, parent);
					
					tag_Div.Properties = strPopertry;
					return tag_Div;
				case "MOD":
					Elements tag_Mod	= new Elements(TypeTag.MOD, strTemp[1], strPopertry, parent);
					
					tag_Mod.Properties = strPopertry;
					return tag_Mod;
				case "ADC":
				case "READ_ADC":
					Elements tag_Adc	= new Elements(TypeTag.ADC, strTemp[1], strPopertry, parent);
					//if (strTemp.Length > 2)
						//tag_Adc.Properties = strTemp[2];
					foreach (Elements tag in element_tags) {
						if (tag.Name == tag_Adc.Name)
						if (tag.Name.Substring(0, 1) == "A") {
							tag_Adc.IO_Port = tag.IO_Port;
							tag_Adc.Properties = tag.Properties;
						}		
					}
					return tag_Adc;	
				case "SHIFT_REG":
					Elements tag_Shift_Reg	= new Elements(TypeTag.SHIFT_REGISTERS, strTemp[1], strPopertry, parent);
					if (strTemp.Length > 2)
						tag_Shift_Reg.Properties = strTemp[2];
					return tag_Shift_Reg;
				case "SHIFT_RES":
					Elements tag_Shift_Res	= new Elements(TypeTag.SHIFT_REG_RESET, strTemp[1], strPopertry, parent);
					return tag_Shift_Res;
				case "SHIFT_INBIT":
					Elements tag_Shift_Inbit	= new Elements(TypeTag.SHIFT_REG_INBIT, strTemp[1], strPopertry, parent);
					return tag_Shift_Inbit;
				case "SHIFT_RIGHT":
					Elements tag_Shift_Right	= new Elements(TypeTag.SHIFT_RIGHT, strTemp[1], strPopertry, parent);
					return tag_Shift_Right;
				case "SHIFT_LEFT":
					Elements tag_Shift_Left	= new Elements(TypeTag.SHIFT_LEFT, strTemp[1], strPopertry, parent);
					return tag_Shift_Left;
					
				case "SHIFT_REGISTER":
					var tag_Shift_Variable	= new Elements(TypeTag.SHIFT_VARIABLE, strTemp[1], strPopertry, parent);
					return tag_Shift_Variable;
					
			//*********************** START IMPORT FORM LDMICRO ***************************//
				case "UART_RECV":
					var tag_UART_RECV	= new Elements(TypeTag.UART_RECV, strTemp[1], strPopertry, parent);
					return tag_UART_RECV;
				case "UART_SEND":
					var tag_UART_SEND	= new Elements(TypeTag.UART_SEND, strTemp[1], strPopertry, parent);
					return tag_UART_SEND;
				case "FORMATTED_STRING":
					var tag_FORMATTED_STRING = new Elements(TypeTag.UART_SEND, strTemp[1], strPopertry, parent);
					return tag_FORMATTED_STRING;
				case "SHORT":
					var tag_SHORT	= new Elements(TypeTag.SHORT, TypeTag.SHORT.ToString(), strPopertry, parent);
					return tag_SHORT;
				case "OPEN":
					var tag_OPEN	= new Elements(TypeTag.OPEN,TypeTag.OPEN.ToString(), strPopertry, parent);
					return tag_OPEN;
					
				case "CTD":
					Elements tag_Ctd	= new Elements(TypeTag.FCP, strTemp[1], string.Format(" <= {0}", strTemp[2]), parent);
					return tag_Ctd;	
				case "CTU":
					Elements tag_Ctu	= new Elements(TypeTag.FCP, strTemp[1], string.Format(">= {0}", strTemp[2]), parent);
					return tag_Ctu;	
				case "CTC":
					Elements tag_Ctc	= new Elements(TypeTag.COIL, strTemp[1], strTemp[2], parent);
					tag_Ctc.Properties_auto_clear = true;
					tag_Ctc.Properties_value1 = 0;
					tag_Ctc.Properties_value = int.Parse(strTemp[2]);
					return tag_Ctc;
					
			//*********************** END IMPORT FORM LDMICRO ***************************//			
					
				case "COIL":	
					Elements tag_Coil	= new Elements(TypeTag.COIL, strTemp[1], strPopertry, parent);
					if (strTemp.Length > 2)
						tag_Coil.Properties_negated |= strTemp[2] == "1";
					if (strTemp.Length > 3)
						tag_Coil.Properties_setOnly |= strTemp[3] == "1";
					if (strTemp.Length > 4)
						tag_Coil.Properties_resetOnly |= strTemp[4] == "1";	
					if (strTemp.Length > 5)
						tag_Coil.Properties_auto_clear |= strTemp[5] == "1";						
					if (strTemp.Length > 6)
						tag_Coil.Properties_value = int.Parse(strTemp[6]);
					if (strTemp.Length > 7)
						tag_Coil.Properties_value1 = int.Parse(strTemp[7]);
					
					foreach (Elements tag in element_tags) {
						if (tag.Name == tag_Coil.Name)
						if (tag.Name.Substring(0, 1) == "Y")
							tag_Coil.IO_Port = tag.IO_Port;
					}
					return tag_Coil;	
					
				default:
					var tag_null	= new Elements(TypeTag.Null, strTemp[0], strTemps, parent);
					return tag_null;	
			}							

			//return null;
		}
		//#########################################################################//

		public static void buildVariablePLCLib()
		{
//******************************************			
//VariablePLCLib_element.Clear();
//***************************************************************************	
			bool delVar = true;
			var temp_del = new Elements();
			foreach (Elements ver_temp in Ladder.VariablePLCLib_element) {
				delVar = true;
				foreach (Elements tag in Ladder.Element_tags) {	
					if (ver_temp.Name == tag.Name) {
						delVar = false;
						break;
					}
//					if (tag.Type == TypeTag.SHIFT_VARIABLE) {
//						if (ver_temp.Name.IndexOf(tag.Name, StringComparison.Ordinal) == 0) {
//							int count = 0;
//							int.TryParse(tag.Properties,out count);
//							for (int i = 0; i < count; i++) {
//								if (string.Format("{0}{1}", tag.Name, i) == ver_temp.Name) {
//									delVar = false;
//									break;
//								}
//							}
//							
//						}
//					}
//					foreach (Elements temp_shift_variable in Ladder.Element_tags) {
//						if (temp_shift_variable.Type == TypeTag.SHIFT_VARIABLE) {
//							if (temp_shift_variable.Name.IndexOf(ver_temp.Name, StringComparison.Ordinal) == 0) {
//								delVar = false;
//								break;
//							}								
//						}
//					}
				}			
				
				if (delVar) {
					temp_del.Tags.Add(ver_temp);
				}					
									
			}
			foreach (Elements del_element in temp_del.Tags) {
				Ladder.VariablePLCLib_element.Remove(del_element);
			}
//***************************************************************************

		}
		
		//=============EXPORT+++++++++++++=========================================//
		
		
		public static string GenVariablePLCLib()
		{	
			string strGenIO = "";
			bool addTag = true;
			
			foreach (Elements tag in Element_tags) {				
				switch (tag.Type) {
					case TypeTag.COIL:
					case TypeTag.TOF:
					case TypeTag.TON: 
					case TypeTag.TPC:
						
					case TypeTag.MOVE:	
					case TypeTag.ADD:
					case TypeTag.SUB:
					case TypeTag.MOD:
					case TypeTag.MUL:
					case TypeTag.DIV:
					case TypeTag.UART_RECV:	
					//case TypeTag.UART_SEND:		
					case TypeTag.ADC:	
					case TypeTag.SHIFT_REGISTERS:
					case TypeTag.SHIFT_VARIABLE:
					case TypeTag.OSR:
					case TypeTag.OSF:	
						addTag = true;
						foreach (Elements temptag in VariablePLCLib_element) {
							if ((temptag.Name == tag.Name) & tag.Type != TypeTag.SHIFT_VARIABLE) {
								addTag = false;
								break;
							}
						}
						if (addTag) {
							Elements tempVariable;
							switch (tag.Type) {
								case TypeTag.MOVE:
								case TypeTag.ADD:
								case TypeTag.SUB:
								case TypeTag.MOD:
								case TypeTag.MUL:
								case TypeTag.DIV:
								case TypeTag.UART_RECV:	
									tempVariable = new Elements(TypeTag.MOVE, tag.Name, null);
									tempVariable.Properties_value = 0;
									VariablePLCLib_element.Add(tempVariable);
									break;
								case TypeTag.SHIFT_REGISTERS:
									tempVariable = new Elements(TypeTag.SHIFT_REGISTERS, tag.Name, null);
									tempVariable.Properties_value = 0;
									tempVariable.Properties_value1 = 0;
									VariablePLCLib_element.Add(tempVariable);
									break;
								case TypeTag.SHIFT_VARIABLE:
									int count = 0;
									if (int.TryParse(tag.Properties, out count)) {
										for (int i = 0; i <= count; i++) {
											tempVariable = new Elements(TypeTag.MOVE, tag.Name + i, tag);
											tempVariable.Properties_value = 0;
											tempVariable.Properties_value1 = 0;
											bool addtemp = true;
											foreach (Elements temptag in VariablePLCLib_element) {
												if (temptag.Name == tempVariable.Name)
													addtemp = false;
											}
											if (addtemp)
												VariablePLCLib_element.Add(tempVariable);
										}										
									}									
									break;
								case TypeTag.ADC:
									tempVariable = new Elements(TypeTag.ADC, tag.Name, null);
									tempVariable.Properties_value = 0;
									VariablePLCLib_element.Add(tempVariable);
									break;
								default :
									VariablePLCLib_element.Add(tag);	
									break;
							}							
						}							
						break;
				}
			}
			addTag = true;
			foreach (Elements tag in Element_tags) {
				addTag = true;
				switch (tag.Type) {
					case TypeTag.COIL:
					case TypeTag.CONTACTS:
					case TypeTag.ADC:
					case TypeTag.SHIFT_REGISTERS:
					case TypeTag.SHIFT_VARIABLE:
						foreach (Elements temptag in VariablePLCLib_element) {
							if (temptag.Name == tag.Name) {
								addTag = false;
								break;
							}
						}
						if (addTag) {
							tag.IO_Port = "";
							VariablePLCLib_element.Add(tag);	
						}
						break;
				}		
			}
			
			int tag_no = 0;
			foreach (Elements temptag in VariablePLCLib_element) {
				switch (temptag.Type) {
					case TypeTag.COIL:
						switch (temptag.Name.Substring(0, 1)) {
							case"C":
								strGenIO += string.Format("\t\tCounter {0}({1},{2});\t\t//{3}\n", temptag.Name, temptag.Properties_value, temptag.Properties_value1, temptag.Type);
								break;
							default :
								strGenIO += string.Format("\t\tunsigned int {0};\t\t//{1}\n", temptag.Name, temptag.Type);					
								break;
						}
						break;
					case TypeTag.SHIFT_REGISTERS:						
						strGenIO += string.Format("\t\tShift {0};\t\t//{1}\n", temptag.Name, temptag.Type);
						break;
					case TypeTag.SHIFT_VARIABLE:	
						//string shift_code = temptag.Name + tag_no.ToString("000");
						tag_no += 1;						
						strGenIO += string.Format("\t\tunsigned int {0}_{2};\t\t//Shift Variable {0}\t\t//{1}\n", temptag.Name, temptag.Type, temptag.Properties.Trim());
						break;
					case TypeTag.TOF:
					case TypeTag.TON:
						strGenIO += string.Format("\t\tunsigned long {0};\t\t//{1}\n", temptag.Name, temptag.Type);								
						break;						
					case TypeTag.CONTACTS:	
						strGenIO += string.Format("\t\tunsigned int {0};\t\t//{1}\n", temptag.Name, temptag.Type);								
						break;
					case TypeTag.ADC:	
						strGenIO += string.Format("\t\tunsigned {0};\t\t//{1}\n", temptag.Name, "Analog Input");								
						break;
					case TypeTag.TPC:	
						strGenIO += string.Format("\t\tunsigned long {0};\t\t//{1}\n", temptag.Name, temptag.Type);								
						strGenIO += string.Format("\t\tunsigned long {0}1;\t\t//{1}\n", temptag.Name, temptag.Type);								
						break;
					case TypeTag.OSR:		
						temptag.Name = "OSR_" + tag_no.ToString("000");
						tag_no += 1;
						strGenIO += string.Format("\t\tunsigned int {0};\t\t//{1}\n", temptag.Name, temptag.Type);								
						break;
					case TypeTag.OSF:
						temptag.Name = "OSF_" + tag_no.ToString("000");		
						tag_no += 1;						
						strGenIO += string.Format("\t\tunsigned int {0};\t\t//{1}\n", temptag.Name, temptag.Type);								
						break;
					case TypeTag.MOVE:	
						if (temptag.Parent != null) {
							if (temptag.Parent.Type == TypeTag.SHIFT_VARIABLE) {
								strGenIO += string.Format("\t\tint {0};\t\t//{1}\n", temptag.Name, "Shift Variables int16");														
							}
						} else {
							strGenIO += string.Format("\t\tint {0};\t\t//{1}\n", temptag.Name, "Variable int16");										
						}
						
						break;
					default :
						strGenIO += string.Format("\t\t//Unount Variable{0};\t\t//{1}\n", temptag.Type, temptag.Type);					
						break;
				}
			}
			
			return strGenIO;
		}
		static int stack_Lavel, stack_parallel;
		static int teb_Lavel;
		static public string function_code;
		public static String GenPLCLib_Code(ProgramLadder program)
		{
			string strGenCode;
			function_code = "//**************** FUNCTION CODE *******************//";
			strGenCode = string.Format("//GENALATOR CODE FOR PLCLibs By MICROPLC Pk Softtech\n");
			strGenCode += string.Format("\tif (millis() < (scanTimeValue + {0})) return;\n\tscanTimeValue = millis();\n\tMasterscanValue = 1;\n", cycle_loop_value);
			
			strGenCode += "\tscanIO();\n";
			
			string strGencodeRung = "";
			
			foreach (Rung rung in program.rungs) {
				stack_Lavel = 0;
				teb_Lavel = 0;
				stack_parallel = 0;
				strGencodeRung = string.Format("\n\n//Start Rung ID = {0}\n\n", rung.Id_rung.ToString("00"));
				if (Find_Master_Relay(rung.Rung_elements)) {
					strGencodeRung += string.Format("scanValue = 1;\t\t //Start Rung Set Troken 1 Find MasterRelay In Rung");	
				} else {
					strGencodeRung += string.Format("scanValue = MasterscanValue;\t\t //Start Rung Set Troken MasterscanValue");	
				}
				stack_Lavel++;
				strGencodeRung += string.Format("\nstack_series.push();\t//Stack Lavels = {0} ScanValue", stack_Lavel);
				
				strGencodeRung += string.Format("\n{0}{1}", Teb_Code(), GenPLCLib_CodeElement(rung.Rung_elements));
				strGenCode += strGencodeRung;
				
			}
			strGenCode += string.Format("\n\n//=========================================\n//GENALATOR CODE FOR PLCLibs By MICROPLC Pk Softtech");
			return strGenCode;
		}
		
		
		static String Teb_Code()
		{
			string ret_string = "";
			int i = 0;
			for (i = 0; i < teb_Lavel; i++) {
				ret_string += "\t";
			}
			return ret_string;
		}
		
		static String GenPLCLib_CodeTag(Elements element)
		{
			string Op_Code_Tag = "";
			try {
				switch (element.Type) {
					case TypeTag.CONTACTS:
						switch (element.Name.Substring(0, 1)) {
							case "C":
								if (element.Properties_setOnly)
									Op_Code_Tag = string.Format("{0}.upperQ()", element.Name);
							
								if (element.Properties_resetOnly)
									Op_Code_Tag = string.Format("{0}.lowerQ()", element.Name);
								break;
							case "S":
								Op_Code_Tag = string.Format("{0}.bitValue({1})", element.Name, element.Properties_value1);
								break;
							default:
								Op_Code_Tag = string.Format("{0}", element.Name);
								break;
						}
						if (element.Properties_negated) {
							Op_Code_Tag = string.Format("_contracNot({0});", Op_Code_Tag);
						} else {
							Op_Code_Tag = string.Format("_contrac({0});", Op_Code_Tag);
						}
						break;
					case TypeTag.COIL:
						string strNot = "";
						string coilCode = "";
								//string coil_Opcode = "";
						switch (element.Name.Substring(0, 1)) {
							case "R":
							case "Y":
								if (element.Properties_negated)
									strNot = "Not";						
								coilCode = "_coil" + strNot;
						
								if (element.Properties_setOnly)
									coilCode = "set";		
								if (element.Properties_resetOnly)
									coilCode = "reset";	
								Op_Code_Tag = string.Format("{1}({0});\t// Output = {0}", element.Name, coilCode);
								break;
							case "C":
								if (element.Properties_resetOnly) {
									Op_Code_Tag = string.Format("{0}.reset();", element.Name);
									break;
								}
								if (element.Properties_setOnly) {
									Op_Code_Tag = string.Format("{0}.preset();", element.Name);
									break;
								}
								if (element.Properties_negated) {
									if (element.Properties_auto_clear) {
										Op_Code_Tag = string.Format("{0}.countDown_loop();", element.Name);
									} else {
										Op_Code_Tag = string.Format("{0}.countDown();", element.Name);
									}
								} else {
									if (element.Properties_auto_clear) {
										Op_Code_Tag = string.Format("{0}.countUp_loop();", element.Name);
									} else {
										Op_Code_Tag = string.Format("{0}.countUp();", element.Name);
									}
								}
								break;
						}
						break;
					case TypeTag.OSR:
					case TypeTag.OSF:
						Op_Code_Tag = string.Format("{1}({0});\t//ONE SHORT [{1}]", element.Name, element.Type);
						break;
					case TypeTag.FCP:
					//string strOp_fcp;
						int Codition_Code = 0;
						string[] strTemp = element.Properties.Split(' ');
						switch (strTemp[0]) {
							case "==":
								Codition_Code = 0;
								break;
							case "!=":
								Codition_Code = 1;
								break;
							case ">":
								Codition_Code = 2;
								break;
							case "<":
								Codition_Code = 3;
								break;
							case ">=":
								Codition_Code = 4;
								break;
							case "<=":
								Codition_Code = 5;
								break;
						}
						Op_Code_Tag = string.Format("compare({0},{1},{2})", element.Name, strTemp[1], Codition_Code);
						if (element.Properties_negated) {
							Op_Code_Tag = string.Format("_contracNot({0});", Op_Code_Tag);
						} else {
							Op_Code_Tag = string.Format("_contrac({0});", Op_Code_Tag);
						}									
						break;
					case TypeTag.TOF:
						Op_Code_Tag = string.Format("timerOff({0},{1});", element.Name, element.Properties_value);		
						break;
					case TypeTag.TON:
						Op_Code_Tag = string.Format("timerOn({0},{1});", element.Name, element.Properties_value);
						break;
					case TypeTag.TPC:
						Op_Code_Tag = string.Format("timerCycle({0},{1},{0}1,{2});", element.Name, element.Properties_value, element.Properties_value1);
						break;
					case TypeTag.MOVE:								
						Op_Code_Tag = string.Format("_move({0},{1});", element.Name, element.Properties);
						break;
					
					case TypeTag.ADD:	
					case TypeTag.SUB:	
					case TypeTag.MUL:	
					case TypeTag.DIV:	
					case TypeTag.MOD:
						strTemp = element.Properties.Split(' ');	
						if (strTemp.Length > 1) {
						
							if (strTemp[0].Substring(0, 1) == "C")
								strTemp[0] += ".count()";
							if (strTemp[1].Substring(0, 1) == "C")
								strTemp[1] += ".count()";
							if (element.Type == TypeTag.ADD)
								Op_Code_Tag = string.Format("_add({0},{1},{2});", element.Name, strTemp[0], strTemp[1]);
							if (element.Type == TypeTag.SUB)
								Op_Code_Tag = string.Format("_sub({0},{1},{2});", element.Name, strTemp[0], strTemp[1]);
							if (element.Type == TypeTag.MUL)
								Op_Code_Tag = string.Format("_mup({0},{1},{2});", element.Name, strTemp[0], strTemp[1]);
							if (element.Type == TypeTag.DIV)
								Op_Code_Tag = string.Format("_div({0},{1},{2});", element.Name, strTemp[0], strTemp[1]);
							if (element.Type == TypeTag.MOD)
								Op_Code_Tag = string.Format("_mod({0},{1},{2});", element.Name, strTemp[0], strTemp[1]);
						}
						break;

					case TypeTag.ADC:	
						string strPin = "";
						foreach (Elements tempVar in VariablePLCLib_element) {
							if (element.Name == tempVar.Name) {
								strPin = tempVar.IO_Port;
								break;
							}										
						}
						Op_Code_Tag = string.Format("_adc({0},_{1});", element.Name, strPin);
						break;
					case TypeTag.SHIFT_VARIABLE:								
						Op_Code_Tag = string.Format("OSR({0}_{1});{0}({1});\t\t// Call SHIFT VARIABLE FUNCTION", element.Name, element.Properties.Trim(), Teb_Code());
					// Create Function Code For Shift Variable //
						string function_shift_variable;
						function_shift_variable = string.Format("\nvoid {0}(int count)\n", element.Name);
						function_shift_variable += "{\n";
						function_shift_variable += "\tif(scanValue)\n\t\t{\n";
					
						for (int i = int.Parse(element.Properties); i > 0; --i) {
							function_shift_variable += string.Format("\t\t\t{0}{1} = {0}{2};\n", element.Name, i, i - 1);
						}
					
					
						function_shift_variable += "\t\t}\n}\n";
						function_code += function_shift_variable;
						break;
					case TypeTag.SHIFT_REGISTERS:								
						Op_Code_Tag = string.Format("{0}.shiftSet(0x{1});\t\t// SET VALUE SHIFT REGISTER_DATA", element.Name, element.Properties);
						break;
					case TypeTag.SHIFT_REG_RESET:								
						Op_Code_Tag = string.Format("{0}.reset();\t\t// RESET SHIFT REGISTER_DATA", element.Name);
						break;
					case TypeTag.SHIFT_REG_INBIT:								
						Op_Code_Tag = string.Format("{0}.inputBit();\t\t// SET INBIT SHIFT REGISTER_DATA", element.Name);
						break;
					case TypeTag.SHIFT_RIGHT:								
						Op_Code_Tag = string.Format("{0}.shiftRight();\t\t// ShiftRight SHIFT REGISTER_DATA", element.Name);
						break;
					case TypeTag.SHIFT_LEFT:								
						Op_Code_Tag = string.Format("{0}.shiftLeft();\t\t// ShiftLeft SHIFT REGISTER_DATA", element.Name);
						break;
													
				//--------------------------------------------------------------------------------------------------------//									
					case TypeTag.SHORT:								
						Op_Code_Tag = string.Format("_short();\t\t// Short Circuit");
						break;	
					case TypeTag.OPEN:								
						Op_Code_Tag = string.Format("_open();\t\t// Open Circuit");
						break;							
					case TypeTag.COMMENT:
						if (element.Properties != null)
							Op_Code_Tag = string.Format("//{0}//", element.Properties.Replace("\n", "\n" + Teb_Code() + "//"));
						break;
					case TypeTag.UART_SEND:								
						Op_Code_Tag = string.Format("\t// UART SENT Data Format");
						break;
					default :
						Op_Code_Tag = "\n*Error*\t// ********************* Unknow Type [- " + element.Name + " -] **************//";
						Op_Code_Tag += Teb_Code() + "\n// *********************[- " + element.Properties + " -] **************//\n";
						break;
					
				} 
				//------------------------------------End Of Element Type-------------------------------------------------//
				return string.Format("\n{1}{0}", Op_Code_Tag, Teb_Code());	
			} catch (ArgumentOutOfRangeException e) {
				MessageBox.Show(e.ToString(), "Error Unformet Exception");
					
			}
			return "";
		}
		
		static String GenPLCLib_CodeElement(Elements element)
		{			
			string strGenCode;
			strGenCode = string.Format("\n{1}//GenCode Of Elements = {0}", element.Name, Teb_Code());
			//string OP_Code = "";
			teb_Lavel += 1;
			switch (element.Type) {							
				case TypeTag.Rung:		
				case TypeTag.SERIES:
			// ******************************** SERIES & RUNG ***********************************
			// ******************************** SERIES & RUNG ***********************************									
					for (int i = 0; i < element.Tags.Count; i++) {
						Elements tag_rung = element.Tags[i];
						switch (tag_rung.Type) {
						//----------------------------------------
						// Parallel In Rung ()
						//________________________________________
							case TypeTag.PARALLEL:
								strGenCode += string.Format("\n{1}stack_series.push();\t//Stack Lavels = {0}", ++stack_Lavel, Teb_Code());
								strGenCode += GenPLCLib_CodeElement(tag_rung);								
								break;
							default:
								strGenCode += GenPLCLib_CodeTag(tag_rung);
								break;
						}
					}
					
					break;
			// ******************************** PARALLER ***********************************
			// ******************************** PARALLER ***********************************			
				case TypeTag.PARALLEL:
					for (int i = 0; i < element.Tags.Count; i++) {
						Elements tag_rung = element.Tags[i];
						//OP_Code = "";		
						stack_parallel++;
						
						strGenCode += string.Format("\n{0}stack_series.pop();\t", Teb_Code());				
						strGenCode += string.Format("stack_series.push();\t//Stack Lavels = {0}\tLoad ScanValue", stack_Lavel);				
								
						switch (tag_rung.Type) {
						//----------------------------------------
						// SERIES In PARALLEL ()
						//________________________________________						
							case TypeTag.SERIES:
								strGenCode += GenPLCLib_CodeElement(tag_rung);
								break;
							default:
								strGenCode += GenPLCLib_CodeTag(tag_rung);
								break;
						}								
						if (i < element.Tags.Count - 1) {
							strGenCode += string.Format("\n{1}stack_parallel.push();   \t//Stack Parallel = {0}", stack_parallel, Teb_Code());
						}
						
					}		
					strGenCode += string.Format("\n{0}stack_series.back();\t  //Return stack level = {1}", Teb_Code(), --stack_Lavel);				
						
					for (int i = element.Tags.Count; i > 1; i--) {
						stack_parallel--;	
						strGenCode += string.Format("\n{1}stack_parallel.orBlock();\t//Stack Parallel = {0}", stack_parallel, Teb_Code());					
						
					}
					break;		
			}
			teb_Lavel -= 1;
			strGenCode += string.Format("\n{1}//End Of {0} Element", element.Type, Teb_Code());			
			
			return strGenCode;
		}
		
		public  static String ExportRungLd(Rung rung)
		{
			string retLd = "";
			const int levelLd = -1;

			retLd += ExportTagsLd(rung.Rung_elements, levelLd);

			//retLd += "END\n";
			return retLd;
		}
		static String ExportTagsLd(Elements tags, int levelLd)
		{
			string retLd = "";
			string tabLd = "";
			++levelLd;
			for (int i = 1; i <= levelLd; i++)
				tabLd += '\t';
			switch (tags.Type) {
				case TypeTag.PARALLEL:
				case TypeTag.Rung:
				case TypeTag.SERIES:
					string tagname = "SERIES\n";
					if (tags.Type == TypeTag.PARALLEL)
						tagname = "PARALLEL\n";
					if (tags.Type == TypeTag.Rung)
						tagname = "RUNG\n";
					retLd += tagname;
					foreach (Elements tag in tags.Tags) {
						retLd += ExportTagsLd(tag, levelLd);
					}
					tagname = tabLd + "END\n";
					retLd += tagname;
					break;
				case TypeTag.CONTACTS:
					if (tags.Properties_negated) {
						tags.Properties = "1";
					} else {
						tags.Properties = "0";
					}
					if (tags.Properties_setOnly) {
						tags.Properties += " 1";
					} else {
						tags.Properties += " 0";
					}
					if (tags.Properties_resetOnly) {
						tags.Properties += " 1";
					} else {
						tags.Properties += " 0";
					}
					if (tags.Name.Substring(0, 1) == "C") {
						tags.Properties += string.Format(" {0} {1}", tags.Properties_value, tags.Properties_value1);
					}
					if (tags.Name.Substring(0, 1) == "S") {
						tags.Properties += string.Format(" {0} {1}", tags.Properties_value, tags.Properties_value1);
					}
					retLd += string.Format("CONTACTS {0} {1}\n", tags.Name, tags.Properties);
					break;
				case TypeTag.COMMENT:
					//retLd += string.Format("_COMMENT_ {0} {1}\n", tags.Name, tags.Properties.Replace(' ', '^').Replace(Environment.NewLine, "/cnc/"));
					retLd += string.Format("COMMENT {0}\n", tags.Properties.Replace(Environment.NewLine, "\\r\\n"));			
					break;
				case TypeTag.TOF:					
					retLd += string.Format("TOF {0} {1}000\n", tags.Name, tags.Properties_value);
					break;
				case TypeTag.TON:					
					retLd += string.Format("TON {0} {1}000\n", tags.Name, tags.Properties_value);
					break;
				case TypeTag.TPC:					
					retLd += string.Format("TPC {0} {1} {2}\n", tags.Name, tags.Properties_value, tags.Properties_value1);
					break;
				case TypeTag.FCP:					
					//retLd += string.Format("FCP {0} {1}\n", tags.Name, tags.Properties);
					string[] strpara = tags.Properties.Split(' ');
					switch (strpara[0]) {
						case "==":
							retLd += string.Format("EQU {0} {1}\n", tags.Name, strpara[1]);
							break;
						case ">":
							retLd += string.Format("GRT {0} {1}\n", tags.Name, strpara[1]);
							break;
						case "<":
							retLd += string.Format("LES {0} {1}\n", tags.Name, strpara[1]);
							break;
						case "!=":
							retLd += string.Format("NEQ {0} {1}\n", tags.Name, strpara[1]);
							break;
						case ">=":
							retLd += string.Format("GEQ {0} {1}\n", tags.Name, strpara[1]);
							break;
						case "<=":
							retLd += string.Format("LEQ {0} {1}\n", tags.Name, strpara[1]);
							break;
					}						
						
					break;
				case TypeTag.OSR:					
					retLd += string.Format("OSR\n");
					break;
				case TypeTag.OSF:					
					retLd += string.Format("OSF\n");
					break;
				case TypeTag.SHORT:					
					retLd += string.Format("SHORT {0}\n", tags.Type, tags.Name);
					break;
				case TypeTag.OPEN:					
					retLd += string.Format("OPEN {0}\n", tags.Type, tags.Name);
					break;
				case TypeTag.UART_RECV:					
					retLd += string.Format("{0} {1}\n", tags.Type, tags.Name);
					break;
				case TypeTag.UART_SEND:					
					retLd += string.Format("{0} {1} {2}\n", tags.Type, tags.Name, tags.Properties);
					break;
				case TypeTag.MASTER_RELAY:					
					retLd += string.Format("MASTER_RELAY {0}\n", tags.Name);
					break;
				case TypeTag.MOVE:					
					retLd += string.Format("MOVE {0} {1}\n", tags.Name, tags.Properties);
					break;
				case TypeTag.ADD:					
					retLd += string.Format("ADD {0} {1}\n", tags.Name, tags.Properties);
					break;
				case TypeTag.SUB:					
					retLd += string.Format("SUB {0} {1}\n", tags.Name, tags.Properties);
					break;
				case TypeTag.MUL:					
					retLd += string.Format("MUP {0} {1}\n", tags.Name, tags.Properties);
					break;
				case TypeTag.DIV:					
					retLd += string.Format("DIV {0} {1}\n", tags.Name, tags.Properties);
					break;
				case TypeTag.MOD:					
					retLd += string.Format("MOD {0} {1}\n", tags.Name, tags.Properties);
					break;
				case TypeTag.ADC:					
					retLd += string.Format("READ_ADC {0}\n", tags.Name, tags.Properties);
					break;
			// SHIFT REGISTER *************************************	
				case TypeTag.SHIFT_VARIABLE:					
					retLd += string.Format("SHIFT_REGISTER {0} {1}\n", tags.Name, tags.Properties);
					break;
				case TypeTag.SHIFT_REGISTERS:					
					retLd += string.Format("SHIFT_REG {0} {1}\n", tags.Name, tags.Properties);
					break;
				case TypeTag.SHIFT_REG_INBIT:					
					retLd += string.Format("SHIFT_INBIT {0}\n", tags.Name);
					break;
				case TypeTag.SHIFT_REG_RESET:					
					retLd += string.Format("SHIFT_RES {0}\n", tags.Name);
					break;	
				case TypeTag.SHIFT_RIGHT:					
					retLd += string.Format("SHIFT_RIGHT {0}\n", tags.Name);
					break;
				case TypeTag.SHIFT_LEFT:					
					retLd += string.Format("SHIFT_LEFT {0}\n", tags.Name);
					break;
				
				case TypeTag.COIL:
					if (tags.Properties_negated) {
						tags.Properties = "1";
					} else {
						tags.Properties = "0";
					}
					if (tags.Properties_setOnly) {
						tags.Properties += " 1";
					} else {
						tags.Properties += " 0";
					}
					if (tags.Properties_resetOnly) {
						tags.Properties += " 1";
					} else {
						tags.Properties += " 0";
					}
					if (tags.Properties_auto_clear) {
						tags.Properties += " 1";
					} else {
						tags.Properties += " 0";
					}
					string strCoil_code = "COIL";
					if (tags.Name.Substring(0, 1) == "C") {
						if (tags.Properties == "0" || tags.Properties_value1 == 0) {
							strCoil_code = "CTC";
							tags.Properties = tags.Properties_value.ToString();
						} else {
							tags.Properties += string.Format(" {0} {1}", tags.Properties_value, tags.Properties_value1);
						}
					}
					retLd += string.Format("{2} {0} {1}\n", tags.Name, tags.Properties, strCoil_code);
					break;
				default:
					retLd += string.Format("{1} {0}\n", tags.Type, tags.Name);
					break;
			}
			return tabLd + retLd;
		}
        
        
		//############################################################################//

		//			ACTION PROGRAM LADDERS
	           
		//############################################################################//
		static Elements preview_tag, temp_parent, temp_tag_select;
		static ProgramLadder ActiveProgram;
		static Elements temp_tag;
		//static int last_position	= 0;
		static bool preview_stratus;
		public static void Set_Tag_Insert(Elements tag_value)
		{
			temp_tag = tag_value;
		}
		// disable once ConvertToAutoProperty
		public static bool Preview_stratus {
			get {
				return preview_stratus;
			}
			set {
				preview_stratus = value;
			}
		}
		static bool addSelect;
		static activePositions ActivePos;
		public static bool SetActiveProgram(ProgramLadder program)
		{
			ActiveProgram = program;
			return true;
		}
		public static int ActiveCommand(commands command, activePositions activePos, ProgramLadder program)
		{
			//ActiveProgram = program;
			if (ActivePos == activePos & command != commands.INSERT_TAG & activePos != activePositions.On_Tag)
				return 0;
			ActivePos = activePos;
        			
			switch (command) {						
				case commands.NULL:
					break;
				case commands.INSERT_PREVIEW:
					if (INSERT_PREVIEW() > -1) {
						Preview_stratus = true;
					} else {
						Preview_stratus = false;
						return -1;
					}      					
					break;
				case commands.INSERT_TAG:        			
					if (Preview_stratus) {     				
        			
						if (temp_tag == null || preview_tag == null || activePos == activePositions.Null)
							break;
						Preview_stratus = false;
        				
						temp_tag.Select_tag = true;
						if (addSelect) {
							int select_tags	= ActiveProgram.Select_tags.Tags.Count;
							if (select_tags > 0)
							if (temp_tag.Parent.Tags.IndexOf(temp_tag) < temp_tag.Parent.Tags.IndexOf(ActiveProgram.Select_tags.Tags[0]))
								select_tags = 0;
							ActiveProgram.Select_tags.Tags.Insert(select_tags, temp_tag);
						}        					
						if (preview_tag.Type == TypeTag.PARALLEL || preview_tag.Type == TypeTag.SERIES) {
							ActiveProgram.Select_tags.Tags.Clear();
							ActiveProgram.Select_tags.Tags.Add(preview_tag);
							preview_tag.Select_tag = true;
						}
						SaveStratus = true;

					} else {
						ActiveProgram.ClearSelectTags();
						ActiveProgram.Select_tags.Tags.Clear();
					}
					ActiveProgram.BuildSelectFrame();
        			//temp_tag.Name	+= Index_Name.ToString("00");
        			//temp_tag.Name	= temp_tag.Parent.Name;
        			//++Index_Name;
					temp_tag = null;
					
					break;	
				case commands.DELECT_TAG:        			
					temp_tag = ActiveProgram.Select_tags.Tags[0];
					//Delete_Tag(temp_tag);
					Remove_Tag(temp_tag);
					ActiveProgram.ClearSelectTags();
					SaveStratus = true;
					break;	
			}
        	
			return 0;
		}
        
		//		static bool Delete_Tag(Elements tag_delete)
		//		{
		//			temp_parent	= tag_delete.Parent;
		//			temp_parent.RemoveTag(tag_delete);
		//			if (temp_parent.Tags.Count <= 1 & temp_parent.Type != TypeTag.Rung) {
		//				int index_temp_pr	= temp_parent.Parent.Tags.IndexOf(temp_parent);
		//				temp_tag	= temp_parent.Tags[0];
		//				//temp_tag.Parent = temp_parent.Parent;
		//				temp_parent.Parent.InsertTag(index_temp_pr, temp_tag);
		//				temp_parent.Parent.RemoveTag(temp_parent);
		//				if (temp_parent.Parent.Type == TypeTag.Rung & temp_tag.Type == TypeTag.SERIES) {
		//					foreach (Elements tag in temp_tag.Tags) {
		//						tag.Parent = temp_parent.Parent;
		//						temp_parent.Parent.InsertTag(index_temp_pr, tag);
		//						index_temp_pr++;
		//					}
		//					temp_parent.Parent.RemoveTag(temp_tag);
		//
		//				}
		//			}
		//
		//			return true;
		//		}
		static bool Remove_Tag(Elements tag_remove)
		{
			var tag_remove_parent = tag_remove.Parent;			
			switch (tag_remove_parent.Type) {
				case TypeTag.Rung:
					tag_remove_parent.RemoveTag(tag_remove);	
					break;
				case TypeTag.SERIES:
					tag_remove_parent.RemoveTag(tag_remove);
					if (tag_remove_parent.Tags.Count <= 1) {
						var tag_remove_parent_tag = tag_remove_parent.Tags[0];
						int index_of_temp_parent = tag_remove_parent.Parent.Tags.IndexOf(tag_remove_parent);
						tag_remove_parent.Parent.InsertTag(index_of_temp_parent, tag_remove_parent_tag);
						tag_remove_parent.Parent.Tags.Remove(tag_remove_parent);
						if (tag_remove_parent_tag.Type == TypeTag.PARALLEL) {
							foreach (Elements tag in tag_remove_parent_tag.Tags) {
								tag_remove_parent.Parent.InsertTag(index_of_temp_parent++, tag);						
							}
							tag_remove_parent.Parent.Tags.Remove(tag_remove_parent_tag);
						}
					}
					break;
				case TypeTag.PARALLEL:
					tag_remove_parent.RemoveTag(tag_remove);
					if (tag_remove_parent.Tags.Count <= 1) {
						var tag_remove_parent_tag = tag_remove_parent.Tags[0];
						int index_of_temp_parent = tag_remove_parent.Parent.Tags.IndexOf(tag_remove_parent);
						tag_remove_parent.Parent.InsertTag(index_of_temp_parent, tag_remove_parent_tag);
						tag_remove_parent.Parent.Tags.Remove(tag_remove_parent);
						if (tag_remove_parent_tag.Type == TypeTag.SERIES || tag_remove_parent_tag.Type == TypeTag.Rung) {
							foreach (Elements tag in tag_remove_parent_tag.Tags) {
								tag_remove_parent.Parent.InsertTag(index_of_temp_parent++, tag);						
							}
							tag_remove_parent.Parent.Tags.Remove(tag_remove_parent_tag);
						}
					}
					break;	
				default :
					return false;
			}
			return true;
		}
		static public bool Can_Preview(Elements tag_past, activePositions past_position)
		{
			Elements tag_base;
			if (ActiveProgram.Select_tags.Tags.Count > 1) {
				if (!CheckParentCommon(ActiveProgram.Select_tags) || Find_Coil(ActiveProgram.Select_tags)) {
					return false;
				}  
			}        		
			if (ActiveProgram.Select_tags.Tags.Count == 0) {				
				tag_base = ActiveProgram.Rung_select.Rung_elements;
				if (tag_base.Tags.Count > 0)
					return false;
			} else {
				tag_base	= ActiveProgram.Select_tags.Tags[0];
			}       		
			if ((tag_past.Type == TypeTag.MASTER_RELAY) & (Find_Master_Relay(ActiveProgram.Rung_select.Rung_elements)))
				return false;
			if (tag_base.Type == TypeTag.Rung & tag_past.Type == TypeTag.COMMENT)
				return true;
			switch (tag_base.Type) {
				case TypeTag.TOF:
				case TypeTag.TON:	
				case TypeTag.TPC:
					switch (tag_past.Type) {
						case TypeTag.CONTACTS:
						case TypeTag.UART_RECV:
						case TypeTag.UART_SEND:
						case TypeTag.OPEN:	
						case TypeTag.SHORT:
						case TypeTag.OSR:
						case TypeTag.OSF:
						case TypeTag.FCP:
						case TypeTag.TOF:
						case TypeTag.TON:	
						case TypeTag.TPC:						
							if (past_position == activePositions.Right || past_position == activePositions.Left)
								return true;
							break;
						case TypeTag.COIL:
						case TypeTag.MOVE:
						case TypeTag.ADD:
						case TypeTag.SUB:
						case TypeTag.MUL:
						case TypeTag.DIV:
						case TypeTag.MOD:
						case TypeTag.ADC:
						case TypeTag.MASTER_RELAY:
						case TypeTag.SHIFT_REGISTERS:
						case TypeTag.SHIFT_VARIABLE:
						case TypeTag.SHIFT_LEFT:
						case TypeTag.SHIFT_RIGHT:
						case TypeTag.SHIFT_REG_INBIT:
						case TypeTag.SHIFT_REG_RESET:
							if (tag_base.Parent != null)
							if (tag_base.Parent.Type == TypeTag.Rung) {
								if (ActiveProgram.Select_tags.Tags.Count > 1)
									tag_base = ActiveProgram.Select_tags.Tags[ActiveProgram.Select_tags.Tags.Count - 1];
								if (tag_base.Parent.Tags.IndexOf(tag_base) == tag_base.Parent.Tags.Count - 1 & past_position == activePositions.Right)
									return true;
							}
							if (ActiveProgram.Select_tags.Tags.Count == 0 & past_position == activePositions.InRung)
								return true;
        						
							break;
						default:
							return false;
					}
					break;
				case TypeTag.CONTACTS:
				case TypeTag.UART_RECV:
				case TypeTag.UART_SEND:
				case TypeTag.OPEN:	
				case TypeTag.SHORT:
				case TypeTag.OSR:
				case TypeTag.OSF:
				case TypeTag.FCP:					
				case TypeTag.Rung:        		
				case TypeTag.SERIES:
					switch (tag_past.Type) {						
						case TypeTag.TOF:
						case TypeTag.TON:
						case TypeTag.TPC:
							if (past_position == activePositions.Top || past_position == activePositions.Buttom)
								return false;
							foreach (Elements tag in tag_base.Tags) {
								if (tag.Type == TypeTag.COIL || tag.Type == TypeTag.MASTER_RELAY) {
									return false;
								}
							}
							
							return true;							
						case TypeTag.CONTACTS:
						case TypeTag.UART_RECV:
						case TypeTag.UART_SEND:
						case TypeTag.OPEN:	
						case TypeTag.SHORT:
						case TypeTag.OSR:
						case TypeTag.OSF:
						case TypeTag.FCP:
							foreach (Elements tag in tag_base.Tags) {
								if (tag.Type == TypeTag.COIL || tag.Type == TypeTag.MASTER_RELAY) {
									return false;
								}
							}
							return true;
						case TypeTag.COIL:
						case TypeTag.MOVE:
						case TypeTag.ADD:
						case TypeTag.SUB:
						case TypeTag.MUL:
						case TypeTag.DIV:
						case TypeTag.MOD:
						case TypeTag.ADC:
						case TypeTag.MASTER_RELAY:
						case TypeTag.SHIFT_REGISTERS:
						case TypeTag.SHIFT_VARIABLE:
						case TypeTag.SHIFT_LEFT:
						case TypeTag.SHIFT_RIGHT:
						case TypeTag.SHIFT_REG_INBIT:
						case TypeTag.SHIFT_REG_RESET:
							if (tag_base.Parent != null)
							if (tag_base.Parent.Type == TypeTag.Rung) {
								if (ActiveProgram.Select_tags.Tags.Count > 1)
									tag_base = ActiveProgram.Select_tags.Tags[ActiveProgram.Select_tags.Tags.Count - 1];
								if (tag_base.Parent.Tags.IndexOf(tag_base) == tag_base.Parent.Tags.Count - 1 & past_position == activePositions.Right)
									return true;
							}
							if (ActiveProgram.Select_tags.Tags.Count == 0 & past_position == activePositions.InRung)
								return true;
        						
							break;
					}
					break;
				case TypeTag.PARALLEL:	
					switch (tag_past.Type) {
						case TypeTag.COIL:
						case TypeTag.MOVE:
						case TypeTag.ADD:
						case TypeTag.SUB:	
						case TypeTag.MUL:
						case TypeTag.DIV:
						case TypeTag.MOD:
						case TypeTag.ADC:
						case TypeTag.MASTER_RELAY:
						case TypeTag.SHIFT_REGISTERS:
						case TypeTag.SHIFT_VARIABLE:
						case TypeTag.SHIFT_LEFT:
						case TypeTag.SHIFT_RIGHT:
						case TypeTag.SHIFT_REG_INBIT:
						case TypeTag.SHIFT_REG_RESET:
							foreach (Elements tag in tag_base.Tags) {
								if ((tag.Type == TypeTag.COIL
								    || tag.Type == TypeTag.MOVE
								    || tag.Type == TypeTag.ADC
								    || tag.Type == TypeTag.SHIFT_LEFT
								    || tag.Type == TypeTag.SHIFT_REG_RESET
								    || tag.Type == TypeTag.SHIFT_REGISTERS
								    || tag.Type == TypeTag.SHIFT_VARIABLE
								    || tag.Type == TypeTag.SHIFT_RIGHT
								    ) & past_position != activePositions.Left & past_position != activePositions.Right) {
									return true;
								}
							}
							if (!Find_Coil(tag_base.Parent) & tag_base.Parent.Tags.IndexOf(tag_base) == tag_base.Parent.Tags.Count - 1)
							if (past_position == activePositions.Right)
								return true;
							break;
						
						case TypeTag.TOF:
						case TypeTag.TON:
						case TypeTag.TPC:
							switch (tag_past.Type) {
								case TypeTag.CONTACTS:
								case TypeTag.UART_RECV:
								case TypeTag.UART_SEND:
								case TypeTag.OPEN:	
								case TypeTag.SHORT:
								case TypeTag.OSR:
								case TypeTag.OSF:
								case TypeTag.FCP:
								case TypeTag.TOF:
								case TypeTag.TON:	
								case TypeTag.TPC:
									if (past_position == activePositions.Right || past_position == activePositions.Left)
										return true;
									break;
								default:
									return false;
							}
							break;
						case TypeTag.CONTACTS:
						case TypeTag.UART_RECV:
						case TypeTag.UART_SEND:
						case TypeTag.OPEN:	
						case TypeTag.SHORT:
						case TypeTag.OSR:
						case TypeTag.OSF:
						case TypeTag.FCP:
							foreach (Elements tag in tag_base.Tags) {
								if (tag.Type != TypeTag.COIL || tag.Type != TypeTag.MASTER_RELAY || past_position == activePositions.Left)
									return true;
							}   
							break;
					}
					break;
				case TypeTag.COIL:
				case TypeTag.MOVE:
				case TypeTag.ADD:
				case TypeTag.SUB:
				case TypeTag.MUL:
				case TypeTag.DIV:
				case TypeTag.MOD:
				case TypeTag.ADC:
				case TypeTag.MASTER_RELAY:
				case TypeTag.SHIFT_REGISTERS:
				case TypeTag.SHIFT_VARIABLE:
				case TypeTag.SHIFT_LEFT:
				case TypeTag.SHIFT_RIGHT:
				case TypeTag.SHIFT_REG_INBIT:
				case TypeTag.SHIFT_REG_RESET:
					switch (tag_past.Type) {
						case TypeTag.COIL:
						case TypeTag.MOVE:
						case TypeTag.ADD:
						case TypeTag.SUB:
						case TypeTag.MUL:
						case TypeTag.DIV:
						case TypeTag.MOD:
						case TypeTag.ADC:
						case TypeTag.MASTER_RELAY:
						case TypeTag.SHIFT_REGISTERS:
						case TypeTag.SHIFT_VARIABLE:
						case TypeTag.SHIFT_LEFT:
						case TypeTag.SHIFT_RIGHT:
						case TypeTag.SHIFT_REG_INBIT:
						case TypeTag.SHIFT_REG_RESET:
							if (past_position == activePositions.Top || past_position == activePositions.Buttom)
								return true;
							break;
						case TypeTag.CONTACTS:
						case TypeTag.UART_RECV:
						case TypeTag.UART_SEND:
						case TypeTag.OPEN:	
						case TypeTag.SHORT:
						case TypeTag.OSR:
						case TypeTag.OSF:
						case TypeTag.FCP:
						case TypeTag.TOF:
						case TypeTag.TON:
							if (past_position == activePositions.Left)
								return true;
							break;
					}
					break;
			}
			return false;
		}
		static bool Find_Coil(Elements tags)
		{
			foreach (Elements tag in tags.Tags) {
				switch (tag.Type) {
					case TypeTag.COIL:
					case TypeTag.MOVE:
					case TypeTag.ADD:
					case TypeTag.SUB:
					case TypeTag.MUL:
					case TypeTag.DIV:
					case TypeTag.MOD:
					case TypeTag.ADC:
					case TypeTag.MASTER_RELAY:
					case TypeTag.SHIFT_REGISTERS:
					case TypeTag.SHIFT_VARIABLE:
					case TypeTag.SHIFT_LEFT:
					case TypeTag.SHIFT_RIGHT:
					case TypeTag.SHIFT_REG_INBIT:
					case TypeTag.SHIFT_REG_RESET:
						return true;
					case TypeTag.PARALLEL:
					case TypeTag.SERIES:
					case TypeTag.Rung:
						if (Find_Coil(tag))
							return true;
						break;
				}
			}
			return false;        	
		}
		public static bool Find_Master_Relay(Elements tags)
		{
			foreach (Elements tag in tags.Tags) {
				switch (tag.Type) {
				//case TypeTag.COIL:
					case TypeTag.MASTER_RELAY:
						return true;
					case TypeTag.PARALLEL:
					case TypeTag.SERIES:
					case TypeTag.Rung:
						if (Find_Master_Relay(tag))
							return true;
						break;
				}
			}
			return false;        	
		}
		static public int Index_Name = 01;
		static int INSERT_PREVIEW()
		{
			if (temp_tag == null)
				return -1;
			if (preview_stratus & ActivePos == activePositions.Null) {
				ORG_PREVIEW();
				return 0;
			}    	
			int index_of_select_tag = 1;
			addSelect = true;
			if (ActivePos == activePositions.InRung) {
				temp_parent = ActiveProgram.Rung_select.Rung_elements;
				temp_tag_select	= temp_parent;
			}        		
        	
			if (ActiveProgram.Select_tags.Tags.Count == 1 & ActivePos != activePositions.Null) {
				temp_tag_select	= ActiveProgram.Select_tags.Tags[0];
				temp_parent = temp_tag_select.Parent;
				if (temp_parent == null)
					temp_parent = new Elements(TypeTag.Null, "RUNG", null);
				index_of_select_tag	= temp_parent.Tags.IndexOf(temp_tag_select);  
				if (index_of_select_tag == -1) {
					//test
				}
			}	
			if (ActiveProgram.Select_tags.Tags.Count > 1)
				goto SELECTS_TAGS;
        	
			if (temp_tag_select == null)
				return -1;
			temp_tag.Parent	= temp_parent;
			if (!Can_Preview(temp_tag, ActivePos))
				return -1;     	       	
	
			switch (temp_parent.Type) {
				case TypeTag.SERIES:
				case TypeTag.Rung:	
					switch (ActivePos) {
						case activePositions.InRung:
							if (ActiveProgram.Rung_select.Rung_elements.Tags.Count > 0)
								return -1;
							preview_tag = temp_tag;
							temp_parent.AddTag(preview_tag);
							temp_tag_select = null;
							break;
							
						case activePositions.Left:
							preview_tag = temp_tag;
							temp_parent.InsertTag(index_of_select_tag, preview_tag);
							temp_tag_select = null;
							break;	
							
						case activePositions.Right:
							preview_tag = temp_tag;
							temp_parent.InsertTag(index_of_select_tag + 1, preview_tag);
							temp_tag_select = null;
							break;
						case activePositions.Top:
							if (temp_tag_select.Type == TypeTag.PARALLEL) {
								preview_tag = temp_tag;
								//preview_tag.Parent= temp_tag_select;
								temp_tag_select.InsertTag(0, preview_tag);
								temp_parent	= temp_tag_select;
								temp_tag_select = null;								
								addSelect = false;
								break;
							}
							preview_tag	= new Elements(TypeTag.PARALLEL, "PARALLEL", temp_parent);
							temp_tag.Parent	= preview_tag;
							//temp_tag_select.Parent = preview_tag;
							//temp_tag.Parent = preview_tag;
							preview_tag.AddTag(temp_tag);
							preview_tag.AddTag(temp_tag_select);
							temp_parent.InsertTag(index_of_select_tag, preview_tag);
							temp_parent.RemoveTag(temp_tag_select);
							break;
						case activePositions.Buttom:
							if (temp_tag_select.Type == TypeTag.PARALLEL) {
								preview_tag = temp_tag;
								//preview_tag.Parent= temp_tag_select;
								temp_tag_select.AddTag(preview_tag);
								temp_parent	= temp_tag_select;
								temp_tag_select = null;								
								addSelect = false;
								break;
							}
							preview_tag	= new Elements(TypeTag.PARALLEL, "PARALLEL", temp_parent);
							temp_tag.Parent	= preview_tag;
							//temp_tag_select.Parent = preview_tag;
							//temp_tag.Parent = preview_tag;
							preview_tag.AddTag(temp_tag_select);
        					//temp_tag	= new Elements(TypeTag.CONTACTS,"CONTACTS",preview_tag);
							// temp_tag.Select_tag = true;
							preview_tag.AddTag(temp_tag);	
							temp_parent.InsertTag(index_of_select_tag, preview_tag);
							temp_parent.RemoveTag(temp_tag_select);
							break;	
					}
					break;
			// PARENT IS PARALLER ELEMENTS
				case TypeTag.PARALLEL:	
					switch (ActivePos) {
						case activePositions.Top:
							preview_tag = temp_tag;
							temp_parent.InsertTag(index_of_select_tag, preview_tag);
							temp_tag_select = null;
							break;						
						case activePositions.Buttom:
							preview_tag = temp_tag;
							temp_parent.InsertTag(index_of_select_tag + 1, preview_tag);
							temp_tag_select = null;
							break;
						case activePositions.Left:
							if (temp_tag_select.Type == TypeTag.PARALLEL) {
								preview_tag = temp_tag;
								//preview_tag.Parent= temp_tag_select;
								temp_tag_select.InsertTag(0, preview_tag);
								temp_parent	= temp_tag_select;
								temp_tag_select = null;								
								addSelect = false;
								break;
							}
							preview_tag	= new Elements(TypeTag.SERIES, "SERIES", temp_parent);
							temp_tag.Parent	= preview_tag;
							//temp_tag_select.Parent = preview_tag;
							preview_tag.AddTag(temp_tag);
							preview_tag.AddTag(temp_tag_select);
							temp_parent.InsertTag(index_of_select_tag, preview_tag);
							temp_parent.RemoveTag(temp_tag_select);
							break;
						case activePositions.Right:
							if (temp_tag_select.Type == TypeTag.PARALLEL) {
								preview_tag = temp_tag;
								//preview_tag.Parent= temp_tag_select;
								temp_tag_select.AddTag(preview_tag);
								temp_parent	= temp_tag_select;
								temp_tag_select = null;								
								addSelect = false;
								break;
							}
							preview_tag	= new Elements(TypeTag.SERIES, "SERIES", temp_parent);
							temp_tag.Parent	= preview_tag;
							//temp_tag_select.Parent = preview_tag;
							preview_tag.AddTag(temp_tag_select);
        					//temp_tag	= new Elements(TypeTag.CONTACTS,"CONTACTS",preview_tag);
							// temp_tag.Select_tag = true;
							preview_tag.AddTag(temp_tag);	
							temp_parent.InsertTag(index_of_select_tag, preview_tag);
							temp_parent.RemoveTag(temp_tag_select);
							break;	
					}
					break;
			}
			return 1;
        	
			//###########################################################################//   
			//###########################################################################//   
			//###########################################################################//   	
			SELECTS_TAGS:	// IN CASE SELECTED TAGS MORE 2 Obj.
     	
			if (!CheckParentCommon(ActiveProgram.Select_tags)) {
				return -1;
			}       

			temp_parent = ActiveProgram.Select_tags.Tags[0].Parent;
			int index_last_tag	=	-1;
			int index_befor_tag	=	999;
			foreach (Elements tag in ActiveProgram.Select_tags.Tags) {
				int index_tag	= temp_parent.Tags.IndexOf(tag);
				index_befor_tag = Math.Min(index_befor_tag, index_tag);
				index_last_tag = Math.Max(index_last_tag, index_tag);
			}
			if (index_befor_tag == -1 || index_last_tag == -1) {
				// Debug
			}
        	
			temp_tag_select = ActiveProgram.Select_tags.Tags[0];
			temp_tag.Parent	= temp_parent;
			if (!Can_Preview(temp_tag, ActivePos))
				return -1;
        	
			switch (temp_parent.Type) {        	
				case TypeTag.Rung: 	// PARENT IS SERIES OR Rung ELEMENTS	
				case TypeTag.SERIES: 
					switch (ActivePos) {
						case activePositions.Left:
							preview_tag = temp_tag;
							temp_parent.InsertTag(index_befor_tag, preview_tag);
							temp_tag_select = null;
							break;
						case activePositions.Right:
							preview_tag = temp_tag;
							temp_parent.InsertTag(index_last_tag + 1, preview_tag);
							temp_tag_select = null;
							break;
						case activePositions.Top:
							temp_tag_select = new Elements(TypeTag.SERIES, "SERIES", temp_parent);
							foreach (Elements tag in ActiveProgram.Select_tags.Tags) {
								temp_parent.RemoveTag(tag);
								temp_tag_select.AddTag(tag);
								tag.Parent	= temp_tag_select;
							}
							preview_tag	= new Elements(TypeTag.PARALLEL, "PARALLEL", temp_parent);
							//temp_tag_select.Parent = preview_tag;
							//temp_tag.Parent = preview_tag;
							preview_tag.AddTag(temp_tag);
							preview_tag.AddTag(temp_tag_select);
							temp_parent.InsertTag(index_befor_tag, preview_tag);
							break;
						case activePositions.Buttom:
        					//index_of_select_tag	= temp_parent.Tags.IndexOf(program.Select_tags.Tags[0]);
							temp_tag_select = new Elements(TypeTag.SERIES, "SERIES", temp_parent);
							foreach (Elements tag in ActiveProgram.Select_tags.Tags) {
								temp_parent.RemoveTag(tag);
								temp_tag_select.AddTag(tag);
								tag.Parent	= temp_tag_select;
							}
							preview_tag	= new Elements(TypeTag.PARALLEL, "PARALLEL", temp_parent);
							//temp_tag_select.Parent = preview_tag;
							//temp_tag.Parent = preview_tag;
							preview_tag.AddTag(temp_tag_select);
							preview_tag.AddTag(temp_tag);	
							
							temp_parent.InsertTag(index_befor_tag, preview_tag);
							break;
					}
					break;
				case TypeTag.PARALLEL: 
					switch (ActivePos) {
						case activePositions.Top:
							index_of_select_tag	= temp_parent.Tags.IndexOf(ActiveProgram.Select_tags.Tags[0]);
							preview_tag = temp_tag;
							// preview_tag.Select_tag = true;
							temp_parent.InsertTag(index_befor_tag, preview_tag);
							temp_tag_select = null;
							break;
						case activePositions.Buttom:
							index_of_select_tag	= temp_parent.Tags.IndexOf(ActiveProgram.Select_tags.Tags[0]);
							preview_tag = temp_tag;
							// preview_tag.Select_tag = true;
							temp_parent.InsertTag(index_last_tag + 1, preview_tag);
							temp_tag_select = null;
							break;
						case activePositions.Left:
							//index_of_select_tag	= temp_parent.Tags.IndexOf(program.Select_tags.Tags[0]);
							temp_tag_select = new Elements(TypeTag.PARALLEL, "PARALLEL", temp_parent);
							foreach (Elements tag in ActiveProgram.Select_tags.Tags) {
								temp_parent.RemoveTag(tag);
								temp_tag_select.AddTag(tag);
								tag.Parent	= temp_tag_select;
							}
							preview_tag	= new Elements(TypeTag.SERIES, "SERIES", temp_parent);
							//temp_tag_select.Parent = preview_tag;
							//temp_tag.Parent = preview_tag;
							preview_tag.AddTag(temp_tag);
							preview_tag.AddTag(temp_tag_select);
							temp_parent.InsertTag(index_befor_tag, preview_tag);
							break;
						case activePositions.Right:
							//index_of_select_tag	= temp_parent.Tags.IndexOf(program.Select_tags.Tags[0]);
							temp_tag_select = new Elements(TypeTag.PARALLEL, "PARALLEL", temp_parent);
							foreach (Elements tag in ActiveProgram.Select_tags.Tags) {
								temp_parent.RemoveTag(tag);
								temp_tag_select.AddTag(tag);
								tag.Parent	= temp_tag_select;
							}
							preview_tag	= new Elements(TypeTag.SERIES, "SERIES", temp_parent);
							//temp_tag_select.Parent = preview_tag;
							//temp_tag.Parent = preview_tag;
							preview_tag.AddTag(temp_tag_select);
							preview_tag.AddTag(temp_tag);
							
							temp_parent.InsertTag(index_befor_tag, preview_tag);
							break;
					}
					break;		
			}
     
			return 2;
		}
        
		static void ORG_PREVIEW()
		{
			int index_temp = temp_parent.Tags.IndexOf(preview_tag);

			if (temp_parent.Type == TypeTag.Null) {
				ActiveProgram.Rung_select.Rung_elements.RemoveTag(preview_tag);
			} else {
				temp_parent.RemoveTag(preview_tag);
			}			
			if (temp_tag_select	!= null & index_temp != -1) {
				
				if (ActiveProgram.Select_tags.Tags.Count == 1) {
					//temp_tag_select.Parent = temp_parent;
					temp_parent.InsertTag(index_temp, temp_tag_select);
				} else {
					for (int i = 0; i < temp_tag_select.Tags.Count; i++) {
						Elements tag = temp_tag_select.Tags[i];
						//tag.Parent = temp_parent;
						temp_parent.InsertTag(index_temp + i, tag);
					}
				}
			}
        		
			preview_stratus	= false;
		}
		static public bool CheckParentCommon(Elements elementObj)
		{
			Elements temp_tag = null;
			foreach (Elements tag in elementObj.Tags) {
				if (temp_tag != null) {
					if (tag.Parent != temp_tag.Parent) {
						return false;
					}     					
				}
				temp_tag	= tag;
			}
			return true;
		}
		
	}
}
