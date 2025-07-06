using System.Collections.Generic;
using CarRentalSystem.Models;

namespace CarRentalSystem.Interfaces
{
    public interface ICarDataAccess
    {
        List<Car> ReadCars();
        void WriteCars(List<Car> cars);
    }
}
