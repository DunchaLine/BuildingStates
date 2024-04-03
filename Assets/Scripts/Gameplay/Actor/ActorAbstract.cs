using Gameplay.StateMachine;
using GameSignals;

using UnityEngine;

namespace Gameplay.Actor
{
    [RequireComponent(typeof(MeshRenderer))]
    public abstract class ActorAbstract : MonoBehaviour
    {
        public MeshRenderer MeshRenderer { get; private set; }

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
            MeshRenderer = GetComponent<MeshRenderer>();
        }

        public abstract void DisplayInfo();

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
            {
                CurrentState = newState;
                CurrentState.StateData.ActivateData(this);
            }    
        }

        public bool IsDisabled()
        {
            return CurrentState != null || CurrentState.IsDisabled;
        }

        private void OnDisable()
        {
            try
            {
                _signalBus.Unsubscribe<Signals.SetNewStateSignal>(UpdateState);
            }
            catch { }
        }
    }
}
