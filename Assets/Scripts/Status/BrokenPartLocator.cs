using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrokenPartLocator : MonoBehaviour
{
    
    [SerializeField]
    private Image left, right;

    [SerializeField]
    private PartBreakingManager breaker;

    private int playerWagonPosition = -1;

    private void Update() {
        UpdateArrows();
    }

    public void SetPlayerWagonPosition(int position){
        playerWagonPosition = position;
        UpdateArrows();
    }

    private void UpdateArrows(){
        bool leftOn = false;
        bool rightOn = false;

        foreach (var brokenPart in breaker.BrokenParts)
        {
            if(brokenPart.wagon > playerWagonPosition){
                leftOn = true;
            } else if (brokenPart.wagon < playerWagonPosition) {
                rightOn = true;
            }
        }

        left.enabled = leftOn;
        right.enabled = rightOn;

    }

}
