using Gameplay.Actor;
using Gameplay.StateMachine;
using GameSignals;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Actor
{
    public class ActorsStartStateHandler
    {
        private Dictionary<ActorAbstract, AbstractState> _actorsWithStartState = new Dictionary<ActorAbstract, AbstractState>();

        private Zenject.SignalBus _signalBus;
        
        [Zenject.Inject]
        private void Init(List<ActorAbstract> actors, Zenject.SignalBus signalBus)
        {
            _signalBus = signalBus;

            foreach (var actor in actors)
            {
                var state = GetRandomState();
                _actorsWithStartState.Add(actor, state);
            }
        }

        private AbstractState GetRandomState()
        {
            int randomNum = Random.Range(0, 3);
            switch (randomNum)
            {
                case 0:
                    return new DisabledState();
                case 1:
                    return new ActiveState();
                case 2:
                    return new DestroyedState();
                default:
                    Debug.Log($"incorrect num: {randomNum}");
                    return null;
            }
        }

        public void SetupStartSignals()
        {
            foreach (var actorWithStartState in _actorsWithStartState)
                _signalBus.Fire(new Signals.SetNewStateSignal(actorWithStartState.Key, actorWithStartState.Value));
        }
    }
}
