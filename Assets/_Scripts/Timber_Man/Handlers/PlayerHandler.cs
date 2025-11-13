using _Scripts.Timber_Man.Controllers;
using _Scripts.Timber_Man.Signals.Inputs;

namespace _Scripts.Timber_Man.Handlers
{
    public class PlayerHandler
    {
        private readonly PlayerController _playerController;

        public PlayerHandler(PlayerController playerController)
        {
            _playerController = playerController;
        }

        public void OnRequestToMoveLeft(RequestToMoveLeftSignal requestToMoveLeftSignal)
        {
            _playerController.MoveLeft();
        }

        public void OnRequestToMoveRight(RequestToMoveRightSignal requestToMoveRightSignal)
        {
            _playerController.MoveRight();
        }

        public void OnPlayerDied()
        {
        }
    }
}