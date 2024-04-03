using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.StateMachine
{
    public class DisabledState : AbstractState
    {
        public override bool IsDisabled { get; protected set; } = true;

        public override void DisplayInfo()
        {
            Debug.Log("Disabled state");
        }

        public override void EnterState()
        {
            Debug.Log($"entering disabled state");
        }

        public override void ExitState()
        {
            Debug.Log($"exit disabled state");
        }
    }
}
