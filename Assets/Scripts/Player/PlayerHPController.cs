using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHPController : MonoBehaviour
{
    public GameObject[] HP;
    public GameObject player;

    void Update()
    {
        if (player != null)
        {
            for (int i = 0; i <= 3; i++)
            {
                if (i == player.GetComponent<PlayerController>().PlayerHealth)
                {
                    HP[i].SetActive(true);
                }
                else
                {
                    HP[i].SetActive(false);
                }
            }
        }
    }
}
