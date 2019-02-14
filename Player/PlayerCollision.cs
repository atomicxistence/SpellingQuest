using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private Status status;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        status.IsDead |= collision.gameObject.tag == "Enemy";
    }
}
