using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartStatusObjectVisual : PartStatusVisual
{
    [SerializeField]
    protected GameObject brokenObject, fixedObject;

    protected override void OnPartChanged(bool isBroken) {
        brokenObject.SetActive(isBroken);
        fixedObject.SetActive(!isBroken);
    }
}
