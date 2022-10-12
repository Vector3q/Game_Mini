using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CriWare;

public class CuePlay : MonoBehaviour
{
    private CriAtomSource atomSrc;

    void Start()
    {
        /* CriAtomSource ��� */
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
            /* CriAtomSource ״̬��� */
            CriAtomSource.Status status = atomSrc.status;
            if ((status == CriAtomSource.Status.Stop) || (status == CriAtomSource.Status.PlayEnd))
            {
                /* ����ֹͣ״̬���Բ��� */
                atomSrc.Play();
            }
            else
            {
                /* ֹͣ���� */
                atomSrc.Stop();
            }
        }
    }
}