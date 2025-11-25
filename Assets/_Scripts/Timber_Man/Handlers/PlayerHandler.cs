using _Scripts.Timber_Man.Controllers;
using _Scripts.Timber_Man.Services;

namespace _Scripts.Timber_Man.Handlers
{
    public class PlayerHandler
    {
        private readonly PlayerController _playerController;
        private readonly LeaderboardService _leaderboardService;
        

        public PlayerHandler(PlayerController playerController, LeaderboardService leaderboardService)
        {
            _playerController = playerController;
            _leaderboardService = leaderboardService;
        }

        public void OnRequestToMoveLeft()
        {
            _playerController.MoveLeft();
        }

        public void OnRequestToMoveRight()
        {
            _playerController.MoveRight();
        }

        public void OnPlayerDied()
        {
            _playerController.PlayerDied();
            _leaderboardService.Submit(10);
        }
    }
}