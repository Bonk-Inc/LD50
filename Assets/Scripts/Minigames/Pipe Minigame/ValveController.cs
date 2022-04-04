using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class ValveController : MonoBehaviour
{
    [SerializeField] 
    private ValveStatus currentStatus, correctStatus;

    [SerializeField] 
    private SpriteRenderer valveSprite;

    [SerializeField] 
    private Color colorClosed, colorOpen;

    [SerializeField]
    private float animationDuration = 1f, rotationSpeed = 2f;

    public event Action onValveChange;

    private float currentTime;
    
    private bool turning;

    public ValveStatus getValveStatus => currentStatus;
    
    public ValveStatus getCorrectStatus => correctStatus;
    
    private void Awake()
    {
        RandomlySetValveStatus();
        
        valveSprite.color = (currentStatus == ValveStatus.CLOSED) ? colorClosed : colorOpen;
    }

    private void Update()
    {
        if (!turning)
            return;
        
        currentTime += Time.deltaTime;
        var t = currentTime * 0.5f;

        SetValveColor(t);
        RotateValve();

        if (t >= animationDuration)
            turning = false;
    }

    private void OnMouseDown()
    {
        currentStatus = (currentStatus == ValveStatus.OPEN) ? ValveStatus.CLOSED : ValveStatus.OPEN;
        currentTime = 0f;
        turning = true;
        
        onValveChange?.Invoke();
    }

    private void SetValveColor(float time)
    {
        var colorBegin = (currentStatus == ValveStatus.CLOSED) ? colorOpen : colorClosed;
        var colorTarget = (currentStatus == ValveStatus.CLOSED) ? colorClosed : colorOpen;

        valveSprite.color = Color.Lerp(colorBegin, colorTarget, time);
    }

    private void RotateValve()
    {
        var speed = (currentStatus == ValveStatus.CLOSED) ? rotationSpeed : -rotationSpeed;
        
        transform.Rotate(0, 0, speed);
    }

    private void RandomlySetValveStatus()
    {
        var random = Random.Range(0, 3);

        currentStatus = (random == 1) ? ValveStatus.CLOSED : ValveStatus.OPEN;
    }
}

public enum ValveStatus
{
    OPEN,
    CLOSED
}