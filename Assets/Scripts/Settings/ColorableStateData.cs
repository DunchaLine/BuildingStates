using Gameplay.Actor;

using UnityEngine;

/// <summary>
/// Экземпляр контейнера, в котором идет смена материала
/// </summary>
[CreateAssetMenu(fileName = "new ColorableStateData", menuName = "State/ColorableStateData")]
public class ColorableStateData : StateDataAbstract
{
    [SerializeField]
    private Material _material;

    /// <summary>
    /// Активация данных на актора
    /// </summary>
    /// <param name="actor"></param>
    public override void ActivateData(ActorAbstract actor)
    {
        if (actor == null || actor.MeshRenderer == null)
            return;

        actor.MeshRenderer.material = _material;
    }
}
