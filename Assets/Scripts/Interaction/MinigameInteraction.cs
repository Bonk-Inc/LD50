using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameInteraction : BasicInteraction
{

    [SerializeField]
    private MinigameOpener opener;

    public override void Interact(GameObject player)
    {
        if(status.isBroken){
            opener.Open();
        }
    }

}
