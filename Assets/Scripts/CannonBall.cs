using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] Rigidbody2D rb;

    [Header("Shoot Direction")]
    [SerializeField] bool shootsRight;
    [SerializeField] bool shootsLeft;
    [SerializeField] bool shootsUp;
    [SerializeField] bool shootsDown;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip explosion;

    private float _timer = 0;
    private BoxCollider2D boxCollider;

    Health health;
    ScreenShakeController shakeController;

    private void Awake()
    {
        audioSource = FindObjectOfType<AudioSource>();
    }

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
        if (_timer > 0.05)
            boxCollider.enabled = true;
        if (_timer > 3)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        shakeController.StartShake(.1f, .1f);

        if (collision.gameObject.layer == 3) // If collision object's layer is "Player"
        {
            audioSource.PlayOneShot(explosion);
            health.TakeDamage(1);
            Destroy(gameObject);
        }

        if (_timer > .06)
        {
            audioSource.PlayOneShot(explosion);
            Destroy(gameObject); // Destroy the ball if it hits something
        }
    }
}
