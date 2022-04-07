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

    [SerializeField]
    private WagonPartManager lastWagon;


    public List<WagonPartManager> Wagons => wagons;
    
    public WagonPartManager LastWagon => lastWagon;

    private void Awake()
    {
        foreach (var wagon in wagons){
            SetupWagon(wagon);
        }

        lastWagon = wagons[wagons.Count-1];
    }

    public void AddWagon(WagonPartManager wagon)
    {
        lastWagon.SetLast(false);
        lastWagon = wagon;
        lastWagon.SetLast(true);
        SetupWagon(wagon);
        wagons.Add(wagon);
    }

    private void SetupWagon(WagonPartManager wagon) {
        wagon.Status.OnWagonBroken += timer.StopTimer;
        wagon.OnPartAdded += partBreakingManager.AddPart;
        wagon.AddRandomPart();
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