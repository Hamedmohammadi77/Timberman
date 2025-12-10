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

        private const string LeaderBoardKeyPrefix = "Leaderboard_";

        private IKeyValueStorage _storage;
        private KeyValueStorageResolver _resolver;
        private SettingRepository _settingRepository;

        public LeaderboardRepository(KeyValueStorageResolver resolver, SettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
            _resolver = resolver;
            _storage = _resolver.Resolve();
        }

        public void Save(List<LeaderboardRecord> recs)
        {
            _storage = _resolver.Resolve();
            
            var json = recs.ToJson();
            var key = $"{LeaderBoardKeyPrefix}{_storage.Type}";
            _storage.Save(key, json);
        }


        public List<LeaderboardRecord> Load()
        {
            _storage = _resolver.Resolve();
            
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