using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameCameraFitter : MonoBehaviour
{
    [SerializeField]
    private Collider2D boundsCollie;

    private Camera cam;
    private OrthographicCameraFitter fitter;

    private void Awake()
    {
        cam = GetComponent<Camera>();
        fitter = new OrthographicCameraFitter(cam);
        Focus(boundsCollie.bounds);
    }

    private void Focus(Bounds bounds)
    {
        fitter.SetObject(bounds);
        cam.orthographicSize = fitter.CalculateCameraSize();
        transform.position = fitter.CalculateCameraPosition().ToVector3(transform.position.z);
    }
}
