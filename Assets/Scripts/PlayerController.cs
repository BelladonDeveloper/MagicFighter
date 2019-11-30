using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float SPEED = 400f;
    public float HEIGHT = 18200f;
    public LayerMask whatIsGround;
    public Transform groundCheck;

    private new Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    private Animator anim;

    private float isMove;
    private float groundRadius = 0.8f;
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        
        isMove = Input.GetAxis("Horizontal");
        go();

        if (Input.GetButtonDown("Fire1")) Shoot();
        if (Input.GetButtonDown("Jump")) Jump();
    }

    private void Jump()
    {
        if (grounded) rigidbody.AddForce(transform.up * HEIGHT, ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        anim.SetTrigger("Shoot");
    }

    private void go()
    {
        rigidbody.velocity = new Vector2(isMove * SPEED, rigidbody.velocity.y);

        if (isMove == 0)
        {
            anim.SetBool("IsRun", false);
        }
        else
        {
            anim.SetBool("IsRun", true);
        }
        if (isMove < 0)
        {
            sprite.flipX = true;
        }
        if (isMove > 0)
        {
            sprite.flipX = false;
        }        
    }
}