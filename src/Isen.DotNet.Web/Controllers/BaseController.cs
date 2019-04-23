using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Isen.DotNet.Library.Models;
using Isen.DotNet.Library.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Isen.DotNet.Web.Controllers
{
    public abstract class BaseController<T, TRepo> : Controller
        where T : BaseModel<T>
        where TRepo : IBaseRepository<T>
    {
        protected readonly TRepo Repository;

        protected BaseController(TRepo repository)
        {
            Repository = repository;
        }

        public virtual IActionResult Index() => View(Repository.GetAll());

        [HttpGet] // facultatif car par défaut
        public virtual IActionResult Edit(int? id)
        {
            if (id == null) return View();
            return View(Repository.Single(id.Value));
        }

        [HttpPost]
        public virtual IActionResult Edit(int id, [Bind] T model)
        {
            Repository.Update(model);
            Repository.SaveChanges();
            return RedirectToAction("Index");
        }

        public virtual IActionResult Delete(int? id)
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
