using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject load;
    private float duration = 3f;

    public GameObject EnterDialog;

    private float trigDelay = 1f;
    private float trigTimer;
    private bool corpTrig = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnterDialog.SetActive(true);
        if (collision.gameObject.tag == "Player")
        {
            corpTrig = true;
            //if (Input.GetKey(KeyCode.J))
            //{
            //    load.SetActive(true);

            //    Invoke(nameof(winLoad), duration);
            //}
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        if (Input.GetKey(KeyCode.J))
    //        {
    //            load.SetActive(true);

    //            Invoke(nameof(winLoad), duration);
    //        }
    //    }
    //}

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnterDialog.SetActive(false);
    }

    private void winLoad()
    {
        Debug.Log("——————————————————");
        SceneManager.LoadScene("Main_Scene");
    }

    private void enterNext()
    {
        load.SetActive(true);
        Invoke(nameof(winLoad), duration);
        trigTimer = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) && corpTrig)
        {
            trigTimer = Time.time + trigDelay;
        }

        if (trigTimer > Time.time)
        {
            enterNext();
        }
    }
}
