using Gameplay.Actor;
using Gameplay.StateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSignals
{
    public class Signals
    {
        public class SellSignal
        {
            public SellSignal()
            {

            }
        }

        public class UpdateSignal
        {
            public UpdateSignal()
            {

            }
        }

        public class DestroySignal
        {
            public DestroySignal()
            {

            }
        }

        public class CreateSignal
        {
            public CreateSignal()
            {

            }
        }

        public class SelectActorSignal
        {
            public readonly ActorAbstract selectedActor;

            public SelectActorSignal(ActorAbstract actor)
            {
                selectedActor = actor;
            }
        }

        public class SetNewStateSignal
        {
            public readonly ActorAbstract Actor;
            public readonly AbstractState State;

            public SetNewStateSignal(ActorAbstract actor, AbstractState state)
            {
                Actor = actor;
                State = state;
            }
        }
    }
}
