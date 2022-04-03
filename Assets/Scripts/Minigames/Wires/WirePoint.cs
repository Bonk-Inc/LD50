using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WirePoint : MonoBehaviour
{

    [SerializeField]
    private WireDrawer drawer;

    [SerializeField]
    private LineRenderer line;

    [SerializeField]
    private PointColor color;

    public bool hasLine;

    private bool mouseOverSad = false;

    private void OnMouseExit() {
        mouseOverSad = false;
    }

    private void OnMouseEnter() {
        mouseOverSad = true;
    }

    private void Update() {
        if(mouseOverSad && Input.GetMouseButtonUp(0)){
            MouseUp();
        }
    }

    private void OnMouseDown() {
        if(hasLine)
            return;
        drawer.SetNewPoint(this, line);
    }

    private void MouseUp() {
        Debug.Log(drawer.currentDragPoint);

        if(drawer.currentDragPoint == this || drawer.currentDragPoint == null){
            Debug.Log("this aint good");
            return;
        }

        if(drawer.currentDragPoint.color == color){
            Debug.Log("this do be good");
            line.SetPositions(new Vector3[] {
                drawer.currentDragPoint.transform.position,
                transform.position
            });
            hasLine = true;
        } else {
            Debug.Log("this do be weird");
            drawer.currentDragPoint.line.enabled = false;
        }

        drawer.SetNewPoint(null, null);
        

    }

}

enum PointColor{
    RED,
    BLUE,
    YELLOW,
    GREEN
}
