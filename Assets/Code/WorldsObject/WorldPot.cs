using Unity.VisualScripting;
using UnityEngine;

public class WorldPot : MonoBehaviour
{
    public PotData PotData;
    public float myDistance;
    public PlayerInputSystem player;
    public bool iAlreadyWork = false;
    public bool youCanWorkWithMe = false;

    void Update()
    {
        if (player != null && player.potINeedRemember != null && PotData == player.potINeedRemember.PotData)
        {
            myDistance = Vector3.Distance(transform.position, player.transform.position);
            if (myDistance <= player.distanceToTake)
            {
                if (player.isLookingPot == true)
                {
                    youCanWorkWithMe = true;
                }
                else
                {
                    youCanWorkWithMe = false;
                }
            }
            else
            {
                return;
            }
        }
    }
}
