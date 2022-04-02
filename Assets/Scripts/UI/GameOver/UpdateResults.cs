using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateResults : MonoBehaviour
{
    [SerializeField]
    private Timer timer;
    [SerializeField]
    private TMP_Text resultText;
    private void Awake() {
        timer.OnTimeUpdate += UpdateText; // TODO Should be OnGameFinish instead of OnTimeUpdate
    }

    private void UpdateText(float time) {
        resultText.text = "You survived for " + time + " seconds";
    }
}
