using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFDataAccessLibrary.Migrations;
using System.Reflection.Metadata;

namespace EFDataAccessLibrary.DataAccess
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options) { }
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> EmailAddresses { get; set; }
        public DbSet<Apartment> Apartments2 { get; set; }
        public DbSet<ApartmentPPM> ApartmentPPMs2 { get; set; }
        public DbSet<ApartmentService> ApartmentServices2 { get; set; }
        public DbSet<ApartmentCheque> ApartmentCheques2 { get; set; }
        public DbSet<Contract> Contracts2 { get; set; }
        public DbSet<ContractDue> ContractDues2 { get; set; }
        public DbSet<PPM> PPMs2 { get; set; }
        public DbSet<PPMtime> PPMtimes2 { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>()
                .HasOne(e => e.PPM)
                .WithOne(e => e.Apartment)
                .HasForeignKey<ApartmentPPM>(e => e.ApartmentNumber)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = ConfigurationManager.ConnectionStrings["EFDemoDB"]?.ConnectionString;
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Connection string 'EFDemoDb' not found.");
                }

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
        //=> optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFDemoDb;Integrated Security=True;");
    }
}
