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
    private BoxCollider2D boxCollider;

    Health health;
    ScreenShakeController shakeController;

    private void Start()
    {
        health = FindObjectOfType<Health>();
        shakeController = FindObjectOfType<ScreenShakeController>();
        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.enabled = false;

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
        // A timer is used to give the ball enough time to get out of the cannon's collider
        _timer += Time.deltaTime;
        if (_timer > 0.03)
            boxCollider.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shakeController.StartShake(.1f, .1f);

        if (collision.gameObject.layer == 3) // If collision object's layer is "Player"
        {
            health.TakeDamage(1);
            Destroy(gameObject);
        }

        if (_timer > .04)
            Destroy(gameObject); // Destroy the ball if it hits something
    }
}
