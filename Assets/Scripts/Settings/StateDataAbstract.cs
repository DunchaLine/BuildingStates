using Gameplay.Actor;

using UnityEngine;

/// <summary>
/// Абстрактный контейнер, в котором идет обработка актора
/// </summary>
public abstract class StateDataAbstract : ScriptableObject
{
    /// <summary>
    /// TODO: продумать лучшую логику
    /// </summary>
    [field: SerializeField]
    public string Name { get; private set; }

    /// <summary>
    /// Активация данных на актора
    /// </summary>
    /// <param name="actor"></param>
    public abstract void ActivateData(ActorAbstract actor);
}
