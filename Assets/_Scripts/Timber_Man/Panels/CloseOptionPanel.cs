using _Scripts.Timber_Man.Signals.UI;
using _Scripts.Timber_Man.Signals.UI.OptionSignals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Timber_Man.Panels
{
    public class CloseOptionPanel : MonoBehaviour
    {
        [Inject] private readonly SignalBus _signalBus;
        private Button _closeOptionButton;

        void Start()
        {
            _closeOptionButton = GetComponent<Button>();

            _closeOptionButton.onClick.AddListener(CloseLeaderBoard);
        }

        private void CloseLeaderBoard()
        {
            _signalBus.Fire(new CloseOptionSignal());
        }
    }
}