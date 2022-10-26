using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnAround : Action
{
    private Animator ani;
    private static Transform ori;
    public override void OnAwake()
    {
        ori = gameObject.transform;
        ani = gameObject.GetComponentInChildren<Animator>();
    }
    public override TaskStatus OnUpdate()
    {
        gameObject.transform.localScale = new Vector3(-ori.localScale.x, ori.localScale.y);
        
        return TaskStatus.Success;
    }
}
