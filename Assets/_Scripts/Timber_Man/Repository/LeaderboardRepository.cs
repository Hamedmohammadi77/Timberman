using System.Collections.Generic;
using System.Linq;
using _Scripts.Timber_Man.Domain;
using _Scripts.Timber_Man.Extensions;
using _Scripts.Timber_Man.Resolvers;
using _Scripts.Timber_Man.Storages;
using _Scripts.Timber_Man.Storages.Abstraction;


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

        private readonly IKeyValueStorage _storage;

        public LeaderboardRepository(KeyValueStorageResolver resolver)
        {
            _storage = resolver.Resolve();
        }

        public void Save(List<LeaderboardRecord> recs)
        {
            var json = recs.ToJson();
            if (_storage is BayeganStorage)
            {
                _storage.Save(LeaderBoardKeyForBayegan, json);
            }

            _storage.Save(LeaderBoardKeyForPlayerprefs, json);
        }

        public List<LeaderboardRecord> Load()
        {
            string refineRecordsString;
            if (_storage is BayeganStorage)
            {
                refineRecordsString = _storage.Load(LeaderBoardKeyForBayegan, string.Empty);
            }
            else
            {
                refineRecordsString = _storage.Load(LeaderBoardKeyForPlayerprefs, string.Empty);
            }

            if (string.IsNullOrEmpty(refineRecordsString))
                return new List<LeaderboardRecord>();

            var refineRecords = refineRecordsString.FromJson<List<LeaderboardRecord>>();

            return refineRecords
                .OrderByDescending(record => record.Score)
                .ToList();
        }
    }
}