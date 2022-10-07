using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Skill
{
    public class CharacterSkillManager : MonoBehaviour
    {
        public SkillData[] skills; // 技能列表

        private void Start()
        {
            for(int i=0; i<skills.Length; i++)
            {
                InitSkill(skills[i]);
            }
        }

        /// <summary>
        /// 初始化技能
        /// </summary>
        /// <param name="data"></param>
        private void InitSkill(SkillData data)
        {
            //prefabName --> skillPrefab
            data.skillPrefab = Resources.Load<GameObject>("Skill/" + data.prefabName);
            data.owner = gameObject;
        }

        public SkillData PrepareSkill(int id)
        {
            SkillData data = Find(id);
            if (data != null && data.coolRemain <= 0)
                return data;
            else
                return null;
        }

        private SkillData Find(int id)
        {
            for(int i=0; i<skills.Length; i++)
            {
                if(skills[i].skillID == id)
                {
                    return skills[i];
                }
            }
            return null;
        }

        /// <summary>
        /// 生成技能
        /// </summary>
        public void GenerateSkill(SkillData data)
        {
            //创建技能预制体
            GameObject skillGo = Instantiate(data.skillPrefab, transform.position, transform.rotation);

            //销毁技能
            Destroy(skillGo, data.durationTime);

            //技能冷却
            StartCoroutine(CoolTimeDown(data));
        }

        /// <summary>
        /// 技能冷却
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private IEnumerator CoolTimeDown(SkillData data)
        {
            data.coolRemain = data.coolTime;
            while (data.coolRemain > 0)
            {
                yield return new WaitForSeconds(1);
                data.coolRemain--;
            }
        }
    }


}