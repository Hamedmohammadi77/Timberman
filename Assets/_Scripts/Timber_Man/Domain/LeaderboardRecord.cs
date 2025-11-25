using System;

namespace _Scripts.Timber_Man.Domain
{
    public class LeaderboardRecord
    {
        public DateTime SubmitDateTimeUtc { get; set; }
        
        public double Score { get; set; }
    }
}