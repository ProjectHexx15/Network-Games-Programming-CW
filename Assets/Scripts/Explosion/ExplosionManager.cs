using UnityEngine;
using UnityEngine.Tilemaps;

public class ExplosionManager : MonoBehaviour
{
    // temp for working version of destruction
    public Tilemap destructibleTiles;
    public GameObject obstaclePrefab;

    [SerializeField] private GameObject explosionPrefab;

    [SerializeField] private int defaultRadius = 2;

    [SerializeField] private float explosionDuration = 0.5f;

    [SerializeField] private LayerMask explosionLayerMask;


    public void CreateExplosion(Vector2 center)
    {
        CreatePiece(center, ExplosionState.Start, ExplosionDirection.Center);

        Explode(center, Vector2.up, defaultRadius);
        Explode(center, Vector2.down, defaultRadius);
        Explode(center, Vector2.left, defaultRadius);
        Explode(center, Vector2.right, defaultRadius);
    }

    private void Explode(Vector2 position, Vector2 direction, int length)
    {
        for (int i = 1; i <= length; i++)
        {
            Vector2 nextPosition = position + direction * i;

            Collider2D hit = Physics2D.OverlapPoint(nextPosition, explosionLayerMask);

            if (hit != null)
            {
                if(hit.CompareTag("Destructable"))
                {
                    ClearTile(nextPosition);
                }

                Debug.Log("Blocked by: " + hit.name);
                break;
            }

            ExplosionState state = i == length ? ExplosionState.End : ExplosionState.Middle;

            CreatePiece(nextPosition, state, GetDirection(direction));
        }


    }

    private void CreatePiece(Vector2 position, ExplosionState state, ExplosionDirection direction)
    {
        GameObject piece = Instantiate(explosionPrefab, position, Quaternion.identity);

        piece.GetComponent<ExplosionController>().Initialize(state, direction);

        Destroy(piece, explosionDuration);
    }

    private ExplosionDirection GetDirection(Vector2 direction)
    {
        if (direction == Vector2.up)
        {
            return ExplosionDirection.Up;
        }

        if (direction == Vector2.down)
        {
            return ExplosionDirection.Down;
        }

        if (direction == Vector2.left)
        {
            return ExplosionDirection.Left;
        }

        return ExplosionDirection.Right;
    }


    private void ClearTile(Vector2 position)
    {
        Vector3Int cell = destructibleTiles.WorldToCell(position);
        TileBase tile = destructibleTiles.GetTile(cell);

        if(tile != null)
        {
            Instantiate(obstaclePrefab, position, Quaternion.identity);
            destructibleTiles.SetTile(cell, null);
            Debug.Log("IM GONNA CLEAR YA!");
        }
    }


}

