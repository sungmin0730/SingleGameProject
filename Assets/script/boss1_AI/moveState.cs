using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveState : StateMachineBehaviour
{
    Boss1 boss1;
    Transform boss1Transform;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss1 = animator.GetComponent<Boss1>();
        boss1Transform = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (boss1.player.position.x - boss1Transform.position.x > 0)
        {
            boss1Transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            boss1Transform.localScale = new Vector3(1, 1, 1);
        }
        if (Vector2.Distance(boss1.player.position, boss1Transform.position) > 3f)
            boss1Transform.position = Vector3.MoveTowards(boss1Transform.position, new Vector3(boss1.player.position.x, boss1Transform.position.y, boss1Transform.position.z), Time.deltaTime * boss1.speed);
        else
        {
            animator.SetBool("Iswalk", false);
            if (boss1.atkDelay <= 0)
                animator.SetTrigger("Attack");
        }
        if (Vector2.Distance(boss1.player.position, boss1Transform.position) <= 50f && boss1.skillatkDelay <= 0)
        {
            animator.SetTrigger("SkillAttack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
