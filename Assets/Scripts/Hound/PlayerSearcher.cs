
using UnityEngine;

public class PlayerSearcher : MonoBehaviour {

    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float yOffset;

    private int range = 10;
    
    public bool IsPlayerInRange { get; private set; }

    private Vector2 SearchInRange(Vector2 currentPosition)
    {
        Vector2 targetRange;
        if (transform.localScale.x == 1)
        {
            targetRange = new Vector2(currentPosition.x + range, currentPosition.y + yOffset);
        }
        else
        {
            targetRange = new Vector2(currentPosition.x - range, currentPosition.y + yOffset);
        }
        return targetRange;
    }

    void Update()
    {
        Vector2 currentPosition = transform.position;
        Vector2 targetRange = SearchInRange(currentPosition);
        RaycastHit2D hit = Physics2D.Linecast(currentPosition, targetRange, layerMask);
        
        //if not hitting anything.
        if (!hit)
        {
            IsPlayerInRange = false;
            return;
        }

        if (hit.transform.tag == "Player")
        {
            IsPlayerInRange = true;
            Debug.Log("Player found");
        }
        
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector2 currentPosition = transform.position;
        Vector2 targetRange = SearchInRange(currentPosition);
        Gizmos.DrawLine(currentPosition, targetRange);
    }
}
