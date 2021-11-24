using CreationalDP;
using StructuralDP.DecoratorDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDP
{
    class VehicleExchange : IVehicleFactory
    {
        private readonly Vehicle _vehicle;
        public VehicleExchange(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }

        public Vehicle ExchangeCar()
        {
            var superCar = _vehicle;
            superCar.TransmissionType = "extra Transmission";
            superCar.EngineType = "extra Engine";
            superCar.FuelType = "extra Fuel";
            superCar.GetVehicle();
            return superCar;
        }
    }
}
