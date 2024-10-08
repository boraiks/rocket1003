# Disclaimer
This project is intended solely for educational and hobby purposes. The creator of this project is a student with a strong interest in space vehicles and rocket technology. The goal is to learn and share knowledge about model rocketry in a safe and responsible manner. That being said, enjoy the repository.

## **Table of Contents**
-[About TVC Mount](#about-tvc-mount)


-[About Manual Controller](#about-manual-controller)


-[About Flight Computer](#about-flight-computer)


-[What am i working on right now?](#what-am-i-working-on-right-now)


-[Tests](#tests)

## **About TVC Mount**
**I'm planning to model a TVC (Thrust Vector Control) Mount for RocketV2 since using 4 high-torque servos for RocketV1 proved to be unnecessarily heavy. By designing a TVC mount for just 2 servos to control the X and Y axes, I can significantly reduce weight. After realizing the high-torque motors were too bulky.**
>UPDATE: I shifted to a more efficient design with 9g servos. Check out my nearly completed TVC design below.
>
>![ROCKETV2-TVC](RocketV2/TVCprototypes/img/TVC2-PROTOTYPE2.png)
>
## **About Manual Controller**
**I coded a manual controller, to test and control the servos with my joystick, making it easier to integrate the limits into the model.**
>I thought it might also be good to have the ability to control it manually in case of emergencies like airbrakes, drag chute for safe landing etc, so I might add more buttons and functions in the future.
>
>![MANUALCONTROLLER](manualController/img/manualController.gif)

## **About Flight Computer**
**As part of my TVC (Thrust Vector Control) RocketV2 project, I've designed a detailed flight computer schematic. It includes connections for an Arduino Nano, MPU6050, and BMP280 sensors. To create this schematic, I had to make some custom .lbr files for the Eagle program, as they aren't available online.**  
>If you're interested in these files, you can find them in the `flightComputer` directory of this repository. Also check schematic (basic outline for now) down below.
>
>![ROCKETV2-PCB](flightComputer/img/PCB_OUTLINE4.png)

## **What am i working on right now?**
**Soldering, assembling, and more. I regularly update this `What am I working on right now?` section, so you can check out the latest progress and final products.**
>![ROCKETV2-FLIGHTCOMPUTER](flightComputer/img/protoboardV2.jpeg)
>This week, I added more modules to the board, including a microSD card adapter to record the maximum altitude. I also added a new buzzer and an RGB LED to ensure the rocket is ready for launch. Additionally, I upgraded from the BMP180 to the BMP280 for improved accuracy. And of course, I threw in a switch—because why not?
>
>UPDATE: I implemented a level shifter to enable communication between the BMP280 and MPU6050 modules and the Arduino Nano, as both sensors operate at 3.3V while the Arduino operates at 5V. I used the SDA and SCL pins on the Arduino for the MPU6050; however, I ran out of pins for the BMP280. As a result, I opted for software I2C to connect the BMP280.

## **Tests**
Gyro Test:
>![FLIGHTCOMPUTERGYROTEST1](flightComputer/img/FlightComputerGyroTest.gif)
>
## NOTICE
As of September 25, 2024 I've stopped the project, feel free to follow up and ask questions but I will most likely not update anymore about TVC—at least for a while. It's been a great journey and thank you to everyone who supported me for the past year.

## CAUTION
><img align="left" src="RocketV1/imagesV1/WarningLAbel.jpeg" alt="Warning">

Please be careful while doing this project (**handle it with extreme care**.)
