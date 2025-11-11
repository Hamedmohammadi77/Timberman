using _Scripts.Timber_Man.Services;
using _Scripts.Timber_Man.Services.Abstractions;
using Zenject;

namespace _Scripts.Timber_Man.Installers
{
    public class TimberManInstaller : MonoInstaller<TimberManInstaller>
    {
        public override void InstallBindings()
        {
            AddInputService();
        }

        private void AddInputService()
        {
#if android || ios
            Container.Bind<IInputService>().To<TouchInputService>().AsTransient();
#else
            Container.Bind<IInputService>().To<KeyboardInputService>().AsTransient();
#endif
        }
    }
}