using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBalls : Action
{
    public Rigidbody2D rb;
    public GameObject FireBall;
    private Animator ani;

    public float offset;
    
    public int index;
    public int num;
    public int[] Ct = { 0, 1, 2, 3, 2, 1, 0 };
    public override void OnAwake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        ani = gameObject.GetComponentInChildren<Animator>();
        index = Random.Range(-14, 14);
        num = 0;
    }
    public override TaskStatus OnUpdate()
    {
        rb.velocity = new Vector2(0, 0);
        for(int i=-15;i<=15;i++)
        {   
            if(i<=index-Ct[num] || i>=index+Ct[num])
            {
                var ball = GameObject.Instantiate(FireBall, new Vector3(1.0f * i * 2 +Random.Range(-offset,offset), 9+ Random.Range(-0.02f,0.02f), 0), gameObject.transform.rotation);
                ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
            }
        }
        num++;
        if (num >= 6) { num = 0;

            index = Random.Range(-14, 14);
        }
        return TaskStatus.Success;
    }
}
