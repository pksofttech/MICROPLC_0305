/*
  plcLib Version 1.1.0, last updated 16 May, 2015.
  
  A simple Programmable Logic Controller (PLC) library for the
  Arduino and compatibles.

  Author:    W. Ditch
  Publisher: www.electronics-micros.com

  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU General Public License as published by
  the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU General Public License for more details, available from:
  <http://www.gnu.org/licenses/>
*/

#include "Arduino.h"
#include "plcLib.h"

unsigned int scanValue;
unsigned int MasterscanValue;
unsigned long scanTimeValue;
unsigned long _scanTimeValue;
boolean ioChang = false; 
unsigned int test = 0;
String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete

// Define default pin directions and initial output levels.
void setupPLC() {
#if defined(ARDUINO_AVR_PLC_DECA)
  // initialize serial:
  Serial.begin(9600);
  // reserve 200 bytes for the inputString:
 // inputString.reserve(200);
  
 #endif
}
#if defined(ARDUINO_AVR_PLC_DECA)
void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
    // add it to the inputString:
    inputString += inChar;
    // if the incoming character is a newline, set a flag
    // so the main loop can do something about it:
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}
#endif
void loop_plc() {
#if defined(ARDUINO_AVR_PLC_DECA)
    // print the string when a newline arrives:
  if (stringComplete) {
  if(inputString =="chks\n")
    Serial.println("\"MICRO PLC DECA");
	Serial.println("By Pk Softtech");
	Serial.println("Base Arduino Mega2560\"");
    // clear the string:
    inputString = "";
    stringComplete = false;	
  }
  
  if(ioChang) {
	ioChang = false;
	Serial.print("\f");
	Serial.println("\':"+ String(PINA,HEX) +":"+ String(PINB,HEX) +":"+ String(PINC,HEX) +":"+ String(PIND,HEX) +":"+ String(PINE,HEX) +":"+ String(PINF,HEX) +":"+ String(PING,HEX) +":"+ String(PINH,HEX) +":"+ String(PINJ,HEX) +":"+ String(PINK,HEX) +":"+ String(PINL,HEX) + "\'");
	Serial.println("\'\n\r Micro_Time " + String((scanTimeValue - _scanTimeValue)) + "\'");
	_scanTimeValue = scanTimeValue;

  }
 #endif
}

// #############	MOdifile By PksofttecH #####################//

// compare an auxiliary compare
unsigned int compare_(unsigned int input1,unsigned int input2,unsigned int function_code) {
	unsigned int retValue = 0; 
	switch(function_code){
		case 0 :
			if (input1 == input2)
				retValue = 1;
		break;
		case 1 :
			if (input1 != input2)
				retValue = 1;
		break;
		case 2 :
			if (input1 > input2)
				retValue = 1;
		break;
		case 3 :
			if (input1 < input2)
				retValue = 1;
		break;
		case 4 :
			if (input1 >= input2)
				retValue = 1;
		break;
		case 5 :
			if (input1 <= input2)
				retValue = 1;
		break;
	}
	return(retValue);
}
// compare an auxiliary compare
unsigned int compare_(int input1,unsigned int input2,unsigned int function_code) {
	unsigned int retValue = 0; 
	switch(function_code){
		case 0 :
			if (input1 == input2)
				retValue = 1;
		break;
		case 1 :
			if (input1 != input2)
				retValue = 1;
		break;
		case 2 :
			if (input1 > input2)
				retValue = 1;
		break;
		case 3 :
			if (input1 < input2)
				retValue = 1;
		break;
		case 4 :
			if (input1 >= input2)
				retValue = 1;
		break;
		case 5 :
			if (input1 <= input2)
				retValue = 1;
		break;
	}
	return(retValue);
}
unsigned int compare(unsigned int &input1,unsigned int input2,unsigned int function_code) {
	return(compare_(input1,input2,function_code));
}
unsigned int compare(int &input1,unsigned int input2,unsigned int function_code) {
	return(compare_(input1,input2,function_code));
}
unsigned int compare(int &input1, int input2,unsigned int function_code) {
	return(compare_(input1,input2,function_code));
	}
	
unsigned int compare(int &input1,char input2,unsigned int function_code) {
	return(compare_(input1,input2,function_code));
}

 unsigned int compare(Counter &input1,unsigned int input2,unsigned int function_code) {
 	return(compare_(input1.count(),input2,function_code));
 }
 
 unsigned int compare(Counter &input1,Counter &input2,unsigned int function_code) {
 	return(compare_(input1.count(),input2.count(),function_code));
 }
 
unsigned int OSR(unsigned int &_osr) {
	if (scanValue != _osr) {		// Rising or falling edge detected
		if (scanValue == 1) {		// Rising edge detected
			_osr = 1;				// Pulse input tracker = 1
		}
		else {						// Falling edge detectede
			_osr = 0;				// Pulse input tracker = 0
		}
	}
	else {							// No change detected
		scanValue = 0;				// Set scanValue detect values to zero
	}
 	return(scanValue);
 }

 unsigned int OSF(unsigned int &_osf) {
	if (scanValue != _osf) {		// Rising or falling edge detected
		if (scanValue == 1) {		// Rising edge detected
			_osf = 1;				// Pulse input tracker = 1
			scanValue = 0;
		}
		else {						// Falling edge detectede
			_osf = 0;				// Pulse input tracker = 0
			scanValue = 1;
		}
	}
	else {							// No change detected
		scanValue = 0;				// Set scanValue detect values to zero
	}
	return(scanValue);
 }

