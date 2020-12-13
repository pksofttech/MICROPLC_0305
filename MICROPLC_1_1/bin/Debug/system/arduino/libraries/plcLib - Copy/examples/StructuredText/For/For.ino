#include <plcLib.h>

/* Programmable Logic Controller Library for the Arduino and Compatibles

   FOR loop - Manually created 'PWM' waveform (very primitive)

   Connections:
   Input - potentiometer connected to input X0 (Arduino pin A0 / Tinkerkit pin I0)
   Output - LED connected to output Y0 (Arduino pin 3 / Tinkerkit O5)

   Software and Documentation:
   http://www.electronics-micros.com/software-hardware/plclib-arduino/

*/

void setup() {
  setupPLC();                               // Setup inputs and outputs
}

void loop() {

  for(unsigned int i = 0; i <= 1023; i++) { // Loop from i=0 to i=1023 in unit steps
    inAnalog(i);                            // Read count as an 'analogue' value
    compareGT(X0);                          // Compare with Analogue Input 0
    out(Y0);                                // Output comparison result to Output 0
  }
}
