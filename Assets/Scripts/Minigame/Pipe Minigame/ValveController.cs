using System;
using UnityEngine;

public class ValveController : MonoBehaviour
{
    [SerializeField] 
    private ValveStatus currentStatus, correctStatus;

    [SerializeField] 
    private SpriteRenderer valveSprite;

    [SerializeField] 
    private Color colorClosed;
    
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
        valveSprite.color = (currentStatus == ValveStatus.CLOSED) ? colorClosed : Color.white;
    }
}

public enum ValveStatus
{
    OPEN,
    CLOSED,
}