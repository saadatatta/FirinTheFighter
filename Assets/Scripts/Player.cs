using System.Collections;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Button _jumpButton;
    [SerializeField] private Button _attackButton;
    [SerializeField] private Button powerButton;
    [SerializeField] private int _jumpHeight = 1000;
    [SerializeField] private PlayerProjectile swordSliceParticles;
    [SerializeField] private Slider powerSlider;
    [SerializeField] private ushort powerConsumptionDecrement;

    private ushort powerMaxValue = 100;
    private float powerCooldownValue;

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
        Assert.IsNotNull(powerButton);
        Assert.IsNotNull(swordSliceParticles);
        Assert.IsNotNull(powerSlider);
    }

    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _jumpButton.onClick.AddListener(OnJumpButtonPressed);
        _attackButton.onClick.AddListener(OnAttackButtonPressed);
        powerButton.onClick.AddListener(OnPowerButtonPressed);
        maxHealth += HealthStatValues.GetHealthStatValues(PlayerStats.Instance.CurrentHealthLevel);
        currentPlayerHealth = maxHealth;
        PlayerStats.Instance.OnHealthUpgrade += ChangePlayerHealth;
        StartCoroutine(UpdatePower());
        SetPowerUpValues();
        
    }

    IEnumerator UpdatePower()
    {
        powerCooldownValue += 5;
        powerCooldownValue = Mathf.Clamp(powerCooldownValue, 0, powerMaxValue);
        powerSlider.value = powerCooldownValue / powerMaxValue;
        yield return new WaitForSeconds(2);
        StartCoroutine(UpdatePower());
    }

    void SetPowerUpValues()
    {
        powerCooldownValue = powerMaxValue;
        powerSlider.value = 1f;
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
            _animator.SetTrigger(MagicStrings.PlayerJump);
            _canJump = false;
            GameManager.Instance.Timer.Add(EnableJump,1f);
            _rigidbody2D.AddForce(Vector2.up*_jumpHeight, ForceMode2D.Impulse);
        }
    }

    void OnAttackButtonPressed()
    {
        //The player swings the sword.
        _animator.SetTrigger(MagicStrings.PlayerAttack);
    }

    void OnPowerButtonPressed()
    {
        //if player has enough power to perform special attack.
        if (powerCooldownValue - powerConsumptionDecrement >= powerConsumptionDecrement)
        {
            powerCooldownValue -= powerConsumptionDecrement;
            powerCooldownValue = (ushort)Mathf.Clamp(powerCooldownValue, 0, powerMaxValue);
            _animator.SetTrigger(MagicStrings.PlayerPowerAttack);
            powerSlider.value = powerCooldownValue / powerMaxValue;
            GameManager.Instance.Timer.Add(FireProjectile, 0.5f);
        }
    }

    void FireProjectile()
    {
        PlayerProjectile projectile = Instantiate(swordSliceParticles, transform.position, Quaternion.identity);

        if ((int)transform.localScale.x == -1)
        {

            projectile.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectile.Speed, 0);
        }
        if ((int)transform.localScale.x == 1)
        {
            projectile.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(projectile.Speed, 0);
        }
    }

    void EnableJump()
    {
        _canJump = true;
    }
}
