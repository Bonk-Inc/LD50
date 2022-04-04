using UnityEngine;
using TMPro;

public class UpdateResults : MonoBehaviour
{
    [SerializeField] 
    private DayTracker dayTracker;

    [SerializeField]
    private PlaySound playSound;
    
    [SerializeField] 
    private TMP_Text resultText;

    private void Awake()
    {
        dayTracker.OnGameFinish += SetText;
    }

    private void SetText(int time = 0, Day finalDay = Day.Sunday)
    {
        if(resultText == null) return;

        var text = "Your train ran for " + time + " days! Your final day was " + finalDay.ToString() + " - " + time + ".";
        resultText.text = text;
        playSound?.PlayClip();
    }
}