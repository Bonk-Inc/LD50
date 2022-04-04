using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputChecker : MonoBehaviour
{
    public bool BasicKeyInteraction() {
        return (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space));
    }

    public bool BasicMouseInteraction() {
        return (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1));
    }
}
