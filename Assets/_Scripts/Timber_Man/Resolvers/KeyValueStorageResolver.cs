using System.Linq;
using _Scripts.Timber_Man.Enums;
using _Scripts.Timber_Man.Settings;
using _Scripts.Timber_Man.Storages.Abstraction;

namespace _Scripts.Timber_Man.Resolver
{
    public class KeyValueStorageResolver
    {
        private readonly IKeyValueStorage[] _keyValueStorages;
        private readonly StorageSetting _storageSetting;

        public KeyValueStorageResolver(
            IKeyValueStorage[] keyValueStorages, 
            StorageSetting storageSetting)
        {
            _keyValueStorages = keyValueStorages;
            _storageSetting = storageSetting;
        }
        
        
        public IKeyValueStorage Resolve(StorageType? type = null)
        {
            if(type.HasValue == false)
                type = _storageSetting.RepositoryType;
            
            return _keyValueStorages.FirstOrDefault(hr => hr.Type == type);
        }
    }
}