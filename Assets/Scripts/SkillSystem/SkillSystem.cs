using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Skill
{
    [RequireComponent(typeof(CharacterSkillManager))]
    public class SkillSystem : MonoBehaviour
    {

        private CharacterSkillManager skillManager;
        private Animator anim;
        private SkillData skill;

        private void Start()
        {
            skillManager = GetComponent<CharacterSkillManager>();

            //获取动画器
            anim = GetComponentInChildren<Animator>();
            //AnimatorEventBehavior?
        }
        /// <summary>
        /// 玩家使用技能
        /// </summary>
        public void AttackUseSkill(int skillID)
        {
            //准备技能
            skill = skillManager.PrepareSkill(skillID);
            if (skill == null) return;
            //播放动画
            anim.SetBool(skill.animationName,true);
            //之后放到动画播放时间段中
            skillManager.GenerateSkill(skill);
            //生成技能
        }
    }
}
