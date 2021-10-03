using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalDP
{
    class VehicleFactory
    {
        public static Vehicle CreateVehicleByType(string vehicleType)
        {
            Vehicle vehicle = null;
            VehicleDirector vehicleDirector = VehicleDirector.GetInstance;
            switch (vehicleType)
            {
                case "car":
                    Car car = new Car();
                    vehicle = vehicleDirector.MakeVehicle(car);
                    vehicle.GetVehicle();
                    break;
                case "moto":
                    Motorcycle moto = new Motorcycle();
                    vehicle = vehicleDirector.MakeVehicle(moto);
                    vehicle.GetVehicle();
                    break;
            }
            return vehicle;
        }
    }
}
