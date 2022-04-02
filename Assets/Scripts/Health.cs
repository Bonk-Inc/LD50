using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;

    public bool isDead => health <= 0f;
    
    public void DecreaseBy(float amount)
    {
        health -= amount;
    }
}