unsigned int _short() {
	return(scanValue);
}
unsigned int _open() {
	scanValue = 0;
	return(scanValue);
}


//###########################END OF PK MODIFY###################################//

unsigned int inplc(unsigned int &variable,int input) {
	int buffread = digitalRead(input);
	if(variable != buffread){
		variable = buffread;
		ioChang = true;
		return(1);
		}else{
		return(0);
	}	
}
unsigned int inplcNot(unsigned int &variable,int input) {
	int buffread = ~digitalRead(input);
	if(variable != buffread){
		variable = buffread;
		ioChang = true;
		return(1);
		}else{
		return(0);
	}	
}
unsigned int outplc(unsigned int &variable,int output) {

	int buffread = digitalRead(output);
	if(variable != buffread){
		if (variable == 1) {
			digitalWrite(output, HIGH);
		}else {
			digitalWrite(output, LOW);
		}
		ioChang = true;
		return(1);
	}else{
		return(0);
	}	
}
unsigned int outplcNot(unsigned int &variable,int output) {

	int buffread = ~digitalRead(output);
	if(variable != buffread){
		if (variable != 1) {
			digitalWrite(output, HIGH);
		}else {
			digitalWrite(output, LOW);
		}
		ioChang = true;
		return(1);
	}else{
		return(0);
	}	
}
// Read an input pin (pin number supplied as integer)
unsigned int in(int input) {
	scanValue = digitalRead(input);
	return(scanValue);
}

// Read an auxiliary input (variable supplied as unsigned integer)
unsigned int in(unsigned int input) {
	scanValue = input;
	return(scanValue);
}

// Read an auxiliary input (variable supplied as unsigned integer)
unsigned int ld(unsigned int input) {
	scanValue &= input & MasterscanValue;
	return(scanValue);
}

// Read an variable input (variable supplied as unsigned integer)
unsigned int _contrac(unsigned int input) {
	scanValue &= input;
	return(scanValue);
}
unsigned int _contracNot(unsigned int input) {
	scanValue &= ~input;
	return(scanValue);
}

 //Read Analog Value input to variable (variable supplied as integer)
unsigned int _adc(unsigned int &variable, int apin) {
	if (scanValue == 1) {
		variable = analogRead(apin);			
	}
	return(scanValue);
}

 //Move Value input to variable (variable supplied as integer)
unsigned int _move( int &variable, int value) {
	if (scanValue == 1) {
		variable = value;
	}
	return(scanValue);
}

 //Move Value input to Shift variable (variable supplied as unsigned integer)
unsigned int _move(Shift shift,unsigned int value) {
	if (scanValue == 1) {
		shift.shiftSet(value);
	}
	return(scanValue);
}

 //Move Value input to Counter variable (variable supplied as unsigned integer)
unsigned int _move(Counter counter,unsigned int value) {
	if (scanValue == 1) {
		counter.set(value);
	}
	return(scanValue);
}

unsigned int _add( int &destination ,int variable, int value) {
	if (scanValue == 1) {
		destination = variable + value;
	}
	return(scanValue);
}
unsigned int _add(Counter counter,int variable, int value) {
	if (scanValue == 1) {
		counter.set(variable + value);
	}
	return(scanValue);
}

unsigned int _sub( int &destination ,int variable, int value) {
	if (scanValue == 1) {
		destination = variable - value;
	}
	return(scanValue);
}
unsigned int _sub(Counter counter,int variable, int value) {
	if (scanValue == 1) {
		counter.set(variable - value);
	}
	return(scanValue);
}

unsigned int _mup( int &destination ,int variable, int value) {
	if (scanValue == 1) {
		destination = variable * value;
	}
	return(scanValue);
}
unsigned int _div( int &destination ,int variable, int value) {
	if (scanValue == 1) {
		destination = variable / value;
	}
	return(scanValue);
}
unsigned int _mod( int &destination ,int variable, int value) {
	if (scanValue == 1) {
		destination = variable % value;
	}
	return(scanValue);
}
//unsigned int move( int &variable, int &_variable) {
//	if (scanValue == 1) {
//		variable = _variable;
//	}
//	return(scanValue);
//}

// Read an auxiliary input (variable supplied as unsigned long)
unsigned int in(unsigned long input) {
	scanValue = input;
	return(scanValue);
}

// Read an inverted input (pin number supplied as integer)
unsigned int inNot(int input) {
	if (digitalRead(input) == 1) {
		scanValue = 0;
	}
	else {
		scanValue = 1;
	}
	return(scanValue);
}
// Read an inverted auxiliary input (variable supplied as unsigned integer)
unsigned int ldNot(unsigned int input) {
	scanValue &= ~input & MasterscanValue;
	
	return(scanValue);
}
// Read an inverted auxiliary input (variable supplied as unsigned integer)
unsigned int inNot(unsigned int input) {
	if (input == 1) {
		scanValue = 0;
	}
	else {
		scanValue = 1;
	}
	return(scanValue);
}

