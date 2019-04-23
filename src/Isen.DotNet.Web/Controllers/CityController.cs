using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.InMemory;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Isen.DotNet.Web.Models;

namespace Isen.DotNet.Web.Controllers
{
    public class CityController : BaseController<City, ICityRepository>
    {
        public CityController(ICityRepository repository) : base(repository)
        {
        }

        public IActionResult Index() => View(Repository.GetAll());

        [HttpGet] // facultatif car par défaut
        public IActionResult Edit(int? id)
        {
            if (id == null) return View();
            return View(Repository.Single(id.Value));
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind] City model)
        {
            Repository.Update(model);
            Repository.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Repository.Delete(id.Value);
                Repository.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
