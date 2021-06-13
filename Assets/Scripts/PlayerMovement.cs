using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Config parameters
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] Transform groundCheck;
    [SerializeField] float checkRadius;
    [SerializeField] int extraJumpsValue;

    [Header("Audio")]
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumpClip;

    // State variables
    private float _moveInput;
    private Rigidbody2D _rb;
    [SerializeField] private bool _isGrounded;
    public bool facingRight = true;
    [SerializeField] private int _extraJumps;

    // Cached references
    private Animator _animator;

    // Animator states
    private static readonly int Moving = Animator.StringToHash("Moving");

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _extraJumps = extraJumpsValue;
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        _moveInput = Input.GetAxis("Horizontal");
        _rb.velocity = new Vector2(_moveInput * speed, _rb.velocity.y);

        if (facingRight == false && _moveInput > 0)
            Flip();
        else if (facingRight == true && _moveInput < 0)
            Flip();

        if (_rb.velocity.x != 0)
            _animator.SetBool(Moving, true);
        else
            _animator.SetBool(Moving, false);
    }

    private void Update()
    {
        if (_isGrounded)
            _extraJumps = extraJumpsValue;

        if (Input.GetKeyDown(KeyCode.Space) && _extraJumps > 0)
        {
            _rb.velocity = Vector2.up * jumpForce;
            _extraJumps--;
            audioSource.PlayOneShot(jumpClip);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _extraJumps == 0 && _isGrounded == true)
        {
            _rb.velocity = Vector2.up * jumpForce;
            audioSource.PlayOneShot(jumpClip);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
