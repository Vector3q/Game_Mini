using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetect : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D co)
    {
        if (PlayerController.AttackInput == true)
        {
            Debug.Log(co.name);
        }
    }
}
