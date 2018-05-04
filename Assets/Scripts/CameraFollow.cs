using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private float smoothTime = 1.0f;

    private Transform _player;
    private Vector3 previousPosition;
    private Vector3 targetVelocity;

    void Start()
    {
        _player = GameManager.Instance.Player;
        previousPosition = transform.position;
    }

    private void LateUpdate()
    {
        if (GameManager.Instance.IsPlayerAlive)
        {
            Vector3 targetPosition = new Vector3(_player.position.x, _player.position.y, transform.position.z) + offset;
            Vector3 dampedPos = Vector3.SmoothDamp(previousPosition, targetPosition, ref targetVelocity, smoothTime);
            transform.position = dampedPos;
            previousPosition = dampedPos;
        }
    }
}
