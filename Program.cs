using CarRentalSystem.Models;
using System.Reflection.PortableExecutable;
using CarRentalSystem.Services;
using CarRentalSystem.IO;

namespace CarRentalSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var reader = new FileReader(@"C:\Users\Chani\OneDrive\Desktop\CAR RENTAL SYSTEM\CarRentalSystem\Cars.csv");
            var writer = new FileWriter(@"C:\Users\Chani\OneDrive\Desktop\CAR RENTAL SYSTEM\CarRentalSystem\Cars.csv");

            var service = new CarRentalService(reader, writer);
            var listOfCars = new ListCars(reader, writer);
            var search = new SearchCar(reader);

            Console.WriteLine("Welcome to the Car Rental System!");
            Console.WriteLine("Commands: add, edit <id>, remove <id>, rent <id>, return <id>, list, search <keyword>, save, exit");

            while (true)
            {
                Console.Write("Command: ");
                var input = Console.ReadLine();
                var i = input.Split(' ', 2);
                var cmd = i[0].ToLower();
                var arg = i.Length > 1 ? i[1] : "";

                try
                {
                    switch (cmd)
                    {
                        case "add":
                            Console.WriteLine("Enter: Id,Make,Model,Year,Type,Availability");
                            var data = Console.ReadLine().Split(',');
                            service.AddCar(new Car(
                                int.Parse(data[0]), data[1], data[2],
                                int.Parse(data[3]), data[4], data[5]
                            ));
                            break;

                        case "edit":
                            service.EditCar(int.Parse(arg));
                            break;

                        case "remove":
                            service.RemoveCar(int.Parse(arg));
                            break;

                        case "rent":
                            Console.WriteLine("Enter renter name:");
                            var renterName = Console.ReadLine();

                            Console.WriteLine("Enter renter ID:");
                            var renterId = Console.ReadLine();

                            Console.WriteLine("Enter rental start date (yyyy-MM-dd):");
                            var startDateStr = Console.ReadLine();
                            DateTime startDate = DateTime.Parse(startDateStr);

                            Console.WriteLine("Enter expected return date (yyyy-MM-dd):");
                            var expectedReturnStr = Console.ReadLine();
                            DateTime expectedReturnDate = DateTime.Parse(expectedReturnStr);

                            service.RentCar(int.Parse(arg), renterName, renterId, startDate, expectedReturnDate);
                            break;

                        case "return":
                            service.ReturnCar(int.Parse(arg));
                            break;

                        case "list":
                            listOfCars.List();
                            break;

                        case "search":
                            search.SearchCars(arg);
                            break;

                        case "save":
                            service.Save();
                            Console.WriteLine("Data saved.");
                            break;

                        case "exit":
                            service.Save();
                            Console.WriteLine("Goodbye!");
                            return;

                        default:
                            Console.WriteLine("Unknown command.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
