using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlankController : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int PlankRemaining = animator.GetInteger("PlankTimeMultiplier");
        if (PlankRemaining > 0) {
            animator.SetInteger("PlankTimeMultiplier", PlankRemaining - 1);
        }
    }

}
