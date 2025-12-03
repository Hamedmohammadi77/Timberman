using _Scripts.Timber_Man.Enums;
using _Scripts.Timber_Man.Storages.Abstraction;
using Bayegan.Builder;
using Bayegan.Storage.Abstractions;

namespace _Scripts.Timber_Man.Storages
{
    public class BayeganStorage : IKeyValueStorage
    {
        private readonly IBayeganDictionary _bayeganDictionaryBuilder;

        public StorageType Type => StorageType.BayeganStorage;

        private const string EncryptionKey = "12345678901234567890123456789012";
        private const string Iv = "1234567890123456";

        public BayeganStorage()
        {
            _bayeganDictionaryBuilder = new BayeganDictionaryBuilder()
                .UseDefaultSecurePlayerPrefs(EncryptionKey, Iv)
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