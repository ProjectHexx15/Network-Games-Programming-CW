using UnityEngine;

public class SpriteAnimation : MonoBehaviour
{
    // handles sprite animation for any game object, the game object controls which animation is played and when

    private SpriteRenderer spriteRenderer;

    [SerializeField] private Sprite idleSprite;
    [SerializeField] private Sprite[] animationSprites;

    [SerializeField] private float frameRate = 0.1f;

    private float timer;
    private int currentFrame;
    private bool isPlaying;


    private void Awake()
    {
        if(spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    private void Update()
    {
        if(!isPlaying)
        {
            return;
        }

        if(animationSprites == null || animationSprites.Length == 0)
        {
            return;
        }

        timer += Time.deltaTime;

        if(timer >= frameRate)
        {
            timer = 0;
            currentFrame++;

            if(currentFrame >= animationSprites.Length)
            {
                currentFrame = 0;
            }
        }

        spriteRenderer.sprite = animationSprites[currentFrame];
    }

    public void Play()
    {
        if(isPlaying)
        {
            return;
        }

        isPlaying = true;

        timer = 0f;
        currentFrame = 0;

        if(animationSprites != null && animationSprites.Length > 0)
        {
            spriteRenderer.sprite = animationSprites[currentFrame];
        }
    }

    public void Stop()
    {
        isPlaying = false;
        currentFrame = 0;
        timer = 0;

        if(idleSprite != null)
        {
            spriteRenderer.sprite = idleSprite;
        }

    }


}


