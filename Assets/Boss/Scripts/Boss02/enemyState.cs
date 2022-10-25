using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyState : MonoBehaviour
{
    public static bool isGround;
    public Animator enemyAnimator;

    private Rigidbody2D myrigidbody;
    private SpriteRenderer mt;
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
        mt = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        AnimatorController();
        if (Input.GetKeyDown(KeyCode.A)) BeAttacked();
    }

    private void BeAttacked()
    {
        if (sheld > 0)
        {
            StartCoroutine(recover());
            sheld--;
        }
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


    IEnumerator recover()
    {
        mt.material.SetColor("_Color", Color.white);
        mt.material.SetInt("_BeAttack", 1);
        yield return new WaitForSeconds(0.1f);
        mt.material.SetInt("_BeAttack", 0);
        yield break;
    }
}
