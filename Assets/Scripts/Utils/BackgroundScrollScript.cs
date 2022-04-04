using UnityEngine;

public class BackgroundScrollScript : MonoBehaviour
{
    [SerializeField] 
    private float speed;

    private void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * speed, 0f);
    }
}