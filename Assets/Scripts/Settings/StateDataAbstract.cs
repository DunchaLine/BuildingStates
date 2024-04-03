using Gameplay.Actor;

using UnityEngine;

/// <summary>
/// Абстрактный контейнер, в котором идет обработка актора
/// </summary>
public abstract class StateDataAbstract : ScriptableObject
{
    /// <summary>
    /// Временно, продумать лучшую логику
    /// </summary>
    [field: SerializeField]
    public string Name { get; private set; }

    public abstract void ActivateData(ActorAbstract actor);
}
