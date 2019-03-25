using System;
using System.Collections.Generic;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Lists;
using Isen.DotNet.Library.Persons;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var jd = new Person(
                "John",
                "Doe",
                new DateTime(1964,12,24)
            );
            Console.WriteLine(jd);

            var unborn = 
                new Person("The", "Unborn");            
            Console.WriteLine(unborn);

            var inlinePerson = new Person()
            {
                LastName = "Appleseed",
                FirstName = "Jon",                
                DateOfBirth = new DateTime(1968,2,4)
            };
            Console.WriteLine(inlinePerson);
        }
    }
}
