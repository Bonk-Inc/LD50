using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFitTest : MonoBehaviour
{

    public Camera cam;


    public SpriteRenderer rend;
    public OrthographicCameraFitter fitter;

    private void Awake() {
        fitter = new OrthographicCameraFitter(cam);
    }

    void Update()
    {
        fitter.SetObject(rend.bounds);
        cam.transform.position = fitter.CalculateCameraPosition().ToVector3(cam.transform.position.z);
        cam.orthographicSize = fitter.CalculateCameraSize();
    }
}
