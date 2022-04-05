using System.Collections.Generic;
using UnityEngine;

public class WagonManager : MonoBehaviour
{
    [SerializeField]
    private List<WagonPartManager> wagons;

    [SerializeField] 
    private Timer timer;

    [SerializeField]
    private PartBreakingManager partBreakingManager;

    public List<WagonPartManager> Wagons => wagons;
    
    private void Awake()
    {
        foreach (var wagon in wagons){
            wagon.OnPartAdded += partBreakingManager.GetParts;
            wagon.Status.OnWagonBroken += timer.StopTimer;
            wagon.AddPart();
        }
    }

    public void AddWagon(WagonPartManager wagon)
    {
        wagon.Status.OnWagonBroken += timer.StopTimer;
        wagon.OnPartAdded += partBreakingManager.GetParts;
        wagon.AddPart();
        
        wagons.Add(wagon);
    }

    public bool PartsAvailable() {
        foreach (var wagon in wagons){
            if(wagon.PartsLeft > 0) return true;
        }
        return false;
    }

    public List<WagonPartManager> GetAvailablePartsWagons() {
        var availableWagons = new List<WagonPartManager>();
        foreach (var wagon in wagons){
            if(wagon.PartsLeft > 0) availableWagons.Add(wagon);
        }
        return availableWagons;
    }
}