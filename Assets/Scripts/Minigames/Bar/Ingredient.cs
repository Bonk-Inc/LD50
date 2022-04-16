using System;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField]
    private Draggable draggable;

    [SerializeField] 
    private string ingredientName;

    [SerializeField]
    private PlaySound playSound;
    
    public event Action<Ingredient> OnStartDrag, OnEndDrag;

    public string IngredientName => ingredientName;

    private void Awake() {
        draggable.OnEndDrag += HandleEndDrag;

        draggable.OnStartDrag += () => {
            OnStartDrag?.Invoke(this);
        };
    }

    private void HandleEndDrag()
    {
        playSound.PlayClip();
        OnEndDrag?.Invoke(this);
    }
}