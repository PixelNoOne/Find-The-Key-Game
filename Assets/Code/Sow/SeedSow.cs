using System;
using System.Collections;
using UnityEditor;
using UnityEngine;

public class SeedSow : MonoBehaviour
{
    public SeedData seedData;
    public ItemData item;
    public GameObject stage;
    public event Action WhenIGrow;
    public event Action StagePlus;
    public int growthAndGrowthTaimStage = 0;

    void Start()
    {
        stage = Instantiate(seedData.growthStage[growthAndGrowthTaimStage]);
        stage.transform.position = transform.position;
        StartCoroutine(grow());
    }
    IEnumerator grow()
    {
        while(growthAndGrowthTaimStage <= seedData.growthStage.Length - 1)
        {
            yield return new WaitForSeconds(seedData.growthStageTime[growthAndGrowthTaimStage]);
            if (growthAndGrowthTaimStage < seedData.growthStage.Length - 1)
            {
                Destroy(stage);
            }
            else
            {
                break;
            }
            growthAndGrowthTaimStage++;
            stage = Instantiate(seedData.growthStage[growthAndGrowthTaimStage]);
            stage.transform.position = transform.position;
        }
        WhenIGrow?.Invoke();
    }
}
