using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedRemove : MonoBehaviour
{
    [SerializeField]
    private float delay;
    private void Awake() {
        Invoke("Delete", delay);
    }

    private void Delete() {
        GameObject.Destroy(gameObject);
    }
}
