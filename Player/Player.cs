using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Status status;

    private Vector3 startingPosition;
    private Vector2 startingFacingDirection;

    private void Awake()
    {
        startingPosition = transform.position;
        startingFacingDirection = new Vector2(transform.localScale.x, transform.localScale.y);
    }

    public void Respawn()
    {
        status.IsDead = false;
        transform.position = startingPosition;
        transform.localScale = startingFacingDirection;
    }
}
