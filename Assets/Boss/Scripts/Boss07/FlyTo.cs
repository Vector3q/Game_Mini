using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTo : Action
{
    public Vector2 target;
    public GameObject Bullet;
    public float fireSpeed;
    public float speed;

    public float time;
    private float c_time;

    public override void OnStart()
    {
        c_time = Time.time;
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (Time.time - c_time >= time)
        {
            var bullet=GameObject.Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, fireSpeed);
            c_time = Time.time;
        }
            
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target, speed);
        if(Mathf.Abs(gameObject.transform.position.x-target.x)>=0.1f)
             return TaskStatus.Success;
        return TaskStatus.Running;
    }

}