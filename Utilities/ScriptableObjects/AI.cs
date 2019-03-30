using UnityEngine;

[CreateAssetMenu (fileName = "AI", menuName = "Utility/AI")]
public class AI : ScriptableObject
{
    public float MoveSpeed;
    public float Shell;

    public LayerMask GroundLayer;
}
