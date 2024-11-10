// See https://aka.ms/new-console-template for more information

using System.Device.Gpio;
using System.Threading;

Console.WriteLine("Starting LED Blink Program");

var ledPin = 17; // Use the GPIO pin you’ve connected the LED to
using var controller = new GpioController();
controller.OpenPin(ledPin, PinMode.Output);

while (true)
{
    Console.WriteLine("Turning LED ON");
    controller.Write(ledPin, PinValue.High); // LED ON
    Thread.Sleep(2000); // Wait 2 seconds

    Console.WriteLine("Turning LED OFF");
    controller.Write(ledPin, PinValue.Low); // LED OFF
    Thread.Sleep(1000); // Wait 1 second
}