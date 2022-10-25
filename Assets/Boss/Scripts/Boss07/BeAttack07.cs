using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAttack07 : Action
{
    private Animator ani;
    

    public override void OnAwake()
    {
        ani = gameObject.GetComponentInChildren<Animator>();
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if (Boss07State.HP == 0)
        {
            return TaskStatus.Running;
        }
        Boss07State.HP -= 1;

        if (Boss07State.HP == 0)
        {
            return TaskStatus.Running;
        }
        return TaskStatus.Success;
    }



}
