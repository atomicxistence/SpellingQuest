using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private PolygonCollider2D playerCollider;

    [SerializeField]
    private MovementSettings playerMovementSettings;
    [SerializeField]
    private CollisionSettings playerCollisionSettings;
    [SerializeField]
    private Status status;
    [SerializeField]
    private AudioManager audioManager;

    private RaycastOrigins playerRayOrigins;
    private float horizontalMovement;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<PolygonCollider2D>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void Update()
    {
        if (!status.IsDead)
        {
            GetInput();
        }
        else
        {
            horizontalMovement = 0;
        }

        if (status.IsMoving)
        {
            FlipPlayer();
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontalMovement * playerMovementSettings.MoveSpeed, rb2d.velocity.y);

        if (status.IsJumping)
        {
            Jump();
        }

        UpdateBounds();
        GroundedCheck();
        GravityModification();
    }

    private void GetInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        status.IsMoving = Mathf.Abs(horizontalMovement) > 0;

        if (status.IsGrounded)
        {
            status.IsJumping |= Input.GetButtonDown("Jump");
        }
    }

    private void FlipPlayer()
    {
        transform.localScale = new Vector2(Mathf.Sign(horizontalMovement) * 1f, transform.localScale.y);
    }

    private void Jump()
    {
        rb2d.AddForce(Vector2.up * playerMovementSettings.JumpForce, ForceMode2D.Impulse);
        status.IsJumping = false;
        status.IsGrounded = false;
        audioManager.Play("Jump");
    }

    private void UpdateBounds()
    {
        var playerBounds = playerCollider.bounds;

        playerRayOrigins.bottomLeft = new Vector2(playerBounds.min.x, playerBounds.min.y);
        playerRayOrigins.bottomRight = new Vector2(playerBounds.max.x, playerBounds.min.y);
        playerRayOrigins.centerLeft = new Vector2(playerBounds.min.x, playerBounds.center.y);
        playerRayOrigins.centerRight = new Vector2(playerBounds.max.x, playerBounds.center.y);
    }

    private void GroundedCheck()
    {
        status.IsGrounded = RaycastFromOrigin(playerRayOrigins.bottomLeft) || RaycastFromOrigin(playerRayOrigins.bottomRight);
    }

    private bool RaycastFromOrigin(Vector2 origin)
    {
        return Physics2D.Raycast(origin, Vector2.down, playerMovementSettings.RayLength, playerCollisionSettings.ObstacleLayer);
    }

    private void GravityModification()
    {
        if (rb2d.velocity.y < 0)
        {
            rb2d.gravityScale = playerMovementSettings.FallGravity;
        }
        else if (rb2d.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rb2d.gravityScale = playerMovementSettings.ShortJumpGravity;
        }
        else
        {
            rb2d.gravityScale = 1f;
        }
    }
}
