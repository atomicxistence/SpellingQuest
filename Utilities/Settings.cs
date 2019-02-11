using UnityEngine;

[CreateAssetMenu (fileName = "Settings", menuName = "Utility/Settings")]
public class Settings : ScriptableObject
{
    public float MoveSpeed;

    public float JumpForce;
    public float FallGravity;
    public float ShortJumpGravity;

    public float Shell;
}
