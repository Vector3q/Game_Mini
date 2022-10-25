using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_1 : Action
{
    public Transform target;
    public ScreenShake screen;

    public float jump_force;
    public bool jumping;
    public float speed;

    private Vector2 tmp_target;
    private Rigidbody2D myrigidbody;
    public Animator enemyAnimator;
    private AnimatorStateInfo animaInfo;

    float distance;
    float direction;

    public override void OnAwake()
    {
        enemyAnimator = gameObject.GetComponentInChildren<Animator>();
        myrigidbody = gameObject.GetComponent<Rigidbody2D>();
        jumping = false;
        base.OnAwake();
    }

    public override TaskStatus OnUpdate()
    {
        animaInfo = enemyAnimator.GetCurrentAnimatorStateInfo(0);
        if (target == null) return TaskStatus.Failure;
        //if (enemyState.isGround && !jumping && !animaInfo.IsName("Green Jump Start-up - Animation"))
        if (enemyState.isGround && !jumping && !animaInfo.IsName("StartJump"))
        {
            //enemyAnimator.Play("Green Jump Start-up - Animation");
            enemyAnimator.Play("StartJump");
            tmp_target = target.position;
            direction = transform.position.x - tmp_target.x < 0 ? 1 : -1;
            transform.localScale = new Vector3(direction, 1, 1);
        }
        //if(animaInfo.IsName("Green Jump Start-up - Animation") && animaInfo.normalizedTime>=0.9f && !jumping)
         if (animaInfo.IsName("StartJump") && animaInfo.normalizedTime >= 0.9f && !jumping)
            {
            jumping = true;
            myrigidbody.gravityScale = 1f;
            myrigidbody.AddForce(Vector2.up * jump_force, ForceMode2D.Impulse);
        }
        if(jumping)
        {
            float x = transform.position.x;
            x += (tmp_target.x - transform.position.x) * speed * Time.deltaTime;
            transform.position = new Vector3(x, transform.position.y, -1f);
            if (myrigidbody.velocity.y <= 0f)
            {
                myrigidbody.gravityScale = 10f;
                screen.CallShake();
                jumping = false;
                return TaskStatus.Success;
            }
            
        }
        return TaskStatus.Running;
    }


}
