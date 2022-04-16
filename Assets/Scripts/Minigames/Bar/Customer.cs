using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer
{
    private List<Ingredient> requiredIngredients = new List<Ingredient>();
    public List<Ingredient> RequiredIngredients => requiredIngredients;

    public List<Ingredient> GenerateIngredients(List<Ingredient> availableIngredients, int minimumIngredients = 1)
    {
        requiredIngredients.Clear();
        var size = Random.Range(minimumIngredients, availableIngredients.Count);

        for (var i = 0; i < size; i++)
            requiredIngredients.Add(GetRandomIngredient(availableIngredients));
        
        return requiredIngredients;
    }

    public void AddIngredient(Ingredient ingredient) {
        requiredIngredients.Add(ingredient);
    }

    private Ingredient GetRandomIngredient(List<Ingredient> availableIngredients)
    {
        var ingredient = availableIngredients.GetRandom();

        if (requiredIngredients != null && requiredIngredients.Contains(ingredient)) // TODO isn't there a possibility to get stuck here?
            ingredient = GetRandomIngredient(availableIngredients);

        return ingredient;
    }
}
