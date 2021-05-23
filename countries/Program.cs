using System;
using Microsoft.EntityFrameworkCore;
using countries.data;
using countries.data.repos;
using System.Linq;
using System.Text.Json;

var connectionString = Environment.GetEnvironmentVariable("COUNTRIES_CONNECTIONSTRING");
var mySqlServerVersion = Environment.GetEnvironmentVariable("COUNTRIES_MYSQL_VERSION");

var optionsBuilder = new DbContextOptionsBuilder<CountriesContext>();
optionsBuilder.UseMySql(
    connectionString,
    new MySqlServerVersion(mySqlServerVersion),
    options => options.MigrationsAssembly("countries.migrations")
);


var countriesContext = new CountriesContext(optionsBuilder.Options);

var countriesRepo = new CountriesRepo(countriesContext);

var countries = await countriesRepo.GetCountriesWithContinentAsync();
var countriesJsonString = JsonSerializer.Serialize(countries, new JsonSerializerOptions
{
    WriteIndented = true,
});
Console.WriteLine(countriesJsonString);