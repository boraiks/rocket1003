#include <Adafruit_MPU6050.h>
#include <Adafruit_Sensor.h>
#include <Wire.h>
#include <Servo.h>

Servo servo;
Adafruit_MPU6050 mpu;

void setup(void)
{
  Serial.begin(115200);
  servo.attach(9);
  Wire.begin();
  mpu.begin();
  servo.write(0);

  mpu.setAccelerometerRange(MPU6050_RANGE_8_G);
  mpu.setGyroRange(MPU6050_RANGE_1000_DEG);
  mpu.setFilterBandwidth(MPU6050_BAND_21_HZ);

  delay(100);
}

void loop()
{

  sensors_event_t a, g, temp;
  mpu.getEvent(&a, &g, &temp);

  int value = a.acceleration.y;

  value = map(value, -8, 8, 180, 0);
  servo.write(value);  
  Serial.println(value);
  delay(10);
}
