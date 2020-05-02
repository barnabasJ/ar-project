using UnityEngine;

public class PushUpController : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int PushUpsRemaining = animator.GetInteger("PushUpsRemaining");
        if (PushUpsRemaining > 0)
        {
            animator.SetInteger("PushUpsRemaining", PushUpsRemaining - 1);
        }
    }
}
