using System;
using UnityEngine;

public class PlayerInputSystem : MonoBehaviour
{
    private MeshRenderer mesh;
    public Material outline;
    public Material myMat;
    public PlayerPocket playerP;
    public RewardUi reward;
    public Transform hand;
    public float distanceToTake = 7f;
    public float rayLength = 7f;
    public GameObject furniture;
    public WorldFurniture furnitureINeedRemember;
    public GameObject pot;
    public WorldPot potINeedRemember;
    public GameObject item;
    public WorldItem itemINeedRemember;
    public GameObject door;
    public WorldDoor doorINeedRemember;
    public event Action Interact;
    public event Action<ItemData, GameObject> onSow;
    public event Action<ItemData> onItemTake;
    public event Action<int> whenIOpen;
    public event Action WhenIOpenDoor;
    public event Action onVectorBoxOpen;
    public event Action onEulerBoxOpen;
    public event Action onCartonBoxOpen;
    private ItemData onClickItem;
    public bool isLookingBox;
    public bool isLookingPot;
    public bool isLookingItem;
    public bool iSeeExit;
    public int howMuchBoxIOpen = 0;
    void Awake()
    {
        reward.onClickDo += OnClickDo;
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
        iSeeExit = false;
        if(furniture != null && mesh != null)
        {
            var matArray = mesh.materials;
            myMat = matArray[0];
            matArray[1] = myMat;
            mesh.materials = matArray;
        }
        if (Physics.Raycast(ray, out hit, rayLength))
        {
            if (hit.collider.GetComponent<WorldFurniture>())
            {
                furniture = hit.collider.gameObject;
                furnitureINeedRemember = furniture.GetComponent<WorldFurniture>();
                if (furnitureINeedRemember.youCanOpen == true)
                {
                    isLookingBox = true;
                    mesh = furniture.GetComponent<MeshRenderer>();
                    var matArray = mesh.materials;
                    matArray[1] = outline;
                    mesh.materials = matArray;
                }
            }
            if (hit.collider.GetComponent<WorldPot>())
            {
                pot = hit.collider.gameObject;
                potINeedRemember = pot.GetComponent<WorldPot>();
                if (pot != null && potINeedRemember != null)
                {
                    isLookingPot = true;
                }
            }
            if (hit.collider.GetComponent<WorldItem>())
            {
                item = hit.collider.gameObject;
                itemINeedRemember = item.GetComponent<WorldItem>();
                isLookingItem = true;
            }
            if (hit.collider.GetComponent<WorldDoor>())
            {
                door = hit.collider.gameObject;
                doorINeedRemember = door.GetComponent<WorldDoor>();
                if(doorINeedRemember.door.iCanOpen == true && doorINeedRemember.youCanOpenMe == true)
                {
                    iSeeExit = true;
                }
            }
        }
        if (pressedE && isLookingBox && furnitureINeedRemember != null && furnitureINeedRemember.imNotOpenYet == true)
        {
            Interact?.Invoke();
            howMuchBoxIOpen++;
            whenIOpen?.Invoke(howMuchBoxIOpen);
            if(furnitureINeedRemember.myOpenVector) onVectorBoxOpen?.Invoke();
            if(!furnitureINeedRemember.myOpenVector && !furnitureINeedRemember.iAmBox) onEulerBoxOpen?.Invoke();
            if (!furnitureINeedRemember.myOpenVector && furnitureINeedRemember.iAmBox) onCartonBoxOpen?.Invoke();
        }
        if (pressedE && isLookingItem && item != null)
        {
            onItemTake?.Invoke(itemINeedRemember.data);
        }
        if (pressedE && potINeedRemember != null && potINeedRemember.youCanWorkWithMe == true)
        {
            onSow?.Invoke(playerP.itemData, pot);
        }
        if(pressedE && iSeeExit)
        {
            WhenIOpenDoor?.Invoke();
        }
    }
    public void OnClickDo(ItemData items)
    {
        onClickItem = items;
        onItemTake?.Invoke(onClickItem);
    }
}
