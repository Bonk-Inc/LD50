using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFocus : MonoBehaviour
{
    [SerializeField]
    private CameraFocus focus;
    
    [SerializeField]
    private Collider2D startFocus, focusNoQuit;

    public void Focus()
    {
#if UNITY_EDITOR || UNITY_WEBGL
        startFocus = focusNoQuit;
#endif
        focus.Focus(startFocus);
    }
}
