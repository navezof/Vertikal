using UnityEngine;
using System.Collections;

public class MoveComponent : AComponent {

    bool bVerticalEnabled = false;
    bool bHorizontalEnabled = true;
    bool bFacingRight = true;

    Rigidbody2D body;
    StealthComponent stealth;
    Animator animator;

    public bool bAirControl;
    public float maxSpeed;

    public Transform groundCheck;
    const float groundedRadius = .2f;
    public LayerMask groundLayer;
    bool bGrounded = true;

    void Start()
    {
        groundCheck = transform.Find("GroundCheck");

        stealth = GetComponent<StealthComponent>();
        pawn = GetComponent<APawn>();
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        bGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, groundLayer);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                bGrounded = true;
        }

        animator.SetBool("Ground", bGrounded);
    }

    public void HorizontalMove(float horizontalMove)
    {
        if ((bGrounded || bAirControl) && bHorizontalEnabled)
        {            
            horizontalMove = ApplyStealthMod(horizontalMove);           
            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
            body.velocity = new Vector2(horizontalMove * maxSpeed, body.velocity.y);

            if (horizontalMove > 0 && !bFacingRight)
                Flip();
            else if (horizontalMove < 0 && bFacingRight)
                Flip();
        }
    }

    public void VerticalMove(float verticalMove)
    {
        if (bVerticalEnabled)
        {

        }
    }

    void Flip()
    {
        bFacingRight = !bFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    float ApplyStealthMod(float horizontalMove)
    {
        if (!stealth)
            return horizontalMove;
        return stealth.ApplyStealthMod(horizontalMove);
    }
}
