using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehavioralDP.domain.StateDP
{
    class TransmissionBox
    {
        private TransmissionState _state = null;

        public TransmissionBox(TransmissionState state)
        {
            this.TransitionTo(state);
        }

        public void TransitionTo(TransmissionState state)
        {
            Console.WriteLine($"Transition to {state.GetType().Name}.");
            this._state = state;
            this._state.SetTransmissionState(this);
        }

        public void Accelerate()
        {
            this._state.Accelerate();
        }
        public void Decelerate()
        {
            this._state.Decelerate();
        }
        public void TurnLeft()
        {
            this._state.TurnLeft();
        }

        public void TurnRight()
        {
            this._state.TurnRight();
        }
    }
}
