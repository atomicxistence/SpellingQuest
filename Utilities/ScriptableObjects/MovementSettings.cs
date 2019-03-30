using UnityEngine;

[CreateAssetMenu (fileName = "MovementSettings", menuName = "Utility/Movement Settings")]
public class MovementSettings : ScriptableObject
{
    public float MoveSpeed;

    public float JumpForce;
    public float FallGravity;
    public float ShortJumpGravity;

    public float RayLength;
}
