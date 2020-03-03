using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserRole : BaseEntity
    {
        public int Name { get; set; }

        public IList<User> Users { get; set; }
    }
}
