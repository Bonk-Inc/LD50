using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpot : MonoBehaviour
{
    [SerializeField]
    private int position;

    public int Position => position;

    [SerializeField]
    private MinigameBook book;

    public MinigameBook Book => book;

    public event Action<BookSpot> MouseOver, MouseLeave;

    public void SetBook(MinigameBook book){
        if(book != null){
            book.transform.SetParent(transform);
            book.transform.localPosition = Vector3.zero;
        }
        this.book = book;
    }

    private void OnMouseEnter() {
        MouseOver?.Invoke(this);
    } 


     private void OnMouseExit() {
         MouseLeave?.Invoke(this);
     }




}
