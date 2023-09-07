using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeShop.Domain;
using DevPro.Pagination.PagedList;

namespace DevProApp.Areas.Administration.Controllers
{
    [RouteArea("Administration", AreaPrefix = "Admin")]
    [RoutePrefix("Errors")]
    [Route("Errors")]
    [Authorize(Roles = "Admin")]
    public class ErrorsController : Controller
    {

        List<BikeShop.Domain.Error> AllErrors = BikeShopContext.Errors.All().ToList();

        [Route("Index")]
        [Authorize(Roles = "Admin")]
        // GET: Administration/Errors
        public ActionResult Index(int? page)
        {
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            PagedList<BikeShop.Domain.Error> model = new PagedList<BikeShop.Domain.Error>(AllErrors, pageNumber, 10);

            return View(model);
        }

        [Route("Details")]
        [Authorize(Roles = "Admin")]
        // GET: Administration/Errors/Details/5
        public ActionResult Details(int id)
        {
            var data = BikeShopContext.Errors.Single(id);

            return View(data);
        }

        [Route("Delete")]
        [Authorize(Roles = "Admin")]
        // GET: Administration/Errors/Delete/5
        public ActionResult Delete(int id)
        {
            var data = BikeShopContext.Errors.Single(id);

            return View(data);
        }

        // POST: Administration/Errors/Delete/5
        //[HttpPost]
        [Route("Delete/")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BikeShop.Domain.Error errorModel)
        {
            try
            {
                BikeShopContext.Errors.Delete(errorModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
