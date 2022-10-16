using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game.Skill
{
    public class CharacterSkillManager : MonoBehaviour
    {
        [HideInInspector]
        public SkillData[] skills; // 技能列表
        public Animator anima = null;

        private void Start()
        {
            foreach(SkillData skill in skills)
            {
                this.InitSkill(skill);
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
            if(data.skillPrefab == null)
            {
                Debug.LogError("Skill prefab not found: " + data.prefabName);
                return;
            }
            data.owner = this.gameObject;
        }
        /// <summary>
        /// 根据技能ID获取技能数据，并检查技能是否可用
        /// </summary>
        /// <param name="id">技能ID</param>
        /// <returns>技能数据，不满足条件返回空</returns>
        public SkillData PrepareSkill(int id)
        {
            SkillData data = this.skills.First(x => x.skillID == id);

            if(data == null)
            {
                Debug.LogError("Skill not found: " + id);
                return null;
            }

            if (data.coolRemain <= 0)
                return data;
            else
                return null;
        }

        /// <summary>
        /// 生成技能
        /// </summary>
        /// <param name="data">技能数据</param>
        public void GenerateSkill(SkillData data)
        {
            if(data == null)
            {
                Debug.LogError("Cannot generate null skill");
                return;
            }
            //创建技能预制体
            GameObject skillGo = Instantiate(data.skillPrefab, this.transform.position, this.transform.rotation);

            //传递技能数据
            SkillDeployer deployer = skillGo.GetComponent<SkillDeployer>();
            deployer.SkillData = data;

            //播放技能动画
            if(data.animationName != "")
            {
                anima.SetTrigger(data.animationName);
            }

            //执行技能
            //

            //销毁技能
            

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
                yield return new WaitForSeconds(0.02f);
                data.coolRemain -= 0.02f;
            }
        }
    }


}