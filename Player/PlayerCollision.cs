using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private Status status;
    [SerializeField]
    private CollisionSettings collisionSettings;
    [SerializeField]
    private AudioManager audio;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            // LayerMask.value returns a bitmask value
            //gameObject.layer = collisionSettings.WhileDeadLayer.value;
            status.IsDead = true;
            audio.Play("Death");
        }
    }
}