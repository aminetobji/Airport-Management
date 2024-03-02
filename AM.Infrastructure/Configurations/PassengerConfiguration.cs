using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public  class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            builder.OwnsOne(p => p.FullName/* for the passenger*/,f/*for the fullname*/ => {
                f.Property(n => n.FirstName).HasColumnName("PassFirstName").
                HasMaxLength(30);
                f.Property(n => n.LastName).HasColumnName("PassLastName").
                IsRequired();

                //TP5
                //specifies if a an object can be a type of an inherited object
                //Traveller can be passenger or staff we need to say it with hasDescrimintor
                //builder.HasDiscriminator<String>("isTraveller ")
                //    .HasValue<Passenger>("0")
                //    .HasValue<Traveller>("1")
                //    .HasValue<Staff>("2");
                builder.OwnsOne(f => f.FullName, f =>
                {
                    f.Property(n=>n.FirstName).HasColumnName("Pass").HasMaxLength(30);

                });

            });
        }

         
    }
}
