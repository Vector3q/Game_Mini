using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class CuePlay : MonoBehaviour
{
    private CriAtomSource atomSrc;

    void Start()
    {
        /* CriAtomSource 获得 */
        atomSrc = (CriAtomSource)GetComponent("CriAtomSource");
    }

    public void PlaySound()
    {
        if (atomSrc != null)
        {
            atomSrc.Play();
        }
    }

    public void PlayAndStopSound()
    {
        if (atomSrc != null)
        {
            /* CriAtomSource 状态获得 */
            CriAtomSource.Status status = atomSrc.status;
            if ((status == CriAtomSource.Status.Stop) || (status == CriAtomSource.Status.PlayEnd))
            {
                /* 处于停止状态可以播放 */
                atomSrc.Play();
            }
            else
            {
                /* 停止播放 */
                atomSrc.Stop();
            }
        }
    }
}