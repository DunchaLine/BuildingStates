using GameSignals;

using UnityEngine;

namespace UI
{
    /// <summary>
    /// Обработчик Actions с UI кнопок
    /// </summary>
    public class ActionsHandler : MonoBehaviour
    {
        private Zenject.SignalBus _signalBus;

        [Zenject.Inject]
        private void Init(Zenject.SignalBus signalBus)
        {
            _signalBus = signalBus;
        }

        public void UpgradeAction()
        {
            _signalBus.Fire(new Signals.UpdateSignal());
        }

        public void SellAction()
        {
            _signalBus.Fire(new Signals.SellSignal());
        }

        public void DestroyAction()
        {
            _signalBus.Fire(new Signals.DestroySignal());
        }

        public void CreateAction()
        {
            _signalBus.Fire(new Signals.CreateSignal());
        }
    }
}
