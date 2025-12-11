using UnityEngine;

[CreateAssetMenu(menuName = "Quests")]
public class QuestData : ScriptableObject
{
    public string[] Quests;
    public string rewardText;
    public ItemData itemReward;
}
