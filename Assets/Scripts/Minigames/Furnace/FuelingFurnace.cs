using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelingFurnace : MonoBehaviour
{
    [SerializeField]
    private MinigameStatus status;

    [SerializeField]
    private CoalCatcher cather;
    private void Awake() {
        cather.OnCoalCatched += FuelFurnace;
    }

    private void FuelFurnace() {
        //TODO Should fill furnace amount when minigame type is set to active. Currently completes the minigame\
        status.CompleteMinigame();
    }
}
