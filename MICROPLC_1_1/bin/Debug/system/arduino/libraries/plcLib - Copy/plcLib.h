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

#ifndef plcLib_h
#define plcLib_h

#include "Arduino.h"

/*
// Define basic I/O pins for Arduino Uno and compatibles
const int X0 = A0;
const int X1 = A1;
const int X2 = A2;
const int X3 = A3;

const int Y0 = 0;
const int Y1 = 1;
const int Y2 = 2;
const int Y3 = 3;

// Define Motor Shield pin names
const int DIRA = 12;
const int DIRB = 13;
const int PWMA = 3;
const int PWMB = 11;
const int BRAKEA = 9;
const int BRAKEB = 8;
const int CURRENTA = A0;
const int CURRENTB = A1;

 Define additional I/O pins for Mega, Mega 2560 and Due
#if defined(__AVR_ATmega1280__) || defined(__AVR_ATmega2560__) || defined(__SAM3X8E__)
const int X4 = A6;
const int X5 = A7;
const int X6 = A8;
const int X7 = A9;
const int Y4 = 4;
const int Y5 = 7;
const int Y6 = 8;
const int Y7 = 12;
#endif
*/
//Define basic I/O pins for Arduino-UNO compatibles
const int _A0 = A0;
const int _A1 = A1;
const int _A2 = A2;
const int _A3 = A3;
const int _A4 = A4;
const int _A5 = A5;

const int _D0 = 0;
const int _D1 = 1;
const int _D2 = 2;
const int _D3 = 3;
const int _D4 = 4;
const int _D5 = 5;
const int _D6 = 6;
const int _D7 = 7;
const int _D8 = 8;
const int _D9 = 9;
const int _D10 = 10;
const int _D11 = 11;
const int _D12 = 12;
const int _D13 = 13;

//Define additional I/O pins for Mega, Mega 2560 and Due 
#if defined(__AVR_ATmega1280__) || defined(__AVR_ATmega2560__) || defined(__SAM3X8E__)
// A ANALOG_INPUT

const int _A6 = A6;
const int _A7 = A7;
const int _A8 = A8;
const int _A9 = A9;
const int _A10 = A10;
const int _A11 = A11;
const int _A12 = A12;
const int _A13 = A13;
const int _A14 = A14;
const int _A15 = A15;

const int _D14 = 14;
const int _D15 = 15;
const int _D16 = 16;
const int _D17 = 17;
const int _D18 = 18;
const int _D19 = 19;
const int _D20 = 20;
const int _D21 = 21;
const int _D22 = 22;
const int _D23 = 23;
const int _D24 = 24;
const int _D25 = 25;
const int _D26 = 26;
const int _D27 = 27;
const int _D28 = 28;
const int _D29 = 29;
const int _D30 = 30;
const int _D31 = 31;
const int _D32 = 32;
const int _D33 = 33;
const int _D34 = 34;
const int _D35 = 35;
const int _D36 = 36;
const int _D37 = 37;
const int _D38 = 38;
const int _D39 = 39;
const int _D40 = 40;
const int _D41 = 41;
const int _D42 = 42;
const int _D43 = 43;
const int _D44 = 44;
const int _D45 = 45;
const int _D46 = 46;
const int _D47 = 47;
const int _D48 = 48;
const int _D49 = 49;
const int _D50 = 50;
const int _D51 = 51;
const int _D52 = 52;
#endif

#if defined(ARDUINO_AVR_PLC_DECA)
// Y OUTPUT
const int _Y00 = 37;
const int _Y01 = 35;
const int _Y02 = 33;
const int _Y03 = 31;
const int _Y04 = 29;
const int _Y05 = 27;
const int _Y06 = 25;
const int _Y07 = 23;

const int _Y08 = 22;
const int _Y09 = 24;
const int _Y10 = 26;
const int _Y11 = 28;
const int _Y12 = 30;
const int _Y13 = 13;
const int _Y14 = 34;
const int _Y15 = 36;

// X INPUT
const int _X00 = 39;
const int _X01 = 41;
const int _X02 = 43;
const int _X03 = 45;
const int _X04 = 47;
const int _X05 = 49;
const int _X06 = 51;
const int _X07 = 53;

const int _X08 = 52;
const int _X09 = 50;
const int _X10 = 48;
const int _X11 = 46;
const int _X12 = 44;
const int _X13 = 42;
const int _X14 = 40;
const int _X15 = 38;

#endif

void setupPLC();
void loop_plc();

