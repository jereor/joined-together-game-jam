using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rb;

    private void Start()
    {
        // This needs to be changed so the ball travels to the direction the cannon is facing
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3)
            // Damage slimes

        Destroy(gameObject);
    }
}
