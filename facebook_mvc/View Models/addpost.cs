using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using facebook_mvc.Models;

namespace facebook_mvc.View_Models
{
    public class addpost
    {
        public post post { get; set; }
        public user_profile user { get; set; }
        public comment comment { get; set; }
    }
}