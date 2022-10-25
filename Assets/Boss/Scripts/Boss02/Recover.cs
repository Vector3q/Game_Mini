using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : Action
{
    private Animator ani;

    public override void OnAwake()
    {
        ani = gameObject.GetComponentInChildren<Animator>();
        base.OnAwake();
    }

    public override TaskStatus OnUpdate()
    {
        ani.Play("recover");
        enemyState.sheld = 20;
        return TaskStatus.Success;
    }
}
