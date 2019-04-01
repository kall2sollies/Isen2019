using System;
using System.Collections.Generic;
using System.Linq;
using Isen.DotNet.Library.Models;

namespace Isen.DotNet.Library.Repositories.InMemory
{
    public class InMemoryCityRepository
    {
        private List<City> _modelCollection; 
        public IQueryable<City> ModelCollection
        {
            get
            {
                if (_modelCollection != null) return _modelCollection.AsQueryable();
                _modelCollection = new List<City>()
                {
                    new City() { Id = 1, Name = "Toulon", ZipCode = "83000" },
                    new City() { Id = 2, Name = "Marseille", ZipCode = "13000" },
                    new City() { Id = 3, Name = "Nice", ZipCode = "06000" },
                    new City() { Id = 4, Name = "Paris", ZipCode = "75000" },
                    new City() { Id = 5, Name = "Lyon", ZipCode = "69000" },
                };
                return _modelCollection.AsQueryable();
            }
        }

        public int NewId() => 
            ModelCollection.Max(c => c.Id) + 1;

        public City Single(int id) => 
            ModelCollection.SingleOrDefault(c => c.Id == id);
        public City Single(string name) => 
            ModelCollection.FirstOrDefault(c => c.Name.Equals(name));

        public void Update(City entity)
        {
            if (entity == null) return;

            var entities = ModelCollection.ToList();

            if (entity.IsNew)
            {
                entity.Id = NewId();
                entities.Add(entity);
            }
            else
            {
                var existing = Single(entity.Id);
                existing.Name = entity.Name;
                existing.ZipCode = entity.ZipCode;
            }

            _modelCollection = entities;
        }

        public void SaveChanges()
        {

        }
    }
}