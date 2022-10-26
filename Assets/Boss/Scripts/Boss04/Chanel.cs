using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chanel : Action
{
    private Animator ani;
    private Animator ani_a;
    private AnimatorStateInfo animaInfo;
    private bool flag;

    public GameObject arrey;

    public override void OnAwake()
    {
        flag = true;
        arrey = GameObject.FindGameObjectWithTag("Respawn");
        ani_a = arrey.GetComponent<Animator>();
        ani = gameObject.GetComponentInChildren<Animator>();
        base.OnAwake();
    }

    public override TaskStatus OnUpdate()
    {
        animaInfo = ani.GetCurrentAnimatorStateInfo(0);
        if(flag)
        {
            if(animaInfo.IsName("chanel"))
            {
                if(animaInfo.normalizedTime >= 0.9f)
                {
                    arrey.SetActive(false);
                    flag = false;
                }
                return TaskStatus.Running;
            }
            ani.Play("chanel");
            ani_a.Play("out");
            return TaskStatus.Running;
        }
        if (animaInfo.IsName("Attack") && animaInfo.normalizedTime >= 0.9f)
        { 
            gameObject.transform.position = new Vector3(99, 99);
            flag = true;
            return TaskStatus.Success;
        }
        gameObject.transform.position = new Vector3(0, 5);
        ani.Play("Attack");
        arrey.SetActive(true);
        ani_a.Play("out");


        return TaskStatus.Running;
    }
}
