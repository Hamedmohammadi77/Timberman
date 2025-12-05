using _Scripts.Timber_Man.Panels;
using _Scripts.Timber_Man.Repository;
using _Scripts.Timber_Man.Signals.UI.OptionSignals;

namespace _Scripts.Timber_Man.Handlers
{
    public class RepositoryHandler
    {
        private LeaderboardRepository _leaderboardRepository;

        public RepositoryHandler(LeaderboardRepository leaderboardRepository)
        {
            _leaderboardRepository = leaderboardRepository;
        }

        public void StorageChange(StorageChangeSignal signal)
        {
            _leaderboardRepository.ChangeStorage(signal.StorageSetting);
        }
    }
}