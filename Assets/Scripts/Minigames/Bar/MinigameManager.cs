using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField]
    private Ingredient alwaysIngredient;

    [SerializeField] 
    private GameObject itemBox, requiredItemPrefab;

    [SerializeField] 
    private MinigameStatus minigameStatus;
    
    [SerializeField] 
    private List<Ingredient> requiredIngredients, availableIngredients, gatheredIngredients;
    
    private void Awake()
    {
        foreach (var availableIngredient in availableIngredients)
            availableIngredient.OnIngredientClick += AddIngredientToList;

        if (alwaysIngredient != null)
        {
            alwaysIngredient.OnIngredientClick += AddIngredientToList;
            requiredIngredients.Add(alwaysIngredient);
        }

        GenerateRequiredIngredientsList();
        PlaceRequiredItemsInBox();
    }

    private void AddIngredientToList(Ingredient ingredient)
    {
        gatheredIngredients.Add(ingredient);

        if (gatheredIngredients.UnorderedEqual(requiredIngredients))
            minigameStatus.CompleteMinigame();
    }

    private void GenerateRequiredIngredientsList()
    {
        var size = Random.Range(0, availableIngredients.Count);

        for (var i = 0; i <= size; i++)
            requiredIngredients.Add(GetRandomIngredient());
    }

    private void PlaceRequiredItemsInBox()
    {
        var position = new Vector3(-3.583071f, 3.38f, 0f);

        foreach (var ingredient in requiredIngredients)
        {
            var prefab = Instantiate(requiredItemPrefab, position, transform.rotation);
            var prefabPosition = prefab.transform.position;

            prefab.transform.parent = itemBox.transform;
            prefab.GetComponent<SpriteRenderer>().sprite = ingredient.GetComponent<SpriteRenderer>().sprite;
            
            position = new Vector3(prefabPosition.x + 3.1f, prefabPosition.y, prefabPosition.z);
        }
    }

    private Ingredient GetRandomIngredient()
    {
        var ingredient = availableIngredients.GetRandom();

        if (requiredIngredients.Contains(ingredient))
            ingredient = GetRandomIngredient();

        return ingredient;
    }
}
