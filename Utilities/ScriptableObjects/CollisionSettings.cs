using UnityEngine;

[CreateAssetMenu (fileName = "CollisionSettings", menuName = "Utility/Collision Settings")]
public class CollisionSettings : ScriptableObject
{
   public LayerMask WhileAliveLayer;
   public LayerMask WhileDeadLayer;

   public LayerMask CollisionLayer;
   public LayerMask ObstacleLayer;
}
