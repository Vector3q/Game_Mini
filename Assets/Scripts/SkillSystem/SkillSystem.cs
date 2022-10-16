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

            //��ȡ������
            anim = GetComponentInChildren<Animator>();
            //AnimatorEventBehavior?
        }
        /// <summary>
        /// ���ʹ�ü���
        /// </summary>
        public void AttackUseSkill(int skillID)
        {
            //׼������
            skill = skillManager.PrepareSkill(skillID);
            if (skill == null) return;
            //���Ŷ���
            anim.SetBool(skill.animationName,true);
            //֮��ŵ���������ʱ�����
            skillManager.GenerateSkill(skill);
            //���ɼ���
        }
    }
}
