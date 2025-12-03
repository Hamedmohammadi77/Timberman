using _Scripts.Timber_Man.Controllers.Ui;
using _Scripts.Timber_Man.Signals.UI;
using _Scripts.Timber_Man.UI;
using UnityEngine;

namespace _Scripts.Timber_Man.Handlers
{
    public class UIHandler
    {
        private UIController _uiController;
        private LeaderBoardUI _leaderBoardUI;
        private ScoreUIController _scoreUIController;

        public UIHandler(UIController uiController, LeaderBoardUI leaderBoardUI, ScoreUIController scoreUIController)
        {
            _scoreUIController = scoreUIController;
            _uiController = uiController;
            _leaderBoardUI = leaderBoardUI;
        }

        public void OnPlayerDied()
        {
            _uiController.ShowLostUIController();
        }

        public void OpenLeaderBoard()
        {
            _leaderBoardUI.OpenLeaderBoardUIController();
        }

        public void CloseLeaderBoard()
        {
            _leaderBoardUI.CloseLeaderBoardUIController();
        }

        public void ShowScoreboard(ScoreSignal signal)
        {
            _scoreUIController.ShowScoreUIController(signal.Score);
        }
    }
}