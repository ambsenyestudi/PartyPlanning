using System;
using System.Collections.Generic;
using System.Text;

namespace PartyPlanning.Domain.Users
{
    public class Profile
    {
        
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public ProfileId ProfileId { get; }
        public string Name { get; private set; }

        public Profile(ProfileId profileId)
        {
            this.ProfileId = profileId;
            this.Name = string.Empty;
            this.Surname = string.Empty;
            this.Email = string.Empty;
        }

        
    }
}
