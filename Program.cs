using System;
using Unosquare.RaspberryIO;
using Unosquare.RaspberryIO.Gpio;

namespace BlinkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine ("Start Blinking LED...");

            // Using Bread Board with T-Cobbler see https://github.com/unosquare/raspberryio for more info
            var led1 = Pi.Gpio.Pin07;
            var led2 = Pi.Gpio.Pin01;

            // Configure the pin as an output
            led1.PinMode = GpioPinDriveMode.Output;
            led2.PinMode = GpioPinDriveMode.Output;

            // perform writes to the pin by toggling the isOn variable
            var isOn = true;
            for (var i = 0; i < 10; i++)
            {
                led1.Write(isOn);
                System.Threading.Thread.Sleep(500);
                led1.Write(!isOn);
                led2.Write(isOn);
                System.Threading.Thread.Sleep(500);       
                led2.Write(!isOn);         
            }

			Console.WriteLine ("Stop Blinking LED...");
        }
    }
}
