using Gameplay;
using Gameplay.Actor;
using Gameplay.StateMachine;
using GameSignals;

using Zenject;

public class GameplayInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);
        DeclareSignals();

        Container.BindInterfacesAndSelfTo<GameplayHandler>().FromComponentInHierarchy().AsSingle();

        Container.BindInterfacesAndSelfTo<ActorsStartStateRandom>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<ActorAbstract>().FromComponentsInHierarchy().AsSingle().Lazy();
    }

    private void DeclareSignals()
    {
        Container.DeclareSignal<Signals.SelectActorSignal>();
        Container.DeclareSignal<Signals.DestroySignal>();
        Container.DeclareSignal<Signals.CreateSignal>();
        Container.DeclareSignal<Signals.SetNewStateSignal>();
        Container.DeclareSignal<Signals.SellSignal>();
        Container.DeclareSignal<Signals.UpdateSignal>();
    }
}
