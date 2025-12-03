using TMPro;
using UnityEngine;

namespace _Scripts.Timber_Man.Controllers.Ui
{
    public class ScoreUIController : MonoBehaviour
    {
        private TextMeshProUGUI _scoreText;

        private void Start()
        {
            _scoreText = GetComponent<TextMeshProUGUI>();
        }

        public void ShowScoreUIController(int score)
        {
            _scoreText.text = score.ToString();
        }
    }
}