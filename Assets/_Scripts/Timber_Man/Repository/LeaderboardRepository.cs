using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using _Scripts.Timber_Man.Domain;
using _Scripts.Timber_Man.Wrapper;
using UnityEngine;


namespace _Scripts.Timber_Man.Repository
{
    public class LeaderboardRepository
    {
        private const string _scoreSave = "Score_";
        private const string _dataTime = "PlayerIsAliveParent";

        public void Save(List<LeaderboardRecord> recs)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetInt(_scoreSave + i, recs[i].Score);
                PlayerPrefs.SetString(_dataTime+i, recs[i].SubmitDateTimeUtc.ToString());
            }
        }

        public List<LeaderboardRecord> Load()
        {
            List<LeaderboardRecord> refineRecords = new List<LeaderboardRecord>();

            for (int i = 0; i < 5; i++)
            {
                string dateStr = PlayerPrefs.GetString(_dataTime + i, "");

                DateTime dateValue;

                if (!DateTime.TryParse(dateStr, out dateValue))
                    dateValue = DateTime.UtcNow;

                refineRecords.Add(new LeaderboardRecord
                {
                    Score =  PlayerPrefs.GetInt(_scoreSave + i),
                    SubmitDateTimeUtc = dateValue
                });
            }

            return refineRecords
                .OrderByDescending(record => record.Score)
                .ToList();
        }

    }
}