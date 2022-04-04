using UnityEngine;
using TMPro;

public class UpdateResults : MonoBehaviour
{
    [SerializeField] 
    private DayTracker dayTracker;
    
    [SerializeField] 
    private TMP_Text resultText;

    private void Awake()
    {
        dayTracker.OnGameFinish += SetText;
    }

    private void SetText(int time, Day finalDay)
    {
        resultText.text = "Your train ran for " + time + " days! Your final day was " + finalDay.ToString() + " - " + time + ".";
    }
}