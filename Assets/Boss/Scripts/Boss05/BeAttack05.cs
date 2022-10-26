using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAttack05 : Action
{
    private Animator ani;
    private SpriteRenderer mt;


    public override void OnAwake()
    {
        ani = gameObject.GetComponentInChildren<Animator>();
        mt = gameObject.GetComponentInChildren<SpriteRenderer>();
        base.OnAwake();
    }
    public override TaskStatus OnUpdate()
    {
        if (Boss05State.HP == 0)
        {
            return TaskStatus.Running;
        }
        ani.Play("Rat_Hit");
        Boss05State.HP -= 1;
        StartCoroutine(recover());
        if (Boss05State.HP==0)
        {
            ani.Play("Rat_Death");
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
