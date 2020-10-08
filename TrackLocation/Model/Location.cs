using System;
using System.Collections.Generic;
using System.Linq;

namespace TrackLocation.Model
{
    public partial class Location
    {
        public long LocationId { get; set; }
        public string Tracking { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long UserId { get; set; }
        public long CarId { get; set; }
        public byte? Severity { get; set; }

        public virtual Car Car { get; set; }
        public virtual User User { get; set; }

       
    }
}
