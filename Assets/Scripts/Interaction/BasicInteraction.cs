using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicInteraction : Interactible
{

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    public override void EnterInteract()
    {
        spriteRenderer.color = Color.green;
    }

    public override void LeaveInteract()
    {
        spriteRenderer.color = Color.white;
    }

}
