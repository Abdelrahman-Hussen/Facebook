using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using facebook_mvc.Models;
using facebook_mvc.View_Models;

namespace facebook_mvc.Controllers
{
    public class FriendsController : Controller
    {
        db_facebookEntities db = new db_facebookEntities();

        // GET: Friends
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult profile()
        {
            var user_id = Convert.ToInt32(Session["id"]);

            return View(db.friends.Where(m => m.friend_id == user_id).ToList());
        }

        public ActionResult friend_requst()
        {
            var user_id = Convert.ToInt32(Session["id"]);
            return View(db.friend_requests.Where(m => m.user_id == user_id  ).ToList());
        }

        public ActionResult myFriend(int friend_id)
        {
           // string state = "puplic";
            int x = Convert.ToInt32(Session["id"]);

            var userinfo = db.user_profile.Find(friend_id );
            //var p_posts = db.posts.Where(p => p.post_state.Contains(state));
            addpost user = new addpost
            {
                user = userinfo
            };

            return View(user);
        }

        public ActionResult accept(int friend_id)
        {
            int user_id = Convert.ToInt32(Session["id"]);
            int f_id = Convert.ToInt32(friend_id);

            friend friend_0 = new friend();

            friend_0.user_id = user_id;
            friend_0.user_profile = db.user_profile.Find(user_id);

            friend_0.friend_id = f_id;
            friend_0.user_profile1 = db.user_profile.Find(f_id);

            db.friends.Add(friend_0);
            db.SaveChanges();

            friend friend_1 = new friend();


            friend_1.friend_id = user_id;
            friend_1.user_profile1 = db.user_profile.Find(user_id);

            friend_1.user_id = f_id;
            friend_1.user_profile = db.user_profile.Find(f_id);

            db.friends.Add(friend_1);
            db.SaveChanges();

            db.friend_requests.RemoveRange(db.friend_requests.Where(m => m.user_id == user_id && m.request_id == friend_id).ToList());
            db.SaveChanges();


            return RedirectToAction("friend_requst");

        }

        public ActionResult reject(int friend_id)
        {
            int user_id = Convert.ToInt32(Session["id"]);
            int f_id = Convert.ToInt32(friend_id);

            db.friend_requests.RemoveRange(
                db.friend_requests.Where(
                    r => r.user_id == f_id && r.user_id == f_id).ToList());
            db.SaveChanges();


            return RedirectToAction("Index","Profile");
        }
    }
}