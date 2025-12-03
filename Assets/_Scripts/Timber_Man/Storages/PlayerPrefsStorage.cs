using _Scripts.Timber_Man.Enums;
using _Scripts.Timber_Man.Storages.Abstraction;
using UnityEngine;

namespace _Scripts.Timber_Man.Storages
{
    public class PlayerPrefsStorage : IKeyValueStorage
    {
        public StorageType Type => StorageType.PlayerPrefsStorage;

        public void Save(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }

        public string Load(string key, string defaultValue)
        {
            var getdata = PlayerPrefs.GetString(key);

            if (!string.IsNullOrEmpty(getdata))
            {
                return getdata;
            }

            return defaultValue;
        }
    }
}