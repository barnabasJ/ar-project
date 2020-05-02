using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationExit : StateMachineBehaviour
{
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Destroy(animator.gameObject);
    }
}
