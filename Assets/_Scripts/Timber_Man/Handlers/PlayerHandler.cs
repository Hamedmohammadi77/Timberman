using _Scripts.Timber_Man.Controllers;

namespace _Scripts.Timber_Man.Handlers
{
    public class PlayerHandler
    {
        private readonly PlayerController _playerController;


        public PlayerHandler(PlayerController playerController)
        {
            _playerController = playerController;
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
        }
    }
}