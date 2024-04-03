using UnityEngine;

/// <summary>
/// Экземпляр цен для Active состояния
/// </summary>
[CreateAssetMenu(fileName = "new ActiveStateCost", menuName = "State/ActiveStateCost")]
public class ActiveStateCost : StateCostAbstract
{
    [field: SerializeField]
    public int UpgradeCost { get; private set; }

    [field: SerializeField]
    public int SellCost { get; private set; }

    public override int GetCost()
    {
        return 0;
    }
}
