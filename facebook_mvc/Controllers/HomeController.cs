using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using facebook_mvc.Models;

namespace facebook_mvc.Controllers
{
    public class HomeController : Controller
    {
        db_facebookEntities db = new db_facebookEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string searching)
        {
            return View(db.user_profile.Where(x => x.Fname.Contains(searching) || x.mobile.Contains(searching) || x.email.Contains(searching) || searching == null).ToList());
        }



        //AddFriend
        public ActionResult addfriend(int? id) // بتاع الكارد 
        {
            int x = Convert.ToInt32(Session["id"]);
            int re_id = Convert.ToInt32(id);

            friend_requests fr_Re = new friend_requests();

            fr_Re.user_id = x;
            fr_Re.user_profile = db.user_profile.Find(x);

            fr_Re.request_id = re_id;
            fr_Re.user_profile1 = db.user_profile.Find(re_id);

            db.friend_requests.Add(fr_Re);
            db.SaveChanges();

            return RedirectToAction("Index", "Profile");
        }


    }
}