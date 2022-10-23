using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rush : Action
{
    public float c_dir;
    public float speed;
    public float dir;

    private Rigidbody2D rb;

    public override void OnAwake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        c_dir = dir;
        dir = Boss05State.dir;
        if (c_dir != dir)
            return TaskStatus.Success;
        rb.velocity = new Vector2(speed * c_dir, rb.velocity.y);
        
        return TaskStatus.Running;

    }
}
