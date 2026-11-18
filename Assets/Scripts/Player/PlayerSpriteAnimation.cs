using UnityEngine;

public class PlayerSpriteAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite[] upAnimationSprites;
    [SerializeField] private Sprite[] downAnimationSprites;
    [SerializeField] private Sprite[] leftAnimationSprites;
    [SerializeField] private Sprite[] rightAnimationSprites;

    private Animation currentAnimation;
    private FacingDirection currentFacingDirection;

    [SerializeField] private float frameRate = 0.1f;

    private float timer;
    private int currentFrame;
    private bool isPlaying;


    private void Awake()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        if (!isPlaying)
        {
            return;
        }

        timer += Time.deltaTime;

        if(timer >= frameRate)
        {
            timer = 0;
            currentFrame++;

            Sprite[] frames = null;

            switch (currentFacingDirection)
            {
                case FacingDirection.Up:
                    frames = upAnimationSprites;
                    break;

                case FacingDirection.Down:
                    frames = downAnimationSprites;
                    break;

                case FacingDirection.Left:
                    frames = leftAnimationSprites;
                    break;

                case FacingDirection.Right:
                    frames = rightAnimationSprites;
                    break;
            }
            if (frames != null && frames.Length > 0)
            {
                currentFrame %= frames.Length;
                spriteRenderer.sprite = frames[currentFrame];
            }
        }

    }

    public void Play(FacingDirection direction)
    {
        if (isPlaying && currentFacingDirection == direction)
        {
            return;
        }

        currentFacingDirection = direction;
        isPlaying = true;

        Sprite[] frames = GetDirectionFrames(currentFacingDirection);

        switch (currentFacingDirection)
        {
            case FacingDirection.Up:
                frames = upAnimationSprites;
                break;

            case FacingDirection.Down:
                frames = downAnimationSprites;
                break;

            case FacingDirection.Left:
                frames = leftAnimationSprites;
                break;

            case FacingDirection.Right:
                frames = rightAnimationSprites;
                break;
        }

        if(frames != null && frames.Length > 0)
        {
            spriteRenderer.sprite = frames[0];
        }
    }

    public void Stop()
    {
        isPlaying = false;
        currentFrame = 0;
        timer = 0;

    }

    private Sprite[] GetDirectionFrames(FacingDirection direction)
    {
        switch (direction)
        {
            case FacingDirection.Up:
                return upAnimationSprites;

            case FacingDirection.Down:
                return downAnimationSprites;

            case FacingDirection.Left:
                return leftAnimationSprites;

            case FacingDirection.Right:
                return rightAnimationSprites;

            default:
                return null;
        }
    }

}
