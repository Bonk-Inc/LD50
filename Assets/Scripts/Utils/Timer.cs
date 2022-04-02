using System.Collections;
using System;
using UnityEngine;

public class Timer : MonoBehaviour {
    
    [SerializeField]
    private float timeOfSecond = 1;
    private Coroutine timer;
    private float timeSurvived = 0;
    public float TimeSurvived => timeSurvived;

    public event Action<float> OnTimeUpdate;
    
    private void Start() {
        StartTimer();
    }

    private IEnumerator TimerRoutine() {
        while (true) {
            yield return new WaitForSeconds(timeOfSecond);
            timeSurvived += timeOfSecond;
            OnTimeUpdate?.Invoke(timeSurvived);
        }
    }

    public void ResetTimeSurvived() {
        timeSurvived = 0;
    }

    public void StartTimer() {
        timer = StartCoroutine("TimerRoutine");
    }

    public void StopTimer() {
        StopCoroutine(timer);
    }
}