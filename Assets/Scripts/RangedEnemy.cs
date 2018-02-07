
using System.Collections;
using UnityEngine;

public class RangedEnemy : Enemy
{
    [SerializeField] private int _range = 10;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Projectile _projectile;
    [SerializeField]
    private float _projectileShootHeight = 0.45f;
    [SerializeField] private float _projectileShootSpeed;
    [SerializeField] private float _timeBetweenAttacks = 2f;
    [SerializeField] private float _delayBeforeSpawningProjectile;

    private float _previousFireTime;

    // Use this for initialization
	protected override void Start ()
	{
        base.Start();
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector2 currentPosition = transform.position;
        Vector2 targetRange = SearchInRange(currentPosition);
        Gizmos.DrawLine(currentPosition,targetRange);
    }

    private Vector2 SearchInRange(Vector2 currentPosition)
    {
        Vector2 targetRange;
        if (MovingRight)
        {
            targetRange = new Vector2(currentPosition.x + _range, currentPosition.y + 0.5f);
        }
        else
        {
           targetRange = new Vector2(currentPosition.x - _range, currentPosition.y + 0.5f);
        }
        return targetRange;
    }

    // Update is called once per frame
	void Update ()
	{
        Vector2 currentPosition = transform.position;
	    Vector2 targetRange = SearchInRange(currentPosition);
        RaycastHit2D hit = Physics2D.Linecast(currentPosition, targetRange, _layerMask);
        ContinuePatrol();
        //if not hitting anything.
	    if (!hit)
	    {
	        return;
	    }
	    if (hit.transform.tag == "Player")
	    {
	        ReadyForAttack(hit);
	    }
	}

    void ReadyForAttack(RaycastHit2D hit)
    {
        Vector2 targetPosition = GetPlayerPosition(hit);
        IsAttacking = true;
        IsWalking = false;
        if (Time.time > _previousFireTime +_timeBetweenAttacks)
        {
            StartCoroutine(FireArrow(targetPosition));
        }
      
        
    }

     IEnumerator FireArrow(Vector2 targetPos)
     {
         _previousFireTime = Time.time; // current time to store for next fire
         Animator.SetTrigger("Attack");
         yield return new WaitForSeconds(_delayBeforeSpawningProjectile);// wait for arrow to load
        Projectile newArrow = Instantiate(_projectile);
        
        newArrow.transform.position = new Vector3(transform.position.x, transform.position.y + _projectileShootHeight, 0);

        // Reverse arrow direction
        if ((int)transform.localScale.x == -1)
        {
            newArrow.transform.rotation = Quaternion.Euler(0, -180f, 0);
            newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(-_projectileShootSpeed,0);
        }
        if ((int)transform.localScale.x == 1)
        {
            newArrow.GetComponent<Rigidbody2D>().velocity = new Vector2(_projectileShootSpeed, 0);
        }
         yield return null;
         StopCoroutine(FireArrow(targetPos));
     }

    void ContinuePatrol()
    {
        IsAttacking = false;
        IsWalking = true;
    }

    public override void PerformAttack()
    {
        base.PerformAttack();
        

    }

    Vector2 GetPlayerPosition(RaycastHit2D hit)
    {
        return hit.point;
    }
}
