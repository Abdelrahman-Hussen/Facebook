using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using facebook_mvc.Models;

namespace facebook_mvc.View_Models
{
    public class friends_view
    {
        public user_profile user { get; set; }
        public friend friend { get; set; }
        public friend_requests friend_Requests { get; set; }

    }
}