using UnityEngine;
using System.Collections;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private float _timeToLive;
    [SerializeField] private int _damageAmount;
    [SerializeField] private ushort speed;

    public ushort Speed { get { return speed; } }

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, _timeToLive);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            int playerCurrentHealth = other.GetComponent<IEnemyHealth>().Health;
            int health =  playerCurrentHealth - _damageAmount;

            if (health <= 0)
            {
                Destroy(other.gameObject);
            }
            Destroy(gameObject); // Destroy the projectile
        }
        else if(other.tag =="Hurdle")
        {
            Destroy(gameObject);
        }
    }
}
