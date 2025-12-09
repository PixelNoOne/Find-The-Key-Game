using UnityEngine;
using UnityEngine.InputSystem.Processors;
using UnityEngine.UI;

public class HotBarUi : MonoBehaviour
{
    public Image icon;
    public Sprite image;
    public PlayerPocket playerP;
    void Start()
    {
        playerP.onItemPickUp += UpdateUi;
    }
    public void UpdateUi(ItemData item)
    {
        if (item != null)
        {
            image = item.icon;
            icon.sprite = image;
            icon.enabled = true;
        }
        else
        {
            image = null;
            icon.sprite = null;
            icon.enabled = false;
        }
    }
}
