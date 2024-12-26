using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{

    private enum State
    {
        Normal,
        Dashing,
        Attacking,
        Shield
    }

    public CapsuleCollider2D capsuleCollider2D;
    private PlayerControls playerControls;
    private PlayerCombat_V2 playerCombat_V2;
    private Rigidbody2D rb;
    public float moveSpeed, dashSpeed, shieldCoolDown;
    public Vector2 movement, lastMoveDir;
    private Vector2 moveDir, dashDir;
    private State state;
    public Animator animator;

    private void Awake()
    {
        playerCombat_V2 = GetComponent<PlayerCombat_V2>();
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
                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    dashDir = lastMoveDir;
                    dashSpeed = 10f;
                    state = State.Dashing;
                    // isDashButtonDown = true;
                }

                if (Input.GetMouseButtonDown(1))
                {
                    shieldCoolDown = 0.5f;
                    state = State.Shield;
                }

                if (Input.GetMouseButtonDown(0))
                {
                    state = State.Attacking;
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

            case State.Attacking:

                playerCombat_V2.Attack();
                state = State.Normal;

                break;

            case State.Shield:

                //float shieldCoolDownMuiltiplier = 1f;
                capsuleCollider2D.enabled = false;
                animator.SetTrigger("IsShielding");
                shieldCoolDown -= Time.deltaTime;

                if (shieldCoolDown <= 0)
                {
                    capsuleCollider2D.enabled = true;
                    animator.SetBool("IsShielding", false);
                    state = State.Normal;

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
}
