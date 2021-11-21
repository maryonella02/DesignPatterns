# DesignPatterns
## Creational Design Patterns

### Author: Brânzeanu Marinela

#### Theory
In software engineering, creational design patterns are design patterns that deal with object creation mechanisms, trying to create objects in a manner suitable to the situation.

The basic form of object creation could result in design problems or added complexity to the design. Creational design patterns solve this problem by somehow controlling this object creation.

Some examples of this kind of design patterns are :
* Singleton
* Builder
* Prototype
* Factory Method
* Abstract Factory

#### Implementation
I choose to implement Factory Method, Builder and Singleton with the emphasis on the fundamental object Vehicle.

**Singleton Pattern**

I thought that VehicleDirector is the perfect choice for making as a singleton class because  we need to ensure that only one instance of a particular class is going to be created.
I choose to implement it lazy-loaded.

``` c#
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
  ```
  **Factory Pattern**
  
VehicleFactory class is used to Create Vehicle by type with the help of a switch that gets string value as parameter to create vehicle type. 

``` c#
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
```

**Builder Pattern**

Inside the previous code snippet you can observe that inside switch cases we create specific instances according to parameter. 
And that specific object (car) is send to MakeVehicle method of our singleton class VehicleDirector which returns the vehicle object with all properties set with the help of abstract class VehicleBuilder and specific values of wanted instance (car).

``` c#
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

            VehicleFactory.CreateVehicleByType("car");
          
            Console.WriteLine("-------------------");

            VehicleFactory.CreateVehicleByType("moto");

            Console.WriteLine("-------------------");

```

The output is:
```console
Transmission Type : automatic
Engine Type : internal combustion
Fuel Type : diesel
-------------------
Transmission Type : manual
Engine Type : internal combustion
Fuel Type : gasoline
-------------------
```
