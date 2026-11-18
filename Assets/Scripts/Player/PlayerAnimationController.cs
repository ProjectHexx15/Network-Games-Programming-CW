using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    // choses which animation should play for the player based on movmeent/facing direction

    [SerializeField] private MovementController movementController;

    [SerializeField] private SpriteRenderer spriteRenderer;

    // idle sprites for each direction
    [SerializeField] private Sprite idleUp;
    [SerializeField] private Sprite idleDown;
    [SerializeField] private Sprite idleLeft;
    [SerializeField] private Sprite idleRight;

    [SerializeField] private PlayerSpriteAnimation spriteAnimation;

    private void Update()
    {
        if (movementController.IsMoving)
        {
            spriteAnimation.Play(movementController.Facing);

        }
        else
        {
            StopCurrentAnimation();
            SetIdleSprite();

        }
    }

    private void PlayAnimation(FacingDirection direction)
    {
        spriteAnimation.Play(direction);
    }

    private void StopCurrentAnimation()
    {
        spriteAnimation.Stop();
    }

    private void SetIdleSprite()
    {
        switch(movementController.Facing)
        {
            case FacingDirection.Up:
                spriteRenderer.sprite = idleUp;
                break;

            case FacingDirection.Down:
                spriteRenderer.sprite = idleDown;
                break;

            case FacingDirection.Left:
                spriteRenderer.sprite = idleLeft;
                break;

            case FacingDirection.Right:
                spriteRenderer.sprite = idleRight;
                break;
        }
    }

}
