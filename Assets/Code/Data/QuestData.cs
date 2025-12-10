using System.Globalization;
using UnityEngine;

[CreateAssetMenu(menuName = "Quests")]
public class QuestData : ScriptableObject
{
    public string[] Quests;
    public bool[] QuestKey;
    public string rewardText;
    public ItemData itemReward;
}
