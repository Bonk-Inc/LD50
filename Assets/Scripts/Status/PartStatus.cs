using UnityEngine;

public class PartStatus : MonoBehaviour
{
    [SerializeField]
    private float healthDecreaseFactor = 1f;
    
    public Health health { get; private set; }

    private void Awake()
    {
        health = GetComponent<Health>();
    }

    private void Update()
    {
        
    }

    public void DecreasePartHealthBy(float amount)
    {
        health.DecreaseBy(amount * healthDecreaseFactor);
    }
}