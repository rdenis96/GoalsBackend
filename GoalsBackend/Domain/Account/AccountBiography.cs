using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Account
{
    public class AccountBiography : IEquatable<AccountBiography>
    {
        public DateTime BirthDate { get; set; }
        public int Gender { get; set; }
        public string About { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string JobTitle { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return Equals((AccountBiography)obj);
        }

        public bool Equals(AccountBiography obj)
        {
            if (obj == null)
                return false;

            return BirthDate == obj.BirthDate &&
                   Gender == obj.Gender &&
                   About == obj.About &&
                   Country == obj.Country &&
                   City == obj.City &&
                   JobTitle == obj.JobTitle;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(BirthDate, Gender, About, Country, City, JobTitle);
        }
    }
}