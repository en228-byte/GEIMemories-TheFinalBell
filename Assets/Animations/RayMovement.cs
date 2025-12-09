using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayMovement : MonoBehaviour
{
    public float speed = 3f;

    private Animator anim;
    private Rigidbody2D rb;

    float moveX;
    float moveY;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        moveY = Input.GetAxisRaw("Vertical"); // W/S or Up/Down

        rb.velocity = new Vector2(moveX, moveY) * speed;

        anim.SetBool("Walkright", moveX > 0);
        anim.SetBool("Walkleft", moveX < 0);
        anim.SetBool("Walkup", moveY > 0);
        anim.SetBool("Walkdown", moveY < 0);
    }
}