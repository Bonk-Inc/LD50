using System.Collections;
using System;
using UnityEngine;

public class CoalCatcher : MonoBehaviour
{
    [SerializeField]
    private string targetTag;

    public event Action OnCoalCatched;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == targetTag) {
            GameObject.Destroy(collider.gameObject);
            OnCoalCatched?.Invoke();
        } 
    }
}
