using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class PlayerAtomSourceFromAnimation : MonoBehaviour
{
    public CriAtomSource atomBsource;
    public float a;
   
    public void PlayAttack(string cueName)
    {
        atomBsource.Play(cueName);
    }

}
