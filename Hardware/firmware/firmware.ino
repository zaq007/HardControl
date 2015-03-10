#include <avr\interrupt.h>

#define BTN_DELAY 1000000

unsigned long volatile last = 0;

void setup()
{
	attachInterrupt(1, int0, RISING);
        Serial.begin(9600);
        
}

void int0()
{       
        unsigned long time = micros();
        if(time - last > BTN_DELAY)
        {
          Serial.write("Clicked!\n");
          last = time;
        }
}

void loop()
{

  /* add main program code here */

}
