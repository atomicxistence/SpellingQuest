using UnityEngine;

[CreateAssetMenu (fileName = "Status", menuName = "Utility/Status")]
public class Status : ScriptableObject
{
    public bool IsMoving;
    public bool IsJumping;
    public bool IsGrounded;

    public bool IsDead;
    public bool IsCollectingItem;
}
