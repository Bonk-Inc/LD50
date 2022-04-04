using System;
using System.Collections.Generic;
using UnityEngine;

public enum Day { 
    Sunday = 0, 
    Monday = 1, 
    Tuesday = 2, 
    Wednesday = 3, 
    Thursday = 4, 
    Friday = 5,
    Saturday = 6 
}

public class DayTracker : MonoBehaviour {
    [SerializeField]
    private Timer timer;

    [SerializeField]
    private Day startDay;

    [SerializeField]
    private float secondsInDay = 8.5f;

    private int maxDays = 7;
    private int daysSurvived = 0;
    private Day currentDay;

    public float SecondsInDay => secondsInDay;
    public Day StartDay => startDay;

    public event Action<int, Day> OnGameFinish;

    public event Action<float> OnTimeUpdated;
    public event Action<int, Day> OnDayUpdated;

    private void Awake() {
        currentDay = startDay;
        timer.OnGameFinish += OnGameFinished;
        timer.OnTimeChanged += OnTimeChanged;
    }

    private void OnTimeChanged(float timeSurvived) {
        var restDay = RestOfDay(timeSurvived);
        OnTimeUpdated?.Invoke(restDay);
        
        var dayInfo = CalculateDay(timeSurvived);
        
        if(!currentDay.Equals(dayInfo.Item2)) {
            daysSurvived = dayInfo.Item1;
            currentDay = dayInfo.Item2;

            OnDayUpdated?.Invoke(daysSurvived, currentDay);
        }
    }

    private void OnGameFinished(float timeSurvived) {
        OnGameFinish?.Invoke(daysSurvived, currentDay);
    }

    private Tuple<int, Day> CalculateDay(float timeSurvived) {
        var daysSurvived = (int) Math.Floor(timeSurvived / secondsInDay);
        var day = (daysSurvived + (int) startDay) % maxDays;

        return new Tuple<int, Day> (daysSurvived, (Day) day);
    }

    private float RestOfDay(float timeSurvived) {
        return timeSurvived % secondsInDay;
    }
}