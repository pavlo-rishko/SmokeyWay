using System;
using System.Collections.Generic;

namespace DAL.Entities
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public string PhoneNumber { get; set; }

        public int PositionId { get; set; }

        public EmployeePosition Position { get; set; }

        public int GenderId { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public IList<Order> Orders { get; set; }

        public IList<OfflineTableReservation> OfflineTableResrvations { get; set; }
    }
}
