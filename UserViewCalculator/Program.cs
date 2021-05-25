using System;
using UserViewCalculator;

namespace WrapperOverCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            new UserConsoleCalculator(new MyConsole()).Start();
        }
    }
}
