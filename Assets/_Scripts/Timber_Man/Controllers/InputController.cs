using _Scripts.Timber_Man.Services.Abstractions;
using UnityEngine;
using Zenject;

namespace _Scripts.Timber_Man.Controllers
{
    public class InputController : MonoBehaviour
    {
        [Inject] private readonly IInputService _inputService;

        private void Update()
        {
            _inputService.Update();
        }
    }
}