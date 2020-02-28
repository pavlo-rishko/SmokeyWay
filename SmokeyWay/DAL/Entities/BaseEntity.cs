using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class BaseEntity<TKey>
    {
        public TKey Id { get; set; }

        public DateTime CreateDateTime { get; private set; } = DateTime.Now;

        public DateTime? UpdateDateTime { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}
