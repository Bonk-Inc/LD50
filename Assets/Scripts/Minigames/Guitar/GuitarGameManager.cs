using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarGameManager : MonoBehaviour
{

    [SerializeField]
    private List<GuitarString> strings;


    [SerializeField]
    private int answerCount;

    [SerializeField]
    private float answerShowTimeSpacing = 0.2f;

    [SerializeField]
    private float wrongSeconds = 0.2f;

    [SerializeField]
    private MinigameStatus status;

    private List<GuitarString> answers;

    private int correctlyAnswered = 0;

    private void Awake() {
        AddEvents();
        CreateAnswers();
        StartCoroutine(ShowAnswersRoutine(1f));
    }

    private IEnumerator ShowAnswersRoutine(float startdelay = 0f){
        SetLocked(true);
        yield return new WaitForSeconds(startdelay);
        foreach (var answer in answers)
        {
            yield return answer.Highlight();
            yield return new WaitForSeconds(answerShowTimeSpacing);
        }
        SetLocked(false);
    }

    private void CreateAnswers(){
        answers = new List<GuitarString>();
        for (int i = 0; i < answerCount; i++)
        {
            var newAnswer = strings.GetRandom();
            answers.Add(newAnswer);
        }
    }

    private void AddEvents(){
        foreach (var guitarString in strings)
        {
            guitarString.StringClicked += () => {
                if (answers[correctlyAnswered] == guitarString)
                {
                    correctlyAnswered++;
                } else {
                    correctlyAnswered = 0;
                    StartCoroutine(Wrong());
                }

                if(correctlyAnswered == answers.Count){
                    status.CompleteMinigame();
                }
            };
        }
    }

    private void SetLocked(bool locked){
        foreach (var guitarString in strings)
        {
            guitarString.SetLocked(locked);
        }
    }

    private IEnumerator Wrong(){
        SetLocked(true);
        foreach (var guitarString in strings)
        {
            guitarString.Wrong(wrongSeconds);
        }
        yield return StartCoroutine(ShowAnswersRoutine(1f));
    }

}
