using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackState : StateMachineBehaviour
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

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss2.atkDelay = boss2.atkCooltime;
    }
}
