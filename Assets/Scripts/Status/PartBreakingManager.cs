using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PartBreakingManager : MonoBehaviour
{
    [SerializeField]
    private List<PartStatus> parts;
     private List<PartStatus> brokenParts = new List<PartStatus>();

    private List<WagonStatus> wagons;

    [SerializeField, Header("Delay")]
    private float speed=4;

    [SerializeField]
    private float baseTime = 100f, startSkip = 50f;

    [SerializeField, Header("Spawn Chance")]
    public float spawnMaxChance = 100f;

    [SerializeField]
    public float spawnThreshold = 50f;

    [SerializeField]
    private float addedChanceMultiplier = 0.5f;

    private float currentTime = 0f;

    public List<PartStatus> BrokenParts => brokenParts;

    [SerializeField]
    private BrokenPartLocator locator;

    public void PlayerEnterWagon(WagonStatus wagon){
        locator.SetPlayerWagonPosition(wagons.FindIndex((w) => w == wagon));
    }

    private void Reset() {
        GetParts();
    }

    private void Awake() {
        GetParts();
        StartCoroutine(SpawnRoutine());
    }

    private void Update() {
        currentTime += Time.deltaTime;
    }

    private IEnumerator SpawnRoutine(){
        while (true)
        {
            TryBreak();

            var nextTime = (baseTime/(currentTime+startSkip))*speed;
            yield return new WaitForSeconds(nextTime);
        }
    }

    private void TryBreak(){
        var addedChance = Mathf.Sqrt(currentTime)*addedChanceMultiplier;
        var random = Random.Range(0, spawnMaxChance);
        var finalChance = random + addedChance;
        if(finalChance > spawnThreshold || brokenParts.Count == 0){
            var randomPart = parts.GetRandom();
            randomPart?.BreakPart();
        }
    }



    private void GetParts(){
        wagons = new List<WagonStatus>(FindObjectsOfType<WagonStatus>());
        parts = new List<PartStatus>();
        wagons.Sort((a, b) => (int)(b.transform.position.x - a.transform.position.x));
        
        for (int i = 0; i < wagons.Count; i++)
        {
            var wagon = wagons[i];
            parts.AddRange(wagon.Parts);
            foreach (var part in wagon.Parts)
            {
                part.wagon = i;
            }
        }

        foreach (var part in parts)
        {
            part.OnRepaired += () => {
                brokenParts.Remove(part);
                parts.Add(part);
            };

            part.OnBreak += () => {
                brokenParts.Add(part);
                parts.Remove(part);
            };
        }
    }



}
