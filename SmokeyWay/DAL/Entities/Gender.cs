using System.Collections.Generic;

namespace DAL.Entities
{
    public class Gender
    {
        public Gender()
        {
            this.Users = new List<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Descriprion { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
