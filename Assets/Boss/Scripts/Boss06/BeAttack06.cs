using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAttack06 : Action
{
    private Animator ani;
    private SpriteRenderer mt;
    public Material[] mtls;


    public override void OnAwake()
    {
        ani = gameObject.GetComponentInChildren<Animator>();
        mt = gameObject.GetComponentInChildren<SpriteRenderer>();
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if(Boss06State.HP==0)
        {
            return TaskStatus.Running;
        }
        Boss06State.HP -= 1;
        StartCoroutine(recover());
        if(Boss06State.HP == 0)
        {
            mt.sharedMaterial = mtls[1];
            ani.Play("dead");
            GameEvents.current.BossDie();
            return TaskStatus.Running;
        }
        return TaskStatus.Success;
    }
    IEnumerator recover()
    {
        mt.material.SetColor("_Color", Color.red);
        mt.material.SetInt("_BeAttack", 1);
        yield return new WaitForSeconds(0.1f);
        mt.material.SetInt("_BeAttack", 0);
        yield break;
    }


}
