using _Scripts.Timber_Man.Controllers;
using _Scripts.Timber_Man.Signals.Inputs;

namespace _Scripts.Timber_Man.Handlers
{
    public class PlayerHandler
    {
        private readonly PlayerController _playerController;
        private readonly InputController _inputController;

        public PlayerHandler(PlayerController playerController, InputController inputController)
        {
            _playerController = playerController;
            _inputController = inputController;
        }

        public void OnRequestToMoveLeft(RequestToMoveLeft requestToMoveLeft)
        {
            _playerController.MoveLeft();
        }

        public void OnRequestToMoveRight(RequestToMoveRight requestToMoveRight)
        {
            _playerController.MoveRight();
        }

        public void OnPlayerDied()
        {
            _inputController.enabled = false;
        }
    }
}