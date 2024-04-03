using UnityEngine;

/// <summary>
/// Контейнер цен для состояний
/// </summary>
public abstract class StateCostAbstract : ScriptableObject
{
    public abstract int GetCost();
}
