using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour,IEnemy
{
    [SerializeField] private float _speed;
    [SerializeField] protected int health;

    private EnemyCombatLevel enemyCombatLevel;

    protected Animator Animator;
    protected bool MovingRight = true;
    protected bool IsAttacking;
    protected bool IsWalking = true;

    private Waypoint _waypoint;
    
    public int Health
    {
        //Health will change as the level progresses.
        get { return health * enemyCombatLevel.CombatLevel; }
        set { health = value; }

    }

    protected virtual void Start()
    {
        Animator = GetComponent<Animator>();
        _waypoint = GetComponent<Waypoint>();
        enemyCombatLevel = GetComponent<EnemyCombatLevel>();
        StartCoroutine(PatrolInCheckPoints());

    }

    public virtual void PerformAttack()
    {
        //Perform the default Attack.
        Animator.SetBool("Attack",true);
    }

    public virtual void TakeDamage(int amount)
    {
        // Receive damage from player.
    }

    IEnumerator PatrolInCheckPoints()
    {
        if (GameManager.Instance.IsPlayerAlive)
        {
            Vector2 nextWaypoint = _waypoint.MoveTowardsNextWaypoint();
            Animator.SetBool("Walk", IsWalking); // Set walking toward waypoint.
            while (Vector2.Distance(transform.position, nextWaypoint) > 0)
            {
                while (IsAttacking)
                {
                    yield return null;
                    Animator.SetBool("Walk", IsWalking); // Stop until attack mode
                }
                Animator.SetBool("Walk", IsWalking); // Player died or out of range
                transform.position = Vector2.MoveTowards(transform.position, nextWaypoint, _speed*Time.deltaTime);
                yield return null;
            }
            Animator.SetBool("Walk", false); // Reached waypoint.Stop for 2 seconds.

            yield return new WaitForSeconds(2f);

            TurnAround();
            StartCoroutine(PatrolInCheckPoints());
        }
    }

    /// <summary>
    /// Enemy changes face direction on reaching target waypoint.
    /// </summary>
    private void TurnAround()
    {
        MovingRight = !MovingRight;
        transform.localScale = new Vector3(transform.localScale.x*-1, 1, 1);
    }
}
