using CarRentalSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalSystem.Interfaces
{
    public interface IVehicle
    {
        int Id { get; set; }
        string Make { get; set; }
        string Model { get; set; }
        int Year { get; set; }
        string Type { get; set; }
        string Availability { get; set; }
        Customer CurrentRenter { get; set; }

        string GetVehicleInfo();
    }
}

