﻿using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Order : BaseEntity<int>
    {
        public DateTime DateTime { get; set; }

        public int TableId { get; set; }

        public Table Table { get; set; }

        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public IList<OrderDish> OrdersDishes { get; set; }
    }
}
