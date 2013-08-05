using System;
using System.Data.Linq;

namespace Northwind.Data
{
    public partial class Employee
    {
        // Task 8 - By inheriting the Employee entity class create a class which allows
        // employees to access their corresponding territories as property of type EntitySet<T>.

        public EntitySet<Territory> EmployeeTerritories
        {
            get
            {
                var emplTerritories = new EntitySet<Territory>();
                emplTerritories.AddRange(this.Territories);

                return emplTerritories;
            }
        }
    }
}
