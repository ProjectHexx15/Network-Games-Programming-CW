using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int bombAmount = 1;
    [SerializeField] private int blastRadius = 2;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private int health = 3;

    public int BombAmount => bombAmount;
    public int BlastRadius => blastRadius;
    public float MoveSpeed => moveSpeed;
    public int Health => health;

    public void AddBomb()
    {
        bombAmount++;
    }

    public void AddBlastRadius()
    {
        blastRadius++;
    }

    public void AddSpeed(float amount)
    {
        moveSpeed += amount;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

}
