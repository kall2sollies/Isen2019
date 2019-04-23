using System;
using System.Collections.Generic;
using System.Text;
using Isen.DotNet.Library.Context;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;

namespace Isen.DotNet.Library.Repositories.Db
{
    public class DbContextCityRepository : 
        BaseDbRepository<City>,
        ICityRepository
    {
        public DbContextCityRepository(
            ApplicationDbContext dbContext) : 
            base(dbContext)
        {
        }
    }
}
