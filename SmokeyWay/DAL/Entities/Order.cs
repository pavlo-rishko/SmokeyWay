using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public int TableId { get; set; }

        public Table Table { get; set; }

        public int EmployeeId { get; set; }

        public List<OrderDish> OrdersDishes { get; set; }
    }
}
