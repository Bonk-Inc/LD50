using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    [SerializeField]
    private ValveController valve;

    [SerializeField] 
    private GameObject smoke;
    
    private void Awake()
    {
        valve.onValveChange += SetSmokeActive;
    }

    private void Start()
    {
        SetSmokeActive();
    }

    private void SetSmokeActive()
    {
        var open = valve.getValveStatus == ValveStatus.OPEN;
        
        smoke.SetActive(open);
    }
}