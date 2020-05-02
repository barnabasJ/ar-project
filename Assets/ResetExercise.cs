using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetExercise : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetInteger("ExerciseNumber", 0);
    }
}
