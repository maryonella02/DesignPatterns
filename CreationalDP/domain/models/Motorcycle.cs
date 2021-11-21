using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalDP
{
    class Motorcycle : VehicleBuilder
    {
        public override void SetEngineType()
        {
            vehicleObject.EngineType = "internal combustion";

        }

        public override void SetFuelType()
        {
            vehicleObject.FuelType = "gasoline";

        }

        public override void SetTransmissionType()
        {
            vehicleObject.TransmissionType = "manual";
        }
    }
}