// Read an inverted auxiliary input (variable supplied as unsigned long)
unsigned int inNot(unsigned long input) {
	if (input == 1) {
		scanValue = 0;
	}
	else {
		scanValue = 1;
	}
	return(scanValue);
}
// Read an analogue input (input pin supplied as an integer)
unsigned int inAnalog(int input) {
	scanValue = analogRead(input);
	return(scanValue);
}

// Read an analogue auxiliary value (variable supplied as an unsigned integer)
unsigned int inAnalog(unsigned int input) {
	scanValue = input;
	return(scanValue);
}

// Read an analogue auxiliary value (variable supplied as an unsigned long)
unsigned int inAnalog(unsigned long input) {
	scanValue = input;
	return(scanValue);
}

// Output to an output pin
unsigned int out(int output) {
	if (scanValue == 1) {
		digitalWrite(output, HIGH);
	}
	else {
		digitalWrite(output, LOW);
	}
	return(scanValue);
}

// Output to an auxiliary variable (variable type = unsigned integer)
unsigned int out(unsigned int &output) {
	if (scanValue == 1) {
		output = 1;
	}
	else {
		output = 0;
	}
	return(scanValue);
}

// Output to an auxiliary variable (variable type = unsigned long)
void _coil(unsigned int &output) {
	if (scanValue == 1) {
		output = 1;
	}
	else {
		output = 0;
	}
	//return(scanValue);
}
void _coilNot(unsigned int &output) {
	if (scanValue == 0) {
		output = 1;
	}
	else {
		output = 0;
	}
	//return(scanValue);
}
// Output to an output pin (inverted)
unsigned int outNot(int output) {
	if (scanValue == 1) {
		digitalWrite(output, LOW);
	}
	else {
		digitalWrite(output, HIGH);
	}
	return(scanValue);
}

// Output to an auxiliary variable (inverted) (variable type = unsigned integer)
unsigned int outNot(unsigned int &output) {
	if (scanValue == 1) {
		output = 0;
	}
	else {
		output = 1;
	}
	return(scanValue);
}

// Output to an auxiliary variable (inverted) (variable type = unsigned long)
unsigned int outNot(unsigned long &output) {
	if (scanValue == 1) {
		output = 0;
	}
	else {
		output = 1;
	}
	return(scanValue);
}

// Output a PWM value to an output pin (scanValue in range 0-1023)
unsigned int outPWM(int output) {
	analogWrite(output, scanValue / 4);
	return(scanValue);
}

// AND scanValue with input (pin number supplied as integer)
unsigned int andBit(int input) {
	scanValue = scanValue & digitalRead(input);
	return(scanValue);
}

// AND scanValue with auxiliary variable (variable supplied as unsigned integer)
unsigned int andBit(unsigned int input) {
	scanValue = scanValue & input;
	return(scanValue);
}

// AND scanValue with auxiliary variable (variable supplied as unsigned long)
unsigned int andBit(unsigned long input) {
	scanValue = scanValue & input;
	return(scanValue);
}

// AND scanValue with inverted input (pin number supplied as integer)
unsigned int andNotBit(int input) {
	scanValue = scanValue & ~digitalRead(input);
	return(scanValue);
}

// AND scanValue with inverted auxiliary variable (variable supplied as unsigned integer)
unsigned int andNotBit(unsigned int input) {
	scanValue = scanValue & ~input;
	return(scanValue);
}

// AND scanValue with inverted auxiliary variable (variable supplied as unsigned long)
unsigned int andNotBit(unsigned long input) {
	scanValue = scanValue & ~input;
	return(scanValue);
}

// OR scanValue with input (pin number supplied as integer)
unsigned int orBit(int input) {
	scanValue = scanValue | digitalRead(input);
	return(scanValue);
}

// OR scanValue with auxiliary variable (variable supplied as unsigned integer)
unsigned int orBit(unsigned int input) {
	scanValue = scanValue | input;
	return(scanValue);
}

// OR scanValue with auxiliary variable (variable supplied as unsigned long)
unsigned int orBit(unsigned long input) {
	scanValue = scanValue | input;
	return(scanValue);
}

// OR scanValue with inverted input (pin number supplied as integer)
unsigned int orNotBit(int input) {
	if (scanValue == 1) {
	}
	else {
		if (digitalRead(input) == 0) {
			scanValue = 1;
		}
		else {
			scanValue = 0;
		}
	}
	return(scanValue);
}

// OR scanValue with inverted auxiliary variable (variable supplied as unsigned integer)
unsigned int orNotBit(unsigned int input) {
	if (scanValue == 1) {
	}
	else {
		if (input == 0) {
			scanValue = 1;
		}
		else {
			scanValue = 0;
		}
	}
	return(scanValue);
}

