/*
 * Created by SharpDevelop.
 * User: FASM
 * Date: 7/3/2015
 * Time: 6:22 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MICROPLC
{
	/// <summary>
	/// Description of PropertiesElement.
	/// </summary>
	public partial class PropertiesElement : Form
	{
		Elements tag, temp_tag;

		public PropertiesElement(Elements element)
		{
			InitializeComponent();			
			tag = element;
			temp_tag = new Elements(tag.Type, tag.Name, tag.Parent);
			temp_tag.Properties_delay = tag.Properties_delay;
			temp_tag.Properties_negated = tag.Properties_negated;
			temp_tag.Properties_setOnly = tag.Properties_setOnly;
			temp_tag.Properties_resetOnly	= tag.Properties_resetOnly;
			temp_tag.Properties_auto_clear	= tag.Properties_auto_clear;
			temp_tag.Properties_value	= tag.Properties_value;
			temp_tag.Properties_value1	= tag.Properties_value1;
			
			Text = string.Format("Type : {0}     Edit Element : {1}", tag.Type, tag.Name);
			
			comboBox_Name.Text = temp_tag.Name;
			
			PreviewElement();
			
			rBnt_Reset.Click += this.Preview_Edit_Tag;
			rBnt_Set.Click += this.Preview_Edit_Tag;
			rBnt_Inverts.Click += this.Preview_Edit_Tag;
			rBnt_Nornal.Click += this.Preview_Edit_Tag;
			
			checkBox_auto_clear.Click += this.Preview_Edit_Tag;
			
			rBnt_Input.Click += this.Preview_Edit_Tag;
			rBnt_Internal_R.Click += this.Preview_Edit_Tag;
			rBnt_Output.Click += this.Preview_Edit_Tag;
			rBnt_Counter_R.Click += this.Preview_Edit_Tag;
			rBnt_Shift_Bit.Click += this.Preview_Edit_Tag;
			
			numeric_Preset.ValueChanged += this.Preview_Nemuric_Edit_Tag;
			numeric_Reset.ValueChanged += this.Preview_Nemuric_Edit_Tag;
			comboBox_Name.TextChanged += this.Preview_Name_Edit_Tag;	
			Preview_Name_Edit_Tag(null,null);
			PreviewElement();
		}
		void PreviewElement()
		{
			rBnt_Output.Visible = false;
			rBnt_Internal_R.Visible = false;
			rBnt_Input.Visible = false;
			rBnt_Counter_R.Visible = false;
			rBnt_Shift_Bit.Visible = false;
			
			rBnt_Reset.Visible = false;
			rBnt_Set.Visible = false;
			label4.Visible = false;
			label_Preset.Visible = false;
			label_Reset.Visible = false;
			
			numericBitValue.Visible = false;
			numeric_Reset.Visible = false;
			numeric_Preset.Visible = false;			
			checkBox_auto_clear.Visible = false;
			
			switch (temp_tag.Type) {
				case TypeTag.COIL:
					rBnt_Output.Visible = true;
					rBnt_Internal_R.Visible = true;
					//rBnt_Input.Visible = false;
					rBnt_Counter_R.Visible = true;
					switch (temp_tag.Name.Substring(0, 1)) {
						case "C":
							rBnt_Nornal.Text = "Counter Up";
							rBnt_Inverts.Text = "Counter Down";
							rBnt_Nornal.Checked = !temp_tag.Properties_negated;
							rBnt_Inverts.Checked = temp_tag.Properties_negated;
							rBnt_Set.Checked = temp_tag.Properties_setOnly;
							rBnt_Reset.Checked = temp_tag.Properties_resetOnly;
							
							break;
						case "R":
						case "Y":
							rBnt_Nornal.Text = "Nornal";
							rBnt_Inverts.Text = "Inverts";
							
							rBnt_Nornal.Checked = !temp_tag.Properties_negated;
							rBnt_Inverts.Checked = temp_tag.Properties_negated;
							rBnt_Set.Checked	= temp_tag.Properties_setOnly;
							rBnt_Reset.Checked = temp_tag.Properties_resetOnly;
							
							break;
					}					
					rBnt_Reset.Visible = true;
					rBnt_Set.Visible = true;
					goto default;
					//break;
				case TypeTag.CONTACTS:
					rBnt_Output.Visible = true;
					rBnt_Internal_R.Visible = true;
					rBnt_Input.Visible = true;
					rBnt_Counter_R.Visible = true;
					rBnt_Shift_Bit.Visible = true;
					switch (temp_tag.Name.Substring(0, 1)) {
						case "C":
							rBnt_Nornal.Checked |= !temp_tag.Properties_negated & temp_tag.Properties_setOnly;
							rBnt_Inverts.Checked |= temp_tag.Properties_negated & temp_tag.Properties_setOnly;
							rBnt_Set.Checked |= !temp_tag.Properties_negated & temp_tag.Properties_resetOnly;
							rBnt_Reset.Checked |= temp_tag.Properties_negated & temp_tag.Properties_resetOnly;
							
							if (rBnt_Nornal.Checked) {
								temp_tag.Properties_negated = false;
								temp_tag.Properties_setOnly = true;
								temp_tag.Properties_resetOnly = false;
							}
							if (rBnt_Inverts.Checked) {
								temp_tag.Properties_negated = true;
								temp_tag.Properties_setOnly = true;
								temp_tag.Properties_resetOnly = false;
							}				
				
							if (rBnt_Set.Checked) {
								temp_tag.Properties_negated = false;
								temp_tag.Properties_setOnly = false;
								temp_tag.Properties_resetOnly = true;
							}
							if (rBnt_Reset.Checked) {
								temp_tag.Properties_negated = true;
								temp_tag.Properties_setOnly = false;
								temp_tag.Properties_resetOnly = true;
							}
							rBnt_Nornal.Text = "UpperQ_NO";
							rBnt_Inverts.Text = "UpperQ_NC";
							rBnt_Set.Text = "LowerQ_NO";
							rBnt_Reset.Text = "LowerQ_NC";
							rBnt_Reset.Visible = true;
							rBnt_Set.Visible = true;
							break;
						case "X":
						case "Y":
						case "R":
							rBnt_Nornal.Text = "NO. (Nornal)";
							rBnt_Inverts.Text = "NC. (Inverts)";
							rBnt_Nornal.Checked = !temp_tag.Properties_negated;
							rBnt_Inverts.Checked = temp_tag.Properties_negated;							
							break;
						case "S":	
							rBnt_Nornal.Text = "NO. (Nornal)";
							rBnt_Inverts.Text = "NC. (Inverts)";
							rBnt_Nornal.Checked = !temp_tag.Properties_negated;
							rBnt_Inverts.Checked = temp_tag.Properties_negated;
							label4.Visible = true;
							numericBitValue.Visible = true;
							
							break;
					}
					goto default;
					//break;
				default:
					switch (temp_tag.Name.Substring(0, 1)) {
						case "X":
							rBnt_Input.Checked = true;
							break;
						case "Y":
							rBnt_Output.Checked = true;
							break;
						case "R":
							rBnt_Internal_R.Checked = true;
							break;
						case "S":
							rBnt_Shift_Bit.Checked = true;
							numericBitValue.Value = temp_tag.Properties_value1;
							break;
						case "C":
							rBnt_Counter_R.Checked = true;
							label_Reset.Visible = true;
							label_Preset.Visible = true;
							numeric_Preset.Visible = true;					
							numeric_Reset.Visible = true;
							checkBox_auto_clear.Visible = true;
							numeric_Preset.Value = temp_tag.Properties_value;					
							numeric_Reset.Value = temp_tag.Properties_value1;
							checkBox_auto_clear.Checked = temp_tag.Properties_auto_clear;
							break;
					}	
					break;
			}	
			CreateListnameelements();
			pictureBox1.Invalidate();
		}
		
		void CreateListnameelements()
		{
			comboBox_Name.TextChanged -= Preview_Name_Edit_Tag;
			comboBox_Name.Items.Clear();
			foreach (Elements element_Temp in Ladder.VariablePLCLib_element) {
				bool addItem = true;
				if (temp_tag.Name.Substring(0, 1) == element_Temp.Name.Substring(0, 1)) {
					foreach (string name in comboBox_Name.Items) {
						if (element_Temp.Name == name) {
							addItem = false;
							break;
						}							
					}
					if (addItem)
						comboBox_Name.Items.Add(element_Temp.Name);
				}
			}
			comboBox_Name.Text = temp_tag.Name;
			comboBox_Name.TextChanged += Preview_Name_Edit_Tag;
		}
		bool Return_Edit_Tag()
		{
			switch (temp_tag.Type) {
				case TypeTag.CONTACTS:					
					if (rBnt_Internal_R.Checked) {
						foreach (Elements tempVar in Ladder.VariablePLCLib_element) {
							if ((tempVar.Name == comboBox_Name.Text) || ("R" == tag.Name.Substring(0, 1))) {
								return (true);
							}
						}
						if (MessageBox.Show("Create Relay Register !", string.Format("Can,n define Relay Register Name:{0} in Ladder Program", temp_tag.Name), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
							return(true);
					}
					if (rBnt_Shift_Bit.Checked) {
						foreach (Elements tempVar in Ladder.VariablePLCLib_element) {
							if (tempVar.Name == comboBox_Name.Text) {
								return (true);
							}
						}
						MessageBox.Show(string.Format("Error no define Shift Register Name:{0} in Ladder Program", temp_tag.Name), "Define Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return(false);
					}
					
					if (rBnt_Input.Checked) {
						foreach (Elements tempVar in Ladder.VariablePLCLib_element) {
							if ((tempVar.Name == comboBox_Name.Text) || ("X" == tag.Name.Substring(0, 1))) {
								return (true);
							}
						}
						if (MessageBox.Show("Create New Input Register !", string.Format("Can,n define Input Register Name:{0} in Ladder Program", temp_tag.Name), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							return(true);
					}
					
					if (rBnt_Output.Checked) {
						foreach (Elements tempVar in Ladder.VariablePLCLib_element) {
							if ((tempVar.Name == comboBox_Name.Text) || ("Y" == tag.Name.Substring(0, 1))) {
								return (true);
							}
						}
						if (MessageBox.Show("Create New Output Register !", string.Format("Can,n define Output Register Name:{0} in Ladder Program", temp_tag.Name), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							return(true);
					}
				
					if (rBnt_Counter_R.Checked) {
						foreach (Elements tempVar in Ladder.VariablePLCLib_element) {
							if (tempVar.Name == comboBox_Name.Text) {
								return (true);
							}
						}
						MessageBox.Show(string.Format("Error no define Counter Register Name:{0} in Ladder Program", temp_tag.Name), "Define Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
						return(false);
					}
					break;
					
				case TypeTag.COIL:
					if (rBnt_Output.Checked) {
						foreach (Elements tempVar in Ladder.VariablePLCLib_element) {
							if ((tempVar.Name == comboBox_Name.Text) || ("Y" == tag.Name.Substring(0, 1))) {
								return (true);
							}
						}
						if (MessageBox.Show("Create Output Register!", string.Format("Can,n define Y Output Register Name:{0} in Ladder Program", temp_tag.Name), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							return(true);
					}
					if (rBnt_Internal_R.Checked) {
						foreach (Elements tempVar in Ladder.VariablePLCLib_element) {
							if ((tempVar.Name == comboBox_Name.Text) || ("R" == tag.Name.Substring(0, 1))) {
								return (true);
							}
						}
						if (MessageBox.Show("Create Relay Register !", string.Format("Can,n define Relay Register Name:{0} in Ladder Program", temp_tag.Name), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							return(true);
					}
			//########################################################################//
			//					COUNTER						#########################//
			
					if (rBnt_Counter_R.Checked) {
						bool findCounter = false;
						foreach (Elements tempVar in Ladder.Element_tags) {
							if(tempVar.Type != TypeTag.COIL)
								continue;
							
							if (tempVar.Name == comboBox_Name.Text) {
								if (tempVar.Properties_resetOnly || tempVar.Properties_setOnly || temp_tag.Properties_resetOnly || temp_tag.Properties_setOnly) {
									findCounter = true;
									continue;
								}								
								
								if ((tempVar.Properties_negated == temp_tag.Properties_negated) & (tempVar != tag)) {
									MessageBox.Show("Define Control Counter in Ladder!", "Error Dupication Counter", MessageBoxButtons.OK, MessageBoxIcon.Error);
									return false;
								}															
								findCounter = true;
							}
						}
						if (findCounter)
							return true;
						if (MessageBox.Show("Create Counter Register !", string.Format("Can,n define Counter Register Name:{0} in Ladder Program", temp_tag.Name), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							return(true);
					}
					break;
			}

			return false;
		}

		void Button2Click(object sender, EventArgs e)
		{	
			DialogResult = DialogResult.Cancel;
			
		}
		void Button1Click(object sender, EventArgs e)
		{
			if (Return_Edit_Tag()) {
				Ladder.SaveStratus = true;			
				//tag.Type = temp_tag.Type;		
				tag.Name = temp_tag.Name;
				tag.Properties_negated = temp_tag.Properties_negated;
				tag.Properties_setOnly = temp_tag.Properties_setOnly;
				tag.Properties_resetOnly = temp_tag.Properties_resetOnly;
				
				tag.Properties_auto_clear = temp_tag.Properties_auto_clear;
				tag.Properties_value = temp_tag.Properties_value;
				tag.Properties_value1 = temp_tag.Properties_value1;
				
				DialogResult = DialogResult.OK;
			}
			
			
		}
		void PictureBox1Paint(object sender, PaintEventArgs e)
		{
			pictureBox1.BackColor = DrawingTags.color_draw_bg;
			var drawPoint = new Point();
			var drawPen	= new Pen(Color.White);
			DrawingTags.Drawtag(temp_tag, e.Graphics, drawPoint, pictureBox1.Width);
			DrawingTags.DrawtagString(temp_tag, e.Graphics, drawPoint, pictureBox1.Width, 1);
		}
		
		void Preview_Name_Edit_Tag(object sender, EventArgs e)
		{
			if (comboBox_Name.Text == "")
				return;
			comboBox_Name.TextChanged -= Preview_Name_Edit_Tag;
			
			if (rBnt_Input.Checked & comboBox_Name.Text.Substring(0, 1) != "X")
				comboBox_Name.Text = "X" + comboBox_Name.Text;
			if (rBnt_Output.Checked & comboBox_Name.Text.Substring(0, 1) != "Y")
				comboBox_Name.Text = "Y" + comboBox_Name.Text;
			if (rBnt_Internal_R.Checked & comboBox_Name.Text.Substring(0, 1) != "R")
				comboBox_Name.Text = "R" + comboBox_Name.Text;
			if (rBnt_Counter_R.Checked & comboBox_Name.Text.Substring(0, 1) != "C")
				comboBox_Name.Text = "C" + comboBox_Name.Text;
			if (rBnt_Shift_Bit.Checked & comboBox_Name.Text.Substring(0, 1) != "S")
				comboBox_Name.Text = "S" + comboBox_Name.Text;
							
			temp_tag.Name = comboBox_Name.Text;
			if (comboBox_Name.Text.Substring(0, 1) == "C") {
				foreach (Elements TempVer in Ladder.VariablePLCLib_element) {
					if (comboBox_Name.Text != tag.Name)
					if (TempVer.Type == TypeTag.COIL)
					if (comboBox_Name.Text == TempVer.Name) {
						temp_tag.Properties_value = TempVer.Properties_value;						
						temp_tag.Properties_value1 = TempVer.Properties_value1;
					}
				}
			}
			
			PreviewElement();
			comboBox_Name.Select(comboBox_Name.Text.Length, 0);	
			
			comboBox_Name.TextChanged += Preview_Name_Edit_Tag;
		}
		void Preview_Edit_Tag(object sender, EventArgs e)
		{
			var radioButton = sender as RadioButton;
			if (radioButton != null) {
				if (!(radioButton.Checked))
					return;						
				switch (radioButton.Name) {
					case "rBnt_Input":
						if (temp_tag.Type == TypeTag.CONTACTS) {
							temp_tag.Name = "X" + temp_tag.Name.Substring(1);
						}
						if (temp_tag.Type == TypeTag.COIL) {
							
						}
						break;
					case "rBnt_Output":
						if (temp_tag.Type == TypeTag.CONTACTS) {
							temp_tag.Name = "Y" + temp_tag.Name.Substring(1);
						}
						if (temp_tag.Type == TypeTag.COIL) {
							temp_tag.Name = "Y" + temp_tag.Name.Substring(1);
						}
						break;		
					case "rBnt_Counter_R":
						if (temp_tag.Type == TypeTag.CONTACTS) {
							temp_tag.Name = "C" + temp_tag.Name.Substring(1);
						}
						if (temp_tag.Type == TypeTag.COIL) {
							temp_tag.Name = "C" + temp_tag.Name.Substring(1);
						}
						break;	
					case "rBnt_Internal_R":
						if (temp_tag.Type == TypeTag.CONTACTS) {
							temp_tag.Name = "R" + temp_tag.Name.Substring(1);
						}
						if (temp_tag.Type == TypeTag.COIL) {
							temp_tag.Name = "R" + temp_tag.Name.Substring(1);
						}
						break;	
					case "rBnt_Shift_Bit":
						if (temp_tag.Type == TypeTag.CONTACTS) {
							temp_tag.Name = "S" + temp_tag.Name.Substring(1);
						}
						if (temp_tag.Type == TypeTag.COIL) {
							
						}
						break;		

					case "rBnt_Nornal":
						if (temp_tag.Type == TypeTag.CONTACTS) {
							switch (temp_tag.Name.Substring(0, 1)) {
								case "X":
								case "Y":
								case "R":
								case "S":	
									temp_tag.Properties_negated = false;
									break;
								case "C":
									temp_tag.Properties_negated = false;
									temp_tag.Properties_setOnly = true;
									temp_tag.Properties_resetOnly = false;
									break;
							}
						}
						if (temp_tag.Type == TypeTag.COIL) {
							switch (temp_tag.Name.Substring(0, 1)) {
								case "Y":
								case "R":	
								case "C":
									temp_tag.Properties_negated = false;
									temp_tag.Properties_setOnly = false;
									temp_tag.Properties_resetOnly = false;
									break;
							}
						}
						break;	
						
					case "rBnt_Inverts":
						if (temp_tag.Type == TypeTag.CONTACTS) {
							switch (temp_tag.Name.Substring(0, 1)) {
								case "X":
								case "Y":
								case "R":
								case "S":	
									temp_tag.Properties_negated = true;
									break;
								case "C":
									temp_tag.Properties_negated = true;
									temp_tag.Properties_setOnly = true;
									temp_tag.Properties_resetOnly = false;
									
									break;
							}
						}
						if (temp_tag.Type == TypeTag.COIL) {
							switch (temp_tag.Name.Substring(0, 1)) {
								case "Y":
								case "R":
								case "C":
									temp_tag.Properties_negated = true;									
									temp_tag.Properties_setOnly = false;
									temp_tag.Properties_resetOnly = false;
									break;
							}
						}
						break;	
						
					case "rBnt_Set":
						if (temp_tag.Type == TypeTag.CONTACTS) {
							switch (temp_tag.Name.Substring(0, 1)) {
								case "C":
									temp_tag.Properties_negated = false;
									temp_tag.Properties_setOnly = false;
									temp_tag.Properties_resetOnly = true;
									
									break;
							}
						}
						if (temp_tag.Type == TypeTag.COIL) {
							switch (temp_tag.Name.Substring(0, 1)) {
								case "Y":
								case "R":
								case "C":
									temp_tag.Properties_negated = false;
									temp_tag.Properties_setOnly = true;
									temp_tag.Properties_resetOnly = false;
									break;
							}
						}
						break;
						
					case "rBnt_Reset":
						if (temp_tag.Type == TypeTag.CONTACTS) {
							switch (temp_tag.Name.Substring(0, 1)) {
								case "C":
									temp_tag.Properties_negated = true;
									temp_tag.Properties_setOnly = false;
									temp_tag.Properties_resetOnly = true;
									
									break;
							}
						}
						if (temp_tag.Type == TypeTag.COIL) {
							switch (temp_tag.Name.Substring(0, 1)) {
								case "Y":
								case "R":
								case "C":
									temp_tag.Properties_negated = false;
									temp_tag.Properties_setOnly = false;
									temp_tag.Properties_resetOnly = true;
									break;
							}
						}
						break;
				}		
				
			} 
			var checkBox = sender as CheckBox;
			if (checkBox != null) {
				if(checkBox.Name == "checkBox_auto_clear"){
					temp_tag.Properties_auto_clear = checkBox.Checked;
				}
			} 
			PreviewElement();
			return;
		}

		void Preview_Nemuric_Edit_Tag(object sender, EventArgs e)
		{
			numeric_Preset.ValueChanged -= Preview_Nemuric_Edit_Tag;
			if (numeric_Reset.Value > numeric_Preset.Value) {
				numeric_Reset.Value = numeric_Preset.Value;
			}
			
			temp_tag.Properties_value = (int)numeric_Preset.Value;
			temp_tag.Properties_value1 = (int)numeric_Reset.Value;
			PreviewElement();
			
			numeric_Preset.ValueChanged += Preview_Nemuric_Edit_Tag;
		}
		void ComboBox_NameKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				Preview_Name_Edit_Tag(sender, e);
				//if (Return_Edit_Tag())
				Button1Click(sender, e);
			}
		}
		void NumericBitValueValueChanged(object sender, EventArgs e)
		{
			temp_tag.Properties_value1 = (int)numericBitValue.Value;
		}

	}
}
