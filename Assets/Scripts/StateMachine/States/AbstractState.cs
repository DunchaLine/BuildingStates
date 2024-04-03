namespace Gameplay.StateMachine
{
    /// <summary>
    /// Абстрактный класс состояния
    /// </summary>
    public abstract class AbstractState
    {
        public abstract bool IsDisabled { get; protected set; }

        public abstract void EnterState();

        public abstract void ExitState();

        public abstract void DisplayInfo();
    }
}
