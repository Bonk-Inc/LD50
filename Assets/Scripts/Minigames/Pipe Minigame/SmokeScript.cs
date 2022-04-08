using UnityEngine;

public class SmokeScript : MonoBehaviour
{
    [SerializeField]
    private ValveController[] valves;

    [SerializeField] 
    private GameObject smoke;
    
    private void Awake()
    {
        foreach (var valve in valves){
            valve.onValveChange += SetSmokeActive;
        }
    }

    private void Start()
    {
        SetSmokeActive();
    }

    private void SetSmokeActive()
    {
        var open = true;
        foreach (var valve in valves){
            if(valve.getValveStatus == ValveStatus.CLOSED) {
                smoke.SetActive(false);
                return;
            }
        }
        
        smoke.SetActive(open);
    }
}