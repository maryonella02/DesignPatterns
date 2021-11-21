using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalDP
{
    public abstract class VehicleBuilder
    {
        protected Vehicle vehicleObject;
        public abstract void SetTransmissionType();
        public abstract void SetEngineType();
        public abstract void SetFuelType();
        public void CreateNewVehicle()
        {
            vehicleObject = new Vehicle();
        }
        public Vehicle GetVehicle()
        {
            return vehicleObject;
        }
    }
}
