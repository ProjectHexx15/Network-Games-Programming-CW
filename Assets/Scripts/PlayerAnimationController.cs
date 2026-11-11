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

    // walking animations for each direction
    [SerializeField] private SpriteAnimation walkUp;
    [SerializeField] private SpriteAnimation walkDown;
    [SerializeField] private SpriteAnimation walkLeft;
    [SerializeField] private SpriteAnimation walkRight;

    private SpriteAnimation currentAnimation;

    private void Update()
    {

        if(movementController.IsMoving)
        {
            switch (movementController.Facing)
            {
                case FacingDirection.Up:
                    PlayAnimation(walkUp);
                    break;

                case FacingDirection.Down:
                    PlayAnimation(walkDown);
                    break;

                case FacingDirection.Left:
                    PlayAnimation(walkLeft);
                    break;


                case FacingDirection.Right:
                    PlayAnimation(walkRight);
                    break;
            }

        }
        else
        {
            StopCurrentAnimation();
            SetIdleSprite();
            
        }
    }

    private void PlayAnimation(SpriteAnimation animation)
    {
        if (currentAnimation == animation)
        {
            return;
        }
        StopCurrentAnimation();
        currentAnimation = animation;
        currentAnimation.Play();
    }


    private void StopCurrentAnimation()
    {
        if(currentAnimation != null)
        {
            currentAnimation.Stop();
            currentAnimation = null;
        }

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