// OR scanValue with inverted auxiliary variable (variable supplied as unsigned long)
unsigned int orNotBit(unsigned long input) {
	if (scanValue == 1) {
	}
	else {
		if (input == 0) {
			scanValue = 1;
		}
		else {
			scanValue = 0;
		}
	}
	return(scanValue);
}

// XOR scanValue with input (pin number supplied as integer)
unsigned int xorBit(int input) {
	scanValue = scanValue ^ digitalRead(input);
	return(scanValue);
}

// XOR scanValue with auxiliary variable (variable supplied as unsigned integer)
unsigned int xorBit(unsigned int input) {
	scanValue = scanValue ^ input;
	return(scanValue);
}

// XOR scanValue with auxiliary variable (variable supplied as unsigned long)
unsigned int xorBit(unsigned long input) {
	scanValue = scanValue ^ input;
	return(scanValue);
}

// Set - Reset latch (output and reset pin numbers supplied as integers)
unsigned int latch(int output, int reset) {
	scanValue = scanValue | digitalRead(output);		// Self latch by ORing with Output pin (Q)
	scanValue = scanValue & ~digitalRead(reset);		// AND-Not with Reset Pin
	if (scanValue == 1) {
		digitalWrite(output, HIGH);
	}
	else {
		digitalWrite(output, LOW);
	}
	return(scanValue);
}

// Set - Reset latch (output pin number supplied as integer, reset as unsigned integer variable)
unsigned int latch(int output, unsigned int reset) {
	scanValue = scanValue | digitalRead(output);		// Self latch by ORing with Output pin (Q)
	scanValue = scanValue & ~reset;						// AND-Not with Reset variable
	if (scanValue == 1) {
		digitalWrite(output, HIGH);
	}
	else {
		digitalWrite(output, LOW);
	}
	return(scanValue);
}

// Set - Reset latch (output pin number supplied as integer, reset as unsigned long variable)
unsigned int latch(int output, unsigned long reset) {
	scanValue = scanValue | digitalRead(output);		// Self latch by ORing with Output pin (Q)
	scanValue = scanValue & ~reset;						// AND-Not with Reset variable
	if (scanValue == 1) {
		digitalWrite(output, HIGH);
	}
	else {
		digitalWrite(output, LOW);
	}
	return(scanValue);
}

// Set - Reset latch (output as unsigned integer variable and reset pin as integer)
unsigned int latch(unsigned int &output, int reset) {
	scanValue = scanValue | output;						// Self latch by ORing with Output pin (Q)
	scanValue = scanValue & ~digitalRead(reset);		// AND-Not with Reset Pin
	if (scanValue == 1) {
		output = 1;
	}
	else {
		output = 0;
	}
	return(scanValue);
}

// Set - Reset latch (output as unsigned long variable and reset pin as integer)
unsigned int latch(unsigned long &output, int reset) {
	scanValue = scanValue | output;						// Self latch by ORing with Output pin (Q)
	scanValue = scanValue & ~digitalRead(reset);		// AND-Not with Reset Pin
	if (scanValue == 1) {
		output = 1;
	}
	else {
		output = 0;
	}
	return(scanValue);
}

// Set - Reset latch (output and reset values are unsigned integer auxiliary variables)
unsigned int latch(unsigned int &output, unsigned int reset) {
	scanValue = scanValue | output;				// Self latch by ORing with Output variable (Q)
	scanValue = scanValue & ~reset;				// AND-Not with Reset variable
	if (scanValue == 1) {
		output = 1;
	}
	else {
		output = 0;
	}
	return(scanValue);
}

// Set - Reset latch (output and reset values are unsigned long auxiliary variables)
unsigned int latch(unsigned long &output, unsigned long reset) {
	scanValue = scanValue | output;				// Self latch by ORing with Output variable (Q)
	scanValue = scanValue & ~reset;				// AND-Not with Reset variable
	if (scanValue == 1) {
		output = 1;
	}
	else {
		output = 0;
	}
	return(scanValue);
}

unsigned int timerOn(unsigned long &timerState, unsigned int timerPeriod) {
	if (scanValue == 0) {									// timer is disabled
		timerState = 0;										// Clear timerState (0 = 'not started')
	}
	else {													// Timer is enabled
		if (timerState == 0) {								// Timer hasn't started counting yet
			timerState = millis();							// Set timerState to current time in milliseconds
			scanValue = 0;									// Result = 'not finished' (0)
		}
		else {												// Timer is active and counting
			if (millis() > (timerState + timerPeriod)) {	// Timer has finished
				scanValue = 1;								// Result = 'finished' (1)
			}
			else {											// Timer has not finished
				scanValue = 0;								// Result = 'not finished' (0)
			}
		}
	}
	return(scanValue);										// Return result (1 = 'finished',
                                                            // 0 = 'not started' / 'not finished')
}

