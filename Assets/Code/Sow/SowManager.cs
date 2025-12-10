using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;

public class SowManager : MonoBehaviour
{
    public PotData PotData;
    private GameObject plant;
    public PlayerInputSystem player;
    public PlayerPocket playerP;
    public SeedSow seedSow;
    public bool seedIsSowed = false;
    public event Action<bool> onSowed;
    public event Action<SeedSow> iCreatedSeedSow;
    
    void Start()
    {
        player.onSow += Interact;
    }
    public void Interact(ItemData item, GameObject pot)
    {
        if(item != null && item.seedData != null)
        {
            plant = Instantiate(item.plantPreFab);
            plant.transform.position = pot.transform.position + Vector3.up * 0.55f;
            plant.transform.rotation = Quaternion.identity;
            seedSow = plant.GetComponent<SeedSow>();
            iCreatedSeedSow?.Invoke(seedSow);
            seedSow.seedData = item.seedData;
            Destroy(playerP.itemInHand);
            playerP.itemInHand = null;
            seedIsSowed = true;
            onSowed?.Invoke(seedIsSowed);
        }
    }
}
