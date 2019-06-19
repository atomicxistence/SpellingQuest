using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private Status status;
    [SerializeField]
    private CollisionSettings collisionSettings;

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
        // LayerMask.value returns a bitmask value
        //gameObject.layer = collisionSettings.WhileAliveLayer.value;

        transform.position = startingPosition;
        transform.localScale = startingFacingDirection;
    }
}
