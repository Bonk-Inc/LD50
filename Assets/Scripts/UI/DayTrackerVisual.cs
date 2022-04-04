using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DayTrackerVisual : MonoBehaviour
{
    [SerializeField]
    private DayTracker dayTracker;

    [SerializeField]
    private Image timeBar;

    [SerializeField]
    private TMP_Text text;
    
    private void Awake() {
        dayTracker.OnTimeUpdated += OnTimeUpdated;
        dayTracker.OnDayUpdated += OnDayUpdated;

        OnTimeUpdated(0);
        OnDayUpdated(0, dayTracker.StartDay);
    }

    private void OnTimeUpdated(float timeOfDay) {
        var dayProgress = ((dayTracker.SecondsInDay / 100) * timeOfDay);
        timeBar.fillAmount = dayProgress;
    }

    private void OnDayUpdated(int daysSurvived, Day currentDay) {
        text.text = currentDay.ToString() + " - " + daysSurvived;
    }
}
