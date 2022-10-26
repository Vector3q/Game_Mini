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
    private Animator ani;
    private AnimatorStateInfo animaInfo;
    bool canShoot = false;

    public override void OnStart()
    {
        ani = gameObject.GetComponentInChildren<Animator>();
        c_count = 0;
        c_time = Time.time;
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        while(c_count<max_count)
        {
            if (Time.time-c_time>=time)
            {
                ani.Play("Smash_unbreak");
                canShoot = true;
                c_time = Time.time;
                c_count++;
            }
            animaInfo = ani.GetCurrentAnimatorStateInfo(0);
            if (animaInfo.IsName("Smash_unbreak")&&animaInfo.normalizedTime>=0.9f&&canShoot)
            {
                canShoot = false;
                var bullet_L = GameObject.Instantiate(bullet, this.transform.position, this.transform.rotation);
                var bullet_R = GameObject.Instantiate(bullet, transform.position, transform.rotation);
                var rbL = bullet_L.GetComponent<Rigidbody2D>();
                var rbR = bullet_R.GetComponent<Rigidbody2D>();
                rbL.velocity = new Vector2(15, 0);
                rbR.velocity = new Vector2(-15, 0);
                bullet_R.transform.localScale = new Vector3(0.6f, 0.5f, 1);
                bullet_L.transform.localScale = new Vector3(-0.6f, 0.5f, 1);
            }
            return TaskStatus.Running;
        }
        animaInfo = ani.GetCurrentAnimatorStateInfo(0);
        while (animaInfo.IsName("Smash_unbreak"))
        {
            animaInfo = ani.GetCurrentAnimatorStateInfo(0);
            if (animaInfo.normalizedTime >= 0.9f && canShoot)
            {
                canShoot = false;
                var bullet_L = GameObject.Instantiate(bullet, this.transform.position, this.transform.rotation);
                var bullet_R = GameObject.Instantiate(bullet, transform.position, transform.rotation);
                var rbL = bullet_L.GetComponent<Rigidbody2D>();
                var rbR = bullet_R.GetComponent<Rigidbody2D>();
                rbL.velocity = new Vector2(15, 0);
                rbR.velocity = new Vector2(-15, 0);
                bullet_R.transform.localScale = new Vector3(0.6f, 0.5f, 1);
                bullet_L.transform.localScale = new Vector3(-0.6f, 0.5f, 1);
            }
            return TaskStatus.Running;
        }
        c_count = 0;
        return TaskStatus.Success;
    }
}
