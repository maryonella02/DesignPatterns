using System;

namespace BehavioralDP.domain.StateDP
{
    internal class SecondGear : TransmissionState
    {
        public override void Accelerate()
        {
            Console.WriteLine("Accelerate till it shifts to the third gear.");
            this._transmissionBox.TransitionTo(new ThirdGear());
        }

        public override void Decelerate()
        {
            Console.WriteLine("Decelerate till it shifts to the first gear.");
            this._transmissionBox.TransitionTo(new FirstGear());
        }

        public override void TurnLeft()
        {
            Console.WriteLine("Moves rapidly to the left.");
        }

        public override void TurnRight()
        {
            Console.WriteLine("Moves rapidly to the right.");
        }
    }
}