using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBalls : Action
{
    public GameObject FireBall;
    public float offset;
    public int OFFset;

    public int index;
    public int num;
    public int[] Ct = { 0, 1, 2, 3, 2, 1, 0 };
    public override void OnAwake()
    {
        index = Random.Range(-14, 14);
        num = 0;
    }
    public override TaskStatus OnUpdate()
    {
        Debug.Log(index);
        for(int i=-14;i<=14;i++)
        {   
            if(i<=index-Ct[num] || i>=index+Ct[num])
            {
                var ball = GameObject.Instantiate(FireBall, new Vector3(1.0f * i / 2 +Random.Range(-offset,offset), 10+ Random.Range(-0.02f,0.02f), 0), gameObject.transform.rotation);
                ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1);
            }
        }
        num++;
        if (num >= 6) { num = 0;
            if(index<-2)
                index = index + Random.Range(3-OFFset, 3+OFFset);
            else if(index>2)
                index = index + Random.Range(-3-OFFset, -3+OFFset);
            else 
                index = index + Random.Range(-OFFset, OFFset);
            if (index >= 14) index = 14;
            else if (index <= -14) index = -14;
        }
        return TaskStatus.Success;
    }
}
