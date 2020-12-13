#include <plcLib.h>

/* Programmable Logic Controller Library for the Arduino and Compatibles

   Generate rising-edge and falling-edge pulses using a digital input

   Connections:
   Clock input - switch connected to input X0 (Arduino pin A0 / Tinkerkit pin I0)
   Rising-edge output - LED connected to output Y0 (Arduino pin 3 / Tinkerkit O5)
   Falling-edge output - LED connected to output Y1 (Arduino pin 5 / Tinkerkit O4)

   Software and Documentation:
   http://www.electronics-micros.com/software-hardware/plclib-arduino/

*/

Pulse pulse1;              // Create a pulse object called 'pulse1'

void setup() {
  setupPLC();              // Setup inputs and outputs
}

void loop() {
  in(X0);                  // Read switch connected to Input 0 and
  pulse1.inClock();        // connect it to the clock input
  
  pulse1.rising();         // Read rising edge
  out(Y0);                 // Output rising edge for 1 scan cycle only
  
  pulse1.falling();        // Read falling edge
  out(Y1);                 // Output falling edge for 1 scan cycle only

  delay(50);               // Slow down scan cycle to enable viewing pulses
                           // (remove this delay in the final code)
}
