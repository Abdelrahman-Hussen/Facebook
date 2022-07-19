using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using facebook_mvc.Models;
using facebook_mvc.View_Models;

namespace facebook_mvc.Controllers
{
    public class UserController : Controller
    {
        db_facebookEntities db = new db_facebookEntities();

        public object ImageFile { get; private set; }

        public ActionResult signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult signup(FormCollection form , HttpPostedFileBase ImageFile)
        {
            user_profile user = new user_profile();
            user.Fname = form["fname"].ToString();
            user.Lname = form["lname"].ToString();
            user.email = form["email"].ToString();
            user.password = form["pass"].ToString();

            string path = "";
            if (ImageFile.FileName.Length > 0)
            {
                path = "~/images/" + Path.GetFileName(ImageFile.FileName);
                ImageFile.SaveAs(Server.MapPath(path));
            }

            user.profile_img = path;

            db.user_profile.Add(user);
            db.SaveChanges();

            Session["id"] = user.user_id;
            return RedirectToAction("Index", "Profile");


        }

        public ActionResult login(user_profile user)
        {
            var obj = db.user_profile.Where(z => z.email.Equals(user.email) && z.password.Equals(user.password)).FirstOrDefault();

            if (obj == null)
            {
                //ViewBag.loginErrormassage = "Wrong username or password";
                return View(user);
            }
            else
            {
                Session["id"] = obj.user_id;
                return RedirectToAction("Index", "Profile");

            }
        }


        // GET: user_profile/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            user_profile user_profile = db.user_profile.Find(id);
            if (user_profile == null)
            {
                return HttpNotFound();
            }
            return View(user_profile);
        }

        // POST: user_profile/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(user_profile user_profile, HttpPostedFileBase ImageFile)
        {
            
            if (ModelState.IsValid)
            {
                string path = "";
                if (ImageFile.FileName.Length > 0)
                {
                    path = "~/images/" + Path.GetFileName(ImageFile.FileName);
                    ImageFile.SaveAs(Server.MapPath(path));
                }

                user_profile.profile_img = path;
                db.Entry(user_profile).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index", "Profile");
            }
            return View(user_profile);
        }
    }
}