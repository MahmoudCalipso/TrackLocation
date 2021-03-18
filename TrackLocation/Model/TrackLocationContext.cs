using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace TrackLocation.Model
{
    public class TrackLocationContext:DbContext
    {
        public TrackLocationContext()
        {
        }

        public TrackLocationContext(DbContextOptions<TrackLocationContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<FamilyCar> FamilyCar { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<TypeCar> TypeCar { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Tracks> Tracks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9GD4K4L;Initial Catalog=TrackLocation;User ID=sa;Password=calipso1996;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False", x => x.UseNetTopologySuite());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

          
            
        }
        


    }
}
