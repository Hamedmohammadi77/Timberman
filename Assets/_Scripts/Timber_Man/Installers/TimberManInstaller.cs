using _Scripts.Timber_Man.Controllers;
using _Scripts.Timber_Man.Handlers;
using _Scripts.Timber_Man.Models.Branchs;
using _Scripts.Timber_Man.Models.Branchs.Abstraction;
using _Scripts.Timber_Man.Pools;
using _Scripts.Timber_Man.Services;
using _Scripts.Timber_Man.Services.Abstractions;
using _Scripts.Timber_Man.Signals.Inputs;
using UnityEngine;
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

            Addbranchs();
        }

        private void AddMemoryPools<TBranch, TBranchPool>()
            where TBranch : BaseBranch
            where TBranchPool : BaseBranchPool<TBranch>
        {
            var name = typeof(TBranch).Name;
            Debug.Log(name);
            ////print(name);
            Container.Bind<IBranchPooling>()
                .To<TBranchPool>()
                .FromResolve()
                .AsTransient();

            Container.BindMemoryPool<TBranch, TBranchPool>()
                .WithInitialSize(5)
                .ExpandByDoubling()
                .FromComponentInNewPrefabResource($"Prefabs/Branchs/{name}")
                .UnderTransformGroup("Parent");
        }

        private void Addbranchs()
        {
            AddMemoryPools<LeftBranch, LeftBranchPool>();
            AddMemoryPools<RightBranch, RightBranchPool>();
            AddMemoryPools<NoBranch, NoBranchPools>();

            Container.Bind<BranchPool>().AsTransient();
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
            Container.DeclareSignal<RequestToMoveLeftSignal>();

            Container.DeclareSignal<RequestToMoveRightSignal>();

            Container.BindSignal<RequestToMoveLeftSignal>()
                .ToMethod<PlayerHandler>((handler, signal) => handler.OnRequestToMoveLeft(signal))
                .FromResolve();

            Container.BindSignal<RequestToMoveRightSignal>()
                .ToMethod<PlayerHandler>((handler, signal) => handler.OnRequestToMoveRight(signal))
                .FromResolve();
        }
    }
}