using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalDP
{
    public class Vehicle
    {
        public string TransmissionType { get; set; }
        public string EngineType { get; set; }
        public string FuelType { get; set; }


        public Vehicle GetClone()
        {
            return (Vehicle)this.MemberwiseClone();
        }
        public void GetVehicle()
        {
            Console.WriteLine("Transmission Type : " + TransmissionType);
            Console.WriteLine("Engine Type : " + EngineType);
            Console.WriteLine("Fuel Type : " + FuelType);
        }
    }
}
