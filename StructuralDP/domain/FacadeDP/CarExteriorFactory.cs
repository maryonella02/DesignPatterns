using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDP.FacadeDP
{
    public class CarExteriorFactory
    {
        public void CreateTheCarFramework()
        {
            Console.WriteLine("The car framework is created.");
        } 
        public void PaintTheCar()
        {
            Console.WriteLine("The car is painted.");
        }
    }
}
