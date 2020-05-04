using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemainingExercise : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int remaining = animator.GetInteger("ExerciseParameter");
        if (remaining > 0)
        {
            animator.SetInteger("ExerciseParameter", remaining - 1);
        }
    }
}
