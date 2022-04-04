using System.Collections;
using System;
using UnityEngine;

public class MinigameInput : MonoBehaviour
{
    [SerializeField]
    private InputChecker inputCheck;

    [SerializeField]
    private float delayAfter = 3;

    private bool canTrigger = true;

    public event Action OnTrigger;

    private void Update() {
        if(canTrigger && (inputCheck.BasicKeyInteraction() || inputCheck.BasicMouseInteraction())) {
            StartCoroutine("Shoot");
        }
    }
    
    private IEnumerator Shoot() {
        canTrigger = false;
        OnTrigger?.Invoke();

        yield return new WaitForSeconds(delayAfter);
        canTrigger = true;
    }
}
