using Gameplay.Actor;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Gameplay
{
    /// <summary>
    /// Обработчик геймплея
    /// </summary>
    public class GameplayHandler : MonoBehaviour
    {
        private StateMachine.StateMachine _stateMachine;
        private Zenject.SignalBus _signalBus;

        [Zenject.Inject]
        private void Init(Zenject.SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        private void Awake()
        {
            _stateMachine = new StateMachine.StateMachine();
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
