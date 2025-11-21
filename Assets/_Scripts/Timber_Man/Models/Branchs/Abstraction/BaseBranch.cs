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

        public void MoveDown()
        {
            transform.position = new Vector2(0, transform.position.y - 2);
        }

        public void Branch_Destroy(PlayerState playerState, Action action)
        {
            switch (playerState)
            {
                case PlayerState.Right:
                    transform.DOMove(new Vector2(-_throwVectorX, _throwVectorY), 0.5f);
                    transform.DORotate(new Vector3(0, 0, 180), .5f).onComplete += () => action();

                    break;
                case PlayerState.Left:
                    transform.DOMove(new Vector2(_throwVectorX, _throwVectorY), 0.5f);
                    transform.DORotate(new Vector3(0, 0, -180), .5f).onComplete += () => action();
                    break;
            }
        }
    }
}