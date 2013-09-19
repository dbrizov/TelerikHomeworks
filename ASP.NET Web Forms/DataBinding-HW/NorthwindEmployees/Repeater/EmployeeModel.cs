using Northwind.Data;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace NorthwindEmployees.Repeater
{
    [Serializable]
    public class EmployeeModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Notes { get; set; }

        public static Expression<Func<Employee, EmployeeModel>> FromEmployeeEntity()
        {
            return entity => new EmployeeModel()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Title = entity.Title,
                City = entity.City,
                Address = entity.Address,
                Notes = entity.Notes
            };
        }
    }
}