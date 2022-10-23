using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyState : MonoBehaviour
{
    public static bool isGround;
    public Animator enemyAnimator;

    private Rigidbody2D myrigidbody;
    private AnimatorStateInfo animaInfo;

    public int sheld, max_sheld;
    public int HP, max_HP;

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
        else
        {
            HP--;
            sheld = max_sheld;
        }
    }

private void AnimatorController()
    {
        animaInfo = enemyAnimator.GetCurrentAnimatorStateInfo(0);

        if(!isGround && myrigidbody.velocity.y < 0.5f && !animaInfo.IsName("Green Jump To Fall - Animation"))
        {
            enemyAnimator.Play("Green Jump To Fall - Animation");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Weapon") BeAttacked();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground") isGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground") isGround = false;
    }
    
}
