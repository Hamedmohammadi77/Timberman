using _Scripts.Timber_Man.Controllers;
using _Scripts.Timber_Man.Controllers.Ui;
using _Scripts.Timber_Man.Enums;
using _Scripts.Timber_Man.Handlers;
using _Scripts.Timber_Man.Models.Branchs;
using _Scripts.Timber_Man.Models.Branchs.Abstraction;
using _Scripts.Timber_Man.Models.Parents;
using _Scripts.Timber_Man.Pools;
using _Scripts.Timber_Man.Repository;
using _Scripts.Timber_Man.Resolvers;
using _Scripts.Timber_Man.Services;
using _Scripts.Timber_Man.Services.Abstractions;
using _Scripts.Timber_Man.Settings;
using _Scripts.Timber_Man.Signals.Inputs;
using _Scripts.Timber_Man.Signals.Players;
using _Scripts.Timber_Man.Signals.UI;
using _Scripts.Timber_Man.Signals.UI.OptionSignals;
using _Scripts.Timber_Man.Storages;
using _Scripts.Timber_Man.Storages.Abstraction;
using _Scripts.Timber_Man.UI;
using UnityEngine;
using Zenject;
using SettingRepository = _Scripts.Timber_Man.Repository.SettingRepository;

namespace _Scripts.Timber_Man.Installers
{
    public class TimberManInstaller : MonoInstaller<TimberManInstaller>
    {
        [SerializeField] StorageType storageType;

        public override void InstallBindings()
        {
            AddPlayer();

            AddServices();

            AddSignals();

            AddHandlers();

            Addbranchs();

            AddTree();

            AddLeaderBoard();

            AddUI();

            AddStorage();

            AddSettings();
        }

        private void AddServices()
        {
            AddInputService();

            AddRepositoryService();
        }

        private void AddRepositoryService()
        {
            Container.Bind<SettingRepository>().AsSingle();
        }

        private void AddSettings()
        {
            Container.Bind<StorageSetting>()
                .FromMethod(ctx =>
                {
                    var repo = ctx.Container.Resolve<SettingRepository>();
                    return repo.Load();
                })
                .AsSingle();
        }

        private void AddStorage()
        {
            Container.Bind<IKeyValueStorage>()
                .To<BayeganStorage>()
                .AsTransient();

            Container.Bind<IKeyValueStorage>()
                .To<PlayerPrefsStorage>()
                .AsTransient();

            Container.Bind<KeyValueStorageResolver>()
                .AsTransient();
        }

        private void AddUI()
        {
            Container.Bind<UIController>().FromComponentsInHierarchy().AsSingle();

            Container.Bind<LeaderBoardUI>().FromComponentInHierarchy().AsSingle();

            Container.Bind<OptionUI>().FromComponentInHierarchy().AsSingle();

            Container.Bind<ScoreUIController>().FromComponentInHierarchy().AsSingle();
        }

        private void AddLeaderBoard()
        {
            Container.Bind<LeaderboardService>().AsSingle();

            Container.Bind<LeaderboardRepository>().AsSingle();
        }

        private void AddTree()
        {
            Container.Bind<TreeController>().FromComponentInHierarchy().AsSingle();
        }

        private void AddMemoryPools<TBranch, TBranchPool>()
            where TBranch : BaseBranch
            where TBranchPool : BaseBranchPool<TBranch>
        {
            var name = typeof(TBranch).Name;
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

            AddParent();
        }

        private void AddParent()
        {
            Container.Bind<PlayerIsAliveParent>()
                .FromComponentInHierarchy()
                .AsSingle();

            Container.Bind<PlayerIsDeadParent>()
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

            UISignals();
        }

        private void UISignals()
        {
            Container.DeclareSignal<CloseLeaderBoardSignal>();

            Container.DeclareSignal<OpenLeaderBoardSignal>();

            Container.DeclareSignal<OpenOptionSignal>();

            Container.DeclareSignal<CloseOptionSignal>();

            Container.DeclareSignal<ScoreSignal>();

            Container.BindSignal<CloseLeaderBoardSignal>()
                .ToMethod<UIHandler>((handler, signal) => handler.CloseLeaderBoard())
                .FromResolve();

            Container.BindSignal<OpenLeaderBoardSignal>()
                .ToMethod<UIHandler>((handler, signal) => handler.OpenLeaderBoard())
                .FromResolve();

            Container.BindSignal<OpenOptionSignal>()
                .ToMethod<UIHandler>((handler, signal) => handler.OpenOption())
                .FromResolve();

            Container.BindSignal<CloseOptionSignal>()
                .ToMethod<UIHandler>((handler, signal) => handler.CloseOption())
                .FromResolve();

            Container.BindSignal<ScoreSignal>()
                .ToMethod<UIHandler>((handler, signal) => handler.ShowScoreboard(signal))
                .FromResolve();
        }

        public void AddHandlers()
        {
            Container.Bind<PlayerHandler>().AsTransient();

            Container.Bind<UIHandler>().AsTransient();
        }

        private void PlayerSignals()
        {
            Container.DeclareSignal<RequestToMoveLeftSignal>();

            Container.DeclareSignal<RequestToMoveRightSignal>();

            Container.DeclareSignal<PlayerDied>();

            Container.BindSignal<RequestToMoveLeftSignal>()
                .ToMethod<PlayerHandler>((handler, signal) => handler.OnRequestToMoveLeft())
                .FromResolve();

            Container.BindSignal<RequestToMoveRightSignal>()
                .ToMethod<PlayerHandler>((handler, signal) => handler.OnRequestToMoveRight())
                .FromResolve();

            Container.BindSignal<PlayerDied>()
                .ToMethod<PlayerHandler>((handler, signal) => handler.OnPlayerDied())
                .FromResolve();

            Container.BindSignal<PlayerDied>()
                .ToMethod<UIHandler>((handler, signal) => handler.OnPlayerDied())
                .FromResolve();
        }
    }
}