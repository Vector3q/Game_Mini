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

    public Transform[] point;
    static private int index=0;
    public override void OnStart()
    {
        ani = gameObject.GetComponentInChildren<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if(Boss06State.isGround)
        {
            var dir = point[index].position - gameObject.transform.position + new Vector3(0, force, 0);
            gameObject.transform.localScale = new Vector2(gameObject.transform.position.x > target.transform.position.x ? 1 : -1, 1);
            ani.Play("StartJump");
            rb.AddForce(dir, ForceMode2D.Impulse);
            int add = Random.Range(0, 1);
            if (add == 0) add = -1;
            index = (index + add + 3) % 3;
        }
        
            return TaskStatus.Success;
      
    }
}
