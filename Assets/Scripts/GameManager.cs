using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Transform _player;

    private int currentLevel = 1;
    private Timer _timer;
    private bool _isPlayerAlive = true;

    public bool IsPlayerAlive
    {
        get { return _isPlayerAlive; }
        set { _isPlayerAlive = value; }
    }

    public int CurrentLevel
    {
        get { return currentLevel; }
    }

    public void IncrementLevel()
    {
        currentLevel += 1;
    }

    public Timer Timer
    {
        get
        {
            if (_timer == null)
                _timer = GetComponent<Timer>();
            return _timer;
        }
    }

    public Transform Player
    {
        get { return _player; }
    }

    void Awake()
    {
        Assert.IsNotNull(_player);
    }

    private void LateUpdate()
    {
        if (!IsPlayerAlive && _player != null)
        {
            Destroy(_player.gameObject);
        }
    }

}
