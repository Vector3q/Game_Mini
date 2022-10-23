using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : Action
{
    private Animator ani;
    public override void OnStart()
    {
        ani = gameObject.GetComponentInChildren<Animator>();
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        ani.Play("strike");
        gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x,gameObject.transform.localScale.y);
        return TaskStatus.Success;
    }
}
