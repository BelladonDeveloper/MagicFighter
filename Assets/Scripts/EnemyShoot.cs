using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject mushroom;

    private float timer;

    void FixedUpdate()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        timer += Time.deltaTime;
        while (timer >= 1.0f)
        {
            GameObject leftMushroom = Instantiate(mushroom,
                new Vector2(transform.position.x + 50 * -1.0f, transform.position.y),
                Quaternion.Euler(0, 0, 270));
            leftMushroom.GetComponent<SpriteRenderer>().flipY = true;

            GameObject rightMushroom = Instantiate(mushroom,
                new Vector2(transform.position.x + 50 * 1.0f, transform.position.y),
                Quaternion.Euler(0, 0, 270));

            timer = 0;
            yield return null;
        }
    }
}