unsigned int timerPulse(unsigned int &timerState, unsigned int timerPeriod) {
	if (scanValue == 1 || timerState != 0){					// Timer is enabled
		if (timerState == 0) {								// Timer hasn't started counting yet
			timerState = scanTimeValue;							// Set timerState to current time in milliseconds
			scanValue = 1;									// Pulse = 'Active' (1)
		}
		else {												// Timer is active and counting
			if (scanTimeValue > (timerState + timerPeriod)) {	// Timer has finished
			    if (scanValue == 0) {                       // Finished AND trigger is low
				    timerState = 0;							// Re-enabled timer
					scanValue = 0;							// Pulse = 'finished' (0)
				}
				else {                                      // Finished but trigger is still high
					scanValue = 0;                          // Wait for trigger to go low before re-enabling
				}
			}
			else {											// Timer has not finished
				scanValue = 1;								// Pulse = 'Active' (1)
			}
		}
	}
	return(scanValue);										// Return result (1 = 'active',
															// 0 = 'not started' / 'not yet re-enabled')
}

unsigned int timerOff(unsigned long &timerState, unsigned int timerPeriod) {
	if (scanValue == 0) {									// Timer input is off (scanValue = 0)											// Timer is active and counting
		if (scanTimeValue > (timerState + timerPeriod)) {	// Timer has finished
			scanValue = 0;								// Result = 'turn-off delay finished' (0)
		}else {											// Timer has not finished
			scanValue = 1;								// Result = 'turn-off delay not finished' (1)
		}
	}else {													// Timer input is high (scanValue = 1)
		timerState = scanTimeValue;								// Set timerState to current time in milliseconds
	}
	return(scanValue);										// Return result (1 = 'pulse On' / 'turn-off delay in progress',
															// 0 = 'not started' / 'finished')
}

unsigned int timerCycle(unsigned long &timer1State, unsigned int timer1Period, unsigned long &timer2State, unsigned int timer2Period) {
	if (scanValue == 0) {									// Enable input is off (scanValue = 0)
		timer2State = 0;									// Ready to start LOW pulse period when enabled
		timer1State = 1;
	}
	else {													// Enabled
		if (timer2State == 0) {								// Low pulse Active
			if (timer1State == 1) {							// LOW pulse period starting
				timer1State = scanTimeValue;						// Set timerState to current time in milliseconds
			}
			else if (scanTimeValue > (timer1State + timer1Period)) {	// Low pulse period has finished
				timer1State = 0;	
				timer2State = 1;							// Ready to start HIGH pulse period
			}
			scanValue = 0;									// Result = 'Pulse LOW' (0)
		}
		if (timer1State == 0) {								// High pulse Active
			if (timer2State == 1) {							// HIGH pulse period starting
				timer2State = scanTimeValue;						// Set timerState to current time in milliseconds
			}
			else if (scanTimeValue > (timer2State + timer2Period)) {	// High pulse has finished
				timer2State = 0;	
				timer1State = 1;							// Ready to start LOW pulse period
			}
			scanValue = 1;									// Result = 'Pulse HIGH' (1)
		}
	}
	return(scanValue);
}

// Test whether an analogue input is greater than a second analogue input
unsigned int compareGT(int input) {
	if (scanValue > analogRead(input)) {
		scanValue = 1;
	}
	else {
		scanValue = 0;
	}
	return(scanValue);
}

// Test whether an analogue input is greater than a fixed unsigned int value
unsigned int compareGT(unsigned int input) {
	if (scanValue > input) {
		scanValue = 1;
	}
	else {
		scanValue = 0;
	}
	return(scanValue);
}

// Test whether an analogue input is greater than a fixed unsigned long value
unsigned int compareGT(unsigned long input) {
	if (scanValue > input) {
		scanValue = 1;
	}
	else {
		scanValue = 0;
	}
	return(scanValue);
}

// Test whether an analogue input is less than a second analogue input
unsigned int compareLT(int input) {
	if (scanValue < analogRead(input)) {
		scanValue = 1;
	}
	else {
		scanValue = 0;
	}
	return(scanValue);
}

// Test whether an analogue input is less than a fixed unsigned int value
unsigned int compareLT(unsigned int input) {
	if (scanValue < input) {
		scanValue = 1;
	}
	else {
		scanValue = 0;
	}
	return(scanValue);
}

// Test whether an analogue input is less than a fixed unsigned long value
unsigned int compareLT(unsigned long input) {
	if (scanValue < input) {
		scanValue = 1;
	}
	else {
		scanValue = 0;
	}
	return(scanValue);
}

// Set a latched output (output pin number supplied as integer)
unsigned int set(int output) {
	scanValue = scanValue | digitalRead(output);		// Self latch by ORing with Output pin
	if (scanValue == 1) {
		digitalWrite(output, HIGH);
	}
	return(scanValue);
}

// Set a latched output (variable supplied as unsigned integer)
unsigned int set(unsigned int &output) {
	scanValue = scanValue | output;		// Self latch by ORing with Output pin
	if (scanValue == 1) {
		output = 1;
	}
	return(scanValue);
}

// Set a latched output (variable supplied as unsigned long)
unsigned int set(unsigned long &output) {
	scanValue = scanValue | output;		// Self latch by ORing with Output pin
	if (scanValue == 1) {
		output = 1;
	}
	return(scanValue);
}

// reset (or clear) a latched output (output pin number supplied as integer)
unsigned int reset(int output) {
	if (scanValue == 1) {
		digitalWrite(output, LOW);
	}
	return(scanValue);
}

