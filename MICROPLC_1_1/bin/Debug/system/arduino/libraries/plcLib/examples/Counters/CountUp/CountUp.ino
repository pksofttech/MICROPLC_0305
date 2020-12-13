#include <plcLib.h>

/* Programmable Logic Controller Library for the Arduino and Compatibles

   Up Counter - Counts 10 pulses on Input 0 with switch debounce

   Connections:
   Count input - switch connected to input X0 (Arduino pin A0 / Tinkerkit pin I0)
   Clear input - switch connected to input X1 (Arduino pin A1 / Tinkerkit pin I1)
   Preset input - switch connected to input X2 (Arduino pin A2 / Tinkerkit pin I2)
   Lower Q output - LED connected to output Y0 (Arduino pin 3 / Tinkerkit O5)
   Upper Q output - LED connected to output Y1 (Arduino pin 5 / Tinkerkit O4)

   Software and Documentation:
   http://www.electronics-micros.com/software-hardware/plclib-arduino/

*/

Counter ctr(10);           // Final count = 10, starting at zero
unsigned long TIMER0 = 0;  // Define variable used to hold timer 0 elapsed time

void setup() {
  setupPLC();              // Setup inputs and outputs
}

void loop() {
  in(X0);                  // Read Input 0
  timerOn(TIMER0, 10);     // 10 ms switch debounce delay
  ctr.countUp();           // Count up
  
  in(X1);                  // Read input X1
  ctr.clear();             // Clear counter (counter at lower limit)
  
  in(X2);                  // Read input X2
  ctr.preset();            // Preset counter (counter at upper limit)

  ctr.lowerQ();            // Display Count Down output on Y0
  out(Y0);
  
  ctr.upperQ();            // Display Count Up output on Y1
  out(Y1);
}