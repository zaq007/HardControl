#include <avr\interrupt.h>
#include <LiquidCrystal.h>
#include <Time.h>  
#define READY_FOR_CONNECTION 'A'
#define MSG_OK 0x02
#define MSG_INFO 0x02

LiquidCrystal lcd(12, 11, 5, 4, 3, 2);
#define BTN_DELAY 1000000

unsigned long volatile last = 0;
byte isConnected = 0;
byte isSerial = 0;

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
        while (Serial.available() > 0) 
        {
          char a = Serial.read(); 
          switch(a)
          {
            case MSG_INFO:
            {
               lcd.clear();
               lcd.setCursor(0,0);
               byte f;
               while(true)
               {
                 f = Serial.read();
                 if(f == 0x00)
                   break;
                 lcd.write(f);
               }
               break; 
            }
          }    
        }
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
      isSerial = 1;
      Serial.print(READY_FOR_CONNECTION);
      isSerial = 0;
      delay(300);
    }
    isConnected = 1;
  }
  delay(300);
}


