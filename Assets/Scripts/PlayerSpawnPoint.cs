
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PlayerSpawnPoint : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            GameManager.Instance.PlatformFallSpawnPosition = this.transform;
        }
    }
}
