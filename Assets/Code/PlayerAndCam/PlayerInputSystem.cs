using System;
using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    public PlayerPocket playerP;
    public Transform hand;
    public float distanceToTake = 7f;
    public float rayLength = 7f;
    public GameObject furniture;
    public WorldFurniture furnitureINeedRemember;
    public GameObject pot;
    public WorldPot potINeedRemember;
    public GameObject item;
    public WorldItem itemINeedRemember;
    public event Action Interact;
    public event Action<ItemData, GameObject> onSow;
    public event Action<WorldItem> onItemTake;
    public bool isLookingBox;
    public bool isLookingPot;
    public bool isLookingItem;
    void Start()
    {

    }
    private void Update()
    {
        bool pressedE = Input.GetKeyDown(KeyCode.E);
        var eye = Camera.main.transform;
        Ray ray = new Ray(eye.position, eye.forward);
        RaycastHit hit;
        isLookingBox = false;
        isLookingPot = false;
        isLookingItem = false;
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.collider.GetComponent<WorldFurniture>())
            {
                furniture = hit.collider.gameObject;
                furnitureINeedRemember = furniture.GetComponent<WorldFurniture>();
                if (furnitureINeedRemember.youCanOpen == true)
                {
                    isLookingBox = true;
                }
            }
            if (hit.collider.GetComponent<WorldPot>())
            {
                pot = hit.collider.gameObject;
                potINeedRemember = pot.GetComponent<WorldPot>();
                isLookingPot = true;
            }
            if (hit.collider.GetComponent<WorldItem>())
            {
                item = hit.collider.gameObject;
                itemINeedRemember = item.GetComponent<WorldItem>();
                isLookingItem = true;
            }
        }
        if(pressedE && isLookingBox)
        {
            Interact?.Invoke();
        }
        if (pressedE && isLookingItem && item != null)
        {
            onItemTake?.Invoke(itemINeedRemember);
        }
        if (pressedE && potINeedRemember.youCanWorkWithMe == true)
        {
            onSow?.Invoke(playerP.itemData, pot);
        }
    }
}
