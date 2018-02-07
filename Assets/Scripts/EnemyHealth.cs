using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private Enemy _enemy;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "sword")
        {
            ReceiveDamage(10);
        }

    }

    void ReceiveDamage(int amount)
    {
        int health = _enemy.Health -= amount;

        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
	
}
