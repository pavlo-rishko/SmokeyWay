using System;

namespace DAL.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateDateTime { get; set; }

        public DateTime? UpdateDateTime { get; set; }
    }
}
