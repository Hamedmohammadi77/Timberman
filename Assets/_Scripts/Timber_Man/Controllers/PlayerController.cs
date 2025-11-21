using _Scripts.Timber_Man.Models.Parents;
using UnityEngine;
using Zenject;

namespace _Scripts.Timber_Man.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Inject] private readonly TreeController _treeController;
        [Inject] private readonly PlayerIsAliveParent _playerIsAliveParent;
        [Inject] private readonly PlayerIsDeadParent _playerIsDeadParent;

        private bool _playerIsAlive;

        private Vector2 _leftPosition = new(-5f, 0f);
        private Vector2 _rightPosition = new(5f, 0f);

        private PlayerState _playerState;

        private void Start()
        {
            _playerIsAliveParent.SetActiveGameObject(true);
            _playerIsDeadParent.SetActiveGameObject(false);
            _playerIsAlive = true;
            _playerState = PlayerState.Left;
            transform.position = _leftPosition;
            transform.localScale = new Vector2(-1, 1);
        }

        public void MoveLeft()
        {
            if (!_playerIsAlive)
            {
                return;
            }

            if (_playerState == PlayerState.Left)
            {
                _treeController.Branch_Cuted(_playerState);
                return;
            }


            _playerState = PlayerState.Left;
            _treeController.Branch_Cuted(_playerState);
            transform.position = _leftPosition;
            transform.localScale = new Vector2(-1, 1);
        }

        public void MoveRight()
        {
            if (!_playerIsAlive)
            {
                return;
            }

            if (_playerState == PlayerState.Right)
            {
                _treeController.Branch_Cuted(_playerState);
                return;
            }

            _playerState = PlayerState.Right;
            _treeController.Branch_Cuted(_playerState);
            transform.position = _rightPosition;
            transform.localScale = new Vector2(1, 1);
        }

        public void PlayerDied()
        {
            _playerIsAliveParent.SetActiveGameObject(false);
            _playerIsDeadParent.SetActiveGameObject(true);
            _playerIsAlive = false;
        }
    }

    public enum PlayerState
    {
        Right,
        Left
    }
}