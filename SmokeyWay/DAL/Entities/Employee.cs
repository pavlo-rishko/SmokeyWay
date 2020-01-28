using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        public int PositionId { get; set; }

        public Position Position { get; set; }

        public int GenderId { get; set; }

        public Gender Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public IList<Order> Orders { get; set; }
    }
}
