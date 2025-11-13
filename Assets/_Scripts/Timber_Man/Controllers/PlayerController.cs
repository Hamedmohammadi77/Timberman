using System;
using UnityEngine;

namespace _Scripts.Timber_Man.Controllers
{
    public class PlayerController : MonoBehaviour
    {
        private Vector2 _leftPosition = new(-5f, 0f);
        private Vector2 _rightPosition = new(5f, 0f);

        private void Start()
        {
            transform.position = _leftPosition;
            transform.localScale = new Vector2(-1, 1);
        }

        public void MoveLeft()
        {
            if (transform.position.x < 0)
                return;

            transform.position = _leftPosition;
            transform.localScale = new Vector2(-1, 1);
        }

        public void MoveRight()
        {
            if (transform.position.x > 0)
                return;

            transform.position = _rightPosition;
            transform.localScale = new Vector2(1, 1);
        }
    }
}