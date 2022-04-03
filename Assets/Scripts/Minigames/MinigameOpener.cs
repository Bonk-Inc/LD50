using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameOpener : MonoBehaviour
{

    private const string PLAYER_GAMEOBJECT_NAME = "Mink-chan"; 
    
    [SerializeField]
    private PartStatus gamePart;

    [SerializeField]
    private MinigameStatus minigamePrefab;

    [SerializeField]
    private MinigameInteraction interaction;

    private MinigameStatus currentMinigame;

    private PlayerMovement playerMovement;

    private void Awake() {
        playerMovement = GameObject.Find(PLAYER_GAMEOBJECT_NAME).GetComponent<PlayerMovement>();
        if(playerMovement == null) {
            throw new System.Exception("Can't find player movement.");
        }
    }

    public void Open(){

        if(currentMinigame)
            return;
        
        playerMovement.enabled=false;
        currentMinigame = Instantiate(minigamePrefab);
        currentMinigame.OnCompleteMinigame += OnMinigameFinished;
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape) && currentMinigame != null){
            CloseMinigame();
        }    
    }

    
    private void OnMinigameFinished(){
        
        CloseMinigame();
        gamePart.FixPart();
        interaction.LeaveInteract();
    }

    private void CloseMinigame(){
        playerMovement.enabled=true;
        currentMinigame.OnCompleteMinigame -= OnMinigameFinished;
        Destroy(currentMinigame.gameObject);
    }



}
