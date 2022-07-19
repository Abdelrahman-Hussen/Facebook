using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using facebook_mvc.Models;
using facebook_mvc.View_Models;


namespace facebook_mvc.Controllers
{
    public class ProfileController : Controller
    {
        db_facebookEntities db = new db_facebookEntities();
        // GET: Profile
        public ActionResult Index()
        {
            
            int x = Convert.ToInt32(Session["id"]);
            var userinfo = db.user_profile.Find(x);
            addpost user = new addpost
            {
                user = userinfo

            };

            return View(user);
        }
        [HttpGet]
        public ActionResult addpost()
         {
            return RedirectToAction("Index", "Profile");
        }

         [HttpPost]
         public ActionResult addpost(string post_description)
         {
            post post = new post();
            string state = "puplic";
            int likes = 0;
            int user_id = Convert.ToInt32(Session["id"]);
            post.likesNumber = likes;
            post.post_state = state;
            post.user_id = user_id;
            post.post_description = post_description;
            db.posts.Add(post);
            db.SaveChanges();
            return RedirectToAction("Index", "Profile");
        }


        public ActionResult addcomment()
        {
            return View();

        }

        [HttpPost]
        public ActionResult addcomment(comment comment)
        {
            int x = Convert.ToInt32(Session["id"]);

            //comment comment = new comment();

            
            comment.user_id = x;

            db.comments.Add(comment);
            db.SaveChanges();

            return RedirectToAction("Index", "Profile");

        }

        public ActionResult single_post(int post_id)
        {

            var post = db.posts.Include(e=> e.comments).Single(e => e.post_id == post_id);

            
            return View(post);
            

        }


        [HttpGet]
        public ActionResult editpost()
        {
            return RedirectToAction("Index", "Profile");
        }

        [HttpPost]
        public ActionResult editpost(post post)
        {
            int x = Convert.ToInt32(Session["id"]);
            post.user_id = x;
           
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;

                db.Entry(post).Property("post_description").IsModified = false;
                db.Entry(post).Property("likesNumber").IsModified = false;

                db.SaveChanges();

                return RedirectToAction("Index","Profile");
            }


            return RedirectToAction("Index", "Profile");
        }

        public ActionResult edit_post_page (int post_id)
        {
            var post = db.posts.Include(e => e.comments).Single(e => e.post_id == post_id);

            return View(post);
        }



    }
}