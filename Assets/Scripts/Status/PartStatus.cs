using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PartStatus : MonoBehaviour
{
    [SerializeField]
    private float healthFactor = 1f, breakFactor = 50f;

    [SerializeField] 
    private bool broken = false;

    [SerializeField] 
    private MinigameStatus minigameStatus;
    
    public bool isBroken => broken;

    public float getHealthFactor => healthFactor;

    private void Awake()
    {
        minigameStatus.OnCompleteMinigame += FixPart;
    }

    private void OnDestroy()
    {
        minigameStatus.OnCompleteMinigame -= FixPart;
    }

    public void TryBreakPart()
    {
        var random = (int) Random.Range(0, breakFactor);
        if (random == 1)
            broken = true;
    }

    private void FixPart()
    {
        broken = false;
    }
}