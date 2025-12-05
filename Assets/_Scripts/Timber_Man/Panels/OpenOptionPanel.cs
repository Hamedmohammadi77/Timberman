using _Scripts.Timber_Man.Signals.UI;
using _Scripts.Timber_Man.Signals.UI.OptionSignals;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Timber_Man.Panels
{
    public class OpenOptionPanel : MonoBehaviour
    {
        [Inject] private readonly SignalBus _signalBus;
        private Button _openOptionButton;

        void Start()
        {
            _openOptionButton = GetComponent<Button>();

            _openOptionButton.onClick.AddListener(OpenLeaderBoard);
        }

        private void OpenLeaderBoard()
        {
            _signalBus.Fire(new OpenOptionSignal());
        }
    }
}