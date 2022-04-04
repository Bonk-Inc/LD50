using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] 
    private Ingredient coffee;

    [SerializeField] 
    private GameObject itemBox, requiredItemPrefab;
    
    [SerializeField] 
    private List<Ingredient> requiredIngredients, availableIngredients;
    
    private List<Ingredient> gatheredIngredients;
    
    private void Awake()
    {
        foreach (var availableIngredient in availableIngredients)
            availableIngredient.OnIngredientClick += AddIngredientToList;

        requiredIngredients.Add(coffee);
        
        GenerateRequiredIngredientsList();
        PlaceRequiredItemsInBox();
    }

    private void AddIngredientToList(Ingredient ingredient)
    {
        gatheredIngredients.Add(ingredient);
    }

    private void GenerateRequiredIngredientsList()
    {
        var size = Random.Range(0, availableIngredients.Count);

        for (var i = 0; i <= size; i++)
        {
            var position = Random.Range(0, availableIngredients.Count);
            var item = availableIngredients[position];
            
            requiredIngredients.Add(item);
        }
    }

    private void PlaceRequiredItemsInBox()
    {
        var position = new Vector3(-3.583071f, 3.38f, 0f);

        foreach (var ingredient in requiredIngredients)
        {
            var prefab = Instantiate(requiredItemPrefab, position, transform.rotation);
            var prefabPosition = prefab.transform.position;

            prefab.GetComponent<SpriteRenderer>().sprite = ingredient.GetComponent<SpriteRenderer>().sprite;
            
            position = new Vector3(prefabPosition.x + 3.1f, prefabPosition.y, prefabPosition.z);
        }
    }
}
