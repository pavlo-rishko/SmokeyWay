using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserRole : BaseEntity<int>
    {
        public int Name { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
