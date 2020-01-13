using ECommerce.DAL;
using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.Controllers
{
    public class ECommerceController : Controller
    {
        // GET: ECommerce
        ECommerceDBContext db = new ECommerceDBContext();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User u)
        {
            var c = (from e in db.Users where e.Name == u.Name && e.Password == u.Password select e).FirstOrDefault();
            if (c != null)
            {
                Session["ID"] = u.ID.ToString();
                return RedirectToAction("ProductList");
            }
            else
                return RedirectToAction("SignUp");
        }
        public ActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User u)
        {
            if(ModelState.IsValid)
            {
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(u);
        }
        public ActionResult ProductList()
        {
            return View(db.Items.ToList());
        }
        public ActionResult ProductDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item i = db.Items.Find(id);
            if (i == null)
            {
                return HttpNotFound();
            }
            return View(i);
        }
    }
}