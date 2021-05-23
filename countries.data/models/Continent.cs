using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace countries.data.models
{
    public class Continent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public ICollection<Country> Countries { get; set; }
    }
}