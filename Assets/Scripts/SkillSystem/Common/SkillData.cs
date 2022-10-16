using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Skill
{ 
    /// 技能数据
    [Serializable]
    public class SkillData
    {
        public int skillID; // 技能ID
        public string name; // 技能名称
        public string description; // 技能描述
        public float coolTime; // 冷却时间
        public float coolRemain; // 冷却剩余 
        public float attackDistance; // 攻击距离
        public string[] attackTargetTags;// 攻击对象tags

        [HideInInspector]
        public Transform[] attackTargets; // 攻击目标
        [Tooltip("技能效果名称列表")]
        public string[] impactType;
        public int nextBatterID; //连击编号
        public float atkRatio; //伤害比率
        public float durationTime; //持续时间
        public float atkInterval; //伤害间隔

        [HideInInspector]
        public GameObject owner;
        public string prefabName; // 技能预制件名称

        [HideInInspector]
        public GameObject skillPrefab;
        public string animationName; // 动画名称
        public string hitFxName; // 受击特效名称

        [HideInInspector]
        public GameObject hitFxPrefab;
        public SelectorType selectorType;
        
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        
    }
}
