using System;

namespace BehavioralDP.domain.StateDP
{
    internal class ReverseGear : TransmissionState
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerate it till starts moving.");
        }

        public override void Decelerate()
        {
            Console.WriteLine("Decelerate it till stops moving.");
        }

        public override void TurnLeft()
        {
            Console.WriteLine("Moves slowly to the RIGHT. Here is the trick!");
        }

        public override void TurnRight()
        {
            Console.WriteLine("Moves slowly to the LEFT. Here is the trick!");
        }
    }
}