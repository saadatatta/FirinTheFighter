using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private PlayerStats playerStats;
    private int damage = 10;
    
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
            int avgDamage = AttackStatValues.GetAttackStatValues(playerStats.CurrentAttackLevel) * damage;
            int minDamage = Mathf.RoundToInt((avgDamage * 2) / Random.Range(2.1f, 2.9f));
            int maxDamage = avgDamage * 2 - minDamage;
            int randomDamage = Random.Range(minDamage, maxDamage);
            ReceiveDamage(randomDamage);
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
