using System;
using Isen.DotNet.Library;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var hello = new Hello("Kall");
            var message = hello.Greet();
            Console.WriteLine(message);
        }
    }
}
