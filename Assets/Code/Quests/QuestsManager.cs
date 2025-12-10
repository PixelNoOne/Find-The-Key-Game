using System;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{
    public PlayerInputSystem player;
    public PlayerPocket playerP;
    public ItemData item;
    public SowManager sow;
    public QuestData data;
    public int progressCount;
    public int finallCount = 13;
    public int index = 0;
    public event Action<string> onQuestStarted;
    public event Action<int, int> onRewardProgress;
    public event Action onFirstQuestFinished;

    void Start()
    {
        player.whenIOpen += ITakeInt;
        sow.onSowed += Sowed;
        playerP.onItemPickUp += keyPickUp;
        onQuestStarted?.Invoke(data.Quests[index]);
        onRewardProgress?.Invoke(progressCount, finallCount);
    }
    public void ITakeInt(int score)
    {
        progressCount = score;
        if (progressCount < finallCount)
        {
            onRewardProgress?.Invoke(progressCount, finallCount);
        }
        else
        {
            data.QuestKey[index] = true;
            onFirstQuestFinished?.Invoke();
            index++;
            onQuestStarted?.Invoke(data.Quests[index]);
        }
    }
    public void Sowed(bool sow)
    {
        data.QuestKey[index] = true;
        index++;
        onQuestStarted?.Invoke(data.Quests[index]);
    }
    public void keyPickUp(ItemData items)
    {
        if (item == items)
        {
            data.QuestKey[index] = true;
            index++;
            onQuestStarted?.Invoke(data.Quests[index]);
        }
        else
        {
            return;
        }
    }
}
