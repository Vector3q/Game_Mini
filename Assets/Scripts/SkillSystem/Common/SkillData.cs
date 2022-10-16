using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Game.Skill
{ 
    /// ��������
    [Serializable]
    public class SkillData
    {
        public int skillID; // ����ID
        public string name; // ��������
        public string description; // ��������
        public float coolTime; // ��ȴʱ��
        public float coolRemain; // ��ȴʣ�� 
        public float attackDistance; // ��������
        public string[] attackTargetTags;// ��������tags

        [HideInInspector]
        public Transform[] attackTargets; // ����Ŀ��
        [Tooltip("����Ч�������б�")]
        public string[] impactType;
        public int nextBatterID; //�������
        public float atkRatio; //�˺�����
        public float durationTime; //����ʱ��
        public float atkInterval; //�˺����

        [HideInInspector]
        public GameObject owner;
        public string prefabName; // ����Ԥ�Ƽ�����

        [HideInInspector]
        public GameObject skillPrefab;
        public string animationName; // ��������
        public string hitFxName; // �ܻ���Ч����

        [HideInInspector]
        public GameObject hitFxPrefab;
        public SelectorType selectorType;
        
        public object Clone()
        {
            return this.MemberwiseClone();
        }
        
    }
}
