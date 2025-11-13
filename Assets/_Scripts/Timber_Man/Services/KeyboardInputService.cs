using _Scripts.Timber_Man.Services.Abstractions;

namespace _Scripts.Timber_Man.Services
{
    public class KeyboardInputService : IInputService
    {
        public void Update()
        {
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.LeftArrow))
            {
                UnityEngine.Debug.Log("Left Arrow Pressed");
                //event
            }

            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.RightArrow))
            {
                UnityEngine.Debug.Log("Right Arrow Pressed");
                //event
            }
        }
    }
}