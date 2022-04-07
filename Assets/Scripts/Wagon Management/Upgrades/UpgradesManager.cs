using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    [SerializeField]
    private WagonManager wagonManager;

    [SerializeField]
    private Canvas upgradeCanvas;

    [SerializeField]
    private PlaySound playSound;

    [SerializeField]
    private DayTracker tracker;

    [SerializeField]
    private Day upgradeDay = Day.Monday;

    [SerializeField]
    private Button addPartButton;

    [SerializeField, Header("Upgrade Info")]
    private List<WagonPartManager> wagons;

    private void Awake()
    {
        tracker.OnDayUpdated += ActivateCanvas;
    }
    
    private void Start() {
        AddCart();
    }

    private bool CheckDay(Day day) => day == upgradeDay; 

    private void ActivateCanvas(int daysSurvived, Day day) {
        if(CheckDay(day)) {
            upgradeCanvas.enabled = true;
            Time.timeScale = 0;
            addPartButton.gameObject.SetActive(wagonManager.PartsAvailable()); 
            playSound.PlayClip();
        }
    }

    public void AddCart() {
        var wagon = Instantiate(wagons.GetRandom());
        wagon.transform.position = wagonManager.LastWagon.Next.position;
        wagonManager.AddWagon(wagon);
        CloseCanvas();
    }

    public void AddPart() {
        var availableWagons = wagonManager.GetAvailablePartsWagons();
        var wagon = availableWagons.GetRandom();
        wagon.AddRandomPart();
        CloseCanvas();
    }

    private void CloseCanvas(){
        upgradeCanvas.enabled = false;
        Time.timeScale = 1;
    }
}
