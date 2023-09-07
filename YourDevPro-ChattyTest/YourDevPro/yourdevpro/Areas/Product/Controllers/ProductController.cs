using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BikeShop.Domain;
using DevPro.Pagination.PagedList;
using DevProApp.Areas.Product.Models;

namespace DevProApp.Areas.Product.Controllers
{
    [RouteArea("Product", AreaPrefix = "Product")]
    [RoutePrefix("Product")]
    public class ProductController : Controller
    {
        List<BikeShop.Domain.Product> AllProducts = BikeShopContext.Products.All().ToList();

        // GET: Product/Product/Index
        [Route("Index")]
        [Authorize(Roles = "Admin, Superuser, User")]
        public ActionResult Index(int? page)
        {
            //List<Product> AllProducts = BikeShopContext.Products.All().ToList();
            Debug.Write("Entered Index method of ProductController ");
            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)

            PagedList<BikeShop.Domain.Product> model = new PagedList<BikeShop.Domain.Product>(AllProducts, pageNumber, 10);


            return View(model);
        }

        // GET: Product/Product/Details/5
        public ActionResult Details(int id)
        {
            var data = BikeShopContext.Products.Single(id);

            return View(data);
        }

        // GET: Product/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Product/Create
        [HttpPost]
        public ActionResult Create(BikeShop.Domain.Product productModel)
        {
            try
            {
                BikeShopContext.Products.Insert(productModel);
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Product/Edit/5
        public ActionResult Edit(int id)
        {

            
            var data = BikeShopContext.Products.Single(id);


            return View(data);
        }

        // POST: Product/Product/Edit/5
        [HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        public ActionResult Edit(int id, BikeShop.Domain.Product editProductModel)
        {
            try
            {
                
                var UpdateThisProduct = BikeShopContext.Products.Single(id);
                ////test update code
                UpdateModel(UpdateThisProduct);
                    
                BikeShopContext.Products.Update(UpdateThisProduct);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Product/Delete/5
        public ActionResult Delete(int id)
        {
            var data = BikeShopContext.Products.Single(id);

            return View(data);
        }

        // POST: Product/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BikeShop.Domain.Product productModel)
        {
            try
            {
                BikeShopContext.Products.Delete(productModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }

}
