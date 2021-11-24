using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructuralDP.FacadeDP
{
    public class CarInteriorFactory
    {
        public void AddTheDashboard()
        {
            Console.WriteLine("The car dashboard was added.");
        }
        public void FixTheSeats()
        {
            Console.WriteLine("The car seats were fixed.");
        }
    }
}
