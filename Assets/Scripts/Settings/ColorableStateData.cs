using Gameplay.Actor;

using UnityEngine;

/// <summary>
/// Экземпляр контейнера, в котором идет смена материала
/// </summary>
[CreateAssetMenu(fileName = "new ColorableStateData", menuName = "State/ColorableStateData")]
public class ColorableStateData : StateDataAbstract
{
    [SerializeField]
    private Material material;

    public override void ActivateData(ActorAbstract actor)
    {
        if (actor == null || actor.MeshRenderer == null)
            return;

        actor.MeshRenderer.material = material;
    }
}
