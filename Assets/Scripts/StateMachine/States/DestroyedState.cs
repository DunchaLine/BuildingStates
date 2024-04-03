using Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.StateMachine
{
    public class DestroyedState : AbstractState, ISellable
    {
        public override bool IsDisabled { get; protected set; } = false;

        public override void DisplayInfo()
        {
            Debug.Log("Destroyed state");
        }

        public override void EnterState()
        {
            Debug.Log($"entering destroyed state");
        }

        public override void ExitState()
        {
            Debug.Log($"exit destroyed state");
        }

        public void Sell()
        {
            Debug.Log($"selling destroyable");
        }
    }
}
