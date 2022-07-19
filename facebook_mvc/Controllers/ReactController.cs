using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using facebook_mvc.Models;

namespace facebook_mvc.Controllers
{
    public class ReactController : Controller
    {
        // GET: React
        db_facebookEntities db = new db_facebookEntities();
        public ActionResult Like(int post_id)
        {

            var post = db.posts.Find(post_id);
            post.likesNumber++;

            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Profile");

            }
            
            return RedirectToAction("Index", "Profile");
        }


        public ActionResult Dislike(int post_id)
        {

            var post = db.posts.Find(post_id);
            post.likesNumber--;

            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Profile");

            }

            return RedirectToAction("Index", "Profile");
        }
    }
}