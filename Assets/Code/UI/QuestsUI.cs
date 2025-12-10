using TMPro;
using UnityEngine;

public class QuestsUI : MonoBehaviour
{
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
    }
    public void OffText()
    {
        progressStatus.enabled = false;
    }
}
