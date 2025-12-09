using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemData : ScriptableObject
{
    public string ItemName;
    public Sprite icon;
    public GameObject handPrefab;
    public SeedData seedData;
    [SerializeField] private GameObject worldRefence;
    public GameObject plantPreFab;
}
