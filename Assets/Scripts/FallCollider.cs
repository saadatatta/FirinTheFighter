
using UnityEngine;

public class FallCollider : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Reduce player health.
            int health = GameManager.Instance.Player.GetComponent<Player>().PlayerHealth -= 20;

            if (health <= 0)
                GameManager.Instance.IsPlayerAlive = false;

            GameManager.Instance.OnPlatformFall();
        }
    }
}
