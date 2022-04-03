using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonStatusVisual : MonoBehaviour
{
    [SerializeField]
    private WagonStatus status;

    [SerializeField]
    private SpriteRenderer healthBar;

    private void Awake() {
        status.OnHealthChanged += UpdateStatusVisual;
    }

    private void UpdateStatusVisual(float currentHealth) {
        var health = ((status.MaxHealth / 100) * currentHealth) / 100;
        healthBar.size = new Vector2(health, 1);
    }
}
