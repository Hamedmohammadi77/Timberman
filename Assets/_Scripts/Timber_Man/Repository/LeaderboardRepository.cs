using System.Collections.Generic;
using System.Linq;
using _Scripts.Timber_Man.Domain;
using _Scripts.Timber_Man.Enums;
using _Scripts.Timber_Man.Extensions;
using _Scripts.Timber_Man.Resolvers;
using _Scripts.Timber_Man.Services;
using _Scripts.Timber_Man.Settings;
using _Scripts.Timber_Man.Storages;
using _Scripts.Timber_Man.Storages.Abstraction;
using UnityEngine;


namespace _Scripts.Timber_Man.Repository
{
    public class LeaderboardRepository
    {
        //controller - controler game object
        // service -> execute - validation, logic, event publish
        // repository -> load and save data, how to get data
        // storage - how to save, file, database, player prefs, sever

        private const string LeaderBoardKeyForBayegan = "LeaderBoardBayegan";
        private const string LeaderBoardKeyForPlayerprefs = "LeaderBoardPlayerPrefs";

        private IKeyValueStorage _storage;
        private KeyValueStorageResolver _resolver;
        private RepositoryService _repositoryService;

        public LeaderboardRepository(KeyValueStorageResolver resolver, RepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
            _resolver = resolver;
            _storage = _resolver.Resolve();
            _repositoryService.Save(new StorageSetting { StorageType = _storage.Type });
        }

        public void ChangeStorage(StorageSetting setting)
        {
            _storage = _resolver.Resolve(setting.StorageType);
            _repositoryService.Save(setting);
        }

        public void Save(List<LeaderboardRecord> recs)
        {
            var json = recs.ToJson();
            _storage.Save(_storage is BayeganStorage ? LeaderBoardKeyForBayegan : LeaderBoardKeyForPlayerprefs, json);
        }


        public List<LeaderboardRecord> Load()
        {
            var key = _storage.Type == StorageType.BayeganStorage
                ? LeaderBoardKeyForBayegan
                : LeaderBoardKeyForPlayerprefs;

            var raw = _storage.Load(key, string.Empty);

            if (string.IsNullOrEmpty(raw))
                return new List<LeaderboardRecord>();

            try
            {
                return raw.FromJson<List<LeaderboardRecord>>()
                    .OrderByDescending(r => r.Score)
                    .ToList();
            }
            catch (System.Exception e)
            {
                Debug.LogError("CORRUPTED JSON => " + raw);
                throw;
            }
        }
    }
}