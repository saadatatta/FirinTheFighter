using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;

    private Transform _player;

    void Start()
    {
        _player = GameManager.Instance.Player;
    }

    private void LateUpdate()
    {
        if (GameManager.Instance.IsPlayerAlive)
        {
           transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z) + offset;
        }
    }
}
