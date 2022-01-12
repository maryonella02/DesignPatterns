using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDP.DecoratorDP
{
    public class SalonOfUpperClassVehicle : UpperClassVehicle
    {
        public override void ChangeSalonType()
        {
            Console.WriteLine("Textile");
        }
    }
}
