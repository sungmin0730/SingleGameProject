using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState : StateMachineBehaviour
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
        if (Vector2.Distance(boss2Transform.position, boss2.player.position) <= 50) // 플레이어와 보스2의 거리가 4이하일경우 실행
            animator.SetBool("Iswalk", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
