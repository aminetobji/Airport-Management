using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=AmineTobji;Integrated Security=true;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }



        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }

        public DbSet<Passenger> Passengers { get; set; }

        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        //Configurations using exterior classes 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new PassengerConfiguration());

            //question 2 TP5
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travellers");

            //question 3 tp5
            modelBuilder.ApplyConfiguration(new TicketConfiguration());

            ConfigureConventions(modelBuilder);
        }

        private void ConfigureConventions(ModelBuilder modelBuilder)
        {
            var dateTimeProperties = modelBuilder.Model
            .GetEntityTypes()
            .SelectMany(e => e.GetProperties())
            .Where(p => p.ClrType == typeof(DateTime));

            foreach (var property in dateTimeProperties)
            {
                property.SetColumnType("date");
            }

        }


        ////Methode de prof(Official)
        //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        //{
        //    configurationBuilder.Properties<DateTime>().HaveColumnType("Date");
        //    configurationBuilder.Properties<String>().HaveMaxLength(50);
        //}





    }
}
