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
    }
}
