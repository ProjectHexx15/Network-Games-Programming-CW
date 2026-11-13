using UnityEngine;

public class PlayerSpriteAnimation : MonoBehaviour
{
    public enum Animation
    {
        Up,
        Down,
        Left,
        Right
    }

    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite idleSprite;

    [SerializeField] private Sprite[] upAnimationSprites;
    [SerializeField] private Sprite[] downAnimationSprites;
    [SerializeField] private Sprite[] leftAnimationSprites;
    [SerializeField] private Sprite[] rightAnimationSprites;

    private Animation currentAnimation;

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

            switch (currentAnimation)
            {
                case Animation.Up:
                    frames = upAnimationSprites;
                    break;

                case Animation.Down:
                    frames = downAnimationSprites;
                    break;

                case Animation.Left:
                    frames = leftAnimationSprites;
                    break;

                case Animation.Right:
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

    public void Play(Animation animation)
    {
        if (isPlaying && currentAnimation == animation)
        {
            return;
        }

        currentAnimation = animation;
        isPlaying = true;

        Sprite[] frames = null;

        switch (currentAnimation)
        {
            case Animation.Up:
                frames = upAnimationSprites;
                break;

            case Animation.Down:
                frames = downAnimationSprites;
                break;

            case Animation.Left:
                frames = leftAnimationSprites;
                break;

            case Animation.Right:
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

        if (idleSprite != null)
        {
            spriteRenderer.sprite = idleSprite;
        }

    }

}
