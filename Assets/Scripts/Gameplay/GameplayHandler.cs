using Gameplay.Actor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Gameplay
{
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

        public void Click(InputAction.CallbackContext context)
        {
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

            _signalBus.Fire(new GameSignals.Signals.SelectActorSignal(actor));
        }
    }
}
