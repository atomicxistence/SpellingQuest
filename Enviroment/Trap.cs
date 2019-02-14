using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private Status playerStatus;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerStatus.IsDead = true;
        }
    }

}
