using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnstitchedClothes.Database;

namespace UnstitchedClothes.Controllers
{
    public class CategoryController : Controller
    {
        UnstitchedClothesDbEntities db = new UnstitchedClothesDbEntities();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string Create(string Name, string Description)
        {
            var category = new Category();
            category.Name = Name;
            category.Description = Description;
            db.Categories.Add(category);
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
        public string Edit(int Id, string EditName, string EditDescription)
        {
            var category = db.Categories.Find(Id);
            category.Name = EditName;
            category.Description = EditDescription;
            db.Entry(category).State = EntityState.Modified;
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
        public PartialViewResult GetCategories()
        {
            var getCategory = db.Categories;
            return PartialView("~/Views/Category/_loadCategories.cshtml", getCategory);
        }
    }
}