using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Skill;
using UnityEngine.UI;
public class SkillChoose : MonoBehaviour
{
    public GameObject player;
    public Text skillText;
    public void changeSkillID_1()
    {
        GameManager.skillID = 1;

    }
    public void changeSkillID_2()
    {
        GameManager.skillID = 2;
    }
    public void changeSkillID_3()
    {
        GameManager.skillID = 3;
    }
    public void changeSkillID_4()
    {
        GameManager.skillID = 4;
    }
    public void changeSkillID_5()
    {
        GameManager.skillID = 5;
    }
    public void changeSkillID_6()
    {
        GameManager.skillID = 6;
    }
    public void changeSkillID_7()
    {
        GameManager.skillID = 7;
    }

    public void SelectSkill()
    {
        if(GameManager.skillID != 8)
        {
            player.GetComponent<CharacterSkillManager>().skills[0] = gameObject.GetComponent<GameManager>().SkillPool[GameManager.skillID - 1].Clone() as SkillData;
            player.GetComponent<CharacterSkillManager>().InitSkill(player.GetComponent<CharacterSkillManager>().skills[0]);
            skillText.text = player.GetComponent<CharacterSkillManager>().skills[0].name;
        }

    }
}
