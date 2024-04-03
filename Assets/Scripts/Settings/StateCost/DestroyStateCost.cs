using UnityEngine;

/// <summary>
/// Экземпляр цен для Destroy состояния
/// </summary>
[CreateAssetMenu(fileName = "new DestroyStateCost", menuName = "State/DestroyStateCost")]
public class DestroyStateCost : StateCostAbstract
{
    [field: SerializeField]
    public int SellCost { get; private set; }

    [field: SerializeField]
    public int RepairCost { get; private set; }

    public override int GetCost()
    {
        return 0;
    }
}
