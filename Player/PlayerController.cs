using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator animator;
    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private Settings playerSettings;

    //TODO: change player raycasting to mimic EnemyController
    private Vector2 playerSize;
    private float horizontalMovement;
    private bool isMoving;

    private bool isGrounded;
    private bool isJumping;
    private bool isHittingHead;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerSize = GetComponent<Renderer>().bounds.size;
    }

    private void Update()
    {
        GetInput();

        if (isMoving)
        {
            FlipPlayer();
        }

        ChangePlayerAnimation();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontalMovement * playerSettings.MoveSpeed, rb2d.velocity.y);

        if (isJumping)
        {
            Jump();
        }

        GroundedCheck();
        GravityModification();
    }

    private void GetInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        isMoving = Mathf.Abs(horizontalMovement) > 0;

        if (isGrounded)
        {
            isJumping |= Input.GetButtonDown("Jump");
        }
    }

        private void FlipPlayer()
    {
        transform.localScale = new Vector2(Mathf.Sign(horizontalMovement) * 1f, transform.localScale.y);
    }

    private void ChangePlayerAnimation()
    {
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isJumping", !isGrounded);
    }

    private void Jump()
    {
        rb2d.AddForce(Vector2.up * playerSettings.JumpForce, ForceMode2D.Impulse);
        isJumping = false;
        isGrounded = false;
    }

    private void CeilingCheck()
    {
        var rayOrigin = (Vector2)transform.position + (Vector2.up * (playerSize.y * 0.5f));
        isHittingHead = Physics2D.Raycast(rayOrigin, Vector2.up, playerSettings.Shell, groundLayer);
    }

    private void GroundedCheck()
    {
        var rayOrigin = (Vector2)transform.position + (Vector2.down * (playerSize.y * 0.5f));
        isGrounded = Physics2D.Raycast(rayOrigin, Vector2.down, playerSettings.Shell, groundLayer);
    }

    private void GravityModification()
    {
        if (rb2d.velocity.y < 0)
        {
            rb2d.gravityScale = playerSettings.FallGravity;
        }
        else if (rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb2d.gravityScale = playerSettings.ShortJumpGravity;
        }
        else
        {
            rb2d.gravityScale = 1f;
        }
    }
}
