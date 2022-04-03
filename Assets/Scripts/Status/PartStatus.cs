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

    public event Action<bool> OnPartChanged;

    public void TryBreakPart()
    {
        var random = (int) Random.Range(0, breakFactor);
        if (random == 1) ChangePart(true);
    }

    public void FixPart()
    {
        ChangePart(false);
    }

    private void ChangePart(bool broke) {
        broken = broke;
        OnPartChanged?.Invoke(broke);
    }
}