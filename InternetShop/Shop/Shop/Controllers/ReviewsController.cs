using Shop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    [Authorize]
    public class ReviewsController : BaseController
    {
        // GET: Reviews
        public ActionResult Index([Bind(Prefix ="ID")]int productId)
        {
            var product = _db.Products.Find(productId);

            if (product != null)
            {
                return View(product);
            }

            return HttpNotFound();
        }

        public ActionResult Create(int productId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Review model)
        {
            if(ModelState.IsValid)
            {
                model.Author = User.Identity.Name;
                _db.Reviews.Add(model);
                _db.SaveChanges();

                return RedirectToAction("Index", new { id = model.ProductId });
            }

            return View(model);
        }


        public ActionResult Edit(int id)
        {
            var review = _db.Reviews.Find(id);

            if (review.Author == User.Identity.Name)
            {
                if (review != null)
                {
                    return View(review);
                }
            }
                return RedirectToAction("Index", "Products");
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Review model)
        {
            if (model.Author == User.Identity.Name)
            {
                if (ModelState.IsValid)
                {
                    _db.Entry(model).State = EntityState.Modified;
                    _db.SaveChanges();

                    return RedirectToAction("Index",new { id = model.ProductId});
                }
            }
            return View(model);
        }

    }
}