using System;
using System.Collections.Generic;

namespace TrackLocation.Model
{
    public partial class User
    {
        public User()
        {
            Car = new HashSet<Car>();
            Location = new HashSet<Location>();
        }

        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Cin { get; set; }
        public string NumTel { get; set; }
        public string NumPassport { get; set; }
        public string Password { get; set; }
        public string TypeUser { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Car> Car { get; set; }
        public virtual ICollection<Location> Location { get; set; }

        public static explicit operator User(long v)
        {
            throw new NotImplementedException();
        }
    }
}
