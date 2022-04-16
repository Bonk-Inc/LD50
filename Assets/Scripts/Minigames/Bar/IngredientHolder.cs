using System;
using System.Collections.Generic;
using UnityEngine;

public class IngredientHolder : MonoBehaviour
{
    private Ingredient currentIngredient;

    [SerializeField]
    private List<Ingredient> ingredients;
    public List<Ingredient> Ingredients => ingredients;

    public event Action<List<Ingredient>> OnIngredientAdded;

    public void AddIngredient(Ingredient ingredient) {
        if(ingredients.Contains(ingredient))
            return;

        ingredients.Add(ingredient);
        OnIngredientAdded?.Invoke(ingredients);
    }

    public void CheckIngredientPosition(Ingredient ingredient) {

    }
}
