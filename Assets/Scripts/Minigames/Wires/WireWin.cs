using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireWin : MonoBehaviour
{
    [SerializeField]
    private PlaySound sound;

    [SerializeField]
    private WirePoint[] points;

    [SerializeField]
    private MinigameStatus status;

    public void CheckWin() {
        sound.PlayClip();
        for (int i = 0; i < points.Length; i++)
        {
            if(!points[i].hasLine)
                return;
        }

        status.CompleteMinigame();
    }

}
