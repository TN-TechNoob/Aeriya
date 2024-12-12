using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class PlayerCombat : MonoBehaviour
{
    private PlayerCtrl playerCtrl;
    public Transform activeWeapon;
    private Animator animator;
    private PolygonCollider2D polygonCollider2D;


    void Awake()
    {
        playerCtrl = GetComponentInParent<PlayerCtrl>();
        animator = GetComponent<Animator>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
    }

    void Update()
    {
        WeaponFlip();


        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }


    private void WeaponFlip()
    {

        if (playerCtrl.lastMoveDir.x < 0)
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            activeWeapon.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().TakeDamage(10);
            Debug.Log("hit!");
        }
    }
}