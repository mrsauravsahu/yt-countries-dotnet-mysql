using System;

namespace countries.data.models
{
    public class Country
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public Continent Continent { get; set; }
    }
}