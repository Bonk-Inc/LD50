using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrthographicCameraFitter
{
    
    private Bounds bounds;

    private Camera camera;

    public OrthographicCameraFitter(Camera camera){
        this.camera = camera;
    }

    public void SetObject(Bounds fitObject){
        bounds = fitObject;
    }

    public float CalculateCameraSize(){
        
        float size;
        if (bounds.size.x / bounds.size.y < camera.aspect)
        {
            size = bounds.size.y;
        }
        else
        {
            float levelAspect = (bounds.size.x / bounds.size.y);
            size = bounds.size.y / camera.aspect * levelAspect;
        }
        return size / 2;
    }

    public Vector2 CalculateCameraPosition(){
        return bounds.center;
    }

}
