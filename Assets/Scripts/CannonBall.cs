using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rb;

    [SerializeField] bool shootsRight;
    [SerializeField] bool shootsLeft;
    [SerializeField] bool shootsUp;
    [SerializeField] bool shootsDown;

    private float _timer = 0;

    Health health;

    private void Start()
    {
        health = FindObjectOfType<Health>();

        if (shootsRight)
            rb.velocity = transform.right * speed;
        else if (shootsLeft)
            rb.velocity = -1 * transform.right * speed;
        else if (shootsUp)
            rb.velocity = transform.up * speed;
        else if (shootsDown)
            rb.velocity = -1 * transform.up * speed;
    }

    private void Update()
    {
        _timer += Time.deltaTime;   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 3) // If collision object's layer is "Player"
        {
            health.TakeDamage(1);
            Destroy(gameObject);
        }
        // A timer is used to give the ball enough time to get out of the cannon's collider
        else if (_timer > 0.5)
            Destroy(gameObject); // Destroy the ball if it hits something
    }
}
