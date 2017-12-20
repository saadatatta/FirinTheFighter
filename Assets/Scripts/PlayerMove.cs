using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Button _jumpButton;
    [SerializeField] private Button _attackButton;
    [SerializeField] private int _jumpHeight;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private bool _canJump = true;

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
    }

    
    void OnJumpButtonPressed()
    {
        if (_canJump)
        {
            // The player jumps.
            _animator.SetTrigger("Jump");
            _canJump = false;
            GameManager.Instance.Timer.Add(EnableJump,1f);
            _rigidbody2D.AddForce(Vector2.up*250, ForceMode2D.Force);
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
