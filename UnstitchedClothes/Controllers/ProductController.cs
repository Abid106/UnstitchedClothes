using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnstitchedClothes.Database;

namespace UnstitchedClothes.Controllers
{
    public class ProductController : Controller
    {
        UnstitchedClothesDbEntities db = new UnstitchedClothesDbEntities();
        // GET: Product
        public ActionResult Index()
        {
            ViewBag.Category = new SelectList(db.Categories.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public string Create(string Name, string Description, string Price, int CategoryId)
        {
            var product = new Product();
            product.Name = Name;
            product.Price = Convert.ToDecimal(Price);
            product.CategoryId = CategoryId;
            product.Description = Description;
            db.Products.Add(product);
            var save = db.SaveChanges();
            if (save == 1)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }

        [HttpPost]
        public string Edit(int Id, string EditName, string EditDescription, string EditPrice, int EditCategoryId)
        {
            var Product = db.Products.Find(Id);
            Product.Name = EditName;
            Product.Description = EditDescription;
            Product.Price = Convert.ToDecimal(EditPrice);
            Product.CategoryId = EditCategoryId;
            db.Entry(Product).State = EntityState.Modified;
            var save = db.SaveChanges();
            if (save == 1)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
        public PartialViewResult GetProducts()
        {
            var products = db.Products.ToList();
            return PartialView("~/Views/Product/_loadProducts.cshtml", products);
        }
        public string Search(string good)
        {
            var products = db.Products.ToList();
            if (!string.IsNullOrEmpty(good))
            {
                products = db.Products.Where(x => x.Name == good).ToList();
            }
            return "";
                //PartialView("~/Views/Product/_loadProducts.cshtml", products);

        }
    }
}