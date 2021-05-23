using System;
using System.Threading.Tasks;
using countries.data.repos;
using Microsoft.EntityFrameworkCore;
using Snapshooter.Xunit;
using Xunit;

namespace countries.data.tests
{
    public class CountriesRepoTests
    {
        private readonly CountriesRepo countriesRepo;

        public CountriesRepoTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<CountriesContext>();
            optionsBuilder.UseMySql("host=sample", new MySqlServerVersion("8.0"));

            var countriesContext = new CountriesContext(optionsBuilder.Options);


            this.countriesRepo = new CountriesRepo(countriesContext);
        }

        [Fact]
        public async Task GetCountriesWithContinentAsync()
        {
            var countries = await countriesRepo.GetCountriesWithContinentAsync();
            Snapshot.Match(countries.ToQueryString());
        }
    }
}
