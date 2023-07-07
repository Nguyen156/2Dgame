using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D coll;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    [SerializeField] float moveSpeed = 7f;
    [SerializeField] float jumpForce = 12f;

    public float direct;
    internal bool isDeath;
    bool onGround;
    bool canJump;
    bool canDoubleJump;
    bool isUseButton;
    Vector3 savePoint;


    // Start is called before the first frame update
    void Start()
    {
        isRight = true;
        SavePoint(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDeath)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        onGround = Physics2D.OverlapBox(groundCheck.position, new Vector2(0.5f, 0.25f), 0, groundLayer);

        if(!isUseButton)
        {
            HandleInput();
        }
        
        if(direct < 0f && isRight || direct > 0 && !isRight)
        {
            Flip();
        } 

        UpdateAnim();
    }

    private void FixedUpdate()
    {
        if (isDeath)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        Move();
        
        if (canJump)
        {
            Jump(jumpForce);
            canJump = false;
        }
    }

    public void MoveControl(float direct)
    {
        this.direct = direct;
        isUseButton = direct != 0;

    }

    public void JumpControl()
    {
        if (onGround)
        {
            canJump = true;
            canDoubleJump = true;
        }
        else
        {
            if(canDoubleJump)
            {
                canJump = true;
                canDoubleJump = false;
            }
        }
    }

    void HandleInput()
    {
        direct = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (onGround)
            {
                canJump = true;
                canDoubleJump = true;

            }
            else
            {
                if (canDoubleJump)
                {
                    canJump = true;
                    canDoubleJump = false;
                }
            }
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(direct * moveSpeed, rb.velocity.y);
    }

    public void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, force);
    }

    


    public void SavePoint(Vector3 newSavePoint)
    {
        savePoint = newSavePoint;
    }

    void LoadSavePoint()
    {
        isDeath = false;
        coll.isTrigger = false;
        ChangeAnim("idle");
        transform.position = savePoint;
    }

    public void Hit()
    {
        isDeath = true;
        ChangeAnim("hit");
        Jump(jumpForce);
        coll.isTrigger = true;
        Invoke(nameof(LoadSavePoint), 2.5f);
    }


    void UpdateAnim()
    {
        if (onGround)
        {
            if(Mathf.Abs(direct) > 0)
            {
                ChangeAnim("run");
            }
            else
            {
                ChangeAnim("idle");
            }

            if (canJump)
            {
                ChangeAnim("jump");
            }
        }
        else
        {
            if (rb.velocity.y < 0f)
            {
                ChangeAnim("fall");
            }

            if (canJump)
            {
                ChangeAnim("double_jump");
            }
        }
    }

    
}
