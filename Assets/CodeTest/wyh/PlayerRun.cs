using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class PlayerRun : MonoBehaviour
{
    public CriAtomSource atomBsource;
    public float test;

    public void PlaySe(string cueName)
    {
        atomBsource.Play(cueName);
    }

}
