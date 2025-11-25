using _Scripts.Timber_Man.Services;
using UnityEngine;
using Zenject;

namespace _Scripts.Timber_Man.Controllers.Ui
{
    public class LeaderboardController: MonoBehaviour
    {
        [Inject] private readonly LeaderboardService _leaderboardService;


        public void Show()
        {
            var recs = _leaderboardService.GetAll();
            //add to view
            foreach (var rec in recs)
                Debug.Log($"record {rec.Score}  {rec.SubmitDateTimeUtc }");
            
            
            gameObject.SetActive(true);
        }

    }
}