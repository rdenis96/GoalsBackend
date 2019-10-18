using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Account
{
    public class Account : IEquatable<Account>
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return Equals((Account)obj);
        }

        public bool Equals(Account obj)
        {
            if (obj == null)
                return false;

            return Id == obj.Id &&
                   Username == obj.Username &&
                   Email == obj.Email &&
                   Password == obj.Password;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Username, Email, Password);
        }
    }
}