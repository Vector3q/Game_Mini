using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

    public event Action OnBossDie;
    public event Action OnPlayerDie;

    public void BossDie()
    {
        if (OnBossDie != null)
        {
            OnBossDie();
        }
    }

    public void PlayerDie()
    {
        if (OnPlayerDie != null)
        {
            OnPlayerDie();
        }
    }
}
