using UnityEngine;
using Zenject;

namespace _Scripts.Timber_Man.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Inject] private readonly TreeController _treeController;

        private Vector2 _leftPosition = new(-5f, 0f);
        private Vector2 _rightPosition = new(5f, 0f);

        private PlayerState _playerState;

        private void Start()
        {
            _playerState = PlayerState.Left;
            transform.position = _leftPosition;
            transform.localScale = new Vector2(-1, 1);
        }

        public void MoveLeft()
        {
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
    }

    public enum PlayerState
    {
        Right,
        Left
    }
}