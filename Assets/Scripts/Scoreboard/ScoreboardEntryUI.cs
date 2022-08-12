using UnityEngine;
using TMPro;

namespace Dummy.Scoreboards
{
    public class ScoreboardEntryUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI entryNameText = null;
        [SerializeField] private TextMeshProUGUI entryScoreText = null;

        public void Initialize(ScoreboardEntryData scoreboardEntryData)
        {
            entryNameText.text = scoreboardEntryData.entryName;
            entryScoreText.text = scoreboardEntryData.entryScore.ToString();
        }
    }
}