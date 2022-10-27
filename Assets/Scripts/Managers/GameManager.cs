using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public static int skillID = 8;

    public Game.Skill.SkillData[] SkillPool;

    public enum GameState
    {
        RUNNING,
        GAMEOVER
    }

    public GameState State;

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning("GameManager already exists");
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        //DontDestroyOnLoad(this.gameObject);
    }
}
