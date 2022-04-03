using System.Collections;
using UnityEngine;

public class ShootingArrow : MonoBehaviour
{
    [SerializeField]
    private Transform arrow;

    [SerializeField]
    private float topAngle = 90, bottomAngle = -60;
    
    [SerializeField]
    private float speed, margin = 0.05f;

    private float direction = 1;

    [SerializeField]
    private MinigameStatus minigameStatus;

    private Coroutine rotateCoroutine;
    
    private void Start() {
        minigameStatus.OnCompleteMinigame += EndRotation;
        rotateCoroutine = StartCoroutine("ArrowRotation");
    }

    private void EndRotation() {
        StopCoroutine(rotateCoroutine);
    }

    private IEnumerator ArrowRotation() {
        while (true) {
            if(IsInRange) direction *= -1;

            float rotation = (speed* Time.deltaTime) * direction;
            // arrow.rotation()
            print(arrow.eulerAngles + "   " + rotation);
            arrow.Rotate(new Vector3(0,0, rotation));
            yield return null; 
        }
    }

    private bool IsInRange => (arrow.eulerAngles.z - margin) <= topAngle || (arrow.eulerAngles.z + margin)  >= bottomAngle;
}
