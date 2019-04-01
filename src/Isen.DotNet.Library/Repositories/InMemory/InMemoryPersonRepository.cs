using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Base;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryPersonRepository :
        BaseInMemoryRepository<Person>,
        IPersonRepository
    {      
        public override List<Person> SampleData =>
            new List<Person>()
            {
                new Person()
                { 
                    Id = 1, 
                    FirstName = "Miles", 
                    LastName = "DAVIS", 
                    Name = "DAVIS Miles",
                    DateOfBirth = new DateTime(1926,5, 26)
                },
                new Person()
                { 
                    Id = 2, 
                    FirstName = "Bill", 
                    LastName = "EVANS", 
                    Name = "EVANS Bill",
                    DateOfBirth = new DateTime(1929,8, 16)
                },
                new Person()
                { 
                    Id = 3, 
                    FirstName = "John", 
                    LastName = "COLTRANE", 
                    Name = "COLTRANCE John",
                    DateOfBirth = new DateTime(1926, 9, 26)
                }
            };
    }
}