using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead : Action
{
    public override TaskStatus OnUpdate()
    {
        return TaskStatus.Running;
    }
}
