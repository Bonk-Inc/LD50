using System;
using UnityEngine;

public class ValveController : MonoBehaviour
{
    [SerializeField] 
    private ValveStatus currentStatus, correctStatus;

    [SerializeField] 
    private SpriteRenderer valveSprite;

    [SerializeField] 
    private Color colorClosed, colorOpen;

    [SerializeField]
    private float animationDuration = 1f;

    public event Action onValveChange;

    private float currentTime = 0f;
    
    private bool turning = false;

    public ValveStatus getValveStatus => currentStatus;
    
    public ValveStatus getCorrectStatus => correctStatus;
    
    private void Start()
    {
        SetValveColor();
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        SetValveColor();
    }

    private void OnMouseDown()
    {
        currentStatus = (currentStatus == ValveStatus.OPEN) ? ValveStatus.CLOSED : ValveStatus.OPEN;
        turning = true;
        
        SetValveColor();
        onValveChange?.Invoke();
    }

    private void SetValveColor()
    {
        var currentColor = (currentStatus == ValveStatus.CLOSED) ? colorClosed : colorOpen;

        valveSprite.color = currentColor;
    }
}

public enum ValveStatus
{
    OPEN,
    CLOSED
}