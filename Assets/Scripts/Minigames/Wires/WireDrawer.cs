using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireDrawer : MonoBehaviour
{    
    [SerializeField]
    private LineRenderer lr;

    [SerializeField]
    private Camera cam;

    public WirePoint currentDragPoint;

    private void LateUpdate() {
        if(currentDragPoint == null || lr == null){
            return;
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentDragPoint = null;
            lr.enabled = false;
            return;
        }

        lr.enabled = true;
        lr.SetPosition(0, currentDragPoint.transform.position);
        lr.SetPosition(1, cam.ScreenToWorldPoint(Input.mousePosition));
    }

    public void SetNewPoint(WirePoint point, LineRenderer renderer){

        if(renderer != null)
            renderer.enabled = true;
        lr = renderer;
        currentDragPoint = point;
    }

}
