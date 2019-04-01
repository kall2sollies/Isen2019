using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryCityRepository
    {
        private List<City> _context; 
        public IQueryable<City> Context
        {
            get
            {
                if (_context != null) return _context.AsQueryable();
                _context = new List<City>()
                {
                    new City() { Id = 1, Name = "Toulon", ZipCode = "83000" },
                    new City() { Id = 2, Name = "Marseille", ZipCode = "13000" },
                    new City() { Id = 3, Name = "Nice", ZipCode = "06000" },
                    new City() { Id = 4, Name = "Paris", ZipCode = "75000" },
                    new City() { Id = 5, Name = "Lyon", ZipCode = "69000" },
                };
                return _context.AsQueryable();
            }
        }

        public int NewId() => 
            Context.Max(c => c.Id) + 1;

        public City Single(int id) => 
            Context.SingleOrDefault(c => c.Id == id);
        public City Single(string name) => 
            Context.FirstOrDefault(c => c.Name.Equals(name));

        public void Update(City entity)
        {
            if (entity == null) return;
            
            var copy = ContextTemp;

            if (entity.IsNew)
            {
                entity.Id = NewId();
                ContextTemp.Add(entity);
            }
            else
            {
                var existing = Single(entity.Id);
                existing.Name = entity.Name;
                existing.ZipCode = entity.ZipCode;
            }
        }

        private List<City> _contextTemp; 
        private List<City> ContextTemp => 
            _contextTemp ??
                (_contextTemp = Context.ToList());

        public void SaveChanges()
        {
            _context = _contextTemp;
            _contextTemp = null;
        }
    }
}