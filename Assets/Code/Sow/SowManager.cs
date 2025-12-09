using Unity.VisualScripting;
using UnityEngine;

public class SowManager : MonoBehaviour
{
    public PotData PotData;
    private GameObject plant;
    public PlayerInputSystem player;
    public PlayerPocket playerP;
    public SeedSow SeedSow;
    
    void Start()
    {
        player.onSow += Interact;
    }
    public void Interact(ItemData item, GameObject pot)
    {
        if(item.seedData != null)
        {
            plant = Instantiate(item.plantPreFab);
            plant.transform.position = pot.transform.position + Vector3.up * 0.55f;
            plant.transform.rotation = Quaternion.identity;
            SeedSow = plant.GetComponent<SeedSow>();
            SeedSow.seedData = item.seedData;
            Destroy(playerP.itemInHand);
            playerP.itemInHand = null;
        }
    }
}
