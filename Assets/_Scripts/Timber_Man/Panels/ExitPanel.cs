using UnityEngine;
using UnityEngine.UI;

namespace _Scripts.Timber_Man.Panels
{
    public class ExitPanel : MonoBehaviour
    {
        private Button _exitButton;

        void Start()
        {
            _exitButton = GetComponent<Button>();

            _exitButton.onClick.AddListener(ExitToGame);
        }

        private void ExitToGame()
        {
            Application.Quit();
        }
    }
}