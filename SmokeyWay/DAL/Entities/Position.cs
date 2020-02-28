using System.Collections.Generic;

namespace DAL.Entities
{
    public class Position : BaseEntity<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IList<Employee> Employees { get; set; }
    }
}
