using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PartStatusVisual : MonoBehaviour
{
    [SerializeField]
    private PartStatus status;

    private void Awake() {
        status.OnPartChanged += OnPartChanged;
        OnPartChanged(status.isBroken);
    }

    protected abstract void OnPartChanged(bool isBroken);
}
