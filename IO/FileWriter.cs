using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.IO
{
    //this class saves data to the csv file
    public class FileWriter : ICarDataAccess
    {
        private string filePath= @"C:\Users\Chani\OneDrive\Desktop\CAR RENTAL SYSTEM\CarRentalSystem2\Cars.csv";

        public FileWriter(string filePath)
        {
            this.filePath = filePath;
        }

        public List<Car> ReadCars()
        {
            throw new NotImplementedException();
        }

        public void WriteCars(List<Car> cars)
        {
            using (var writer = new StreamWriter(filePath))//overwrites the existing content with new content
            {
                writer.WriteLine("Id,Make,Model,Year,Type,Availability,CustomerName,CustomerID,RentalStartDate,ExpectedReturnDate\r\n");//the header
                foreach (var car in cars)
                {
                    writer.WriteLine($"{car.Id},{car.Make},{car.Model},{car.Year},{car.Type},{car.Availability}");//write every car on new line
                }
            }
        }
    }
}
