using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    bool startFight = false;

    public GameObject InfoUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player" && !startFight)
        {
            // 浮现对话框
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player" && !startFight)
        {
            if(Input.GetKeyDown(KeyCode.J)){
                InfoUI.SetActive(true);
                startFight = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // 对话框消失
    }
}
