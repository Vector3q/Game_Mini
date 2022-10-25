using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class Click_Play : MonoBehaviour
{

    public CriAtomSource A_source;
    public void PlaySound()
    {
        if (A_source != null)
        {
            A_source.Play();
        }
    }
}
