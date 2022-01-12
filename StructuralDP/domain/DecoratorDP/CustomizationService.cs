using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDP.DecoratorDP
{
    abstract public class CustomizationService : UpperClassVehicle
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
}
