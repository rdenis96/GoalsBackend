using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Account
{
    public class AccountProfile : IEquatable<AccountProfile>
    {
        public string ProfileImage { get; set; }
        public bool EmailVisible { get; set; }
        public AccountBiography Biography { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            return Equals((AccountProfile)obj);
        }

        public bool Equals(AccountProfile obj)
        {
            if (obj == null)
                return false;

            return ProfileImage == obj.ProfileImage &&
                   EmailVisible == obj.EmailVisible &&
                   EqualityComparer<AccountBiography>.Default.Equals(Biography, obj.Biography);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProfileImage, EmailVisible, Biography);
        }
    }
}