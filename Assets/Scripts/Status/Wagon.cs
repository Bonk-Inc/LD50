using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wagon : MonoBehaviour
{
    [SerializeField]
    private float maxHealth, currentHealth, wagonHealthDecrease = 20f, wagonHealthIncrease = 5f, decreaseDelay = 1f;
    
    [SerializeField]
    private List<PartStatus> parts;

    public bool isBroken => currentHealth <= 0;

    public float MaxHealth => maxHealth;

    public event Action OnWagonBroken;

    public event Action<float> OnHealthChanged;

    public List<PartStatus> Parts => parts;

    private void Awake()
    {
        currentHealth = maxHealth;
    }

    private void Start()
    {
        StartCoroutine(DecreasePartsStatus());
    }

    private IEnumerator DecreasePartsStatus()
    {
        while (true)
        {
            var allFixed = true;
            foreach (var status in parts)
            {
                if (!status.isBroken)
                {
                    // status.TryBreakPart(); // TODO Change this to a different system later on.
                    continue; 
                }
                allFixed = false;
                Damage(status.getHealthFactor);
                
                if (isBroken) OnWagonBroken?.Invoke();
            }

            if(allFixed) Heal(1);

            yield return new WaitForSeconds(decreaseDelay);   
        }
    }

    private void Damage(float decreaseFactor)
    {
        var newHealth = currentHealth - (wagonHealthDecrease * decreaseFactor);
        
        currentHealth = Math.Max(newHealth, 0);
        OnHealthChanged?.Invoke(currentHealth);
    }

    private void Heal(float increaseFactor)
    {
        var newHealth = currentHealth + (wagonHealthIncrease * increaseFactor);
        
        currentHealth = Math.Min(newHealth, maxHealth);
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void Heal() 
    {
        Heal(wagonHealthIncrease);
    }
}