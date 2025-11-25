using System;
using System.Collections.Generic;
using _Scripts.Timber_Man.Domain; 
using System.Linq;

namespace _Scripts.Timber_Man.Services
{
    public class LeaderboardService
    {
        public void Save(List<LeaderboardRecord> recs)
        {
            
        }

        public void Submit(double score)
        {
            var rec = new LeaderboardRecord
            {
                Score = score,
                SubmitDateTimeUtc = DateTime.UtcNow
            };

            var allRecords =GetAll();
            
            allRecords.Add(rec);

            allRecords = allRecords
                .OrderByDescending(rec => rec.Score)
                .Take(5)
                .ToList();
            
            Save(allRecords);

        }

        public List<LeaderboardRecord> GetAll()
        {
            return new List<LeaderboardRecord>();
        }
    }
}