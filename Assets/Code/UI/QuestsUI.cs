using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestsUI : MonoBehaviour
{
    public Image progressBar;
    public TMP_Text text;
    public TMP_Text progressStatus;
    public QuestsManager Quests;

    void Awake()
    {
        Quests.onFirstQuestFinished += OffText;
        Quests.onQuestStarted += UpdateQuest;
        Quests.onRewardProgress += RewardTake;
    }
    public void UpdateQuest(string quest)
    {
        text.text = quest;
    }
    public void RewardTake(int progressCount,int finallCount)
    {
        progressStatus.text = new string($"{progressCount}/{finallCount}");
        progressBar.enabled = true;
    }
    public void OffText()
    {
        progressStatus.enabled = false;
        progressBar.enabled = false;
    }
}
