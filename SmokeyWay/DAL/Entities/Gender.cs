using System.Collections.Generic;

namespace DAL.Entities
{
    public class Gender
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Descriprion { get; set; }

        public List<User> Users { get; set; }
    }
}
