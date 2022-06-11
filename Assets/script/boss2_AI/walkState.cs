using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walkState : StateMachineBehaviour
{
    Transform boss2Transform;
    boss2 boss2;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss2 = animator.GetComponent<boss2>();
        boss2Transform = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (boss2.player.position.x - boss2Transform.position.x > 0)
        {
            boss2Transform.localScale = new Vector3(-1, 1, 1);
        }    
        else
        {
            boss2Transform.localScale = new Vector3(1, 1, 1);
        }
        if (Vector2.Distance(boss2.player.position, boss2Transform.position) > 4f)
            boss2Transform.position = Vector3.MoveTowards(boss2Transform.position, new Vector3(boss2.player.position.x, boss2Transform.position.y, boss2Transform.position.z), Time.deltaTime * boss2.speed);
        else
        {
            animator.SetBool("Iswalk", false);
        }
        if (Vector2.Distance(boss2.player.position, boss2Transform.position) <= 50f && boss2.skillatkDelay <= 0)
            animator.SetTrigger("SkillAttack");
 
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
