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

    private bool isHighlighted = false;
    private bool isInteractable = false;
    public override void EnterInteract()
    {
        isInteractable = true;
        if(!status.isBroken){
            return;
        }
        
        isHighlighted = true;
        SetRendererColor(highlightColor);
    }

    private void Update() {
        if(isInteractable && status.isBroken && !isHighlighted){
            isHighlighted = true;
            SetRendererColor(highlightColor);
        }
    }

    public override void LeaveInteract()
    {
        isHighlighted = false;
        isInteractable = false;
        SetRendererColor(Color.white);
    }

    private void SetRendererColor(Color color){
        foreach (var renderer in spriteRenderers)
        {
            renderer.color = color;
        }
    }

}
