using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameOpener : MonoBehaviour
{
    
    [SerializeField]
    private PartStatus gamePart;

    [SerializeField]
    private MinigameStatus minigamePrefab;

    [SerializeField]
    private MinigameInteraction interaction;

    private MinigameStatus currentMinigame;

    public void Open(){

        if(currentMinigame)
            return;
        
        currentMinigame = Instantiate(minigamePrefab);
        currentMinigame.OnCompleteMinigame += OnMinigameFinished;
    }

    
    private void OnMinigameFinished(){
        CloseMinigame();
        gamePart.FixPart();
        interaction.LeaveInteract();
    }

    private void CloseMinigame(){
        currentMinigame.OnCompleteMinigame -= OnMinigameFinished;
        Destroy(currentMinigame.gameObject);
    }



}
