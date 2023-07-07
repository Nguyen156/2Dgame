using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public enum EnemyState { idle, patrol, attack, death }

public class Rino : Character
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D coll;

    [SerializeField] float moveSpeed;
    [SerializeField] float bounceForce;
    [SerializeField] float gravity;

    EnemyState enemyState;

    float time;
   
    internal bool isDeath;

    Vector2 startPos;
    public Player target;
    

    private void Start()
    {
        isRight = false;
        startPos.x = Random.Range(20, 38);
        startPos.y = transform.position.y;
        ChangeState(EnemyState.idle);
    }

    private void Update()
    {
        if (!isDeath)
        {
            UpdateState(enemyState);
            SetTarget();
        }
       
    }

    public void ChangeState(EnemyState state)
    {
        enemyState = state;
        switch (state)
        {
            case EnemyState.idle:
                time = Random.Range(3f, 6f);
                ChangeAnim("idle");
                break;

            case EnemyState.patrol:
                time = Random.Range(3f, 4f);
                ChangeAnim("run");
                break;

            case EnemyState.attack:
                ChangeAnim("run");
                break;

            case EnemyState.death:
                ChangeAnim("hit");
                break;
        }
    }


    void UpdateState(EnemyState state)
    {
        time -= Time.deltaTime;
        switch (state)
        {
            case EnemyState.idle:
                if(time <= 0f)
                {
                    ChangeState(EnemyState.patrol);
                }

                break;

            case EnemyState.patrol:
                if(time <= 0f)
                {
                    ChangeState(EnemyState.idle);
                    rb.velocity = Vector2.zero;
                }
                rb.velocity = isRight ? Vector2.right * moveSpeed : Vector2.left * moveSpeed;

                break;

            case EnemyState.attack:
                if(target != null)
                {
                    if (target.transform.position.x < transform.position.x && isRight == true || target.transform.position.x > transform.position.x && isRight == false)
                    {
                        Flip();
                    }
                    rb.velocity = isRight ? Vector2.right * moveSpeed : Vector2.left * moveSpeed;
                }
                else
                {
                    ChangeState(EnemyState.patrol);
                }
                break;

        }
    }

    public void Hit()
    {
        isDeath = true;
        ChangeState(EnemyState.death);
        coll.isTrigger = true;
        rb.velocity = new Vector2(0f, bounceForce);
        rb.gravityScale = gravity;
        Invoke(nameof(ReSpawn), 3f);
    }

    void ReSpawn()
    {
        isDeath = false;
        transform.position = startPos;
        ChangeState(EnemyState.idle);
        coll.isTrigger = false;
        rb.gravityScale = 1;
    }

    public void SetTarget()
    {
        if (target != null)
        {
            ChangeState(EnemyState.attack);
        }
    }
}
