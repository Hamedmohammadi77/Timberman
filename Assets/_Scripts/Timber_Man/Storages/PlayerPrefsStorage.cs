using _Scripts.Timber_Man.Enums;
using _Scripts.Timber_Man.Storages.Abstraction;
using UnityEngine;

namespace _Scripts.Timber_Man.Storages
{
    public class PlayerPrefsStorage : IKeyValueStorage
    {
        public StorageType Type => StorageType.PlayerPrefsStorage;

        public PlayerPrefsStorage()
        {
            Debug.Log("Playerprefs Constructor");
        }

        public void Save(string key, string value)
        {
            Debug.Log("Playerprefs Constructor Saved");
            PlayerPrefs.SetString(key, value);
        }

        public string Load(string key, string defaultValue)
        {
            Debug.Log("Playerprefs Constructor Loaded");
            var getdata = PlayerPrefs.GetString(key);

            if (!string.IsNullOrEmpty(getdata))
            {
                return getdata;
            }

            return defaultValue;
        }
    }
}