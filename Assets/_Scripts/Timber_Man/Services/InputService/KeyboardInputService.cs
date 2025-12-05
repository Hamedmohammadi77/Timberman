using _Scripts.Timber_Man.Services.Abstractions;
using _Scripts.Timber_Man.Signals.Inputs;
using Zenject;

namespace _Scripts.Timber_Man.Services
{
    public class KeyboardInputService : IInputService
    {
        [Inject] private readonly SignalBus _signalBus;

        public void Update()
        {
            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.LeftArrow))
            {
                _signalBus.Fire(new RequestToMoveLeftSignal());
            }

            if (UnityEngine.Input.GetKeyDown(UnityEngine.KeyCode.RightArrow))
            {
                _signalBus.Fire(new RequestToMoveRightSignal());
            }
        }
    }
}