using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public ExplosionState State { get; private set; }
    public ExplosionDirection Direction { get; private set; }

    [SerializeField] private ExplosionSpriteController spriteController;

    public void Initialize(ExplosionState state, ExplosionDirection direction)
    {
        State = state;
        Direction = direction;

        spriteController.SetExplosion(this);
    }


}

