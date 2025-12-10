using UnityEngine;

public class SpawnKey : MonoBehaviour
{
    private SeedSow seed;
    public PlayerInputSystem player;
    public SowManager sow;
    [SerializeField] private WorldItem worldItem;
    [SerializeField] private GameObject key;
    void Start()
    {
        sow.iCreatedSeedSow += RememberSeedSow;
    }
    public void KeySpawned()
    {
        Instantiate(key);
        key.transform.position = new Vector3(-5.485f, 4.038f, 5.655f);
        key.transform.rotation = Quaternion.identity;
        worldItem = key.GetComponent<WorldItem>();
        worldItem.player = player;
    }
    void RememberSeedSow(SeedSow seedSow)
    {
        seed = seedSow;
        seed.WhenIGrow += KeySpawned;
    }
}
