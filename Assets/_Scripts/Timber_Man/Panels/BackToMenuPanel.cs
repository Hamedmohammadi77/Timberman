using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.Timber_Man.Panels
{
    public class BackToMenuPanel : MonoBehaviour
    {
        private Button _backToMenuButton;

        void Start()
        {
            _backToMenuButton = GetComponent<Button>();

            _backToMenuButton.onClick.AddListener(BackToMenuGame);
        }

        private void BackToMenuGame()
        {
            SceneManager.LoadScene("MenuScene");
        }
    }
}