// reset (or clear) a latched output (variable supplied as unsigned integer)
unsigned int reset(unsigned int &output) {
	if (scanValue == 1) {
		output = 0;
	}
	return(scanValue);
}

// reset (or clear) a latched output (variable supplied as unsigned long)
unsigned int reset(unsigned long &output) {
	if (scanValue == 1) {
		output = 0;
	}
	return(scanValue);
}




// Up, down, or up-down counter
Counter::Counter(unsigned int pv)	// Counter constructor method
{									// (Default values are for an up counter)
	_pv = pv;						// Set preset value using supplied parameter
	_ct = 0;						// Running count = zero
	_uQ = 0;						// Up counter upper Q output = 0
	_lQ = 1;						// Down counter lower Q output = 1
	_ctUpEdge = 0;					// Prepare rising edge detect for up counter
	_ctDownEdge = 0;				// Prepare rising edge detect for down counter
}
Counter::Counter(unsigned int pv,unsigned int rv)	// Counter constructor method
{									// (Default values are for an up counter)
	_pv = pv;	
	_rv = rv;				// Set preset value using supplied parameter
	_ct = rv;						// Running count = zero
	_uQ = 0;						// Up counter upper Q output = 0
	_lQ = 0;						// Down counter lower Q output = 1
	_ctUpEdge = 0;					// Prepare rising edge detect for up counter
	_ctDownEdge = 0;				// Prepare rising edge detect for down counter
}
/**
 *Counter::Counter(unsigned int pv, unsigned int direction)	// Counter constructor method
 *{									// (Second parameter sets default direction)
 *	_pv = pv;						// Set preset value using supplied parameter
 *	if(direction == 0){				// Set start values for an up counter
 *		_ct = _rv;					// Running count = zero
 *		_uQ = 0;					// Up counter upper Q output = 0
 *		_lQ = 1;					// Down counter lower Q output = 1
 *	}
 *	else {							// Set start values for a down counter
 *		_ct = _pv;					// Running count = preset value
 *		_uQ = 1;					// Up counter upper Q output = 1
 *		_lQ = 0;					// Down counter lower Q output = 0
 *	}
 *	_ctUpEdge = 0;					// Prepare rising edge detect for up counter
 *	_ctDownEdge = 0;				// Prepare rising edge detect for down counter
 *}
 */


unsigned int Counter::presetValue()	// Return preset value method
{
	return(_pv);					// Return preset value
}	

void Counter::set(unsigned int value)				// Clear counter method
{
	if(scanValue == 1) {			// Enabled if scanValue = 1
		_ct = value;					// Running count = 0
		_uQ = 0;					// Up counter upper Q output = 0
		_lQ = 1;					// Down counter lower Q output = 1
		_ctUpEdge = 0;				// Prepare rising edge detect for up counter
		_ctDownEdge = 0;			// Prepare rising edge detect for down counter
	}
}

void Counter::clear()				// Clear counter method
{
	if(scanValue == 1) {			// Enabled if scanValue = 1
		_ct = 0;					// Running count = 0
		_uQ = 0;					// Up counter upper Q output = 0
		_lQ = 1;					// Down counter lower Q output = 1
		_ctUpEdge = 0;				// Prepare rising edge detect for up counter
		_ctDownEdge = 0;			// Prepare rising edge detect for down counter
	}
}

void Counter::preset()				// Preset counter method
{
	if(scanValue == 1) {			// Enabled if scanValue = 1
		_ct = _pv;					// Running count = preset value
		_uQ = 1;					// Up counter upper Q output = 1
		_lQ = 0;					// Down counter lower Q output = 0
		_ctUpEdge = 0;				// Prepare rising edge detect for up counter
		_ctDownEdge = 0;			// Prepare rising edge detect for down counter
	}
}
void Counter::reset()				// Preset counter method
{
	if(scanValue == 1) {			// Enabled if scanValue = 1
		_ct = _rv;					// Running count = _rv
		_uQ = 0;					// Up counter upper Q output = 0
		_lQ = 1;					// Down counter lower Q output = 1
		_ctUpEdge = 0;				// Prepare rising edge detect for up counter
		_ctDownEdge = 0;			// Prepare rising edge detect for down counter
	}
}
unsigned int Counter::upperQ()		// Read up counter upper Q output method
{
	/**
	 *if (_uQ == 1){					// Set scanValue = 1 if upper Q = 1
	 *	scanValue = 1;
	 *}
	 *else {
	 *	scanValue = 0;				// Otherwise set scanValue = 0
	 *}
	 */

	return(_uQ);					// Return upper Q value
}

unsigned int Counter::lowerQ()		// Read down counter lower Q output method
{
	/**
	 *if (_lQ == 1){					// Set scanValue = 1 if lower Q = 1
	 *	scanValue = 1;
	 *}
	 *else {
	 *	scanValue = 0;				// Otherwise set scanValue = 0
	 *}
	 */

	return(_lQ);					// Return lower Q value
}

