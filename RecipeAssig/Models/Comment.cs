//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RecipeAssig.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int Id { get; set; }
        public Nullable<int> RecipeId { get; set; }
        public string Comment1 { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<bool> Disable { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public virtual Recipe Recipe { get; set; }
        public virtual User User { get; set; }
    }
}
