using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : Action
{
    public bool beAttack;
    public override TaskStatus OnUpdate()
    {
       
            gameObject.transform.position = new Vector3(Random.Range(-7, 7), gameObject.transform.position.y, gameObject.transform.position.z);
            return TaskStatus.Success;
      
    }
}
