using PartyPlanning.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PartyPlanning.Domain.Users
{
    public class ProfileId : IdValue, IEquatable<ProfileId>
    {

        public ProfileId() : base()
        {
        }

        public bool Equals(ProfileId other) =>
            base.Equals(other);
        
    }
}
