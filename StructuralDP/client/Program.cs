using System;
using CreationalDP;
using StructuralDP.DecoratorDP;
using StructuralDP.FacadeDP;

namespace StructuralDP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create a simple car: \n");  

            var carExteriorFactory = new CarExteriorFactory();
            var carInteriorFactory = new CarInteriorFactory();
            var assemblingPoint = new AssemblingPoint(carExteriorFactory, carInteriorFactory);
            assemblingPoint.AssembleTheCar();

            Console.WriteLine();
            var car = VehicleFactory.CreateVehicleByType("car");

            Console.WriteLine("-------------------");

            Console.WriteLine("Exchange to super car:");
            IVehicleFactory vehicleFactory = new VehicleExchange(car);
            vehicleFactory.ExchangeCar();

            Console.WriteLine("-------------------");

            var salonChange = new SalonOfUpperClassVehicle();
            RunDecoratorChanges(salonChange);

            var salonChange2 = new SalonCustomizationService(salonChange);
            RunDecoratorChanges(salonChange2);
          
            Console.ReadLine();

        }
        public static void RunDecoratorChanges(UpperClassVehicle upperClassVehicle)
        {
            upperClassVehicle.ChangeSalonType();
        }
       
    }
}
