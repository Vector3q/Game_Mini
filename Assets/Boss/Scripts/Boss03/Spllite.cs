using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spllite : MonoBehaviour
{
    private Animator ani;
    public GameObject Self;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ani.Play("SpikedSlime_Death");
            if(gameObject.transform.localScale.x>=0.6)
            {
                
                var another = GameObject.Instantiate(Self, gameObject.transform.position, gameObject.transform.rotation);
                another.transform.localScale = new Vector3(gameObject.transform.localScale.x / 1.14f, gameObject.transform.localScale.y / 1.14f, gameObject.transform.localScale.z / 1.14f);
                gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x / 1.14f, gameObject.transform.localScale.y / 1.14f, gameObject.transform.localScale.z / 1.14f);
                ani.Play("SpikedSlime_Ability");
            }
        }

    }
}
