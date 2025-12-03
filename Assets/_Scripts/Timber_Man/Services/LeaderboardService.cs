using System;
using System.Collections.Generic;
using _Scripts.Timber_Man.Domain;
using System.Linq;
using _Scripts.Timber_Man.Repository;
using Zenject;

namespace _Scripts.Timber_Man.Services
{
    public class LeaderboardService
    {
        [Inject] private readonly LeaderboardRepository _repository;

        private void Save(List<LeaderboardRecord> recs)
        {
            _repository.Save(recs);
        }

        public void Submit(double score)
        {
            var rec = new LeaderboardRecord
            {
                Score = (int)score,
                SubmitDateTimeUtc = DateTime.UtcNow
            };

            var allRecords = GetAll();

            allRecords.Add(rec);

            allRecords = allRecords
                .OrderByDescending(record => record.Score)
                .Take(5)
                .ToList();

            Save(allRecords);
        }

        public List<LeaderboardRecord> GetAll()
        {
            return _repository.Load();
        }
    }
}