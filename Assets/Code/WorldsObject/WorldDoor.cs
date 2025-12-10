using UnityEngine;

public class WorldDoor : MonoBehaviour
{
    public DoorData door;
    public QuestsManager Quests;
    public PlayerInputSystem player;
    public float myDistance = 0f;
    public bool youCanOpenMe = false;

    void Update()
    {
        if(Quests.iCantFindExit == true)
        {
            door.iCanOpen = false;
        }
        else
        {
            door.iCanOpen = true;
        }
        if (door.iCanOpen == true)
        {
            myDistance = Vector3.Distance(transform.position, player.transform.position);
            if (myDistance <= player.distanceToTake)
            {
                youCanOpenMe = true;
            }
            else
            {
                youCanOpenMe = false;
            }
        }
    }
}
