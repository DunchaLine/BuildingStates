using Interfaces;

using UnityEngine;

namespace Gameplay.StateMachine
{
    /// <summary>
    /// Состояние активного здания
    /// </summary>
    public class ActiveState : AbstractState, ISellable, IUpgradable
    {
        public override bool IsDisabled { get; protected set; } = false;

        public int CurrentLevel { get; private set; } = 1;

        public int UpdateCost { get; private set; }

        public override void DisplayInfo()
        {
            Debug.Log($"Active state; Level: {CurrentLevel}");
        }

        public override void EnterState()
        {
            Debug.Log($"entering active state");
        }

        public override void ExitState()
        {
            Debug.Log($"exit active state");
        }

        public void Sell()
        {
            Debug.Log($"Selling Active state");
        }

        public void Update()
        {
            Debug.Log($"Updrading Active state");
            CurrentLevel++;
        }
    }
}
