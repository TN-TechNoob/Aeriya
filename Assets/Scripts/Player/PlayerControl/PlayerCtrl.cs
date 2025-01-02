using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    private enum State
    {
        Normal,
        Dashing,
        Shield
    }

    private PlayerControls playerControls;
    private Rigidbody2D rb;
    public float moveSpeed, dashSpeed;
    public bool isAttacking, isShielding;
    public bool perfectReduce;
    public float perfectReduceTime;
    public Vector2 movement, lastMoveDir;
    private Vector2 moveDir, dashDir;
    private State state;
    public Animator animator;

    private void Awake()
    {
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    void Start()
    {
        state = State.Normal;
    }

    void Update()
    {

        switch (state)
        {
            case State.Normal:

                PlayerInput();

                // * 取得角色翻滾Input
                if (Input.GetKeyDown(KeyCode.LeftShift) && !isAttacking)
                {
                    dashDir = lastMoveDir;
                    dashSpeed = 10f;
                    state = State.Dashing;
                    // isDashButtonDown = true;
                }

                if (Input.GetMouseButtonDown(1))
                {
                    perfectReduceTime = 2f;
                    perfectReduce = true;
                    isShielding = true;
                    animator.SetBool("IsShielding", true);
                    state = State.Shield;
                }

                break;


            case State.Dashing:

                // * 角色翻滾 + 動畫
                float dashSpeedDropMultiplier = 1f;
                dashSpeed -= dashSpeed * dashSpeedDropMultiplier * Time.deltaTime;
                animator.SetBool("IsDashing", true);

                float dashSpeedMinimum = 5f;
                if (dashSpeed < dashSpeedMinimum)
                {
                    state = State.Normal;
                    animator.SetBool("IsDashing", false);
                }

                break;

            case State.Shield:

                Debug.Log("Right click press");
                if (Input.GetMouseButtonUp(1))
                {
                    perfectReduce = false;
                    isShielding = false;
                    animator.SetBool("IsShielding", false);
                    state = State.Normal;
                }

                if (perfectReduceTime > 0)
                {
                    perfectReduceTime -= Time.deltaTime;
                }
                else
                {
                    perfectReduce = false;
                    perfectReduceTime = 0f;
                }
                
                break;
        }
    }


    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Normal:
                Move();
                break;
            case State.Dashing:
                Dash();
                break;
        }
    }

    private void PlayerInput()
    {
        movement = playerControls.Movement.Move.ReadValue<Vector2>();
        moveDir = new Vector2(movement.x, movement.y).normalized;
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (movement.x != 0 || movement.y != 0)
        {
            lastMoveDir = moveDir;

            animator.SetFloat("X", movement.x);
            animator.SetFloat("Y", movement.y);
        }
    }

    public void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    public void Dash()
    {
        rb.MovePosition(rb.position + movement * (dashSpeed * Time.fixedDeltaTime));
    }

    public void CheckMouse1Hold()
    {
        if (Input.GetMouseButton(1))
        {
            animator.SetBool("IsShielding", true);
        }
    }
}

