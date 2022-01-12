using System;

namespace BehavioralDP.domain.StateDP
{
    internal class ThirdGear : TransmissionState
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerate till you feel like in Need for Speed.");
        }

        public override void Decelerate()
        {
            Console.WriteLine("Decelerate till it shifts to the second gear.");
            this._transmissionBox.TransitionTo(new SecondGear());
        }

        public override void TurnLeft()
        {
            Console.WriteLine("Moves fast to the left.");
        }

        public override void TurnRight()
        {
            Console.WriteLine("Moves fast to the right.");
        }
    }
}