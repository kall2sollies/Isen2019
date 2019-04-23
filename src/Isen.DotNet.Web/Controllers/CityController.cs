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
    public class CityController : Controller
    {
        private readonly ICityRepository _repository;

        public CityController(ICityRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Index() => View(_repository.GetAll());

        [HttpGet] // facultatif car par défaut
        public IActionResult Edit(int? id)
        {
            if (id == null) return View();
            return View(_repository.Single(id.Value));
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind] City model)
        {
            _repository.Update(model);
            _repository.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
