using ModuleExam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ModuleExam.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<Product> p = Product.GetAllProducts();
            return View(p);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            Product p = Product.SingleProduct(id);
            return View(p);
        }

      

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            Product pd = Product.SingleProduct(id);
            return View(pd);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product pd)
        {
            try
            {
                // TODO: Add update logic here
                Product.UpdateProduct(id, pd);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       public ActionResult PartialView1()
        {
            return View();
        }
        
        }
    }

