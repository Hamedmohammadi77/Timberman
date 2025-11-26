using System;
using System.Collections.Generic;
using System.Linq;
using _Scripts.Timber_Man.Domain;
using UnityEngine;


namespace _Scripts.Timber_Man.Repository
{
    public class LeaderboardRepository
    {
        private const string ScoreSave = "Score_";
        private const string DataTime = "PlayerIsAliveParent";

        public void Save(List<LeaderboardRecord> recs)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt(ScoreSave + i, recs[i].Score);
                PlayerPrefs.SetString(DataTime + i, recs[i].SubmitDateTimeUtc.ToString());
                
            }
        }

        public List<LeaderboardRecord> Load()
        {
            List<LeaderboardRecord> refineRecords = new List<LeaderboardRecord>();

            for (int i = 0; i < 5; i++)
            {
                string dateStr = PlayerPrefs.GetString(DataTime + i, "");

                DateTime dateValue;

                if (!DateTime.TryParse(dateStr, out dateValue))
                    dateValue = DateTime.UtcNow;

                refineRecords.Add(new LeaderboardRecord
                {
                    Score = PlayerPrefs.GetInt(ScoreSave + i),
                    SubmitDateTimeUtc = dateValue
                });
            }

            return refineRecords
                .OrderByDescending(record => record.Score)
                .ToList();
        }
    }
}