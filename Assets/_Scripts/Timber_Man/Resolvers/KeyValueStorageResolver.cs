using System.Linq;
using _Scripts.Timber_Man.Enums;
using _Scripts.Timber_Man.Settings;
using _Scripts.Timber_Man.Storages.Abstraction;
using UnityEngine;

namespace _Scripts.Timber_Man.Resolvers
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
         
            Debug.Log($"Construct   {type}");
            
            return _keyValueStorages.FirstOrDefault(hr => hr.Type == type);
        }
    }
}