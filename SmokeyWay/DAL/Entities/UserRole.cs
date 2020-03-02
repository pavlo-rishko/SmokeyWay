using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserRole : BaseEntity
    {
        public string Name { get; set; }

        public virtual IList<User> Users { get; set; }
    }
}
