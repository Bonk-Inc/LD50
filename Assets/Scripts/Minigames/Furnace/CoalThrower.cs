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
    private PlaySound sound;

    [SerializeField]
    private Transform shootingPoint, coalParent;

    [SerializeField]
    private float forceAmount;

    private void Awake() {
        miniInput.OnTrigger += ThrowCoal;
    }

    private void ThrowCoal() {
        sound.PlayClip();
        var coal = Instantiate(shootable, coalParent);
        coal.position = shootingPoint.position;
        var forceBig = shootingPoint.forward * forceAmount;
        coal.AddForce(shootingPoint.right * forceAmount, ForceMode2D.Impulse);
    }
}
