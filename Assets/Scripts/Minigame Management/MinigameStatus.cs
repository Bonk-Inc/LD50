using System;
using UnityEngine;

public class MinigameStatus : MonoBehaviour
{
    private bool completed = false;
    public bool Completed => completed;

    public event Action OnCompleteMinigame;

    public void CompleteMinigame() {
        completed = true;
        OnCompleteMinigame?.Invoke();
    }
}
