using _Scripts.Timber_Man.Enums;

namespace _Scripts.Timber_Man.Storages.Abstraction
{
    public interface IKeyValueStorage
    {
        StorageType Type { get; }

        void Save(string key, string value);

        string Load(string key, string defaultValue);
    }
}