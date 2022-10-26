using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spllite : Action
{
    private Animator ani;
    public GameObject Self;

    public override void OnStart()
    {
        ani = gameObject.GetComponentInChildren<Animator>();
        base.OnStart();
    }

    public override TaskStatus OnUpdate()
    {
        if (gameObject.transform.localScale.x >= 0.6)
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x + gameObject.transform.localScale.x / 1.14f, gameObject.transform.position.y, gameObject.transform.position.z);

            var another = GameObject.Instantiate(Self,
                new Vector3(gameObject.transform.position.x - gameObject.transform.localScale.x / 1.14f, gameObject.transform.position.y, gameObject.transform.position.z),
                gameObject.transform.rotation);

            another.transform.localScale = new Vector3(gameObject.transform.localScale.x / 1.14f, gameObject.transform.localScale.y / 1.14f, gameObject.transform.localScale.z / 1.14f);
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x / 1.14f, gameObject.transform.localScale.y / 1.14f, gameObject.transform.localScale.z / 1.14f);
            ani.Play("Splite");
            return TaskStatus.Success;
        }
        return TaskStatus.Running;
    }
   
}
