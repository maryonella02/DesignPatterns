using System;
using System.Threading.Tasks;

namespace CreationalDP
{
    class Program
    {
        static void Main(string[] args)
        { 

            VehicleFactory.CreateVehicleByType("car");
          
            Console.WriteLine("-------------------");

            VehicleFactory.CreateVehicleByType("moto");

            Console.WriteLine("-------------------");
        }
    }
}
