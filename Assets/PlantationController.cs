using System.Collections;
using UnityEngine;

public class PlantationController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer soilSpriteRenderer;
    public Seed plantedSeed { get; private set; }
    public bool IsReadyToHarvert { get; private set; }

    public void Plant(Seed seed)
    {
        IsReadyToHarvert = false;
        plantedSeed = seed;
        StartCoroutine(DoPlantGrowth());
    }

    private IEnumerator DoPlantGrowth()
    {
        soilSpriteRenderer.sprite = plantedSeed.InSoilSprite;
        yield return new WaitForSeconds(plantedSeed.TimeToStartGrowing);
        soilSpriteRenderer.sprite = plantedSeed.GrowingSprite;
        yield return new WaitForSeconds(plantedSeed.TimeToHarvest);
        soilSpriteRenderer.sprite = plantedSeed.ReadyToHarvestSprite;
        IsReadyToHarvert = true;
    }
}
