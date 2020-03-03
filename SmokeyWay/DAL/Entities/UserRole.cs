using System.Collections.Generic;

namespace DAL.Entities
{
    public class UserRole : BaseEntity
    {
        public string Name { get; set; }

        public IList<User> Users { get; set; }
    }
}
