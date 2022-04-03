using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartStatusSpriteVisual : PartStatusVisual
{
    [SerializeField]
    private SpriteRenderer partRenderer;

    [SerializeField]
    private Sprite brokenSprite, fixedSprite;

    protected override void OnPartChanged(bool isBroken) {
        partRenderer.sprite = isBroken ? brokenSprite : fixedSprite;
    }
}
