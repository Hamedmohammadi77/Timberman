using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.Timber_Man.Panels
{
    public class OpenLeaderBoardPanel : MonoBehaviour
    {
        private Button _openLeaderBoardButton;

        void Start()
        {
            _openLeaderBoardButton = GetComponent<Button>();

            _openLeaderBoardButton.onClick.AddListener(PlayToGame);
        }

        private void PlayToGame()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}