using UnityEngine;

// Controls the movement of the player independantly from where input is recieved

public class MovementController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;

    public Vector2 MovementInput { get; private set; }

    public FacingDirection Facing { get; private set; } = FacingDirection.Down;

    public bool IsMoving => MovementInput != Vector2.zero;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetInput(Vector2 input)
    {
        MovementInput = input;

        if (input == Vector2.up)
        {
            Facing = FacingDirection.Up;
        }
        else if (input == Vector2.down)
        {
            Facing = FacingDirection.Down;
        }
        else if (input == Vector2.left)
        {
            Facing = FacingDirection.Left;
        }   
        else if (input == Vector2.right)
        {
            Facing = FacingDirection.Right;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = MovementInput * speed;
    }
}
