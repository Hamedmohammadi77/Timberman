using _Scripts.Timber_Man.Enums;
using _Scripts.Timber_Man.Models.Parents;
using _Scripts.Timber_Man.Services;
using _Scripts.Timber_Man.Signals.UI;
using UnityEngine;
using Zenject;

namespace _Scripts.Timber_Man.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        [Inject] private readonly TreeController _treeController;
        [Inject] private readonly PlayerIsAliveParent _playerIsAliveParent;
        [Inject] private readonly PlayerIsDeadParent _playerIsDeadParent;
        [Inject] private readonly LeaderboardService _leaderboardService;
        [Inject] private readonly SignalBus _signalBus;

        private bool _playerIsAlive;

        private Vector2 _leftPosition = new(-5f, 0f);
        private Vector2 _rightPosition = new(5f, 0f);
        // scale

        private int _score;

        private PlayerState _playerState;

        private void Start()
        {
            _score = 0;
            StartParent();
            _playerIsAlive = true;
            StartPosition();
        }


        private void StartParent()
        {
            _playerIsAliveParent.SetActiveGameObject(true);
            _playerIsDeadParent.SetActiveGameObject(false);
        }

        private void StartPosition()
        {
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
                _score++;
                _signalBus.Fire(new ScoreSignal(_score));
                _treeController.BranchCut(_playerState);
                return;
            }

            _playerState = PlayerState.Left;
            _score++;
            _signalBus.Fire(new ScoreSignal(_score));
            _treeController.BranchCut(_playerState);
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
                _score++;
                _signalBus.Fire(new ScoreSignal(_score));
                _treeController.BranchCut(_playerState);
                return;
            }

            _playerState = PlayerState.Right;
            _score++;
            _signalBus.Fire(new ScoreSignal(_score));
            _treeController.BranchCut(_playerState);
            transform.position = _rightPosition;
            transform.localScale = new Vector2(1, 1);
        }

        public void PlayerDied()
        {
            _leaderboardService.Submit(_score);
            _playerIsAliveParent.SetActiveGameObject(false);
            _playerIsDeadParent.SetActiveGameObject(true);
            _playerIsAlive = false;
        }
    }
}