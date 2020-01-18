using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public float SPEED = 400f;

    private GameObject player;
    private new Rigidbody2D rigidbody;
    private SpriteRenderer sprite;
    private bool needMove = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player");
    }

    void FixedUpdate()
    {
        float distance = Mathf.Abs(player.transform.position.x - transform.position.x);
        if (distance > 250)
        {
            needMove = true;
        }
        if (distance < 35)
        {
            needMove = false;
        }
        if (needMove) go();
    }

    private void go()
    {
        rigidbody.velocity = new Vector2(SPEED * (sprite.flipX ? -1 : 1), rigidbody.velocity.y);

        if (player.transform.position.x < transform.position.x)
        {
            sprite.flipX = true;
        }
        else if (player.transform.position.x > transform.position.x)
        {
            sprite.flipX = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(0);
        }
    }
}
