using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDataAccessLibrary.DataAccess
{
    public class PeopleContextFactory : IDesignTimeDbContextFactory<PeopleContext>
    {
        public PeopleContext CreateDbContext(string[] args)
        {
            // 1. Build a configuration object to read from appsettings.json (or App.config if you prefer).
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())         // assumes startup project folder
                .AddJsonFile("appsettings.json", optional: true)      // read appsettings.json
                .Build();

            // 2. Read the connection string by name:
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EFDemoDb;Integrated Security=True;";
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                // Fallback to App.config if you’re using ConfigurationManager instead:
                // connectionString = System.Configuration.ConfigurationManager
                //     .ConnectionStrings["EFDemoDb"]?.ConnectionString;
                throw new InvalidOperationException("Connection string 'EFDemoDb' not found.");
            }

            // 3. Create DbContextOptionsBuilder<PeopleContext> and configure the SQL Server provider:
            var optionsBuilder = new DbContextOptionsBuilder<PeopleContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // 4. Return a new PeopleContext with these options:
            return new PeopleContext(optionsBuilder.Options);
        }
    }
}
