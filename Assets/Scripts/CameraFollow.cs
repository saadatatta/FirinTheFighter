using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _cameraSpeed;
    [SerializeField] private Vector3 offset;

    private Transform _player;
    private Vector2 _currentVelocity;
    private float _smoothTime;
    private float _maxSpeed;


    void Start()
    {
        _player = GameManager.Instance.Player;
    }

    private void Update()
    {
        if (GameManager.Instance.IsPlayerAlive)
        {
           transform.position = new Vector3(_player.position.x, transform.position.y, transform.position.z) + offset;
        }
    }
}
