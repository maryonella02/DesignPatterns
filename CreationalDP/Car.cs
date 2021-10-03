using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalDP
{
    class Car : VehicleBuilder
    {
        public override void SetEngineType()
        {
            vehicleObject.EngineType = "internal combustion";
        }

        public override void SetFuelType()
        {
            vehicleObject.FuelType = "diesel";
        }

        public override void SetTransmissionType()
        {
            vehicleObject.TransmissionType = "automatic";
        }
    }
}
