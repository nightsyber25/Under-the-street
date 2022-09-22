using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    [SerializeField] float speed = 8f;
    [SerializeField] float jumpingPower = 16f;
    [SerializeField] TextMeshProUGUI healthText;
    private bool isFacingRight = true;
    Health health;
    Animator myAnimator;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] public Transform groundCheck;
    [SerializeField] public LayerMask groundLayer;

    void Awake()
    {
        health = GetComponent<Health>();
        myAnimator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        UpdateHealth();
    }

    void Update()
    {
        if(health.CurrentHealth == 0) {return;}

        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }
        UpdateHealth();
        Move();
        Flip();
    }

    private void Move()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isWalk",playerHasHorizontalSpeed);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void UpdateHealth()
    {
        healthText.text = health.CurrentHealth.ToString();
    }
}
