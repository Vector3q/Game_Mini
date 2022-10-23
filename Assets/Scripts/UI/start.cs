using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class start : MonoBehaviour
{
    public GameObject Open;
    public GameObject Close;
    public void ButtonPress()
    {
        Open.SetActive(true);
        Close.SetActive(false);

    }
}
