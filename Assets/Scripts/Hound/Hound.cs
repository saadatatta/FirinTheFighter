using UnityEngine;

public class Hound : MonoBehaviour {

    private Transform player;
    private Rigidbody2D rb;
    private Animator animator;
    private GroundDetecter groundDetecter;
    private PlayerSearcher playerSearcher;
    private bool movingRight = true;
    private float nextJumpTime = 2f;
    private float currentTime = 0f;

    [SerializeField] private float speed;

    private void Awake()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
        groundDetecter = transform.GetComponent<GroundDetecter>();
        playerSearcher = transform.GetComponent<PlayerSearcher>();
    }

    private void Start()
    {
        player = GameManager.Instance.Player;

    }

    private void Update()
    {
        currentTime += Time.deltaTime;

        if (playerSearcher.IsPlayerInRange && currentTime > nextJumpTime)
        {
            rb.AddForce(new Vector2(transform.localScale.x, 1)*10000,ForceMode2D.Force);
            animator.SetTrigger(MagicStrings.Jump);
            currentTime = 0f;
            
        }

        if(rb.velocity.magnitude != 0)
        {
            animator.SetBool(MagicStrings.Run, true);
        }
        else
        {
            animator.SetBool(MagicStrings.Run, false);
        }
    }

    private void FixedUpdate()
    {
        if (playerSearcher.IsPlayerInRange)
            return;
        if (movingRight)
            rb.velocity = new Vector2(speed, 0);
        else
            rb.velocity = new Vector2(-speed, 0);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int health = collision.gameObject.GetComponent<Player>().PlayerHealth -= 5;
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x, 1) * 5000, ForceMode2D.Force);
            if (health <= 0)
            {
                GameManager.Instance.IsPlayerAlive = false;
            }

        }
    }

    private void TurnAround()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, 1, 1);
        movingRight = !movingRight;
    }

}
