using System;
using UserViewCalculator;
using StringCalculator;

namespace WrapperOverCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            new UserConsoleCalculator(new MyConsole(),new Calculator()).Work();
        }
    }
}
