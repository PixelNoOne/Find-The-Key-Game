using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(fileName = "SeedData", menuName = "Scriptable Objects/SeedData")]
public class SeedData : ScriptableObject
{
    public ItemData Seed;
    public GameObject[] growthStage = new GameObject[3];
    public float[] growthStageTime = new float[3];
}
