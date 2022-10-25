using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyState : MonoBehaviour
{
    public static bool isGround;
    public Animator enemyAnimator;

    private Rigidbody2D myrigidbody;
    private AnimatorStateInfo animaInfo;

    public int max_sheld;
    public int max_HP;
    static public int HP,sheld;

    private void Awake()
    {
        sheld = max_sheld;
        HP = max_HP;
        enemyAnimator = gameObject.GetComponentInChildren<Animator>();
        myrigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        AnimatorController();
        if (Input.GetKeyDown(KeyCode.A)) BeAttacked();
    }

    private void BeAttacked()
    {
        if (sheld > 0) sheld--;
    }

private void AnimatorController()
    {
        animaInfo = enemyAnimator.GetCurrentAnimatorStateInfo(0);
        enemyAnimator.SetBool("isGround", isGround);

        //if(!isGround && myrigidbody.velocity.y < 0.5f && !animaInfo.IsName("Green Jump To Fall - Animation"))
        //{
        //    enemyAnimator.Play("Green Jump To Fall - Animation");
        //}
        if (!isGround && myrigidbody.velocity.y < 0.5f && !animaInfo.IsName("JumpToFall"))
        {
            enemyAnimator.Play("JumpToFall");
        }
    }

    
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Weapon") BeAttacked();
        if (collision.tag == "Ground") isGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground") isGround = false;
    }
    
}
