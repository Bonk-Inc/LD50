using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{

    [SerializeField]
    private InputChecker inputCheck;

    private const string INTERACTIBLE_TAG = "Interactible";
    private Interactible current;

    private void Update() {
        if(inputCheck.BasicKeyInteraction()){
            current?.Interact(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!other.CompareTag(INTERACTIBLE_TAG)){
            return;
        }
        current = other.GetComponent<Interactible>();
        current.EnterInteract();
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject != current?.gameObject){
            return;
        }
        LeaveCurrent();
    }

    private void LeaveCurrent(){
        if(current == null){
            return;
        }
        current.LeaveInteract();
        current = null;
    }
    
}
