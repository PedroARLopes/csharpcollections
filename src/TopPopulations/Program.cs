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

            //Country[] countries = reader.ReadFirstNCountries(10);
            List<Country> countries = reader.ReadAllCountries();
            Country lillliput = new Country("Lilliput", "LIL", "Somewhere", 2_000_000);
            int lilliputIndex = countries.FindIndex(x => x.Population < 2_000_000);
            countries.Insert(lilliputIndex, lillliput);
            countries.RemoveAt(lilliputIndex);

            foreach (Country country in countries)
                Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
        }
    }
}
