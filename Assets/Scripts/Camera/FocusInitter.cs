using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusInitter : MonoBehaviour
{
    [SerializeField]
    private CameraFocus focus;
    
    [SerializeField]
    private Collider2D startFocus, focusNoQuit;

    private void Start()
    {
#if UNITY_EDITOR || UNITY_WEBGL
        startFocus = focusNoQuit;
#endif
        focus.FocusInstant(startFocus);
    }
}
