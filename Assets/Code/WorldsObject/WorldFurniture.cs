using UnityEngine;

public class WorldFurniture : MonoBehaviour
{
    public FurnitureData data;
    public bool myOpenVector;
    public float speed = 5f;
    public bool imNotOpenYet;
    public PlayerInputSystem player;
    public bool youNeedOpen = false;
    public float myDistance = 0f;
    public bool youCanOpen = false;

    void Start()
    {
        player.Interact += Interact;
    }
    void Update()
    {
        if (player.furniture != null && player.furnitureINeedRemember.data != null && data == player.furnitureINeedRemember.data) 
        {
            myDistance = Vector3.Distance(transform.position,player.transform.position);
            if (myDistance <= player.distanceToTake)
            {
                youCanOpen = true;
            }
            else
            {
                youCanOpen = false;
            }
        }
        if (youNeedOpen && myOpenVector)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, data.VectorOpen.openPosition, speed * Time.deltaTime);
            imNotOpenYet = false;
        }
        else if (youNeedOpen && !myOpenVector)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation,data.EulerOpen.openRotation,speed * Time.deltaTime);
            imNotOpenYet = false;
        }
        {
            
        }
    }
    public void Interact()
    {
        if (player.furnitureINeedRemember.data != null && data == player.furnitureINeedRemember.data) 
        {
            if (imNotOpenYet)
            {
                youNeedOpen = true;
            }
            else
            {
                youNeedOpen = false;
            }
        }
        else 
        {
            return;
        }
    }
}
