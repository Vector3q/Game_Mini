using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeAttackDetect : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("BeAttack:" + collision.gameObject.name);
            Player.GetComponent<PlayerController>().isBeAttacked = true;
        }
    }
}
