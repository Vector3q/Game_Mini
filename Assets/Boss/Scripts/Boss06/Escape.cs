using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : Action
{
    public Animator ani;
    public float force;
    public GameObject target;
    public Rigidbody2D rb;
    public override void OnStart()
    {
        ani = gameObject.GetComponentInChildren<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        gameObject.transform.localScale = new Vector2(gameObject.transform.position.x > target.transform.position.x ? 1 : -1, 1);
        ani.Play("StartJump");
        rb.AddForce(new Vector2(gameObject.transform.position.x > target.transform.position.x ? 1 : -1, 1) * force, ForceMode2D.Impulse);
            return TaskStatus.Success;
      
    }
}
