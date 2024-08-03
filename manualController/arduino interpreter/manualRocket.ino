#include <Servo.h>

Servo servoX;
Servo servoY;

int val;

void setup()
{
  Serial.begin(9600);
  servoX.attach(3);
  servoY.attach(9);
  Serial.setTimeout(10);
}

void loop()
{

  switch(Serial.read())
  {
    case 'X':
      servoX.write(Serial.parseInt());
      break;

    case 'Y':
      servoY.write(Serial.parseInt());
      break;
  }
}
