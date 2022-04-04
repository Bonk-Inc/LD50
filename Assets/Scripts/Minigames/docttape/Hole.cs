using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    
    [SerializeField]
    private MinigameStatus status;

    [SerializeField]
    private Collider2D tape;

    [SerializeField]
    private Collider2D hole;

    private void LateUpdate()
    {

        if(Input.GetMouseButtonUp(0) && hole.OverlapPoint(tape.transform.position)){
            tape.transform.position = hole.transform.position;
            status.CompleteMinigame();
        }
    }
}
