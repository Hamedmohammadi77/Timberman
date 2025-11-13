using _Scripts.Timber_Man.Controllers;
using _Scripts.Timber_Man.Handlers;
using _Scripts.Timber_Man.Services;
using _Scripts.Timber_Man.Services.Abstractions;
using _Scripts.Timber_Man.Signals.Inputs;
using Zenject;

namespace _Scripts.Timber_Man.Installers
{
    public class TimberManInstaller : MonoInstaller<TimberManInstaller>
    {
        public override void InstallBindings()
        {
            AddPlayer();

            AddInputService();

            AddSignals();

            AddHandlers();
        }

        private void AddPlayer()
        {
            Container.Bind<PlayerController>()
                .FromComponentInHierarchy()
                .AsSingle();
        }

        private void AddInputService()
        {
#if android || ios
            Container.Bind<IInputService>().To<TouchInputService>().AsTransient();
#else
            Container.Bind<IInputService>().To<KeyboardInputService>().AsTransient();
#endif
        }

        private void AddSignals()
        {
            SignalBusInstaller.Install(Container);

            PlayerSignals();
        }

        public void AddHandlers()
        {
            Container.Bind<PlayerHandler>().AsTransient();
        }

        private void PlayerSignals()
        {
            Container.BindSignal<RequestToMoveLeftSignal>();
            Container.BindSignal<RequestToMoveRightSignal>();

            Container.BindSignal<RequestToMoveLeftSignal>()
                .ToMethod<PlayerHandler>((handler, signal) => handler.OnRequestToMoveLeft(signal))
                .FromResolve();

            Container.BindSignal<RequestToMoveRightSignal>()
                .ToMethod<PlayerHandler>((handler, signal) => handler.OnRequestToMoveRight(signal))
                .FromResolve();
        }
    }
}