unsigned int in(int input);
unsigned int in(unsigned int input);
unsigned int ld(unsigned int input);
//unsigned int in(unsigned long input);
unsigned int inNot(int input);
unsigned int inNot(unsigned int input);
unsigned int ldNot(unsigned int input);
//unsigned int inNot(unsigned long input);
unsigned int inAnalog(int input);
unsigned int inAnalog(unsigned int input);
unsigned int inAnalog(unsigned long input);
unsigned int out(int output);
unsigned int out(unsigned int &output);
unsigned int out(unsigned long &output);
unsigned int outNot(int output);
unsigned int outNot(unsigned int &output);
unsigned int outNot(unsigned long &output);
unsigned int outPWM(int output);
unsigned int andBit(int input);
unsigned int andBit(unsigned int input);
unsigned int andBit(unsigned long input);
unsigned int andNotBit(int input);
unsigned int andNotBit(unsigned int input);
unsigned int andNotBit(unsigned long input);
unsigned int orBit(int input);
unsigned int orBit(unsigned int input);
unsigned int orBit(unsigned long input);
unsigned int orNotBit(int input);
unsigned int orNotBit(unsigned int input);
unsigned int orNotBit(unsigned long input);
unsigned int xorBit(int input);
unsigned int xorBit(unsigned int input);
unsigned int xorBit(unsigned long input);
unsigned int latch(int output, int reset);
unsigned int latch(int output, unsigned int reset);
unsigned int latch(int output, unsigned long reset);
unsigned int latch(unsigned int &output, int reset);
unsigned int latch(unsigned long &output, int reset);
unsigned int latch(unsigned int &output, unsigned int reset);
unsigned int latch(unsigned long &output, unsigned long reset);
unsigned int timerOn(unsigned long &timerState, unsigned int timerPeriod);
unsigned int timerPulse(unsigned long &timerState, unsigned long timerPeriod);
unsigned int timerOff(unsigned long &timerState, unsigned int timerPeriod);
unsigned int timerCycle(unsigned long &timer1State, unsigned int timer1Period, unsigned long &timer2State, unsigned int timer2Period);
unsigned int compareGT(int input);
unsigned int compareGT(unsigned int input);
unsigned int compareGT(unsigned long input);
unsigned int compareLT(int input);
unsigned int compareLT(unsigned int input);
unsigned int compareLT(unsigned long input);
unsigned int set(int output);
unsigned int set(unsigned int &output);
unsigned int set(unsigned long &output);
unsigned int reset(int output);
unsigned int reset(unsigned int &output);
unsigned int reset(unsigned long &output);
unsigned int OSR(unsigned int &_osr);
unsigned int OSF(unsigned int &_osf);

class Counter
{
  public:
    Counter(unsigned int presetValue);
    Counter(unsigned int presetValue, unsigned int resetValue);
    void countUp();
    void countDown();
	void countUp_loop();
    void countDown_loop();
    void preset();
	void reset();
    void clear();
	//void autoClear();
    unsigned int upperQ();
    unsigned int lowerQ();
    unsigned int count();
    unsigned int presetValue();
	void set(unsigned int value);
  private:
    unsigned int _pv;
	unsigned int _rv;
    unsigned int _ct;
    unsigned int _ctUpEdge;
	unsigned int _ctDownEdge;
    unsigned int _uQ;
    unsigned int _lQ;
};

class Shift
{
  public:
    Shift();
	Shift(unsigned int sreg);
	unsigned int bitValue(unsigned int bitno);
	unsigned int value();
	void shiftSet(unsigned int sreg);
	void reset();
	void inputBit();
	void shiftLeft();
	void shiftRight();
  private:
    unsigned int _srLeftEdge;
    unsigned int _srRightEdge;
	unsigned int _sreg;
	unsigned int _inbit;
};

class Stack
{
  public:
    Stack();
	void push();
	void pop();
	void back();
	void orBlock();
	void andBlock();
  private:
	unsigned long _sreg;
};

class Pulse
{
  public:
    Pulse();
	void inClock();
	void rising();
	void falling();
  private:
	unsigned int _pulseInput;
	unsigned int _pulseUpEdge;
	unsigned int _pulseDownEdge;
};

unsigned int compare(unsigned int &input1,unsigned int input2,unsigned int function_code) ;
unsigned int compare(int &input1,unsigned int input2,unsigned int function_code) ;
unsigned int compare(int &input1, int input2,unsigned int function_code) ;
unsigned int compare(int &input1,char input2,unsigned int function_code) ;

unsigned int compare(Counter &input1,unsigned int input2,unsigned int function_code);
unsigned int compare(Counter &input1,Counter &input2,unsigned int function_code);
unsigned int _move( int &variable, int value);
unsigned int _move(Shift shift,unsigned int value);
unsigned int _move(Counter counter,unsigned int value);

unsigned int _add(int &destination,int variable, int value);
unsigned int _add(Counter counter,int variable, int value);

unsigned int _sub(int &destination,int variable, int value);
unsigned int _sub(Counter counter,int variable, int value);

unsigned int _mup( int &variable, int value);
unsigned int _div( int &variable, int value);
unsigned int _mod( int &variable, int value);
unsigned int _adc(unsigned int &variable, int apin);
void _coil(unsigned int &output);
void _coilNot(unsigned int &output);
unsigned int _contrac(unsigned int input);
unsigned int _contracNot(unsigned int input);
unsigned int _short();
unsigned int _open();

unsigned int inplc(unsigned int &variable,int input);
unsigned int inplcNot(unsigned int &variable,int input);
unsigned int outplc(unsigned int &variable,int output);
unsigned int outplcNot(unsigned int &variable,int output);
#endif