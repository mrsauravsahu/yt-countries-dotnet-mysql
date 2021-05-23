using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using countries.data.models;
using Microsoft.EntityFrameworkCore;

namespace countries.data.repos
{
    public class CountriesRepo
    {
        private readonly CountriesContext countriesContext;

        public CountriesRepo(CountriesContext countriesContext)
        {
            this.countriesContext = countriesContext;
        }

        public Task<IQueryable<Country>> GetCountriesWithContinentAsync()
        {
            return Task.FromResult(
                countriesContext
                    .Countries
                    .OrderBy(country => country.Name)
                    .Include(country => country.Continent)
                    .AsQueryable()
            );
        }
    }
}