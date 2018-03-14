
using UnityEngine;

public class GroundDetecter : MonoBehaviour {

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 3f);

        if (hit.collider == false)
        {
            SendMessageUpwards("TurnAround", SendMessageOptions.DontRequireReceiver);
        }
    }
}
