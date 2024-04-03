using Gameplay.StateMachine;
using GameSignals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Actor
{
    public abstract class ActorAbstract : MonoBehaviour
    {
        public AbstractState CurrentState { get; private set; }

        private Zenject.SignalBus _signalBus;

        [Zenject.Inject]
        private void Init(Zenject.SignalBus signalBus)
        {
            _signalBus = signalBus;
            _signalBus.Subscribe<Signals.SetNewStateSignal>(UpdateState);
        }

        private void Awake()
        {
            // временно, заменить на подгрузку через генератор 
            SetNewState(new DisabledState());
        }

        private void UpdateState(Signals.SetNewStateSignal newStateSignal)
        {
            if (newStateSignal.Actor == null || newStateSignal.Actor.Equals(this) == false)
                return;

            SetNewState(newStateSignal.State);
        }

        public void SetNewState<T>(T newState) where T : AbstractState
        {
            if (newState != null && newState.Equals(CurrentState) == false)
                CurrentState = newState;
        }

        public bool IsDisabled()
        {
            return CurrentState == null || CurrentState.IsDisabled;
        }

        public abstract void DisplayInfo();
    }
}
