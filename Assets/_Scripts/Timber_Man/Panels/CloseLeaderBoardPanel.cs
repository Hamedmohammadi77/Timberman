using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Timber_Man.Panels
{
    public class CloseLeaderBoardPanel : MonoBehaviour
    {
        private Button _closeLeaderBoardButton;

        void Start()
        {
            _closeLeaderBoardButton = GetComponent<Button>();

            _closeLeaderBoardButton.onClick.AddListener(ExitToGame);
        }

        private void ExitToGame()
        {
            Application.Quit();
        }
    }
}