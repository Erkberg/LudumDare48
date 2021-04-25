using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator animator;

    private const string IsMovingBool = "IsMoving";
    private const string DashTrigger = "Dash";

    public void SetMoving(bool moving)
    {
        animator.SetBool(IsMovingBool, moving);
    }

    public void TriggerDash()
    {
        animator.SetTrigger(DashTrigger);
    }
}
