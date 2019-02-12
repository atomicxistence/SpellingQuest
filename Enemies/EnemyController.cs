using UnityEngine;

[RequireComponent (typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class EnemyController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private BoxCollider2D enemyCollider;

    [SerializeField]
    private AI enemyAI;

    private float horizontalMovement = 1f;

    private RaycastOrigins enemyRayOrigins;

    private bool onEdge;
    private bool isObstructed;
    private bool isMovingRight = true;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        enemyCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        UpdateBounds();
        GroundCheck();
        ObstacleCheck();

        if (onEdge || isObstructed)
        {
            Flip();
        }

        horizontalMovement = isMovingRight ? 1f : -1f;
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(horizontalMovement * enemyAI.MoveSpeed, rb2d.velocity.y);
    }

    private void UpdateBounds()
    {
        var enemyBounds = enemyCollider.bounds;

        enemyRayOrigins.bottomLeft = new Vector2(enemyBounds.min.x, enemyBounds.min.y);
        enemyRayOrigins.bottomRight = new Vector2(enemyBounds.max.x, enemyBounds.min.y);
        enemyRayOrigins.centerLeft = new Vector2(enemyBounds.min.x, enemyBounds.center.y);
        enemyRayOrigins.centerRight = new Vector2(enemyBounds.max.x, enemyBounds.center.y);
    }

    private void GroundCheck()
    {
        var rayOrigin = isMovingRight ? enemyRayOrigins.bottomRight : enemyRayOrigins.bottomLeft;
        onEdge = !Physics2D.Raycast(rayOrigin, Vector2.down, enemyAI.Shell, enemyAI.GroundLayer);
    }

    private void ObstacleCheck()
    {
        var rayOrigin = isMovingRight ? enemyRayOrigins.centerRight : enemyRayOrigins.centerLeft;
        isObstructed = Physics2D.Raycast(rayOrigin, new Vector2(horizontalMovement, 0), enemyAI.Shell, enemyAI.GroundLayer);
    }

    private void Flip()
    {
        transform.localScale = new Vector2(Mathf.Sign(horizontalMovement) * -1f, transform.localScale.y);
        isMovingRight = !isMovingRight;
    }
}
