using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAttack05 : Action
{
    private Animator ani;

    public override void OnAwake()
    {
        ani = gameObject.GetComponentInChildren<Animator>();
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        ani.Play("Rat_Hit");
        return TaskStatus.Success;
    }



}
