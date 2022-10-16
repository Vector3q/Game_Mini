using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SkillSelectManager : MonoBehaviour
{
    private static SkillSelectManager _instance;
    public static SkillSelectManager Instance { get { return _instance; } }

    public Game.Skill.CharacterSkillManager player;

    public int[] playerSkill;

    private void Awake()
    {
        if(_instance != null)
        {
            Debug.LogWarning("SkillSelectManager already exists");
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }

        UnityEngine.SceneManagement.SceneManager.sceneLoaded += (scene,mode) =>
        {
            if(scene.name == "GameScene")
            {
                FindPlayer();
                SkillSelectManager.Instance._copySkills();
                GameManager.Instance.State = GameManager.GameState.RUNNING;
            }
        }
    }
    void Start()
    {
        playerSkill = new int[2];
    }

    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Game.Skill.CharacterSkillManager>();
    }

    public void _copySkills(Game.Skill.CharacterSkillManager target, int[] skillId)
    {
        target.skills = new Game.Skill.SkillData[skillId.Length];
        for(int i=0; i<skillId.Length; i++)
        {
            target.skills[i] = GameManager.Instance.SkillPool.First(x => x.skillID == skillId[i]).Clone() as Game.Skill.SkillData;
        }
    }
    public void _copySkills()
    {
        player.skills = new Game.Skill.SkillData[4];
        for(int i=0; i<4; i++)
        {
            player.skills[i] = GameManager.Instance.SkillPool.First(x => x.skillID == playerSkill[i]).Clone() as Game.Skill.SkillData;
        }
    }
}
