using _Scripts.Timber_Man.Repository;
using _Scripts.Timber_Man.Settings;

namespace _Scripts.Timber_Man.Services
{
    public class SettingService
    {
        //setting repository
        private readonly SettingRepository _settingRepository;
        
        public SettingService(SettingRepository repository)
        {
            _settingRepository = repository;
        }

        public void SaveNewSetting(StorageSetting storageSetting)
        {
            _settingRepository.Save(storageSetting);
        }

        public StorageSetting LoadNewSetting()
        {
            return _settingRepository.Load();
        }
    }
}