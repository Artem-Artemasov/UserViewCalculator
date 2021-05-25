using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringCalculator;

namespace WrapperOverCalculator
{
    class UserViewCalculator
    {
        private readonly Calculator calculator = new Calculator();
        
        public void Start()
        {
            int countAction = 0;
            int result = 0;
            while (true)
            {
                result = 0;
                if (countAction == 0)
                {
                    Console.WriteLine("Enter comma separated numbers (enter to exit):");
                }
                else
                {
                    Console.WriteLine("You can enter other numbers (enter to exit)?");
                }

                string inputNumbers = Console.ReadLine();
                if (inputNumbers.Length == 0) return;

                result = calculator.Add(inputNumbers);
                Console.WriteLine($"Result is {result}");
            }
        }
    }
}
