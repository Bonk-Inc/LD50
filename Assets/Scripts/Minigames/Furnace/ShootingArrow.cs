using System.Collections;
using UnityEngine;

public class ShootingArrow : MonoBehaviour
{
    [SerializeField, Header("Required Objects")]
    private MinigameStatus minigameStatus;

    [SerializeField]
    private Transform arrow;

    [SerializeField, Header("Minigame Balancing")]
    private float speed;

    [SerializeField, Header("Arrow Borders")]
    private float topAngle = 90;

    [SerializeField]
    private float bottomAngle = -60;

    [SerializeField]
    private float padding = 90;

    private float direction = 1;

    private Coroutine rotateCoroutine;
    
    private void Start() {
        if(minigameStatus != null) minigameStatus.OnCompleteMinigame += EndRotation;
        rotateCoroutine = StartCoroutine("ArrowRotation");
    }

    private void EndRotation() {
        StopCoroutine(rotateCoroutine);
    }

    private IEnumerator ArrowRotation() {
        while (true) {
            if(IsInRange(arrow.eulerAngles.z + GetNewRotation())) direction *= -1;

            float rotation = GetNewRotation();
            arrow.Rotate(new Vector3(0,0, rotation));
            yield return null; 
        }
    }

    private float GetNewRotation() {
        return (speed * Time.deltaTime) * direction;
    }

    private bool IsInRange(float rotation) {
        var highestValue = 360 - padding;

        if(rotation >= highestValue) rotation -= highestValue;
        else rotation += padding;

        return rotation >= topAngle || rotation  <= bottomAngle;
    }  
}
