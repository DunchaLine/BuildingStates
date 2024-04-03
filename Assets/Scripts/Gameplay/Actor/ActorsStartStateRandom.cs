using Gameplay.StateMachine;
using GameSignals;
using Interfaces;

using System.Collections.Generic;

using UnityEngine;

namespace Gameplay.Actor
{
    /// <summary>
    /// Класс для установки рандомного состояния для каждого из акторов
    /// </summary>
    public class ActorsStartStateRandom : IActorSetupOnStart
    {
        private Dictionary<ActorAbstract, AbstractState> _actorsWithStartState = new Dictionary<ActorAbstract, AbstractState>();

        private Zenject.SignalBus _signalBus;

        private List<StateDataAbstract> _statesDatas;

        [Zenject.Inject]
        private void Init(List<ActorAbstract> actors, Zenject.SignalBus signalBus, List<StateDataAbstract> statesDatas)
        {
            _signalBus = signalBus;
            _statesDatas = statesDatas;

            foreach (var actor in actors)
            {
                var state = GetRandomState();
                _actorsWithStartState.Add(actor, state);
            }
        }

        /// <summary>
        /// Получение рандомного состояния на старте
        /// </summary>
        /// <returns></returns>
        private AbstractState GetRandomState()
        {
            int randomNum = Random.Range(0, 3);
            switch (randomNum)
            {
                case 0:
                    return new DisabledState(_statesDatas, Settings.StatesNames.DISABLED_STATE_NAME);
                case 1:
                    return new ActiveState(_statesDatas, Settings.StatesNames.ACTIVE_STATE_NAME);
                case 2:
                    return new DestroyedState(_statesDatas, Settings.StatesNames.DESTROY_STATE_NAME);
                default:
                    Debug.Log($"incorrect num: {randomNum}");
                    return null;
            }
        }

        /// <summary>
        /// Запуск сигналов на установку стартовых состояний
        /// </summary>
        public void SetupStartSignals()
        {
            foreach (var actorWithStartState in _actorsWithStartState)
                _signalBus.Fire(new Signals.SetNewStateSignal(actorWithStartState.Key, actorWithStartState.Value));
        }
    }
}
