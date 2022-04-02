using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;

    public bool isDead => health <= 0f;
    
    public void DecreaseBy(float amount)
    {
        var newHealth = health - amount;
        if (newHealth <= 0f)
        {
            health = 0f;
            return;
        }

        health = newHealth;
    }
}