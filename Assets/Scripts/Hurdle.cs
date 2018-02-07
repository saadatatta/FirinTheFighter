using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurdle : MonoBehaviour {
    private float damageTime = 0f;
    private float nextDamageDuration = 1f; 
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            damageTime += Time.deltaTime;
            if (damageTime > nextDamageDuration)
            {
                damageTime = 0;
                int health = collision.gameObject.GetComponent<Player>().PlayerHealth -= 5;
                collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();

                if (health <= 0)
                {
                    GameManager.Instance.IsPlayerAlive = false;
                }
            }
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


}
