using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAttack04 : Action
{
    private Animator ani;
    // Start is called before the first frame update
    public override void OnStart()
    {
        ani = gameObject.GetComponentInChildren<Animator>();
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        ani.Play("Golem_Hit_A");
        return TaskStatus.Success;
    }
}
