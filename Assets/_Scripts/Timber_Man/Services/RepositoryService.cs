using _Scripts.Timber_Man.Enums;
using _Scripts.Timber_Man.Settings;
using UnityEngine;

namespace _Scripts.Timber_Man.Services
{
    public class RepositoryService
    {
        private const string RepositoryServiceKey = "RepositoryService";

        public void Save(StorageSetting storageSetting)
        {
            PlayerPrefs.DeleteKey(RepositoryServiceKey);
            PlayerPrefs.SetString(RepositoryServiceKey, storageSetting.StorageType.ToString());
        }

        public StorageSetting Load()
        {
            var temp = PlayerPrefs.GetString(RepositoryServiceKey, StorageType.BayeganStorage.ToString());

            if (temp.Equals(StorageType.BayeganStorage.ToString()))
            {
                return new StorageSetting { StorageType = StorageType.BayeganStorage };
            }
            else
            {
                return new StorageSetting { StorageType = StorageType.PlayerPrefsStorage };
            }
        }
    }
}