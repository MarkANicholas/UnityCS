using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomOnStateEnter : StateMachineBehaviour
{
    private animRandomiser anim;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (anim == null)
        {
            anim = animator.gameObject.GetComponent<animRandomiser>();
        }
        anim.getRandomIdle(); 
    }
}
