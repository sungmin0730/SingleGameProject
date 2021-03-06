using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillattackState : StateMachineBehaviour
{
    Transform boss2Transform;
    boss2 boss2;
    Boss1 boss1;
    Transform boss1Transform;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss2 = animator.GetComponent<boss2>();
        boss2Transform = animator.GetComponent<Transform>();
        boss1 = animator.GetComponent<Boss1>();
        boss1Transform = animator.GetComponent<Transform>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
     
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss2.skillatkDelay = boss2.skillatkCooltime;
    }
}
