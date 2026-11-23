using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;

public class BombController : MonoBehaviour
{
    [SerializeField] private GameObject bombPrefab;
    [SerializeField] private GameObject explosionPrefab;

    public InputAction placeBombAction;

    private PlayerStats stats;
    private int bombsRemaining;


    private void Awake()
    {
        stats = GetComponent<PlayerStats>();
    }

    private void OnEnable()
    {
        bombsRemaining = stats.BombAmount;
        placeBombAction.Enable();
    }

    private void OnDisable()
    {
        placeBombAction.Disable();
    }

    private void Update()
    {


        if (bombsRemaining > 0 && placeBombAction.WasPressedThisFrame())
        {
            PlaceBomb();
        }
    }


    private void PlaceBomb()
    {
        Vector2 position = transform.position;

        position.x = Mathf.Round(position.x);
        position.y = Mathf.Round(position.y);

        GameObject bombObject = Instantiate(bombPrefab, position, Quaternion.identity);
        Bomb bomb = bombObject.GetComponent<Bomb>();

        bomb.Initialize(this);

        bombsRemaining--;

    }

    public void ReturnBomb()
    {
        bombsRemaining++;
    }

}


