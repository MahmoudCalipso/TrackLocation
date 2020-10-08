using System;
using System.Collections.Generic;

namespace TrackLocation.Model
{
    public partial class Car
    {
        public Car()
        {
            Location = new HashSet<Location>();
        }

        public long CarId { get; set; }
        public string NameCar { get; set; }
        public int Puissance { get; set; }
        public int NumberPlace { get; set; }
        public string Matricule { get; set; }
        public DateTime DateCirculation { get; set; }
        public int? TotKm { get; set; }
        public long FamilyCarId { get; set; }
        public long UserId { get; set; }
        public long TypeCarId { get; set; }

        public virtual FamilyCar FamilyCar { get; set; }
        public virtual TypeCar TypeCar { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Location> Location { get; set; }
    }
}
