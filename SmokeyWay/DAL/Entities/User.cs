using System;

namespace DAL.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Number { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public DateTime BirthDate { get; set; }

        public int GenderId { get; set; }

        public string CommunicationLanguage { get; set; }

        public string PasswordHash { get; set; }

        public int RoleId { get; set; }

        public virtual Gender Gender { get; set; }
    }
}
