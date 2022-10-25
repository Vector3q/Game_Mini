using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAttack02 : Action
{
    private Animator ani;
    

    public override void OnAwake()
    {
        ani = gameObject.GetComponentInChildren<Animator>();
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if(enemyState.HP==0)
        {
            return TaskStatus.Running;
        }
        enemyState.HP -= 1;
        if(enemyState.HP == 0)
        {
            return TaskStatus.Running;
        }
        return TaskStatus.Success;
    }



}
