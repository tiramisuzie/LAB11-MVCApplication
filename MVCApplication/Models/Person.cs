using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MVCApplication.Models
{
    public class Person
    {
        // Properties based on parsed CSV data
        public int Year { get; set; }
        public string Honor { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public int Birth_Year { get; set; }
        public int DeathYear { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Context { get; set; }

        // This static method is called once to parse the personOfTheYear.csv file. This turns the raw data and bind it to Person properties.
        public static List<Person> GetPersons(int startYear, int endYear)
        {
            // Create a List collection with Type Person
            List<Person> people = new List<Person>();
            // Get the relative path of current directory
            string path = Environment.CurrentDirectory;
            // Create a full path of personOfTheYear.csv
            string newPath = Path.GetFullPath(Path.Combine(path, @"wwwroot\personOfTheYear.csv"));
            // Read All line in the .csv file and store as an array of strings
            string[] Lines = File.ReadAllLines(newPath);

            // Loop through the Lines string array containing data from personOfTheYear.csv and parse each line of the string to fit the each property of Person.
            for (int i = 1; i < Lines.Length; i++)
            {
                // Properties are split by comma in the .csv file
                // Year,Honor,Name,Country,Birth Year,Death Year,Title,Category,Context
                // [0, 1, 2, 3, 4, 5, 6, 7, 8]
                string[] fields = Lines[i].Split(',');
                people.Add(new Person
                {
                    Year = Convert.ToInt32(fields[0]),
                    Honor = fields[1],
                    Name = fields[2],
                    Country = fields[3],
                    Birth_Year = (fields[4] == "") ? 0 : Convert.ToInt32(fields[4]),
                    DeathYear = (fields[5] == "") ? 0 : Convert.ToInt32(fields[5]),
                    Title = fields[6],
                    Category = fields[7],
                    Context = fields[8],
                });
            }

            // List of Person, use LAMBDA to grab the objects where their Year is greater or equal than to the start Year AND less or equal than to the end Year.
            List<Person> listofPeople = people.Where(p => (p.Year >= startYear) && (p.Year <= endYear)).ToList();

            // Return filter Person list
            return listofPeople;
        }
    }
}
