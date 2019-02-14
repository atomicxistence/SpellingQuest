using UnityEngine;

[CreateAssetMenu (fileName = "MovementSettings", menuName = "Utility/MovementSettings")]
public class MovementSettings : ScriptableObject
{
    public float MoveSpeed;

    public float JumpForce;
    public float FallGravity;
    public float ShortJumpGravity;

    public float RayLength;
    public LayerMask CollisionLayer;
}
