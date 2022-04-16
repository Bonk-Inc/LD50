using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour // TODO Rename
{
    [SerializeField]
    private int minimumIngredients = 1;
    
    [SerializeField]
    private IngredientHolder holder;

    [SerializeField]
    private Ingredient alwaysIngredient;

    [SerializeField] 
    private GameObject itemBox, requiredItemPrefab;

    [SerializeField] 
    private MinigameStatus minigameStatus;
    
    [SerializeField] 
    private List<Ingredient> availableIngredients;

    private Customer customer = new Customer();
    
    private void Awake()
    {
        holder.OnIngredientAdded += CheckIngredients;

        customer.GenerateIngredients(availableIngredients, minimumIngredients);
        if (alwaysIngredient != null) customer?.AddIngredient(alwaysIngredient);
        PlaceRequiredItemsInBox();
    }

    private void CheckIngredients(List<Ingredient> ingredients) {
        if (ingredients.UnorderedEqual(customer.RequiredIngredients))
            minigameStatus.CompleteMinigame();
    }

    private void PlaceRequiredItemsInBox()
    {
        var position = new Vector3(-2f, 0f, 0f);

        foreach (var ingredient in customer.RequiredIngredients)
        {
            var prefab = Instantiate(requiredItemPrefab, position, transform.rotation);
            var prefabPosition = prefab.transform.position;

            prefab.transform.parent = itemBox.transform;
            prefab.transform.localPosition = position;
            prefab.GetComponent<SpriteRenderer>().sprite = ingredient.GetComponent<SpriteRenderer>().sprite;
            
            position = new Vector3(position.x + 1f, position.y, position.z);
        }
    }
}
