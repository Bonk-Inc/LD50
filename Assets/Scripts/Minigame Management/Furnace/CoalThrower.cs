using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoalThrower : MonoBehaviour
{
    [SerializeField]
    private MinigameInput miniInput;

    [SerializeField]
    private Rigidbody2D shootable;

    [SerializeField]
    private Transform shootingPoint;

    private void Awake() {
        miniInput.OnTrigger += ThrowCoal;
    }

    private void ThrowCoal() {
        Instantiate(shootable, shootingPoint);
        print("I just threw a piece of coal!");
    }
}
