using System;
using System.ComponentModel.DataAnnotations;

namespace TrackLocation.Model
{
    public partial class Tracks
    {
        [Key]
        public long TrackID { get; set; }
        public double latitude { get; set; }
       	public double longitude { get; set; }
       	public int SPEED { get; set; }
        public long ENGINE_RPM {get;set;}
        public string ENGINE_LOAD {get;set;}
        public string AmbientAirTemp {get;set;}
        public string ThrottlePos {get;set;}
        public double insFuel {get;set;}
        public double valX {get;set;}
        public double valY {get;set;}
        public double valZ {get;set;}
        public string zone {get;set;}
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/0:dd/yyyy HH:mm:ss}")]
        public DateTime timestamp { get; set; }

        public long LocationId { get; set; }
        public virtual Location Location { get; set; }
    }
}