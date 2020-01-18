using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MagicControl : MonoBehaviour
{
    public int speedMagic;

    private int direction;
    private SpriteRenderer spriteRenderer;
    private new Rigidbody2D rigidbody;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rigidbody = GetComponent<Rigidbody2D>();
        direction = spriteRenderer.flipY ? -1 : 1;
        Destroy(gameObject, 6);
    }

    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x + direction * speedMagic, transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene(0);
        }
    }
}
