using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corpse : MonoBehaviour
{
    public bool startFight = false;
    

    public GameObject InfoUI;

    public GameObject Dialog;

    private float trigDelay = 2f;
    private float trigTimer;
    private bool corpTrig = false;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player" && !startFight)
        {
            Dialog.SetActive(true);
            //if (Input.GetKey(KeyCode.J))
            //{
            //    InfoUI.SetActive(true);
            //    startFight = true;
            //}
            corpTrig = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Dialog.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Dialog.SetActive(false);
        corpTrig = false;
    }

    private void openUI()
    {
        InfoUI.SetActive(true);
        startFight = true;
        trigTimer = 0;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.J) && corpTrig)
        {
            trigTimer = Time.time + trigDelay;
        }

        if(trigTimer > Time.time)
        {
            openUI();
        }
    }
}
