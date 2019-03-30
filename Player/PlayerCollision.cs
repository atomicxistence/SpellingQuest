using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private Status status;
    [SerializeField]
    private CollisionSettings collisionSettings;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            status.IsDead = true;
            gameObject.layer = collisionSettings.WhileDeadLayer.value;
        }
    }
}