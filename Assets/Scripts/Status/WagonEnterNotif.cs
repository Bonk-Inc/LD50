using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonEnterNotif : MonoBehaviour
{
    
    [SerializeField]
    private Wagon wagon;

    private PartBreakingManager breaker;

    private void Awake() {
        breaker = GameObject.FindObjectOfType<PartBreakingManager>();
    }

    public void Notif(){
        breaker?.PlayerEnterWagon(wagon);
    }

}
