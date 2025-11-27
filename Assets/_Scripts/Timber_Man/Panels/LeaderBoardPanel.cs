using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace _Scripts.Timber_Man.Panels
{
    public class LeaderBoardPanel : MonoBehaviour
    {
        private Button _playButton;

        void Start()
        {
            _playButton = GetComponent<Button>();

            _playButton.onClick.AddListener(PlayToGame);
        }

        private void PlayToGame()
        {
            SceneManager.LoadScene("GameScene");
        }
    }
}