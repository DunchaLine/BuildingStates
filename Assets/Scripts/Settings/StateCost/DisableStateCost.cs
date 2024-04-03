using UnityEngine;

/// <summary>
/// Экземпляр цен для Disable состояния
/// </summary>
[CreateAssetMenu(fileName = "new DisableStateCost", menuName = "State/DisableStateCost")]
public class DisableStateCost : StateCostAbstract
{
    [field: SerializeField]
    public int CreateCost { get; private set; }

    public override int GetCost()
    {
        return 0;
    }
}
