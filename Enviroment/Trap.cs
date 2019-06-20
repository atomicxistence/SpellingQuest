using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private Status playerStatus;
    [SerializeField]
    private AudioManager audio;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerStatus.IsDead = true;
            audio.Play("Lava");
        }
    }

}