unsigned int Counter::count()		// Return current count value method
{
	return(_ct);					// Return count value
}
/**
 *void Counter::countUp()				// Count up method
 *{
 *	if (_ct <= _pv) {      			// Not yet finished counting so continue
 *		if (scanValue == 0) {		// clock = 0 so clear counter edge detect
 *			_ctUpEdge = 0;
 *		}
 *		else {						// Clock = 1
 *			if (_ctUpEdge == 0) {	// Rising edge detected so increment count
 *				_ctUpEdge = 1;		// Set counter edge
 *				
 *				_ct++;				// Increment count
 *				if(_ct >= _pv) {	// Counter has reached final value
 *					_uQ = 1;		// Counter upper Q output = 1
 *					_lQ = 0;		// Counter lower Q output = 0
 *				}else{				// Counter is not yet finished
 *					_uQ = 0;		// Counter upper Q output = 0
 *					_lQ = 0;		// Counter lower Q output = 0
 *				}
 *			}
 *		}
 *	}
 *}
 */

void Counter::countUp()				// Count up method
{
	if (_ct < _pv) {      			// Not yet finished counting so continue
		if (scanValue == 0) {		// clock = 0 so clear counter edge detect
			_ctUpEdge = 0;
		}
		else {						// Clock = 1
			if (_ctUpEdge == 0) {	// Rising edge detected so increment count
				_ctUpEdge = 1;		// Set counter edge			
				_ct++;				// Increment count
				if(_ct >= _pv) {	// Counter has reached final value
					_uQ = 1;		// Counter upper Q output = 1
					_lQ = 0;		// Counter lower Q output = 0
				}else{				// Counter is not yet finished
					_uQ = 0;		// Counter upper Q output = 0
					_lQ = 0;		// Counter lower Q output = 0
				}
			}
		}
	}
}
void Counter::countUp_loop()				// Count up method
{
	if (_ct <= _pv) {      			// Not yet finished counting so continue
		if (scanValue == 0) {		// clock = 0 so clear counter edge detect
			_ctUpEdge = 0;
		}
		else {						// Clock = 1
			if (_ctUpEdge == 0) {	// Rising edge detected so increment count
				_ctUpEdge = 1;		// Set counter edge			
				_ct++;				// Increment count
				if(_ct == _pv) {	// Counter has reached final value
					_uQ = 1;		// Counter upper Q output = 1
					_lQ = 0;		// Counter lower Q output = 0
				}else{				// Counter is not yet finished
					_uQ = 0;		// Counter upper Q output = 0
					_lQ = 0;		// Counter lower Q output = 0
				}
				if (_ct > _pv)
					_ct = _rv;
			}
		}
	}
}

void Counter::countDown()			// Count down method
{
	if (_ct > _rv) {					// Not yet finished so continue
		if (scanValue == 0) {		// clock = 0 so clear counter edge detect
			_ctDownEdge = 0;
		}
		else {						// Clock = 1
			if (_ctDownEdge == 0) {	// Rising edge detected so decrement count
				_ctDownEdge = 1;	// Set counter edge
				if(_ct > 0)
				_ct--; 				// Decrement count
				if(_ct <= _rv) {		// Counter has reached final value
					_uQ = 0;		// Counter QUp output = 0
					_lQ = 1;		// Counter QDown output = 1
				}else{		// Counter is not yet finished
					_uQ = 0;		// Counter upper Q output = 0
					_lQ = 0;		// Counter lower Q output = 0
				}
			}
		}
	}
}
void Counter::countDown_loop()			// Count down method
{
	if (_ct >= _rv) {					// Not yet finished so continue
		if (scanValue == 0) {		// clock = 0 so clear counter edge detect
			_ctDownEdge = 0;
		}
		else {						// Clock = 1
			if (_ctDownEdge == 0) {	// Rising edge detected so decrement count
				_ctDownEdge = 1;	// Set counter edge
				//if(_ct > 0)
				_ct--; 				// Decrement count
				if(_ct == _rv) {		// Counter has reached final value
					_uQ = 0;		// Counter QUp output = 0
					_lQ = 1;		// Counter QDown output = 1
				}else{		// Counter is not yet finished
					_uQ = 0;		// Counter upper Q output = 0
					_lQ = 0;		// Counter lower Q output = 0
				}
				if(_ct < _rv)
					_ct = _pv;
			}
		}
	}
}
// Shift register
Shift::Shift()						// Shift register constructor method
{									// (Register width = 32 bits)
	_sreg = 0;						// Set  the shift register to zero
	_srLeftEdge = 0;				// Prepare rising edge detect for left shift
	_srRightEdge = 0;				// Prepare rising edge detect for right shift
}

Shift::Shift(unsigned int sreg)	    // Shift register constructor method
{									// (Register width = 32 bits)
	_sreg = sreg;					// Set initial value
	_srLeftEdge = 0;				// Prepare rising edge detect for left shift
	_srRightEdge = 0;				// Prepare rising edge detect for right shift
}

unsigned int Shift::bitValue(unsigned int bitno)	// Read a bit at a specified position
{
	if(bitRead(_sreg, bitno) == 1) {
		return(1);				// Tested bit = 1
	}
	else {
		return(0);				// Tested bit = 0
	}
	//return(scanValue);				// Return tested bit value
}

