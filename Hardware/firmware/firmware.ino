#include <avr\interrupt.h>
#include <LiquidCrystal.h>

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);
#define BTN_DELAY 1000000

unsigned long volatile last = 0;
byte isConnected = 0;

void setup()
{
	//attachInterrupt(1, int0, RISING);
        Serial.begin(9600);
        lcd.begin(20, 4);
        lcd.setCursor(0, 0);
        lcd.print("Connect me!");
        lcd.setCursor(0, 2);
}

/*void int0()
{       
        unsigned long time = micros();
        if(time - last > BTN_DELAY)
        {
          Serial.write("Clicked!\n");
          last = time;
        }
}*/

void loop()
{
  if(isConnected == 1)
  {
      if(Serial)
      {
        lcd.clear();
        lcd.setCursor(0, 0);
        lcd.print("Connected!");
      } else
      {
       isConnected = 0; 
      }
  } else
  {
    lcd.clear();
    lcd.setCursor(0, 0);
    lcd.print("Connect me!");
    while (Serial.available() <= 0) 
    {
      Serial.print('A');   // send a capital A
      delay(300);
    }
    Serial.readString();
    isConnected = 1;
  }
  delay(300);
}
