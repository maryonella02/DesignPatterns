# DesignPatterns
## Creational Design Patterns

### Author: Brânzeanu Marinela

#### Theory
Structural patterns explain how to assemble objects and classes into larger structures while keeping these structures flexible and efficient.

Some examples of this kind of design patterns are:
* Adapter
* Bridge
* Composite
* Decorator
* Facade
* Flyweight
* Proxy

#### Implementation
I choose to implement Adapter, Decorator and Facade on the base of the Automotive Industry.

**Adapter**

I thought that Vehicle Class would be a good option to be reused at the implementation of this pattern. So it was the Adaptee, while the adapter is class VehicleExchange which trades of a simple car to another more sophisticated.
The interface IVehicleFactory is the domain-specific interface used by the client code.
``` c#
 class VehicleExchange : IVehicleFactory
    {
        private readonly Vehicle _vehicle;
        public VehicleExchange(Vehicle vehicle)
        {
            _vehicle = vehicle;
        }
        -------------------------------------------------------
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
    -------------------------------------------------------
    public interface IVehicleFactory
    {
        public abstract Vehicle ExchangeCar();
        
    }
  ```
  **Decorator Pattern**
Decorator is a structural pattern that allows adding new behaviors to objects dynamically by placing them inside special wrapper objects.  
The base UpperClassVehicle class defines operations that can be altered by decorators.
The class SalonOfUpperClassVehicle provide default implementations of the operations. We can provide several variations of these classes.

``` c#
  public abstract class UpperClassVehicle
    {
        public abstract void ChangeSalonType();
    }
    -------------------------------------------------------
    class SalonOfUpperClassVehicle : UpperClassVehicle
    {
        public override void ChangeSalonType()
        {
            Console.WriteLine("Textile");
        }
    }
```

The CustomizationService class  defines the wrapping interface for all concrete decorators. This is the Decorator which delegates all work to the component.
The SalonCustomizationService class calls the wrapped object and alter its result. 
I've added just one Concrete Decorator, but it is possible to add more.
The client code works with all objects using the Component interface.
This way it can stay independent of the concrete classes of components it works with.


``` c#
  abstract class CustomizationService : UpperClassVehicle
    {
        protected UpperClassVehicle upperClassVehicle;
        public CustomizationService(UpperClassVehicle upperClassVehicle)
        {
            this.upperClassVehicle = upperClassVehicle;
        }
        public void SetComponent(UpperClassVehicle upperClassVehicle)
        {
            this.upperClassVehicle = upperClassVehicle;
        }

        public override void ChangeSalonType()
        {
            if (upperClassVehicle != null)
            {
                this.upperClassVehicle.ChangeSalonType();
            }
        }
    }
    -------------------------------------------------------
     class SalonCustomizationService : CustomizationService
    {
        public SalonCustomizationService(UpperClassVehicle upperClassVehicle) : base(upperClassVehicle)
        {
        }

        public override void ChangeSalonType()
        {
            Console.Write("Change Salon to Leather From ");
            base.ChangeSalonType();
        }
    }
    -------------------------------------------------------

      public static void RunDecoratorChanges(UpperClassVehicle upperClassVehicle)
        {
            upperClassVehicle.ChangeSalonType();
        }
```
**Facade Pattern**

Facade is a structural design pattern that provides a simplified (but limited) interface to a complex system of classes, library or framework.
The AssemblingPoint class is our facade. The Facade delegates the client requests to the appropriate objects within the subsystem. The Facade is also responsible
for managing their lifecycle. All of this shields the client from the undesired complexity of the subsystem.
The CarExteriorFactory and CarInteriorFactory are the subsystems controlled by AssemblingPoint.

``` c#
    public class AssemblingPoint
    {
        protected CarInteriorFactory carInteriorFactory;
        protected CarExteriorFactory carExteriorFactory;

        public AssemblingPoint(CarExteriorFactory carExteriorFactory, CarInteriorFactory carInteriorFactory)
        {
            this.carExteriorFactory = carExteriorFactory;
            this.carInteriorFactory = carInteriorFactory;
        }

        public void AssembleTheCar()
        {
            carExteriorFactory.CreateTheCarFramework();
            carExteriorFactory.PaintTheCar();
            carInteriorFactory.AddTheDashboard();
            carInteriorFactory.FixTheSeats();
        }
    }
    
    -------------------------------------------------------
    
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
````

The driver code is:
``` c#

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
          
```

The output is:
```console
Create a simple car:

The car framework is created.
The car is painted.
The car dashboard was added.
The car seats were fixed.

Transmission Type : automatic
Engine Type : internal combustion
Fuel Type : diesel
-------------------
Exchange to super car:
Transmission Type : extra Transmission
Engine Type : extra Engine
Fuel Type : extra Fuel
-------------------
Textile
Change Salon to Leather From Textile

```
