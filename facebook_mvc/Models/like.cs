//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace facebook_mvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class like
    {
        public int like_id { get; set; }
        public Nullable<int> likes { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> post_id { get; set; }
    
        public virtual post post { get; set; }
        public virtual user_profile user_profile { get; set; }
    }
}
