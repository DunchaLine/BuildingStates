using Gameplay.Actor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateDataAbstract : ScriptableObject
{
    /// <summary>
    /// Временно, продумать лучшую логику
    /// </summary>
    [field: SerializeField]
    public string Name { get; private set; }

    public abstract void ActivateData(ActorAbstract actor);
}
