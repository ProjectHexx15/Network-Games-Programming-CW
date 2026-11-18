using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class BombController : MonoBehaviour
{
    // move these values to the player status, bomb controller should only manage bombs and explosions
    private float bombFuseTime = 3f;
    public int bombAmount = 1;
    public int bombsRemaining;

    private int explosionRadius = 2;

    public InputAction placeBombAction;
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject explosionPrefab;

    public ExplosionState explostate { get; private set; } = ExplosionState.Start;

    private void OnEnable()
    {
        bombsRemaining = bombAmount;
        placeBombAction.Enable();
    }

    private void OnDisable()
    {
        placeBombAction.Disable();
    }

    private void Update()
    {
        if (bombsRemaining >= 0 && placeBombAction.WasPressedThisFrame())
        {
            Debug.Log("im bombing it!");
            StartCoroutine(PlaceBomb());
        }
    }


    private IEnumerator PlaceBomb()

    {
        Vector2 position = transform.position;

        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        bombsRemaining--;

        yield return new WaitForSeconds(bombFuseTime);

        Destroy(bomb);

        GameObject explosion = Instantiate(explosionPrefab, position, Quaternion.identity);

        Destroy(explosion, 0.5f);

        bombsRemaining++;

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            other.isTrigger = false;
        }
    }

    private void SpawnExplosion(Vector2 position)
    {
        Instantiate(explosionPrefab, position, Quaternion.identity);
    }

}

