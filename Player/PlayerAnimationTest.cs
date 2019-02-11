using UnityEngine;

public class PlayerAnimationTest : MonoBehaviour
{
    private Animator animator;

    public bool isMoving;
    public bool isJumping;
    public bool isDead;
    public bool isPickingUpItem;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isDead", isDead);
        animator.SetBool("isPickingUpItem", isPickingUpItem);
    }
}
