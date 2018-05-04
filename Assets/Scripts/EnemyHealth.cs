
using UnityEngine;

public class EnemyHealth : MonoBehaviour,IEnemyHealth
{
    private PlayerStats playerStats;
    private int damage = 10;

    [SerializeField] private int health;
    [SerializeField] private int deathExperience = 20;

    int IEnemyHealth.Health
    {
        get
        {
            return health;
        }
    }   

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
            SoundManager.Instance.PlayHurtSound(SoundManager.Instance.EnemyHurtClips,transform.name);
            ReceiveDamage(randomDamage);
        }

    }

    void ReceiveDamage(int amount)
    {
        int value = health -= amount;

        if (value <= 0)
        {
            playerStats.OnEnemyDeath += AddStats;
            
            Destroy(gameObject);
        }

    }

    void AddStats()
    {
        Debug.Log("Here in callback");
        playerStats.ExperienceStat.AddStat(deathExperience);
        playerStats.OnEnemyDeath -= AddStats;
    }

}
