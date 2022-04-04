using System.Collections.Generic;
using UnityEngine;

public class PipeMinigame : MonoBehaviour
{
    [SerializeField]
    private List<ValveController> valves;

    [SerializeField]
    private MinigameStatus minigameStatus;

    [SerializeField]
    private PlaySound sound;

    private void Awake()
    {
        foreach (var valve in valves)
            valve.onValveChange += HandleValveStatusChange;
    }

    private void HandleValveStatusChange()
    {
        sound.PlayClip();
        if (!valvesInCorrectPosition)
            return;

        minigameStatus.CompleteMinigame();
    }

    private bool valvesInCorrectPosition => 
        valves.TrueForAll(valve => valve.getValveStatus == valve.getCorrectStatus);
}