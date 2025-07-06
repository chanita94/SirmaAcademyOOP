using CarRentalSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CarRentalSystem.Models
{
    //this class loads data from the csv file
    public class FileReader : ICarDataAccess
    {
        //Path to the CSV file with car data
        private string filePath = @"C:\Users\Chani\OneDrive\Desktop\CAR RENTAL SYSTEM\CarRentalSystem2\Cars.csv";

        //Constructor sets the file path
        public FileReader(string filePath)
        {
            this.filePath = filePath;
        }

        //reads car data from the CSV file and returns a list of Car objects
        public List<Car> ReadCars()
        {
            var cars = new List<Car>();

            // If file doesn't exist, return the empty list
            if (!File.Exists(filePath)) return cars;

            //use built-in class to read all lines from the file (each line is a car)
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) // skip header
            {
                var i = line.Split(',');

                if (i.Length >= 10)
                {
                    Customer customer = null;
                    if (!string.IsNullOrEmpty(i[6]))  // CustomerName
                    {
                        customer = new Customer(
                            i[6],                           // Name
                            i[7],                           // ID
                            DateTime.Parse(i[8]),           // RentalStartDate
                            DateTime.Parse(i[9])            // ExpectedReturnDate
                        );
                    }
                    cars.Add(new Car(
                        int.Parse(i[0]),    // Id
                        i[1],               // Make
                        i[2],               // Model
                        int.Parse(i[3]),    // Year
                        i[4],               // Type
                        i[5],                // Availability
                        customer
                    ));
                }
                else
                {
                    Console.WriteLine($"Invalid line: {line}");
                }
            }

            return cars;
        }

        public void WriteCars(List<Car> cars)
        {
            throw new NotImplementedException();
        }
    }
}
