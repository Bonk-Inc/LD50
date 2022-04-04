using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteTutorial : MonoBehaviour
{
    [SerializeField]
    private PartStatus status;
    [SerializeField]
    private SceneSwitcher sceneSwitcher;

    [SerializeField]
    private string scene;

    private void Awake() {
        status.OnRepaired += OnRepaired;
    }

    private void OnRepaired() {
        sceneSwitcher.SwitchScene(scene);
    }
}
