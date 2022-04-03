using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NailHammer : MonoBehaviour
{

    [SerializeField]
    private SpriteMask mask;

    [SerializeField]
    private MinigameStatus minigameStatus;

    [SerializeField]
    private int hits = 2;

    private int currentHit = 0;

    private float boundsY;
    private float startY;

    void Start()
    {
        boundsY = mask.bounds.center.y + mask.bounds.extents.y;
        startY = transform.position.y;
    }

    private void OnMouseDown() {

        currentHit++;
        var position = transform.position;
        position.y = Mathf.Lerp(startY, boundsY, (float)currentHit/hits);
        transform.position = position;

        if(currentHit >= hits){
            minigameStatus.CompleteMinigame();
        }
    }

}
