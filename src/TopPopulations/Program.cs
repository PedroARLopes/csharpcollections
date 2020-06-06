using System;
using System.Collections.Generic;
using System.Linq;

namespace TopPopulations
{
    class Program
    {
        const string CSV_FILE_PATH = "Pop by Largest Final.csv";
        static void Main(string[] args)
        {
            var reader = new CsvReader2(CSV_FILE_PATH);


            /*
                Console.WriteLine("Write country code to lookup");
                var input = Console.ReadLine();
                var countries = reader.ReadAllCountriesDict();
                var country = countries.GetValueOrDefault(input);
                if (country == null)

                    Console.WriteLine($"No country information found for country code {input}");
                else
                    Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}, Country Code: {country.Code}");
            */

            // Groupd countries by region
            List<Country> countries = reader.ReadAllCountries();
            var countriesByRegion = new Dictionary<string, List<string>>();
            countries.ForEach(c =>
            {
                var regionCountries = countriesByRegion.GetValueOrDefault(c.Region);
                if (regionCountries == null)
                {
                    regionCountries = new List<string>();
                    countriesByRegion.Add(c.Region, regionCountries);
                }
                regionCountries.Add(c.Name);
            });

            // Print region followed by its countries
            countriesByRegion.ToList().ForEach(kv =>
            {
                Console.WriteLine($"Region: {kv.Key}");
                kv.Value.ForEach(c => Console.WriteLine($"Country: {c}"));
            });

            Console.WriteLine("Select region whose top 10 countries should be printed");
            var input = Console.ReadLine();

            var regionCountries = countriesByRegion.GetValueOrDefault(input);
            if (regionCountries == null)
            {
                Console.WriteLine("Region not found");
                return;
            }

            regionCountries.Take(10).ToList().ForEach(x => Console.WriteLine(x));
        }
    }
}
