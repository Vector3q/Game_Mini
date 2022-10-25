using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isBreak : Action
{
    private Animator ani;

    public override void OnAwake()
    {
        ani = gameObject.GetComponentInChildren<Animator>();
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if (enemyState.sheld <= 0)
        {
            ani.Play("break");
            return TaskStatus.Success; 
        }
        return TaskStatus.Failure;
    }
}
