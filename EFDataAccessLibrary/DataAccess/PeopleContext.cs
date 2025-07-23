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

        public List<Alert> GetAlerts(DateTime targetDate)
        {
            var today = DateTime.Today;

            var tenancyAlerts = Apartments2
                .Where(a => a.ContractEndDate == targetDate)
                .Select(a => new Alert
                {
                    BuildingNumber = 2,
                    About = a.ApartmentNumber.ToString(),
                    EventDate = a.ContractEndDate,
                    Description = "Tenancy Deadline"
                });

            var chequeAlerts = ApartmentCheques2
                .Where(c => c.DueDate == targetDate && !c.IsCashed)
                .Select(c => new Alert
                {
                    BuildingNumber = 2,
                    About = c.ApartmentNumber.ToString(),
                    EventDate = c.DueDate,
                    Description = "Cheque Payment Due"
                });

            var Q1PPMAlerts = ApartmentPPMs2
                .Where(p => p.Q1Date == targetDate && !p.Q1Done)
                .Select(p => new Alert
                {
                    BuildingNumber = 2,
                    About = p.ApartmentNumber.ToString(),
                    EventDate = p.Q1Date,
                    Description = "AC cleaning Q1"
                });

            var Q2PPMAlerts = ApartmentPPMs2
                .Where(p => p.Q2Date == targetDate && !p.Q2Done)
                .Select(p => new Alert
                {
                    BuildingNumber = 2,
                    About = p.ApartmentNumber.ToString(),
                    EventDate = p.Q2Date,
                    Description = "AC cleaning Q2"
                });

            var Q3PPMAlerts = ApartmentPPMs2
                .Where(p => p.Q3Date == targetDate && !p.Q3Done)
                .Select(p => new Alert
                {
                    BuildingNumber = 2,
                    About = p.ApartmentNumber.ToString(),
                    EventDate = p.Q3Date,
                    Description = "AC cleaning Q3"
                });

            var Q4PPMAlerts = ApartmentPPMs2
                .Where(p => p.Q4Date == targetDate && !p.Q4Done)
                .Select(p => new Alert
                {
                    BuildingNumber = 2,
                    About = p.ApartmentNumber.ToString(),
                    EventDate = p.Q4Date,
                    Description = "AC cleaning Q4"
                });

            return tenancyAlerts
                .Union(chequeAlerts)
                .Union(Q1PPMAlerts)
                .Union(Q2PPMAlerts)
                .Union(Q3PPMAlerts)
                .Union(Q4PPMAlerts)
                .ToList();
        }

        public List<Alert> GetTodaysAlerts(DateTime targetDate)
        {
            var today = DateTime.Today;

            var tenancyAlerts = Apartments2
                .Where(a => a.ContractEndDate == targetDate)
                .Select(a => new Alert
                {
                    BuildingNumber = 2,
                    About = a.ApartmentNumber.ToString(),
                    EventDate = a.ContractEndDate,
                    Description = "Tenancy Deadline"
                });

            var chequeAlerts = ApartmentCheques2
                .Where(c => c.DueDate <= targetDate && c.DueDate != DateTime.MinValue && !c.IsCashed)
                .Select(c => new Alert
                {
                    BuildingNumber = 2,
                    About = c.ApartmentNumber.ToString(),
                    EventDate = c.DueDate,
                    Description = "Cheque Payment Due"
                });

            var Q1PPMAlerts = ApartmentPPMs2
                .Where(p => p.Q1Date <= targetDate && p.Q1Date != DateTime.MinValue && !p.Q1Done)
                .Select(p => new Alert
                {
                    BuildingNumber = 2,
                    About = p.ApartmentNumber.ToString(),
                    EventDate = p.Q1Date,
                    Description = "AC cleaning Q1"
                });

            var Q2PPMAlerts = ApartmentPPMs2
                .Where(p => p.Q2Date <= targetDate && p.Q2Date != DateTime.MinValue && !p.Q2Done)
                .Select(p => new Alert
                {
                    BuildingNumber = 2,
                    About = p.ApartmentNumber.ToString(),
                    EventDate = p.Q2Date,
                    Description = "AC cleaning Q2"
                });

            var Q3PPMAlerts = ApartmentPPMs2
                .Where(p => p.Q3Date <= targetDate && p.Q3Date != DateTime.MinValue && !p.Q3Done)
                .Select(p => new Alert
                {
                    BuildingNumber = 2,
                    About = p.ApartmentNumber.ToString(),
                    EventDate = p.Q3Date,
                    Description = "AC cleaning Q3"
                });

            var Q4PPMAlerts = ApartmentPPMs2
                .Where(p => p.Q4Date <= targetDate && p.Q4Date != DateTime.MinValue && !p.Q4Done)
                .Select(p => new Alert
                {
                    BuildingNumber = 2,
                    About = p.ApartmentNumber.ToString(),
                    EventDate = p.Q4Date,
                    Description = "AC cleaning Q4"
                });

            return tenancyAlerts
                .Union(chequeAlerts)
                .Union(Q1PPMAlerts)
                .Union(Q2PPMAlerts)
                .Union(Q3PPMAlerts)
                .Union(Q4PPMAlerts)
                .ToList();
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
