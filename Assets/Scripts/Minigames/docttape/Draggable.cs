using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    [SerializeField]
    private Camera cam;

    public bool mouseOver = false;
    public bool draggin = false;
    
    private void OnMouseEnter() {
        mouseOver = true;
    }

    private void OnMouseExit() {
        mouseOver = false;
    }

    private void Update() {

        if(mouseOver && !draggin && Input.GetMouseButtonDown(0)){
            draggin = true;
        }

        if(draggin){
            var position = transform.position;
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            position.x = mousePos.x;
            position.y = mousePos.y;
            transform.position = position;
        }

        if(draggin && Input.GetMouseButtonUp(0)){
            draggin = false;
        }
    }

}
