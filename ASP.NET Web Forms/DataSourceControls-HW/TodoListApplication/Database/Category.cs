//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TodoListApplication.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Category
    {
        public Category()
        {
            this.Todos = new HashSet<Todo>();
        }
    
        public int CategoryId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Todo> Todos { get; set; }
    }
}