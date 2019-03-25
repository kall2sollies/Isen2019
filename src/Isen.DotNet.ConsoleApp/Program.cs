using System;
using System.Collections.Generic;
using Isen.DotNet.Library;
using Isen.DotNet.Library.Lists;

namespace Isen.DotNet.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyCollection<string>();
            list.Add("A");
            list.Add("B");
            list.Add("C");
            var enumerator = 
                list.GetEnumerator();
            while (enumerator.MoveNext())
                Console.WriteLine(enumerator.Current);            
        }
    }
}
