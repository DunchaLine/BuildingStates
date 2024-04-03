using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.StateMachine
{
    public abstract class AbstractState
    {
        public abstract bool IsDisabled { get; protected set; }

        public abstract void EnterState();

        public abstract void ExitState();

        public abstract void DisplayInfo();
    }
}
