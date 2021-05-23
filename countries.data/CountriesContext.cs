using countries.data.models;
using Microsoft.EntityFrameworkCore;

namespace countries.data
{
    public class CountriesContext : DbContext
    {
        public CountriesContext(DbContextOptions<CountriesContext> options) : base(options) { }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }
    }
}