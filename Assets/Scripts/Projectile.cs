
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float _timeToLive;
    [SerializeField] private int _damageAmount;

	// Use this for initialization
	void Start () {
		Destroy(gameObject,_timeToLive);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            int health = other.GetComponent<Player>().PlayerHealth -= _damageAmount;
            other.GetComponentInChildren<ParticleSystem>().Play();
            if (health <= 0)
            {
                GameManager.Instance.IsPlayerAlive = false;
                Destroy(other.gameObject);
            }
            Destroy(gameObject); // Destroy the projectile
        }
    }
}
