using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float fuseTime = 3f;

    private BombController owner;

    public void Initialize(BombController bombController)
    {
        owner = bombController;

        StartCoroutine(Fuse());
    }

    private IEnumerator Fuse()
    {
        yield return new WaitForSeconds(fuseTime);

        Explode();
    }

    private void Explode()
    {
        ExplosionManager explosionManager = FindFirstObjectByType<ExplosionManager>();

        if (explosionManager != null)
        {
            explosionManager.CreateExplosion(transform.position);

        }

        owner.ReturnBomb();

        Destroy(gameObject);
    }

}
