// See https://aka.ms/new-console-template for more information

using System.Device.Gpio;

Console.WriteLine("Starting Button LED Control Program");

var ledPin = 17; // GPIO pin for the LED
var buttonPin = 27; // GPIO pin for the button
using var controller = new GpioController();
controller.OpenPin(ledPin, PinMode.Output);
controller.OpenPin(buttonPin, PinMode.InputPullUp); // Enable internal pull-up resistor

Console.WriteLine("Press the button to turn the LED on. Release to turn it off.");

while (true)
{
    // Read the state of the button
    var buttonPressed = controller.Read(buttonPin) == PinValue.Low; // Button is pressed if reading is Low

    if (buttonPressed)
    {
        // Button is pressed
        Console.WriteLine("Button pressed - Turning LED ON");
        controller.Write(ledPin, PinValue.High); // Turn LED on
    }
    else
    {
        // Button is released
        Console.WriteLine("Button released - Turning LED OFF");
        controller.Write(ledPin, PinValue.Low); // Turn LED off
    }

    Thread.Sleep(100); // Small delay to debounce the button
}