using System.Collections.Generic;
using System.Linq;

namespace Gameplay.StateMachine
{
    /// <summary>
    /// Абстрактный класс состояния
    /// </summary>
    public abstract class AbstractState
    {
        public StateDataAbstract StateData { get; private set; }

        public abstract bool IsDisabled { get; protected set; }

        public readonly string Name;

        public AbstractState(List<StateDataAbstract> statesDatas, string name)
        {
            Name = name;

            // Поиск настроек по наименованию
            if (statesDatas != null && statesDatas.Count > 0)
                StateData = statesDatas.FirstOrDefault(g => g.Name.Equals(Name));
        }

        public abstract void EnterState();

        public abstract void ExitState();

        public abstract void DisplayInfo();
    }
}
