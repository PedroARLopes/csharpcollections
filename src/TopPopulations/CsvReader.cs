using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace TopPopulations
{
    class CsvReader2
    {
        private string _csvFilePath;

        public CsvReader2(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }

        public Country[] ReadFirstNCountries(int nCountries)
        {
            Country[] countries = new Country[nCountries];

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Country>();
                    var i = 0;
                    foreach (Country country in records)
                    {
                        countries[i] = country;
                        if (i == countries.Length - 1)
                        {
                            break;
                        }
                        i++;
                    }
                }
            }

            return countries;
        }

        public List<Country> ReadAllCountries()
        {
            var countries = new List<Country>();

            using (StreamReader sr = new StreamReader(_csvFilePath))
            {
                using (var csv = new CsvReader(sr, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<Country>();
                    foreach (Country country in records)
                    {
                        countries.Add(country);
                    }
                }
            }

            return countries;
        }
    }
}