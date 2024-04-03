using Gameplay.StateMachine;
using GameSignals;

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

        /*private void Awake()
        {
            // временно, заменить на подгрузку через генератор 
            SetNewState(new DisabledState());
        }*/

        /// <summary>
        /// Обновление состояния
        /// </summary>
        /// <param name="newStateSignal"></param>
        public void UpdateState(Signals.SetNewStateSignal newStateSignal)
        {
            if (newStateSignal.Actor == null || newStateSignal.Actor.Equals(this) == false)
                return;

            SetNewState(newStateSignal.State);
        }

        /// <summary>
        /// Установка нового состояния
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="newState"></param>
        private void SetNewState<T>(T newState) where T : AbstractState
        {
            if (newState != null && newState.Equals(CurrentState) == false)
                CurrentState = newState;
        }

        public bool IsDisabled()
        {
            return CurrentState != null || CurrentState.IsDisabled;
        }

        public abstract void DisplayInfo();

        private void OnDestroy()
        {
            _signalBus.Unsubscribe<Signals.SetNewStateSignal>(UpdateState);
        }
    }
}
