using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Isen.DotNet.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonRepository _repository;

        public PersonController(IPersonRepository repository)
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
        public IActionResult Edit(int id, [Bind] Person model)
        {
            _repository.Update(model);
            _repository.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                _repository.Delete(id.Value);
                _repository.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}