using System;
using Xunit;
using Isen.DotNet.Library.Lists;
using System.Collections.Generic;
using Isen.DotNet.Library.Repositories.InMemory;

namespace Isen.DotNet.Library.Tests
{
    public class InMemoryCityRepoTest
    {
        [Fact]
        public void SingleById()
        {
            var cityRepo = new InMemoryCityRepository();
            
            var city1 = cityRepo.Single(1);
            Assert.True(city1.Id == 1);

            var noCity = cityRepo.Single(42);
            Assert.True(noCity == null);      
        }

        [Fact]
        public void SingleByName()
        {
            var cityRepo = new InMemoryCityRepository();

            var toulon = cityRepo.Single("Toulon");
            Assert.True(toulon.Name == "Toulon");

            var fake = cityRepo.Single("Fake");
            Assert.True(fake == null);
        }
    }
}