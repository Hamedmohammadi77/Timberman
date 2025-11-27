using _Scripts.Timber_Man.Signals.UI;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace _Scripts.Timber_Man.Panels
{
    public class OpenLeaderBoardPanel : MonoBehaviour
    {
        [Inject] private readonly SignalBus _signalBus;
        private Button _openLeaderBoardButton;

        void Start()
        {
            _openLeaderBoardButton = GetComponent<Button>();

            _openLeaderBoardButton.onClick.AddListener(OpenLeaderBoard);
        }

        private void OpenLeaderBoard()
        {
            _signalBus.Fire(new OpenLeaderBoardSignal());
        }
    }
}