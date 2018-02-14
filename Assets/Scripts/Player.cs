using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Button _jumpButton;
    [SerializeField] private Button _attackButton;
    [SerializeField] private int _jumpHeight;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private bool _canJump = true;
    private int maxHealth = 100;
    private int currentPlayerHealth = 100;

    public int MaxHealth
    {
        get { return maxHealth; }
    }
    public int PlayerHealth
    {
        get { return currentPlayerHealth; }
        set { currentPlayerHealth = value; }
    }

    void Awake()
    {
        Assert.IsNotNull(_jumpButton);
        Assert.IsNotNull(_attackButton);
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _jumpButton.onClick.AddListener(OnJumpButtonPressed);
        _attackButton.onClick.AddListener(OnAttackButtonPressed);
        maxHealth += HealthStatValues.GetHealthStatValues(PlayerStats.Instance.CurrentHealthLevel);
        currentPlayerHealth = maxHealth;
        PlayerStats.Instance.OnHealthUpgrade += ChangePlayerHealth;
    }

    /// <summary>
    /// This function is called when player upgrades its health.
    /// </summary>
    void ChangePlayerHealth()
    {
        maxHealth += HealthStatValues.GetHealthStatValues(PlayerStats.Instance.CurrentHealthLevel);
    }
    
    void OnJumpButtonPressed()
    {
        if (_canJump)
        {
            // The player jumps.
            _animator.SetTrigger("Jump");
            _canJump = false;
            GameManager.Instance.Timer.Add(EnableJump,1f);
            _rigidbody2D.AddForce(Vector2.up*300, ForceMode2D.Force);
        }
    }

    void OnAttackButtonPressed()
    {
        //The player swings the sword.
        _animator.SetTrigger("Attacking");
    }

    void EnableJump()
    {
        _canJump = true;
    }
}
