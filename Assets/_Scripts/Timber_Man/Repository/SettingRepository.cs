using _Scripts.Timber_Man.Enums;
using _Scripts.Timber_Man.Settings;
using UnityEngine;

namespace _Scripts.Timber_Man.Repository
{
    public class SettingRepository
    {
        private const string RepositoryServiceKey = "SettingRepository";

        public void Save(StorageSetting storageSetting)
        {
            PlayerPrefs.SetInt(RepositoryServiceKey, (int)storageSetting.StorageType);
        }

        public StorageSetting Load()
        {
            var value = PlayerPrefs.GetInt(RepositoryServiceKey, (int)StorageType.BayeganStorage);

            return new StorageSetting
            {
                StorageType = (StorageType)value
            };
        }
    }
}