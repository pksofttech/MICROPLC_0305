#include <plcLib.h>

/* Programmable Logic Controller Library for the Arduino and Compatibles

   Turn-off Delay - Delays turning an output off after an input is removed

   Connections:
   Input - switch connected to input X0 (Arduino pin A0 / Tinkerkit pin I0)
   Output - LED connected to output Y0 (Arduino pin 3 / Tinkerkit O5)

   Software and Documentation:
   http://www.electronics-micros.com/software-hardware/plclib-arduino/

*/

unsigned long TIMER0 = 0;  // Variable to hold elapsed time for Timer 0

void setup() {
  setupPLC();              // Setup inputs and outputs
}

void loop() {
  in(X0);                  // Read Input 0
  timerOff(TIMER0, 2000);  // 2 second turn-off delay
  out(Y0);                 // Output to Output 0
}