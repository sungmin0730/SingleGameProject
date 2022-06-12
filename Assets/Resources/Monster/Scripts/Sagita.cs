using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sagita : Monster
{

    public GameObject arrow;

    protected override void Start()
    {
        base.Start();
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
        yield return new WaitForSeconds(0.8f);

        GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation);
        newArrow.transform.right = dir;
        newArrow.GetComponent<Rigidbody2D>().velocity = dir * 20f;
        
        yield return new WaitForSeconds(0.2f);

        isAttacking = false;
        anim.SetBool("isAttacking", false);
    }

}
