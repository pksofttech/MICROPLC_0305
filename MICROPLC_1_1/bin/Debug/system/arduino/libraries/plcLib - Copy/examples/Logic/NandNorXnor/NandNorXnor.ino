#include <plcLib.h>

/* Programmable Logic Controller Library for the Arduino and Compatibles

   NAND, NOR, and XNOR - Boolean Logic functions with inverted outputs

   Connections:
   Input - switch connected to input X0 (Arduino pin A0 / Tinkerkit pin I0)
   Input - switch connected to input X1 (Arduino pin A1 / Tinkerkit pin I1)
   Output - NAND Output - LED connected to output Y0 (Arduino pin 3 / Tinkerkit O5)
   Output - NOR Output - LED connected to output Y1 (Arduino pin 5 / Tinkerkit O4)
   Output - XNOR Output - LED connected to output Y2 (Arduino pin 6 / Tinkerkit O3)

   Software and Documentation:
   http://www.electronics-micros.com/software-hardware/plclib-arduino/
*/

void setup() {
  setupPLC();  // Setup inputs and outputs
}

void loop() {
               // NAND
  in(X0);      // Read Input 0
  andBit(X1);  // AND with Input 1
  outNot(Y0);  // Send result to Output 0 (inverted)

               // NOR
  in(X0);      // Read Input 0
  orBit(X1);   // OR with Input 1
  outNot(Y1);  // Send result to Output 1 (inverted)

               // XNOR
  in(X0);      // Read Input 0
  xorBit(X1);  // XOR with Input 1
  outNot(Y2);  // Send result to Output 2 (inverted)
}


