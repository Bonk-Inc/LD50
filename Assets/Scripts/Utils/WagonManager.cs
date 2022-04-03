using System.Collections.Generic;
using UnityEngine;

public class WagonManager : MonoBehaviour
{
    [SerializeField]
    private List<WagonStatus> wagons;

    [SerializeField] 
    private Timer timer;
    
    private void Awake()
    {
        foreach (var wagon in wagons)
            wagon.OnWagonBroken += timer.StopTimer;
    }

    public void AddWagon(WagonStatus wagon)
    {
        wagon.OnWagonBroken += timer.StopTimer;
        
        wagons.Add(wagon);
    }
}