using System.Collections.Generic;

namespace DAL.Entities
{
    public class Gender : BaseEntity<int>
    {
        public string Name { get; set; }

        public string Descriprion { get; set; }

        public IList<Employee> Employees { get; set; }

        public IList<User> Users { get; set; }
    }
}
