using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss06State : MonoBehaviour
{
    public Animator ani;
    private SpriteRenderer mt;

    public int max_sheld;
    public int max_HP;
    static public int HP, sheld;
    // Start is called before the first frame update
    void Start()
    {
        sheld = max_sheld;
        HP = max_HP;
        ani = gameObject.GetComponentInChildren<Animator>();
        mt = gameObject.GetComponentInChildren<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void BeAttacked()
    {
        if (sheld > 0)
        {
            StartCoroutine(recover());
            sheld--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon") BeAttacked();
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