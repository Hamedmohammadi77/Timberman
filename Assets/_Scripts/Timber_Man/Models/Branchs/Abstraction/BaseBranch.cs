using System;
using _Scripts.Timber_Man.Controllers;
using _Scripts.Timber_Man.Models.Enums;
using DG.Tweening;
using UnityEngine;

namespace _Scripts.Timber_Man.Models.Branchs.Abstraction
{
    public abstract class BaseBranch : MonoBehaviour
    {
        public abstract BranchType Type { get; }

        private readonly float _throwVectorX = 10;
        private readonly float _throwVectorY = -4;

        private BoxCollider2D _boxCollider2D;
        
        private void Start()
        {
            _boxCollider2D=GetComponent<BoxCollider2D>();
        }

        public void MoveDown()
        {
            transform.position = new Vector2(0, transform.position.y - 2);
        }

        public void BranchDestroy(PlayerState playerState, Action action)
        {
            switch (playerState)
            {
                case PlayerState.Right:
                    _boxCollider2D.enabled = false;
                    transform.DOMove(new Vector2(-_throwVectorX, _throwVectorY), 0.5f);
                    transform.DORotate(new Vector3(0, 0, 180), .5f).onComplete += () => action();
                    break;
                case PlayerState.Left:
                    _boxCollider2D.enabled = false;
                    transform.DOMove(new Vector2(_throwVectorX, _throwVectorY), 0.5f);
                    transform.DORotate(new Vector3(0, 0, -180), .5f).onComplete += () => action();
                    break;
            }
        }
    }
}