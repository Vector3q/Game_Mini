using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceToU : MonoBehaviour
{
    public GameObject target;
    public static int HP;
    private SpriteRenderer mt;
    private Vector3 ori;
    // Start is called before the first frame update
    void Start()
    {
        ori = new Vector3(3.5f, 3.5f, 3.5f);
        target = GameObject.FindGameObjectWithTag("Player");
        HP = 5;
        mt = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3((gameObject.transform.position.x > target.transform.position.x ? 1 : -1)*ori.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Weapon") StartCoroutine(recover());
    //}

    IEnumerator recover()
    {
        mt.material.SetColor("_Color", Color.red);
        mt.material.SetInt("_BeAttack", 1);
        yield return new WaitForSeconds(0.1f);
        mt.material.SetInt("_BeAttack", 0);
        yield break;
    }
}
