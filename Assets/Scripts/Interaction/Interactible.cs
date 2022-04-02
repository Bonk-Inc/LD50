using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactible : MonoBehaviour
{
    public abstract void EnterInteract();
    public abstract void LeaveInteract();
    public abstract void Interact(GameObject player);
}
