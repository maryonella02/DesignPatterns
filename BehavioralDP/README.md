# DesignPatterns
## Behavioral Design Patterns

### Author: Brânzeanu Marinela

#### Theory
Behavioral design patterns are concerned with algorithms and the assignment of responsibilities between objects.

Some examples of this kind of design patterns are:
* Chain of Resposibility
* Command
* Iterator
* State
* Template Method

#### Implementation
I choose to implement State design pattern, because it was the perfect fit for the possibilities of the automotive industry, I mean vehicles also have different states.

**State Pattern**

I thought that the gears of a vehicle would be the perfect example of a such implementation, because the acceleration or the deceleration trigger the shift to the next or previous gear.
Also I found necessary to add TurnLeft and TurnRight methods to the sake of diversity. And this way, I also added the Reverse gear to emphasize the difference it makes when turning to the left or to the right.


``` c#
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
  ```
 TransmissionBox class serves the role of a context. It stores a reference to one of the concrete state objects and delegates to it all state-specific work. 


``` c#
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
```
The TransmissionState declares the state specific methods.


``` c#
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
````
The concrete classes like FirstGear class shown above provide their own implementations for the state-specific methods. 
Both context and concrete states can set the next state of the context and perform the actual state transition by replacing the state object linked to the context.
That's why in driver code you will see how the gears are shifted with the help of acceleration and deceleration from the first to the third and back.


The driver code is:
``` c#
 var gearTest = new TransmissionBox(new FirstGear());
            gearTest.Accelerate();
            gearTest.TurnRight();
            gearTest.Accelerate();
            gearTest.TurnLeft();
            gearTest.Decelerate();
            gearTest.TurnLeft();
            gearTest.Decelerate();
            gearTest.TurnRight();
            gearTest.Decelerate();
            gearTest.TurnRight();
            gearTest.Decelerate();
```

The output is:
```console
Transition to FirstGear.
Accelerate it till starts moving.
Transition to SecondGear.
Moves rapidly to the right.
Accelerate till it shifts to the third gear.
Transition to ThirdGear.
Moves fast to the left.
Decelerate till it shifts to the second gear.
Transition to SecondGear.
Moves rapidly to the left.
Decelerate till it shifts to the first gear.
Transition to FirstGear.
Moves slowly to the right.
Decelerate it till stops moving and shifts to Reverse Gear.
Transition to ReverseGear.
Moves slowly to the LEFT. Here is the trick!
Decelerate it till stops moving.
```
