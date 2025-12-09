using Unity.VisualScripting;
using UnityEngine;

public class WorldItem : MonoBehaviour
{
    public ItemData data;
    public bool youCanTakeMe;
    public float myDistance;
    public PlayerInputSystem player;
    public bool goTakeMe = false;

    void Update()
    {
        if (youCanTakeMe)
        {
            myDistance = Vector3.Distance(transform.position,player.transform.position);
            if (myDistance <= player.distanceToTake)
            {
                goTakeMe = true;
            }
            else
            {
                goTakeMe = false;
            }
        }
    }
}
