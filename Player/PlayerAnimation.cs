using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private Status status;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isMoving", status.IsMoving);
        animator.SetBool("isJumping", !status.IsGrounded);
        animator.SetBool("isDead", status.IsDead);
    }


}
