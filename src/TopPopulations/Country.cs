using System;
using CsvHelper.Configuration.Attributes;

namespace TopPopulations
{
    public class Country
    {
        [Index(0)]
        public string Name { get; set; }

        [Index(1)]
        public string Code { get; set; }

        [Index(2)]
        public string Region { get; set; }

        [Index(3)]
        public int Population { get; set; }

        public Country()
        {
        }

        public Country(string name, string code, string region, int population)
        {
            Name = name;
            Code = code;
            Region = region;
            Population = population;
        }
    }
}