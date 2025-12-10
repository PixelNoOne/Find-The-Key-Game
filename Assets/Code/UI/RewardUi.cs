using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardUi : MonoBehaviour
{
    public GameObject rewardWindow;
    public event Action<ItemData> onClickDo;
    public ItemData item;
    public Image icon;
    public TMP_Text text;
    public QuestsManager Quests;
    public bool rewardWindowOpen = false;

    void Start()
    {
        Quests.onFirstQuestFinished += Interact;
    }
    public void Interact()
    {
        rewardWindow.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        icon.sprite = item.icon;
        icon.enabled = true;
        text.text = Quests.data.rewardText;
        rewardWindowOpen = true;
    }
    public void iDo()
    {
        rewardWindow.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        icon.sprite = null;
        icon.enabled = false;
        text.text = null;
        rewardWindowOpen = false;
        onClickDo?.Invoke(item);
    }
}
