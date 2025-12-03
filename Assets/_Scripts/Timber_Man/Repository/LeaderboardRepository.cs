using System.Collections.Generic;
using System.Linq;
using _Scripts.Timber_Man.Domain;
using _Scripts.Timber_Man.Extensions;
using _Scripts.Timber_Man.Storages.Abstraction;
using Zenject;


namespace _Scripts.Timber_Man.Repository
{
    public class LeaderboardRepository
    {
        //controller - controler game object
        // service -> execute - validation, logic, event publish
        // repository -> load and save data, how to get data
        // storage - how to save, file, database, player prefs, sever

        private const string LeaderBoardKey = "LeaderBoard";

        [Inject] private readonly IKeyValueStorage _bayeganStorage;

        public void Save(List<LeaderboardRecord> recs)
        {
            var json = recs.ToJson();
            _bayeganStorage.Save(LeaderBoardKey, json);
        }

        public List<LeaderboardRecord> Load()
        {
            var refineRecordsString = _bayeganStorage.Load(LeaderBoardKey, string.Empty);

            if (string.IsNullOrEmpty(refineRecordsString))
                return new List<LeaderboardRecord>();

            var refineRecords = refineRecordsString.FromJson<List<LeaderboardRecord>>();

            return refineRecords
                .OrderByDescending(record => record.Score)
                .ToList();
        }
    }
}