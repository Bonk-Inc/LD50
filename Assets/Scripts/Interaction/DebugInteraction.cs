using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugInteraction : BasicInteraction
{
    public override void Interact(GameObject player)
    {   
        Debug.Log($"player {player.name} interacting with {gameObject.name}");
    }
}
