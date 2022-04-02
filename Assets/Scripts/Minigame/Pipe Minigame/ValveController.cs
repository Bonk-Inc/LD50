using System;
using UnityEngine;

public class ValveController : MonoBehaviour
{
    [SerializeField] 
    private ValveStatus currentStatus, correctStatus;

    [SerializeField] 
    private SpriteRenderer valveSprite;

    [SerializeField] 
    private Gradient gradientClosed, gradientOpen;

    [SerializeField]
    private float animationDuration = 1f;

    private float currentTime = 0f;
    
    private event Action onValveChange;
    
    private void Start()
    {
        SetValveColor();
    }

    private void OnMouseDown()
    {
        currentStatus = (currentStatus == ValveStatus.OPEN) ? ValveStatus.CLOSED : ValveStatus.OPEN;
        
        SetValveColor();
        onValveChange?.Invoke();
    }

    private void SetValveColor()
    {
        var gradient = (currentStatus == ValveStatus.CLOSED) ? gradientClosed : gradientOpen;

        valveSprite.color = gradient.Evaluate(currentTime / animationDuration);
    }
}

public enum ValveStatus
{
    OPEN,
    CLOSED
}