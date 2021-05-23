using System;
using countries.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace countries.migrations
{
    public class CountriesDesignTimeDbContextFactory : IDesignTimeDbContextFactory<CountriesContext>
    {
        public CountriesContext CreateDbContext(string[] args)
        {
            var connectionString = Environment.GetEnvironmentVariable("COUNTRIES_DESIGNTIME_CONNECTIONSTRING");
            var mySqlServerVersion = Environment.GetEnvironmentVariable("COUNTRIES_MYSQL_VERSION");

            var optionsBuilder = new DbContextOptionsBuilder<CountriesContext>();
            optionsBuilder.UseMySql(
                connectionString,
                new MySqlServerVersion(mySqlServerVersion),
                options => options.MigrationsAssembly("countries.migrations")
            );


            var countriesContext = new CountriesContext(optionsBuilder.Options);
            return countriesContext;
        }
    }
}