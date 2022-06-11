using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleState1 : StateMachineBehaviour
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
        if (Vector2.Distance(boss1Transform.position, boss1.player.position) <= 50f && Vector2.Distance(boss1Transform.position, boss1.player.position) > 4f) // 플레이어와 보스1의 거리가 50이하일경우 실행
            animator.SetBool("Iswalk", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
