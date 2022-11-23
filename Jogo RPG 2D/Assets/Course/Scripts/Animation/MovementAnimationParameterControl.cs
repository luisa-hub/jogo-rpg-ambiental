using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimationParameterControl : MonoBehaviour
{
    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }


    private void OnEnable()
    {
        EventHandler.MovementEvent += SetAnimationParameter;
    }

    private void OnDisable()
    {
        EventHandler.MovementEvent -= SetAnimationParameter;
    }

    private void SetAnimationParameter(float xInput, float yInput, bool isWalking, bool isRunning, bool isIdle,  bool idleUp, bool idleDown,
    bool idleLeft, bool idleRight)
    {
        animator.SetFloat(Settings.xInput, xInput);
        animator.SetFloat(Settings.yInput, yInput);
        animator.SetBool(Settings.isWalking, isWalking);
        animator.SetBool(Settings.isRunning, isRunning);

        if (idleRight)
            animator.SetTrigger(Settings.idleRight);
        if (idleLeft)
            animator.SetTrigger(Settings.idleLeft);
        if (idleUp)
            animator.SetTrigger(Settings.idleUp);
        if (idleDown)
            animator.SetTrigger(Settings.idleDown);


    }


    private void AnimationEventPlayFootstepSound()
    { 
    }
}
