using System.Collections.Generic;
using UnityEngine;

public class PipeMinigame : MonoBehaviour
{
    [SerializeField]
    private List<ValveController> valves;
    
    private void Awake()
    {
        foreach (var valve in valves)
            valve.onValveChange += HandleValveStatusChange;
    }

    private void HandleValveStatusChange()
    {
        if (!valvesInCorrectPosition)
            return;
        
        Debug.Log("Completed");
    }

    private bool valvesInCorrectPosition => 
        valves.TrueForAll(valve => valve.getValveStatus == valve.getCorrectStatus);
}