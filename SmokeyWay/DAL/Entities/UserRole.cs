using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public UserRole()
        {
            this.Users = new List<User>();
        }
    }
}
