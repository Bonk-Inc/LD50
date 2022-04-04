using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusInitter : MonoBehaviour
{
    [SerializeField]
    private CameraFocus focus;
    
    [SerializeField]
    private Collider startFocus;

    private void Start()
    {
        focus.Focus(startFocus.bounds);
    }
}
