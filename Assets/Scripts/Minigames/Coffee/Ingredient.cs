using System;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] 
    private string ingredientName;

    public event Action<Ingredient> OnIngredientClick;

    public string getIngredientName => ingredientName;
    
    private void OnMouseDown()
    {
        OnIngredientClick?.Invoke(gameObject.GetComponent<Ingredient>());
    }
}