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

        private float throw_Vector_x = 10;
        private float throw_Vector_y = -4;

        public void MoveDown()
        {
            transform.position = new Vector2(0, transform.position.y - 2);
        }

        public void Branch_Destroy(PlayerState playerState, Action action)
        {
            switch (playerState)
            {
                case PlayerState.right:
                    transform.DOMove(new Vector2(-throw_Vector_x, throw_Vector_y), 0.5f).onComplete += () => action();
                    break;
                case PlayerState.left:
                    transform.DOMove(new Vector2(throw_Vector_x, throw_Vector_y), 0.5f).onComplete += () => action();
                    break;
            }
        }
    }
}