using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : Action
{
    private int c_count;
    public int max_count;
    public float time;
    private float c_time;
    public GameObject bullet;
    public override void OnStart()
    {
        c_count = 0;
        c_time = Time.time;
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        while(c_count<max_count)
        {
            if(Time.time-c_time>=time)
            {
                Debug.Log("attack");

                var bullet_L= GameObject.Instantiate(bullet, this.transform.position, this.transform.rotation);
                var bullet_R = GameObject.Instantiate(bullet, transform.position, transform.rotation);
                var rbL = bullet_L.GetComponent<Rigidbody2D>();
                var rbR = bullet_R.GetComponent<Rigidbody2D>();
                rbL.velocity = new Vector2(10, 0);
                rbR.velocity = new Vector2(-10, 0);

                c_time = Time.time;
                c_count++;
            }
            return TaskStatus.Running;
        }
        c_count = 0;
        return TaskStatus.Success;
    }
}
