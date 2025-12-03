using _Scripts.Timber_Man.Controllers.Ui;
using _Scripts.Timber_Man.UI;
using UnityEngine;

namespace _Scripts.Timber_Man.Handlers
{
    public class UIHandler
    {
        private UIController _uiController;
        private LeaderBoardUI _leaderBoardUI;
        
        public UIHandler(UIController uiController, LeaderBoardUI leaderBoardUI)
        {
            _uiController= uiController;
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
    }
}