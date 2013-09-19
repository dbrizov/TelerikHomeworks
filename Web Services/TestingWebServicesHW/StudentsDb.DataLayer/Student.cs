//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentsDb.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Student
    {
        public Student()
        {
            this.Marks = new HashSet<Mark>();
        }
    
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<double> Grade { get; set; }
        public int SchoolId { get; set; }
    
        public virtual ICollection<Mark> Marks { get; set; }
        public virtual School School { get; set; }
    }
}