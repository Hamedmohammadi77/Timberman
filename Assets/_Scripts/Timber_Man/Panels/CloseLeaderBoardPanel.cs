using _Scripts.Timber_Man.Signals.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Timber_Man.Panels
{
    public class CloseLeaderBoardPanel : MonoBehaviour
    {
        [Inject] private readonly SignalBus _signalBus;
        private Button _closeLeaderBoardButton;

        void Start()
        {
            _closeLeaderBoardButton = GetComponent<Button>();

            _closeLeaderBoardButton.onClick.AddListener(CloseLeaderBoard);
        }

        private void CloseLeaderBoard()
        {
            _signalBus.Fire(new CloseLeaderBoardSignal());
        }
    }
}