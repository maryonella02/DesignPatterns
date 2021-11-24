using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDP.FacadeDP
{
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
}
