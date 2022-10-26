using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAttack02 : Action
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
        if(enemyState.HP==0)
        {
            return TaskStatus.Running;
        }
        enemyState.HP -= 1;
        StartCoroutine(recover());
        if(enemyState.HP == 0)
        {
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
