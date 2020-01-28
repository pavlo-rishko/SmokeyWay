using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserRole
    {
        public int Id { get; set; }

        public int Name { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
