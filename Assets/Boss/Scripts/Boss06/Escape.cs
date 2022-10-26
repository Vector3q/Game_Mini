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

    public Vector3[] point;
    static private int index=0;
    public override void OnStart()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        point = new Vector3[3];
        point[0] = new Vector3(-30, 0, -1);
        point[1] = new Vector3(0, 0, -1);
        point[2] = new Vector3(30, 0, -1);
        ani = gameObject.GetComponentInChildren<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if(Boss06State.isGround)
        {
            var dir = point[index] - gameObject.transform.position + new Vector3(0, force, 0);
            gameObject.transform.localScale = new Vector2((gameObject.transform.position.x > target.transform.position.x ? 1 : -1)*gameObject.transform.localScale.x, gameObject.transform.localScale.y);
            ani.Play("StartJump");
            rb.AddForce(dir, ForceMode2D.Impulse);
            int add = Random.Range(0, 1);
            if (add == 0) add = -1;
            index = (index + add + 3) % 3;
        }
        
            return TaskStatus.Success;
      
    }
}
