using UnityEngine;


public class ExplosionSpriteAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite[] startAnimationSprites;
    [SerializeField] private Sprite[] middleAnimationSprites;
    [SerializeField] private Sprite[] endAnimationSprites;

    private Sprite[] currentFrames;

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

        if (timer >= frameRate)
        {
            timer = 0;
            currentFrame++;

            if(currentFrame >= currentFrames.Length)
            {
                currentFrame = 0;
            }

            spriteRenderer.sprite = currentFrames[currentFrame];

        }

    }

    public void Play(ExplosionState exploState)
    {
        currentFrames = GetFrames(exploState);

        if (currentFrames == null || currentFrames.Length == 0)
        {
            return;
        }

        currentFrame = 0;
        timer = 0f;
        isPlaying = true;

        spriteRenderer.sprite = currentFrames[0];
    }

    public void Stop()
    {
        isPlaying = false;
        currentFrame = 0;
        timer = 0;

    }

    private Sprite[] GetFrames(ExplosionState state)
    {
        switch (state)
        {
            case ExplosionState.Start:
                return startAnimationSprites;
                break;

            case ExplosionState.Middle:
                return middleAnimationSprites;
                break;

            case ExplosionState.End:
                return endAnimationSprites;
                break;

            default:
                return null;
        }
    }

}
