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
        Boss05State.HP -= 1;
        if(Boss05State.HP==0)
        {
            ani.Play("Rat_Death");
            return TaskStatus.Failure;
        }
        return TaskStatus.Success;
    }



}
