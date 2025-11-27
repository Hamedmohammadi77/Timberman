using System;
using _Scripts.Timber_Man.Services;
using TMPro;
using UnityEngine;
using Zenject;

namespace _Scripts.Timber_Man.Controllers.Ui
{
    public class LeaderboardController: MonoBehaviour
    {
        [Inject] private readonly LeaderboardService _leaderboardService;
        private TextMeshProUGUI _leaderboardText;

        private void Start()
        {
            _leaderboardText= GetComponent<TextMeshProUGUI>();
            Show();
        }

        public void Show()
        {
            string showleaderBoard = "";
            var recs = _leaderboardService.GetAll();
            //add to view
            foreach (var rec in recs)
            {
                showleaderBoard += $"record {rec.Score}  {rec.SubmitDateTimeUtc} {Environment.NewLine}";
                Debug.Log($"record {rec.Score}  {rec.SubmitDateTimeUtc} ");
            }

            _leaderboardText.text = showleaderBoard;

        }

    }
}