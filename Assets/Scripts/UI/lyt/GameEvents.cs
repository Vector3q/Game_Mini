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

    public event Action onBossDie;
    public event Action onPlayerDie;

    public void BossDie()
    {
        if (onBossDie != null)
        {
            onBossDie();
        }
    }

    public void PlayerDie()
    {
        if (onPlayerDie != null)
        {
            onPlayerDie();
        }
    }
}
