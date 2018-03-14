
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
            GameManager.Instance.OnPlayerHurt();
            if (health <= 0)
            {
                GameManager.Instance.IsPlayerAlive = false;
                GameManager.Instance.OnPlayerDeath();
            }
            Destroy(gameObject); // Destroy the projectile
        }
        else if (other.tag == "Hurdle")
        {
            Destroy(gameObject);
        }

    }
}
