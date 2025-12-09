using System;
using UnityEngine;

public class PlayerPocket : MonoBehaviour
{
    public ItemData itemData;
    public event Action<ItemData> onItemPickUp;
    public PlayerInputSystem player;
    public GameObject itemInHand;
    
    Animator animator;
    void Start()
    {
        player.onItemTake += pickUpItem;
        animator = GetComponent<Animator>();
    }
    void pickUpItem(WorldItem item)
    {
        if (item != null && item.data != null)
        {
            itemData = item.data;
            itemInHand = Instantiate(item.data.handPrefab);
            itemInHand.transform.SetParent(player.hand);
            itemInHand.transform.localPosition = Vector3.zero;
            itemInHand.transform.localRotation = Quaternion.identity;
            onItemPickUp?.Invoke(item.data);
            Destroy(player.item);
        }
        else
        {
            return;
        }
    }
}
