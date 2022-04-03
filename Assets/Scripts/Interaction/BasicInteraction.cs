using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicInteraction : Interactible
{

    [SerializeField]
    private SpriteRenderer[] spriteRenderers;

    [SerializeField]
    private Color highlightColor = Color.green;

    [SerializeField]
    protected PartStatus status;
    public override void EnterInteract()
    {
        if(!status.isBroken){
            return;
        }
        
        SetRendererColor(highlightColor);
    }

    public override void LeaveInteract()
    {
        SetRendererColor(Color.white);
    }

    private void SetRendererColor(Color color){
        foreach (var renderer in spriteRenderers)
        {
            renderer.color = color;
        }
    }

}
