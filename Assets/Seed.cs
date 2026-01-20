using UnityEngine;

[CreateAssetMenu]
public class Seed : ScriptableObject
{
    [SerializeField] private Sprite inSoilSprite;
    public Sprite InSoilSprite => inSoilSprite;

    [SerializeField] private Sprite growingSprite;
    public Sprite GrowingSprite => growingSprite;

    [SerializeField] private Sprite readyToHarvestSprite;
    public Sprite ReadyToHarvestSprite => readyToHarvestSprite;

    [SerializeField] private float timeToStartGrowing = 2f;
    public float TimeToStartGrowing => timeToStartGrowing;

    [SerializeField] private float timeToHarvest = 5f;
    public float TimeToHarvest => timeToHarvest;
}