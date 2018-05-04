using System.Linq;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Transform _player;

    private int currentLevel = 1;
    private Timer _timer;
    private bool _isPlayerAlive = true;
    private bool playerDeathAlreadyActivated = false;
    private Transform currentLevelSpawnPosition; // When player dies
    private Transform platformFallSpawnPosition; // When player falls from platform

    private Animator playerAnimator;

    public Transform CurrentLevelSpawnPosition
    {
        get { return currentLevelSpawnPosition; }
        set { if (value != null) currentLevelSpawnPosition = value; }
    }

    public Transform PlatformFallSpawnPosition
    {
        get { return platformFallSpawnPosition; }
        set { if (value != null) platformFallSpawnPosition = value; }
    }

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
        playerAnimator = _player.GetComponent<Animator>();
    }

    private void Update()
    {
        if (!_isPlayerAlive && !playerDeathAlreadyActivated)
        {
            OnPlayerDeath();
            playerDeathAlreadyActivated = true;
        }
    }

    private void OnLevelWasLoaded()
    {
        // if game over do nothing
        if (SceneManager.GetActiveScene().name == MagicStrings.GameOver)
            return;

        Transform levelStartPosition = GameObject.Find(MagicStrings.LevelStartPosition).transform;
        _player.position = levelStartPosition.position;
        currentLevelSpawnPosition = levelStartPosition;
        _player.GetComponent<Animator>().SetBool(MagicStrings.PlayerRunning, false);
        
    }

    /// <summary>
    /// Call this method when the player falls from platform and need to respawn.
    /// </summary>
    public void OnPlatformFall()
    {
        if (!_isPlayerAlive)  // Health is zero. No need to respawn.
        {
            LoadGameOverScene();
            return;
        }
        _player.position = platformFallSpawnPosition.position;
    }

    public void OnPlayerHurt()
    {
        playerAnimator.SetTrigger(MagicStrings.PlayerHurt);
    }

    public void OnPlayerDeath()
    {
        if (!_isPlayerAlive)
        {
            _player.GetComponent<Rigidbody2D>().simulated = false;

            playerAnimator.SetTrigger(MagicStrings.PlayerDeath);

            Instance.Timer.Add(SinkPlayer, 2f);

        }
    }

    void SinkPlayer()
    {
        Destroy(_player.gameObject);
        LoadGameOverScene();
    }

    void LoadGameOverScene()
    {
        SceneManager.LoadScene(MagicStrings.GameOver);
    }

}
