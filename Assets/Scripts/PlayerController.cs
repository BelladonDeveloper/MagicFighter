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
    public GameObject mushroom;
    public HealthBar healthBar;
    public bool grounded;

    private new Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    private Animator anim;

    private float isMove;
    private float groundRadius = 0.8f;

    public bool moveLeft = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);

        anim.SetBool("isGround", grounded);
        
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
        GameObject newMushroom = Instantiate(mushroom, new Vector2(transform.position.x + 30 * (moveLeft ? -1.0f : 1.0f), transform.position.y), Quaternion.Euler(0, 0, 270));
        if (moveLeft) newMushroom.GetComponent<SpriteRenderer>().flipY = true;
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
            moveLeft = true;
        }
        if (isMove > 0)
        {
            sprite.flipX = false;
            moveLeft = false;
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "mushroom")
        {
            healthBar.health -= 20;
        }
    }

}