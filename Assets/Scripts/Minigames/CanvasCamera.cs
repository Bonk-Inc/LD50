using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCamera : MonoBehaviour
{
    [SerializeField]
    private Canvas minigameCanvas;

    private void Awake() {
        minigameCanvas.worldCamera = Camera.main;
    }
}
