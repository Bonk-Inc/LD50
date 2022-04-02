using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private const string WALKING_ANIMATION_PARAM = "IsWalking";

    [SerializeField]
    private float speed = 10f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    private MoveStatus moveStatus;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateMoveStatus();
        Move();
        UpdateVisuals();
    }

    private void UpdateMoveStatus()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveStatus = MoveStatus.LEFT;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveStatus = MoveStatus.RIGHT;
        }
        else
        {
            moveStatus = MoveStatus.IDLE;
        }
    }

    private void Move()
    {
        var direction = MoveStatusDirection(); // normalize to 1 and -1
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    private float MoveStatusDirection() => moveStatus switch
    {
        MoveStatus.LEFT => -1,
        MoveStatus.RIGHT => 1,
        _ => 0,
    };

    private void UpdateVisuals()
    {

        if (moveStatus == MoveStatus.LEFT)
        {
            anim.SetBool("IsWalking", true);
            sprite.flipX = true;
        }
        else if (moveStatus == MoveStatus.RIGHT)
        {
            anim.SetBool("IsWalking", true);
            sprite.flipX = false;
        }
        else
        {
            anim.SetBool("IsWalking", false);
            sprite.flipX = false;

        }
    }
}

public enum MoveStatus
{
    LEFT,
    RIGHT,
    IDLE
}