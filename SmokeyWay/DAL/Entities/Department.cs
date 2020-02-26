using System.Collections.Generic;

namespace DAL.Entities
{
    public class Department : BaseEntity<int>
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public IList<Employee> Employees { get; set; }

        public IList<Table> Tables { get; set; }
    }
}
