using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalDP
{
    public sealed class VehicleDirector
    {
        private static readonly object Instancelock = new object();
        private static VehicleDirector instance = null;

        private VehicleDirector()
        {
        }
        public static VehicleDirector GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (Instancelock)
                    {
                        if (instance == null)
                        {
                            instance = new VehicleDirector();
                        }
                    }
                }
                return instance;
            }
        }
        public Vehicle MakeVehicle(VehicleBuilder vehicleBuilder)
        {
            vehicleBuilder.CreateNewVehicle();
            vehicleBuilder.SetEngineType();
            vehicleBuilder.SetFuelType();
            vehicleBuilder.SetTransmissionType();
            return vehicleBuilder.GetVehicle();
        }
    }
}
