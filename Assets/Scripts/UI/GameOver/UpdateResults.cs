using UnityEngine;
using TMPro;

public class UpdateResults : MonoBehaviour
{
    [SerializeField] 
    private Timer timer;
    
    [SerializeField] 
    private TMP_Text resultText;

    private void Awake()
    {
        timer.OnGameFinish += SetText;
    }

    private void SetText(float time)
    {
        resultText.text = "You survived for " + time + " seconds";
    }
}