using System.Collections.Generic;

using UnityEngine;

using Zenject;

/// <summary>
/// Установщик списка ScriptableObject со стоимостями для определенного состояния
/// </summary>
[CreateAssetMenu(fileName = "BuildingCostInstaller", menuName = "Installers/BuildingCostInstaller")]
public class BuildingCostInstaller : ScriptableObjectInstaller<BuildingCostInstaller>
{
    [SerializeField]
    private List<StateCostAbstract> _stateCosts;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<List<StateCostAbstract>>().FromInstance(_stateCosts).AsSingle();
    }
}