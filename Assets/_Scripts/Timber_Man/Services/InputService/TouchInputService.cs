using _Scripts.Timber_Man.Services.Abstractions;
using UnityEngine;

namespace _Scripts.Timber_Man.Services
{
    public class TouchInputService : IInputService
    {
        public void Update()
        {
            Touch touch = Input.GetTouch(0);

            Vector2 pos = touch.position;

            Debug.Log($"touch position {pos}");
        }
    }
}