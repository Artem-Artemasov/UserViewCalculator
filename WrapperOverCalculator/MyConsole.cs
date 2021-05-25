using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserViewCalculator.Interface;

namespace UserViewCalculator
{
    class MyConsole : IConsole
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}
