using System;
using System.Collections.Generic;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Lists;
using Isen.DotNet.Library.Models;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var toulon = new City()
            {
                Id = 1,
                Name = "Toulon",
                ZipCode = "83000"
            };
            Console.WriteLine(toulon);

            var nice = new City()
            {
                Id = 2,
                Name = "Nice",
                ZipCode = "06000"
            };
            Console.WriteLine(nice);

            var jd = new Person()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1964,12,24),
                BornIn = toulon
            };
            Console.WriteLine(jd);

            var ja = new Person()
            {
                Id = 2,
                LastName = "Appleseed",
                FirstName = "Jon",                
                DateOfBirth = new DateTime(1968,2,4),
                BornIn = nice
            };
            Console.WriteLine(ja);
        }
    }
}
