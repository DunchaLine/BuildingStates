using Gameplay.Actor;
using GameSignals;
using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace Gameplay.StateMachine
{
    public class StateMachine
    {
        public List<ActorAbstract> Actors { get; private set; }

        private ActorAbstract _selectedActor;

        private SignalBus _signalBus;

        [Inject]
        private void Init(List<ActorAbstract> actors, SignalBus signalBus)
        {
            Actors = actors;
            _signalBus = signalBus;

            SubscribeSignals();
        }

        private void SubscribeSignals()
        {
            _signalBus.Subscribe<Signals.UpdateSignal>(UpdateBuiltState);
            _signalBus.Subscribe<Signals.DestroySignal>(DestroyBuild);
            _signalBus.Subscribe<Signals.SellSignal>(SellBuild);
            _signalBus.Subscribe<Signals.CreateSignal>(CreateBuild);
            _signalBus.Subscribe<Signals.SelectActorSignal>(SelectActor);
        }

        private bool IsCorrectActor()
        {
            return IsCorrectActor(_selectedActor);
        }

        private bool IsCorrectActor(ActorAbstract actor)
        {
            return actor != null && Actors.Contains(actor);
        }

        private void SelectActor(Signals.SelectActorSignal selectActorSignal)
        {
            _selectedActor = selectActorSignal.selectedActor;
        }

        public void UpdateBuiltState()
        {
            if (IsCorrectActor() == false)
                return;

            if (_selectedActor.CurrentState is IUpgradable upgradable)
                upgradable.Update();
        }

        public void DestroyBuild()
        {
            if (IsCorrectActor() == false)
                return;

            SetNewState(_selectedActor, new DestroyedState());
        }

        public void CreateBuild()
        {
            if (IsCorrectActor() == false || _selectedActor.IsDisabled() == false)
                return;

            SetNewState(_selectedActor, new ActiveState());
        }

        public void SellBuild()
        {
            if (IsCorrectActor() == false)
                return;

            if (_selectedActor.CurrentState is ISellable sellable)
            {
                sellable.Sell();
                SetNewState(_selectedActor, new DisabledState());
            }
        }

        public void SetNewState<T, Y>(T actor, Y newState) where T : ActorAbstract where Y : AbstractState
        {
            if (IsCorrectActor(actor) == false)
                return;

            actor.CurrentState.ExitState();
            _signalBus.Fire(new Signals.SetNewStateSignal(actor, newState));
            actor.CurrentState.EnterState();
        }
    }
}
