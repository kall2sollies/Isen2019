using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Isen.DotNet.Web.Controllers
{
    public class PersonController : BaseController<Person, IPersonRepository>
    {
        public PersonController(IPersonRepository repository) : base(repository)
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
        public IActionResult Edit(int id, [Bind] Person model)
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