using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] bool isGrounded = false;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float distanceToGround;
    [SerializeField] Transform[] groundCheckPoints;
    float currentJumpPressTime;
    [SerializeField] int performedJumpCount;
    [HideInInspector] public Stats stats;
    float timeOnAir;
    [SerializeField] float jumpInterval = 1f; 
    private float jumpTimer;


    void Start()
    {
        performedJumpCount = 0;
        rb = GetComponent<Rigidbody2D>();
        jumpTimer = jumpInterval; 
    }


    void Update()
    {
        jumpTimer -= Time.deltaTime;


        if (jumpTimer <= 0 && (isGrounded || performedJumpCount < stats.onAirJumps))
        {
            currentJumpPressTime = 0;
            performedJumpCount += 1;
            rb.velocity = new Vector2(rb.velocity.x, stats.jumpStrength);
            jumpTimer = jumpInterval; 
        }

        if (rb.velocity.y < stats.yVelocityLowGravityThreshold && rb.velocity.y > -stats.yVelocityLowGravityThreshold)
        {
            rb.gravityScale = stats.peakGravity;
        }
        else if (rb.velocity.y > 0)
        {
            rb.gravityScale = stats.upGravity;
        }
        else
        {
            rb.gravityScale = stats.downGravity;
        }


        isGrounded = false;
        for (int i = 0; i < groundCheckPoints.Length; i++)
        {
            bool hit = Physics2D.Raycast(
                groundCheckPoints[i].position,
                Vector2.down,
                distanceToGround,
                groundLayer);

            if (hit)
            {
                timeOnAir = 0;
                isGrounded = true;
                performedJumpCount = 0;
                rb.gravityScale = stats.upGravity;
                break;
            }
        }


        if (!isGrounded)
        {
            timeOnAir += Time.deltaTime;
        }
    }
}
