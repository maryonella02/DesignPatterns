using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDP.DecoratorDP
{
    public class SalonCustomizationService : CustomizationService
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
}
