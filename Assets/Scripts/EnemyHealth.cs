using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private PlayerStats playerStats;
    
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int deathExperience;

    private void Awake()
    {
        playerStats = PlayerStats.Instance;

    }

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
            playerStats.OnEnemyDeath += AddStats;
            
            Destroy(gameObject);
        }

    }

    void AddStats(ExperienceStat stat)
    {
        Debug.Log("Here in callback");
        BaseStat baseStat = new BaseStat("Experience", StatType.ExperienceStat, deathExperience);
        playerStats.ExperienceStat.AddStat(baseStat);
        playerStats.OnEnemyDeath -= AddStats;
    }

}
