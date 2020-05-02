using UnityEngine;

public class SitupController : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        int SitupsRemaining = animator.GetInteger("SitupsRemaining");
        if (SitupsRemaining > 0)
        {
            animator.SetInteger("SitupsRemaining", SitupsRemaining - 1);
        }
    }
}
