using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonRangedEnemy : Enemy
{

    [SerializeField] private int _range = 10;
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private ushort attackDamage;
    [SerializeField] private float _timeBetweenAttacks = 2f;
    [SerializeField] private float _delayBeforeNextAttack;

    private float _previousFireTime;

    protected override void Start()
    {
        base.Start();
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector2 currentPosition = transform.position;
        Vector2 targetRange = SearchInRange(currentPosition);
        Gizmos.DrawLine(currentPosition, targetRange);
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

    void Update()
    {
        Vector2 currentPosition = transform.position;
        Vector2 targetRange = SearchInRange(currentPosition);
        RaycastHit2D hit = Physics2D.Linecast(currentPosition, targetRange, _layerMask);


        if (!hit)
        {
            ContinuePatrol();
            return;
        }

        if (hit.transform.tag == "Player")
        {
            ReadyForAttack(hit);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int health = collision.gameObject.GetComponent<Player>().PlayerHealth -= 5;
            collision.gameObject.GetComponentInChildren<ParticleSystem>().Play();
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(transform.localScale.x, 1)*5000,ForceMode2D.Force);
            if (health <= 0)
            {
                GameManager.Instance.IsPlayerAlive = false;
            }

        }
    }

    void ReadyForAttack(RaycastHit2D hit)
    {
        Vector2 targetPosition = GetPlayerPosition(hit);

        if (Time.time > _previousFireTime + _timeBetweenAttacks)
        {
            StartCoroutine(Attack(targetPosition));
        }


    }

    IEnumerator Attack(Vector2 targetPos)
    {
        while (Vector2.Distance(transform.position, targetPos) > 0.25f)
        {
            targetPos = new Vector2(targetPos.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * .1f);
            yield return null;
        }
        IsAttacking = true;
        IsWalking = false;
        _previousFireTime = Time.time; // current time to store for next fire
        Animator.SetTrigger("Attack");
        yield return new WaitForSeconds(_delayBeforeNextAttack);// wait for arrow to load

        StopCoroutine(Attack(targetPos));
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
