using System;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] 
    private string ingredientName;

    [SerializeField]
    private PlaySound playSound;
    
    public event Action<Ingredient> OnIngredientClick;

    public string getIngredientName => ingredientName;
    
    private void OnMouseDown()
    {
        playSound.PlayClip();
        OnIngredientClick?.Invoke(gameObject.GetComponent<Ingredient>());
    }
}