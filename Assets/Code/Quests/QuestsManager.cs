using System;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{
    public PlayerInputSystem player;
    public PlayerPocket playerP;
    public ItemData item;
    [SerializeField] private SowManager sow;
    public SeedSow seedSow;
    public QuestData data;
    public GameObject pot;
    public GameObject placeToPot;
    public WorldPot worldPot;
    public int progressCount;
    public int finallCount = 13;
    public int index = 0;
    public event Action<string> onQuestStarted;
    public event Action<int, int> onRewardProgress;
    public event Action onFirstQuestFinished;
    public bool iCantFindExit = true;

    void Awake()
    {
        sow.iCreatedSeedSow += isSeedCreated;
        sow.onSowed += Sowed;
        player.whenIOpen += ITakeInt;
        playerP.onItemPickUp += keyPickUp;
    }
    void Start()
    {
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
            placeToPot = Instantiate(pot);
            worldPot = placeToPot.GetComponent<WorldPot>();
            worldPot.player = player;
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
    public void isSeedCreated(SeedSow sow)
    {
        seedSow = sow;
        seedSow.WhenIGrow += WhenSowed;
    }
    public void WhenSowed()
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
            iCantFindExit = false;
            index++;
            onQuestStarted?.Invoke(data.Quests[index]);
        }
        else
        {
            return;
        }
    }
}
