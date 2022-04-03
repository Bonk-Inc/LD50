using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PartStatus : MonoBehaviour
{
    [SerializeField]
    private float healthFactor = 1f, breakFactor = 50f;

    [SerializeField] 
    private bool broken = false;
    
    public bool isBroken => broken;

    public float getHealthFactor => healthFactor;

    public event Action OnBreak, OnRepaired;

    public void TryBreakPart()
    {
        var random = (int) Random.Range(0, breakFactor);
        if (random == 1)
            BreakPart();
    }

    public void BreakPart(){
        broken = true;
        OnBreak?.Invoke();
    }

    public void FixPart()
    {
        broken = false;
        OnRepaired?.Invoke();
    }
}