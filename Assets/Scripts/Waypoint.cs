using UnityEngine;

public class Waypoint : MonoBehaviour
{

    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypointIndex;

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 previousWaypoint = Vector2.zero;
        foreach (Transform waypoint in _waypoints)
        {
            Vector2 waypointPosition = waypoint.position;
            Gizmos.DrawWireSphere(waypointPosition,0.2f);
            if (previousWaypoint != Vector2.zero)
            {
                Gizmos.DrawLine(previousWaypoint,waypointPosition);
            }
            previousWaypoint = waypointPosition;
        }
    }

    /// <summary>
    /// Move the game object towards next waypoint.
    /// </summary>
    /// <returns>Vector2 position of the target waypoint.</returns>
    public Vector2 MoveTowardsNextWaypoint()
    {
        SetNextWaypoint();
        return _waypoints[_currentWaypointIndex].position;
        
    }

    
    private void SetNextWaypoint()
    {
        _currentWaypointIndex+=1;
        if (_currentWaypointIndex == _waypoints.Length)
        {
            _currentWaypointIndex = 0;
        }
    }
}
