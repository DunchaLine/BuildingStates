using Gameplay.Actor;
using Interfaces;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

using Zenject;

namespace Gameplay
{
    /// <summary>
    /// Обработчик геймплея
    /// </summary>
    public class GameplayHandler : MonoBehaviour
    {
        private StateMachine.StateMachine _stateMachine;
        private IActorSetupOnStart _startStatesHandler;

        private DiContainer _container;

        private SignalBus _signalBus;

        [Inject]
        private void Init(SignalBus signalBus, DiContainer container)
        {
            _container = container;
            _signalBus = signalBus;
        }

        private void Awake()
        {
            // получаем (при наличии) StateMachine
            _stateMachine = _container.TryResolve<StateMachine.StateMachine>();
            if (_stateMachine == null)
            {
                _stateMachine = new StateMachine.StateMachine();
                _container.BindInterfacesAndSelfTo<StateMachine.StateMachine>().FromInstance(_stateMachine).AsSingle();
            }

            // получаем (при наличии) генератор начальных состояний
            _startStatesHandler = _container.TryResolve<IActorSetupOnStart>();
            if (_startStatesHandler == null)
            {
                _startStatesHandler = new ActorsStartStateRandom();
                _container.BindInterfacesAndSelfTo<IActorSetupOnStart>().FromInstance(_startStatesHandler).AsSingle();
            }
        }

        private void Start()
        {
            _startStatesHandler.SetupStartSignals();
        }

        /// <summary>
        /// Обработка нажатия ЛКМ
        /// </summary>
        /// <param name="context"></param>
        public void LMB_Click(InputAction.CallbackContext context)
        {
            // если до этого уже было нажатие или нажатие идет по UI
            if (context.started == false || EventSystem.current.IsPointerOverGameObject())
                return;

            Vector2 mousePos = Mouse.current.position.ReadValue();
            ActorAbstract actor = null;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(mousePos), out var hit))
            {
                if (hit.collider.TryGetComponent(out actor))
                {
                    Debug.Log($"hit actor");
                    actor.DisplayInfo();
                }
                else
                    Debug.Log($"none hit actor");
            }
            else
                Debug.Log("deselect actor");

            // Отправка события с новый актором
            _signalBus.Fire(new GameSignals.Signals.SelectActorSignal(actor));
        }
    }
}
