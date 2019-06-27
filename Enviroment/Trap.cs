using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField]
    private Status playerStatus;
    [SerializeField]
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.SharedInstance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerStatus.IsDead = true;
            audioManager.Play("Lava");
        }
    }

}
