using Gameplay.Actor;
using Gameplay.StateMachine;

namespace GameSignals
{
    /// <summary>
    /// Контейнер, состоящий из сигналов
    /// </summary>
    public class Signals
    {
        /// <summary>
        /// Сигнал на продажу здания
        /// </summary>
        public class SellSignal
        {
            public SellSignal()
            {

            }
        }

        /// <summary>
        /// Сигнал на апдейт уровня здания
        /// </summary>
        public class UpdateSignal
        {
            public UpdateSignal()
            {

            }
        }

        /// <summary>
        /// Сигнал на уничтожение здания
        /// </summary>
        public class DestroySignal
        {
            public DestroySignal()
            {

            }
        }

        /// <summary>
        /// Сигнал на создание здания
        /// </summary>
        public class CreateSignal
        {
            public CreateSignal()
            {

            }
        }

        /// <summary>
        /// Сигнал на выбор актора
        /// </summary>
        public class SelectActorSignal
        {
            public readonly ActorAbstract selectedActor;

            public SelectActorSignal(ActorAbstract actor)
            {
                selectedActor = actor;
            }
        }

        /// <summary>
        /// Сигнал на установку нового сигнала
        /// </summary>
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
