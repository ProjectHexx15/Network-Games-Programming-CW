using UnityEngine;

public class ExplosionSpriteController : MonoBehaviour
{
    [SerializeField] private ExplosionSpriteAnimation spriteAnimation;

    private ExplosionController explosion;

    public void SetExplosion(ExplosionController explosionController)
    {
        explosion = explosionController;

        ApplyDirection();
        PlayAnimation();
    }

    private void ApplyDirection()
    {
        switch (explosion.Direction)
        {
            case ExplosionDirection.Center:
                transform.rotation = Quaternion.identity;
                break;

            case ExplosionDirection.Up:
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                break;

            case ExplosionDirection.Left:
                transform.rotation = Quaternion.Euler(0f, 0f, 180f);
                break;

            case ExplosionDirection.Down:
                transform.rotation = Quaternion.Euler(0f, 0f, 270f);
                break;

            default:
                transform.rotation = Quaternion.identity;
                break;

        }
    }

    private void PlayAnimation()
    {
        spriteAnimation.Play(explosion.State);
    }

    public void StopAnimation()
    {
        spriteAnimation.Stop();
    }


}
