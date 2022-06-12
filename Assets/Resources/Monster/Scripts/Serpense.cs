using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serpense : Monster
{

    public CapsuleCollider2D attackCollider;

    protected override void Start()
    {
        base.Start();
        attackCollider = GetComponent<CapsuleCollider2D>();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void StartAttack()
    {
        base.StartAttack();

        isAttacking = true;
        anim.SetBool("isAttacking", true);

        StartCoroutine("Attack");
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.6f);

        isAttacking = false;
        anim.SetBool("isAttacking", false);
    }

}
