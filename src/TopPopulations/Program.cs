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

            Country[] countries = reader.ReadFirstNCountries(500);
            //List<Country> countries = reader.ReadAllCountries();

            foreach (Country country in countries)
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
        }
    }
}
