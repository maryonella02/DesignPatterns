using System;
using BehavioralDP.domain.StateDP;
using CreationalDP;
using StructuralDP;
using StructuralDP.DecoratorDP;
using StructuralDP.FacadeDP;

namespace BehavioralDP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create a motorcycle: \n");
            VehicleFactory.CreateVehicleByType("moto");

            Console.WriteLine("-------------------");
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

            Console.WriteLine("-------------------");
            Console.WriteLine("\n Let's test our marvelous transmission box! \n");
            var gearTest = new TransmissionBox(new FirstGear());
            gearTest.Accelerate();
            gearTest.TurnRight();
            gearTest.Accelerate();
            gearTest.TurnLeft();
            gearTest.Decelerate();
            gearTest.TurnLeft();
            gearTest.Decelerate();
            gearTest.TurnRight();
            gearTest.Decelerate();
            gearTest.TurnRight();
            gearTest.Decelerate();

            Console.ReadLine();
        }
        public static void RunDecoratorChanges(UpperClassVehicle upperClassVehicle)
        {
            upperClassVehicle.ChangeSalonType();
        }
    }
}
