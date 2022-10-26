using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rest : Action
{
    public Rigidbody2D rb;
    private Animator ani;
    public GameObject arrey;
    // Start is called before the first frame update
    public override void OnStart()
    {
        arrey = GameObject.FindGameObjectWithTag("Respawn");
        rb = gameObject.GetComponent<Rigidbody2D>();
        ani = gameObject.GetComponentInChildren<Animator>();
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {

        rb.velocity = new Vector2(0, 0);
        gameObject.transform.position = new Vector3(Random.Range(-20, 20), 1.7f, -1);
        ani.Play("rest");
        arrey.SetActive(false);
        arrey.SetActive(true);
        return TaskStatus.Success;
    }
}
