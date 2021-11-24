using CreationalDP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDP
{
    public interface IVehicleFactory
    {
        public abstract Vehicle ExchangeCar();
        
    }
}
