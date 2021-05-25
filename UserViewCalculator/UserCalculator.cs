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
        public void Start()
        {
            int countAction = 0;
            int result = 0;
            while (true)
            {
                result = 0;
                if (countAction == 0)
                {
                    output.WriteLine("Enter comma separated numbers (enter to exit):");
                }
                else
                {
                    output.WriteLine("You can enter other numbers (enter to exit)?");
                }

                string inputNumbers = output.ReadLine();
                if (inputNumbers == "") return;

                result = calculator.Add(inputNumbers);
                output.WriteLine($"Result is {result}");

                countAction++;
            }
        }
    }
}
