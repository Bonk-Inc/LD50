using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusNotifier : MonoBehaviour
{
    private const string CAMERA_FOCUS_TAG = "CameraFocus";
    
    [SerializeField]
    private CameraFocus cam;

    private void Awake() {
        if (cam == null){
            TryGetFocusFromMainCamera();
        }
    }

    private void Reset() {
        TryGetFocusFromMainCamera();
    }

    public void TryGetFocusFromMainCamera(){
        cam = Camera.main.GetComponent<CameraFocus>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(!other.CompareTag(CAMERA_FOCUS_TAG)){
            return;
        }

        var wagonEnter = other.GetComponent<WagonEnterNotif>();
        wagonEnter?.Notif();

        cam.Focus(other);
    }
}
