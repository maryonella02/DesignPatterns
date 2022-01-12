using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDP.domain.StateDP
{
    class FirstGear : TransmissionState
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerate it till starts moving.");
            this._transmissionBox.TransitionTo(new SecondGear());
        }

        public override void Decelerate()
        {
            Console.WriteLine("Decelerate it till stops moving and shifts to Reverse Gear.");
            //lets image that in real life if you decelerate enough you shift the gear to reverse.
            this._transmissionBox.TransitionTo(new ReverseGear());
        }

        public override void TurnLeft()
        {
            Console.WriteLine("Moves slowly to the left.");
        }

        public override void TurnRight()
        {
            Console.WriteLine("Moves slowly to the right.");
        }
    }
}
