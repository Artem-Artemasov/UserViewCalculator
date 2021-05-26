using System;
using StringCalculator;
using UserViewCalculator.Interface;

namespace UserViewCalculator
{
    public class UserConsoleCalculator
    {
        private readonly Calculator calculator;
        private IConsole output;
        
        public UserConsoleCalculator(IConsole console,Calculator calculator)
        {
            this.output = console;
            this.calculator = calculator;
        }
        public void Work()
        {
            int result = 0;

            output.WriteLine("Enter comma separated numbers (enter to exit):");
            string inputNumbers = output.ReadLine();
            result = calculator.Add(inputNumbers);
            output.WriteLine($"Result is {result}");

            while (true)
            {
                result = 0;
                output.WriteLine("You can enter other numbers (enter to exit)?");

                inputNumbers = output.ReadLine();
                if (inputNumbers == "") return;

                result = calculator.Add(inputNumbers);
                output.WriteLine($"Result is {result}");
            }
        }
    }
}
