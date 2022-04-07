using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class PartStatus : MonoBehaviour
{
    [SerializeField]
    private float healthFactor = 1f;

    [SerializeField] 
    private bool broken = false;
    
    public bool isBroken => broken;

    public float getHealthFactor => healthFactor;

    public event Action<bool> OnPartChanged;
    public event Action OnBreak, OnRepaired;

    public int wagon = -1;

    [ContextMenu("Break")]
    public void BreakPart(){
        ChangePart(true);
        OnBreak?.Invoke();
    }

    [ContextMenu("Fix")]
    public void FixPart()
    {
        ChangePart(false);
        OnRepaired?.Invoke();
    }

    private void ChangePart(bool broke) {
        broken = broke;
        OnPartChanged?.Invoke(broke);
    }
}