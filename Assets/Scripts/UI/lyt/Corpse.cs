using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    bool startFight = false;

    public GameObject InfoUI;

    public GameObject Dialog;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player" && !startFight)
        {
            Dialog.SetActive(true);
            if (Input.GetKey(KeyCode.J))
            {
                InfoUI.SetActive(true);
                startFight = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player" && !startFight)
        {
            if(Input.GetKey(KeyCode.J)){
                InfoUI.SetActive(true);
                startFight = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Dialog.SetActive(false);
    }
}
