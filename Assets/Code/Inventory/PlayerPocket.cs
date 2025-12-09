using System;
using UnityEngine;

public class PlayerPocket : MonoBehaviour
{
    public ItemData itemData;
    public event Action<ItemData> onItemPickUp;
    public PlayerInputSystem player;
    public GameObject itemInHand;
    public Animator animator;
    void Start()
    {
        player.onItemTake += pickUpItem;
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(itemInHand == null)
        {
            itemData = null;
            onItemPickUp?.Invoke(null);
        }
        animator.SetBool("itemInHand",itemInHand != null);
    }
    void pickUpItem(WorldItem item)
    {
        if (item != null && item.data != null)
        {
            itemData = item.data;
            itemInHand = Instantiate(item.data.handPrefab);
            itemInHand.transform.SetParent(player.hand);
            itemInHand.transform.localPosition = new Vector3(0.1f, 0.4f, 0.2f);
            itemInHand.transform.localRotation = Quaternion.Euler(250, 0, 0);
            onItemPickUp?.Invoke(item.data);
            Destroy(player.item);
        }
        else
        {
            return;
        }
    }
}
