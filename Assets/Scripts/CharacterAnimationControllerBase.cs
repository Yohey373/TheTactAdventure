using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationControllerBase : MonoBehaviour
{
    public Animator Animator;

    public const string Animation_Idle = "Idle";
    public const string Animation_Walk = "Walk";
    public const string Animation_Jump = "Jump";
    public const string Animation_Attack = "Attack";

    //protected bool isGround = false;

    protected void SetAnimation(string animationName)
    {
        // �����A�j���[�V������������A��
        if (Animator.GetCurrentAnimatorStateInfo(0).IsName(animationName))
        {
            return;
        }

        Animator.Play(animationName, 0);
    }

}
