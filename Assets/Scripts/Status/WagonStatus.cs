using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WagonStatus : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> parts;

    [SerializeField]
    private float partHealthDecrease = 10f, wagonHealthDecrease = 20f;
    
    [SerializeField] 
    private event Action onWagonBroken;

    public Health health { get; private set; }

    private Coroutine statusDecreaseRoutine;

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Start()
    {
        statusDecreaseRoutine = StartCoroutine(nameof(DecreasePartsStatus));
    }

    private void OnDestroy()
    {
        StopCoroutine(statusDecreaseRoutine);
    }

    private IEnumerator DecreasePartsStatus()
    {
        foreach (var status in parts.Select(part => part.GetComponent<PartStatus>()))
        {
            status.DecreasePartHealthBy(partHealthDecrease);

            if (status.health.isDead)
                health.DecreaseBy(wagonHealthDecrease);
        }

        if (health.isDead)
            onWagonBroken?.Invoke();

        yield return new WaitForSeconds(2f);
    }
}