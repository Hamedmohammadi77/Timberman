using System.Collections.Generic;
using System.IO;
using _Scripts.Timber_Man.Domain;
using _Scripts.Timber_Man.Wrapper;
using UnityEngine;


namespace _Scripts.Timber_Man.Repository
{
    public class JsonRepository
    {
        private readonly string _path = Path.Combine(Application.persistentDataPath, "Assets/Resources/leaderboard.json");

        public void Save(List<LeaderboardRecord> recs)
        {
            LeaderboardWrapper wrapper = new LeaderboardWrapper();
            wrapper.records = recs;

            string json = JsonUtility.ToJson(wrapper);

            File.WriteAllText(_path, json);
        }

        public List<LeaderboardRecord> Load()
        {
            if (!File.Exists(_path))
            {
                Debug.Log("no list");
                return new List<LeaderboardRecord>();
            }

            string json = File.ReadAllText(_path);

            if (string.IsNullOrWhiteSpace(json))
                return new List<LeaderboardRecord>();

            LeaderboardWrapper wrapper = JsonUtility.FromJson<LeaderboardWrapper>(json);
            
            return wrapper.records;
        }
    }
}