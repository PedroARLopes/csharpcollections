using System;
using System.Collections.Generic;

namespace TopPopulations
{
    class Program
    {
        const string CSV_FILE_PATH = "Pop by Largest Final.csv";
        static void Main(string[] args)
        {
            var reader = new CsvReader2(CSV_FILE_PATH);


            Console.WriteLine("Write country code to lookup");
            var input = Console.ReadLine();


            var countries = reader.ReadAllCountriesDict();
            var country = countries.GetValueOrDefault(input);
            if (country == null)

                Console.WriteLine($"No country information found for country code {input}");
            else
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}, Country Code: {country.Code}");


            /*
            Country[] countries = reader.ReadFirstNCountries(10);
            foreach (var country in countries)
            {
                var key = country.Key;
                var value = country.Value;
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(value.Population).PadLeft(15)}: {value.Name}, Country Code: {key}");
            }*/
        }
    }
}
