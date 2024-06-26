using Gameplay.Actor;
using GameSignals;
using Interfaces;
using System;
using System.Collections.Generic;

using Zenject;

namespace Gameplay.StateMachine
{
    /// <summary>
    /// Машина состояний
    /// </summary>
    public class StateMachine : IDisposable
    {
        public List<ActorAbstract> Actors { get; private set; }

        private ActorAbstract _selectedActor;

        private SignalBus _signalBus;

        private List<StateDataAbstract> _statesDatas;

        [Inject]
        private void Init(List<ActorAbstract> actors, List<StateDataAbstract> statesDatas, SignalBus signalBus)
        {
            Actors = actors;
            _signalBus = signalBus;
            _statesDatas = statesDatas;

            SubscribeSignals();
        }

        /// <summary>
        /// Подписка на сигналы
        /// </summary>
        private void SubscribeSignals()
        {
            _signalBus.Subscribe<Signals.UpdateSignal>(UpdateBuiltState);
            _signalBus.Subscribe<Signals.DestroySignal>(DestroyBuild);
            _signalBus.Subscribe<Signals.SellSignal>(SellBuild);
            _signalBus.Subscribe<Signals.CreateSignal>(CreateBuild);
            _signalBus.Subscribe<Signals.SelectActorSignal>(SelectActor);
        }

        /// <summary>
        /// Корректный ли актор (не равен null и находится в коллекции с акторами)
        /// </summary>
        /// <returns></returns>
        private bool IsCorrectActor()
        {
            return IsCorrectActor(_selectedActor);
        }

        /// <summary>
        /// Корректный ли актор (не равен null и находится в коллекции с акторами) 
        /// </summary>
        /// <param name="actor"></param>
        /// <returns></returns>
        private bool IsCorrectActor(ActorAbstract actor)
        {
            return actor != null && Actors.Contains(actor);
        }

        /// <summary>
        /// Получение выбранного актора из сигнала
        /// </summary>
        /// <param name="selectActorSignal"></param>
        private void SelectActor(Signals.SelectActorSignal selectActorSignal)
        {
            _selectedActor = selectActorSignal.selectedActor;
        }

        /// <summary>
        /// Апгрейд уровня активного здания
        /// </summary>
        public void UpdateBuiltState()
        {
            if (IsCorrectActor() == false)
                return;

            // если актор реализует интерфейс апгрейда
            if (_selectedActor.CurrentState is IUpgradable upgradable)
                upgradable.Update();
        }

        /// <summary>
        /// Уничтожение здания
        /// </summary>
        public void DestroyBuild()
        {
            if (IsCorrectActor() == false)
                return;

            // уничтожить можно любое здание (в любом состоянии)
            SetNewState(_selectedActor, new DestroyedState(_statesDatas, Settings.StatesNames.DESTROY_STATE_NAME));
        }

        /// <summary>
        /// Создание здания
        /// </summary>
        public void CreateBuild()
        {
            // если актор активен => return
            if (IsCorrectActor() == false || _selectedActor.IsDisabled() == false)
                return;

            SetNewState(_selectedActor, new ActiveState(_statesDatas, Settings.StatesNames.ACTIVE_STATE_NAME));
        }

        /// <summary>
        /// Продажа здания
        /// </summary>
        public void SellBuild()
        {
            if (IsCorrectActor() == false)
                return;

            // если состояния реализует интерфейс продажи
            if (_selectedActor.CurrentState is ISellable sellable)
            {
                sellable.Sell();
                SetNewState(_selectedActor, new DisabledState(_statesDatas, Settings.StatesNames.DISABLED_STATE_NAME));
            }
        }

        /// <summary>
        /// Устиановка нового состояния
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="Y"></typeparam>
        /// <param name="actor">актор</param>
        /// <param name="newState">новое состояние, которое нужно установить в актор</param>
        public void SetNewState<T, Y>(T actor, Y newState) where T : ActorAbstract where Y : AbstractState
        {
            if (IsCorrectActor(actor) == false)
                return;

            // выходим из текущего состояния актора и вызываем сигнал на смену на новый
            actor.CurrentState.ExitState();
            _signalBus.Fire(new Signals.SetNewStateSignal(actor, newState));
            actor.CurrentState.EnterState();
        }

        public void Dispose()
        {
            _signalBus.TryUnsubscribe<Signals.UpdateSignal>(UpdateBuiltState);
            _signalBus.TryUnsubscribe<Signals.DestroySignal>(DestroyBuild);
            _signalBus.TryUnsubscribe<Signals.SellSignal>(SellBuild);
            _signalBus.TryUnsubscribe<Signals.CreateSignal>(CreateBuild);
            _signalBus.TryUnsubscribe<Signals.SelectActorSignal>(SelectActor);
        }
    }
}
