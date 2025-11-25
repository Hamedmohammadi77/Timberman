using System;
using System.Collections.Generic;
using _Scripts.Timber_Man.Domain;

namespace _Scripts.Timber_Man.Wrapper
{
    [Serializable]
    public class LeaderboardWrapper
    {
        public List<LeaderboardRecord> records;
    }
}