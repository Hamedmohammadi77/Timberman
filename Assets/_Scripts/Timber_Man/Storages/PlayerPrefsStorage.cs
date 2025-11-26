using Bayegan.Builder;
using Bayegan.Storage.Abstractions;
using UnityEngine;

namespace _Scripts.Timber_Man.Storages
{
    public class PlayerPrefsStorage
    {
        private readonly IBayeganDictionary _bayeganDictionaryBuilder;

        private const string EncryptionKey = "12345678901234567890123456789012"; // 32 chars
        private const string IV = "1234567890123456";

        public PlayerPrefsStorage()
        {
            _bayeganDictionaryBuilder = new BayeganDictionaryBuilder()
                .UseDefaultSecurePlayerPrefs(EncryptionKey, IV)
                .Build();
        }

        public void Save(string key, string value)
        {
            _bayeganDictionaryBuilder.Store(key, value);
        }

        public string Load(string key, string defaultValue)
        {
            return _bayeganDictionaryBuilder.Load(key, defaultValue);
        }
    }
}