using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarString : MonoBehaviour
{
    
    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private SpriteRenderer StringRenderer;

    [SerializeField]
    private float highlightTimeInSeconds = 0.5f;

    [SerializeField]
    private float clickedTimeInSeconds = 0.2f;
    private bool isLocked = false;

    private Coroutine clickedRoutine;

    public event Action StringClicked;

    public Coroutine Highlight(){
        return StartCoroutine(HiglightRoutine());
    }

    private IEnumerator HiglightRoutine(){
        StringRenderer.color = Color.green;
        audioSource.Play();
        yield return new WaitForSeconds(highlightTimeInSeconds);
        StringRenderer.color = Color.white;
    }

    public Coroutine Wrong(float time){
        return StartCoroutine(WrongRoutine(time));
    }

    private IEnumerator WrongRoutine(float time){
        isLocked = true;
        StringRenderer.color = Color.red;
        yield return new WaitForSeconds(time);
        StringRenderer.color = Color.white;
        isLocked = false;
    }

    private IEnumerator ClickedRoutine(){
        StringRenderer.color = Color.blue;
        yield return new WaitForSeconds(clickedTimeInSeconds);
        StringRenderer.color = Color.white;
    }

    public void SetLocked(bool locked){
        isLocked = locked;
    }

    private void OnMouseUpAsButton() {
        if(isLocked)
            return;

        if (clickedRoutine != null)
        {
            StopCoroutine(clickedRoutine);
        }

        clickedRoutine = StartCoroutine(ClickedRoutine());
        audioSource.Play();
        StringClicked?.Invoke();
    }
    

}
