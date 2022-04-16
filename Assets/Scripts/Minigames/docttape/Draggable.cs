using System;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    [SerializeField]
    private Camera cam;

    private bool mouseOver = false;
    private bool draggin = false;
    
    public event Action OnStartDrag, OnEndDrag;

    private void OnMouseEnter() {
        mouseOver = true;
    }

    private void OnMouseExit() {
        mouseOver = false;
    }

    private void Update() {

        if(mouseOver && !draggin && Input.GetMouseButtonDown(0)){
            draggin = true;
            OnStartDrag?.Invoke();
        }

        if(draggin) UpdatePosition();

        if(draggin && Input.GetMouseButtonUp(0)){
            draggin = false;
            OnEndDrag?.Invoke();
        }
    }

    private void UpdatePosition() {
        var position = transform.position;
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            position.x = mousePos.x;
            position.y = mousePos.y;
            transform.position = position;
    }
}
