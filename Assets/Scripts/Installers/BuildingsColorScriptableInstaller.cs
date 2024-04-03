using Interfaces;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "BuildingsColorScriptableInstaller", menuName = "Installers/BuildingsColorScriptableInstaller")]
public class BuildingsColorScriptableInstaller : ScriptableObjectInstaller<BuildingsColorScriptableInstaller>
{
    [SerializeField]
    private List<StateDataAbstract> StatesDatas;

    public override void InstallBindings()
    {
        Container.BindInterfacesAndSelfTo<List<StateDataAbstract>>().FromInstance(StatesDatas).AsSingle();
        //Container.Bind<List<StateDataAbstract>>().To<ColorableStateData>().FromInstance(StatesDatas).AsSingle();
        //Container.BindInstance(StatesDatas).AsSingle();
    }
}