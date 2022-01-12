using System;

namespace BehavioralDP.domain.StateDP
{
    abstract class TransmissionState
    {
        protected TransmissionBox _transmissionBox;

        internal void SetTransmissionState(TransmissionBox transmissionBox)
        {
            this._transmissionBox = transmissionBox;
        }

        public abstract void Accelerate();
        public abstract void Decelerate();
        public abstract void TurnLeft();
        public abstract void TurnRight();



    }
}