using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject load;
    private float duration = 3f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                load.SetActive(true);

                Invoke(nameof(winLoad), duration);
                
            }
        }
    }

    private void winLoad()
    {
        Debug.Log("——————————————————");
        SceneManager.LoadScene("MainScene");
    }
}