void Shift::shiftSet(unsigned int sreg)
{
	if(scanValue == 1){
		_sreg = sreg;					// Set  the shift register to zero
		_srLeftEdge = 0;			// Prepare rising edge detect for left shift
		_srRightEdge = 0;			// Prepare rising edge detect for right shift
		}
}
unsigned int Shift::value()			// Return the current shift register value
{
	return(_sreg);
}

void Shift::reset()					// Reset the shift register if scanValue = 0
{
	if(scanValue == 1){
		_sreg = 0;					// Set  the shift register to zero
		_srLeftEdge = 0;			// Prepare rising edge detect for left shift
		_srRightEdge = 0;			// Prepare rising edge detect for right shift
		}
}

void Shift::inputBit()				// Set the input bit of the shift register
{
	if (scanValue == 0) {			// If scanValue = 0, clear input bit
		_inbit = 0;
	}
	else {							// Otherwise set the input bit
		_inbit = 1;
	}
}

void Shift::shiftRight()			// Shift right method
{
	if (scanValue == 0) {			// clock = 0 so clear shift right edge detect
		_srRightEdge = 0;
	}
	else {							// Clock = 1
		if (_srRightEdge == 0) {	// Rising edge detected so shift right
			_srRightEdge = 1;		// Set shift right edge detect
			_sreg = _sreg >> 1;		// Shift to the right
			if (_inbit == 1) {		// Shift-in new input bit at LHS
				bitSet(_sreg, 15);
			}
		}
	}
}

void Shift::shiftLeft()				// Shift left method
{
	if (scanValue == 0) {			// clock = 0 so clear shift left edge detect
		_srLeftEdge = 0;
	}
	else {							// Clock = 1
		if (_srLeftEdge == 0) {		// Rising edge detected so shift left
			_srLeftEdge = 1;		// Set shift left edge detect
			_sreg = _sreg << 1;		// Shift to the left
			if (_inbit == 1) {		// Shift-in new input bit at RHS
				bitSet(_sreg, 0);
			}
		}
	}
}

// Single-bit Software Stack
Stack::Stack()						// Stack constructor method
{									// (Register width = 32 bits)
	_sreg = 0;						// Set the stack to zero
}

void Stack::push()					// Push scanValue bit onto the stack method
{
	_sreg = _sreg >> 1;				// Shift stack 1-bit to the right
	if (scanValue == 1) {			// Shift-in scanValue bit at LHS
		bitSet(_sreg, 31);
	}
	else {
		bitClear(_sreg, 31);
	}
}

void Stack::pop()					// Pop scanValue bit from the stack method
{
	scanValue = bitRead(_sreg, 31);	// Set scanValue to leftmost bit of stack
	_sreg = _sreg << 1;				// Shift stack 1-bit to the left
}
void Stack::back()					// Pop scanValue bit from the stack method
{
	//scanValue = bitRead(_sreg, 31);	// Set scanValue to leftmost bit of stack
	_sreg = _sreg << 1;				// Shift stack 1-bit to the left
}

void Stack::orBlock()				// OR scanValue with value Popped from stack method
{
	scanValue = scanValue | bitRead(_sreg, 31);	// OR scanValue with top of stack
	_sreg = _sreg << 1;				// Shift stack 1-bit to the left
}

void Stack::andBlock()				// AND scanValue with value Popped from stack method
{
	scanValue = scanValue & bitRead(_sreg, 31);	// AND scanValue with top of stack
	_sreg = _sreg << 1;				// Shift stack 1-bit to the left
}

// Single scan cycle Pulse with rising or falling edge detection
Pulse::Pulse()						// Pulse constructor method
{
	_pulseInput = 0;				// Set pulse input tracker to zero
	_pulseUpEdge = 0;				// Prepare rising edge detect
	_pulseDownEdge = 0;				// Prepare falling edge detect
}

void Pulse::inClock()				// Read the clock input method
{
	if (scanValue != _pulseInput) {	// Rising or falling edge detected
		if (scanValue == 1) {		// Rising edge detected
			_pulseUpEdge = 1;		// Set rising edge detect value
			_pulseDownEdge = 0;		// Clear falling edge detect value
			_pulseInput = 1;		// Pulse input tracker = 1
		}
		else {						// Falling edge detected
			_pulseUpEdge = 0;		// Clear rising edge detect value
			_pulseDownEdge = 1;		// Set falling edge detect value
			_pulseInput = 0;		// Pulse input tracker = 0
		}
	}
	else {							// No change detected
	_pulseUpEdge = 0;				// Set both edge detect values to zero
	_pulseDownEdge = 0;				// (and leave pulse tracker unchanged)
	}
}

void Pulse::rising()		        // Pulse rising edge detected method
{
	scanValue = _pulseUpEdge;		// scanValue = 1 if rising edge detected, 0 otherwise
}

void Pulse::falling()		        // Pulse falling edge detected method
{
	scanValue = _pulseDownEdge;		// scanValue = 1 if falling edge detected, 0 otherwise
}
