using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMinigameManager : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private BookSpot[] spots;

    [SerializeField]
    private PlaySound sound;
    
    [SerializeField]
    private MinigameStatus status;

    private BookSpot current = null;

    [SerializeField]
    private int currentEmpty;

    private MinigameBook draggingBook = null;

    private void Awake() {
        ShuffleBooks();
        for (int i = 0; i < spots.Length; i++)
        {
            spots[i].MouseOver += (spot) => {

                if(draggingBook != null) {
                    var spotDifference = spot.Position - currentEmpty;
                    var mult = 1;
                    if(spotDifference != 0)
                        mult = spotDifference / Mathf.Abs(spotDifference);

                    for (int i = 1; i <= Mathf.Abs(spotDifference); i++)
                    {
                        var prevEmpty = currentEmpty + (i-1) * mult;
                        var move = currentEmpty + i * mult;
                        spots[prevEmpty].SetBook(spots[move].Book);
                        spots[move].SetBook(null);
                    }
                    currentEmpty = spot.Position;
                }
                 current = spot;
            };

            spots[i].MouseLeave += (spot) => {
                current = null;
            };
        }
    }

    private void Update() {
        if(current != null && Input.GetMouseButtonDown(0)){
            draggingBook = current.Book;
            currentEmpty = current.Position;
        }
        if(draggingBook != null) {
            var position = draggingBook.transform.position;
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            position.x = mousePos.x;
            position.y = mousePos.y;
            draggingBook.transform.position = position;
        }
        if(draggingBook != null && Input.GetMouseButtonUp(0)) {
            spots[currentEmpty].SetBook(draggingBook);
            draggingBook = null;
            sound?.PlayClip();
            CheckWin();
        }
    }

    private void ShuffleBooks(){
        var books = new List<MinigameBook>();
        for (int i = 0; i < spots.Length; i++)
        {
            books.Add(spots[i].Book);
        }

        for (int i = 0; i < spots.Length; i++)
        {
            var book = books.GetRandom();
            books.Remove(book);
            spots[i].SetBook(book);
        }
    }

    private void CheckWin(){
        for (int i = 0; i < spots.Length; i++)
        {
            if(spots[i].Position != spots[i].Book.book)
                return;
        }
        status.CompleteMinigame();
    }

}
